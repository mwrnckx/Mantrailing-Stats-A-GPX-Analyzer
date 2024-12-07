Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Resources
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports GPXTrailAnalyzer.My.Resources

Public Class Form1

    Private gpxCalculator As GPXDistanceCalculator
    Private currentCulture As CultureInfo = Thread.CurrentThread.CurrentCulture

    Private Sub btnReadGpxFiles_Click(sender As Object, e As EventArgs) Handles btnReadGpxFiles.Click

        Me.txtWarnings.Visible = True

        Try

            'send directoryPath to gpxCalculator
            If gpxCalculator.ReadAndProcessData(dtpStartDate.Value, dtpEndDate.Value) Then
                Me.btnChartDistances.Visible = True
                Me.rbTotDistance.Visible = True
                Me.rbDistances.Visible = True
                Me.rbAge.Visible = True
                Me.rbSpeed.Visible = True
            Else
                MessageBox.Show(My.Resources.Resource1.mBoxDataRetrievalFailed)
            End If
        Catch ex As Exception
            MessageBox.Show(My.Resources.Resource1.mBoxDataRetrievalFailed)
        End Try

    End Sub


    Private Sub SaveCSVFile(sender As Object, e As EventArgs)
        If gpxCalculator.distances.Count < 1 Then
            MessageBox.Show(My.Resources.Resource1.mBoxMissingData)
            Return
        End If

        Dim FileName As String = "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") 'Path.Combine(directoryPath, "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") & ".csv")

        Using dialog As New SaveFileDialog()
            dialog.Filter = "Soubory csv|*.csv"
            dialog.CheckFileExists = True 'když existuje zeptá se 
            dialog.AddExtension = True
            dialog.InitialDirectory = My.Settings.Directory
            dialog.Title = "Save as CSV"
            dialog.FileName = FileName

            If dialog.ShowDialog() = DialogResult.OK Then

                Debug.WriteLine($"Selected file: {dialog.FileName}")
                Dim csvFilePath As String = dialog.FileName
                Try
                    gpxCalculator.WriteCSVfile(csvFilePath)
                Catch ex As Exception
                    MessageBox.Show($"{My.Resources.Resource1.mBoxErrorCreatingCSV}: {csvFilePath} " & ex.Message & vbCrLf, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using



    End Sub

    Private Sub SaveRtfFile(sender As Object, e As EventArgs) Handles mnuExportAs.Click
        If gpxCalculator.distances.Count < 1 Then
            MessageBox.Show(My.Resources.Resource1.mBoxMissingData)
            Return
        End If

        Dim FileName As String = "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") 'Path.Combine(directoryPath, "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") & ".csv")

        Using dialog As New SaveFileDialog()
            dialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text (*.txt)|*.txt|Comma-separated values (*.csv)|*.csv"
            'dialog.CheckFileExists = True 'když existuje zeptá se 
            dialog.AddExtension = True
            dialog.InitialDirectory = My.Settings.Directory
            dialog.Title = "Save as"
            dialog.FileName = FileName

            ' Načti obsah RichTextBoxu jako RTF text
            Dim rtfText As String = rtbOutput.Rtf

            If dialog.ShowDialog() = DialogResult.OK Then


                Debug.WriteLine($"Selected file: {dialog.FileName}")
                'Ulož upravený RTF text zpět do souboru



                Try
                    Select Case dialog.FilterIndex
                        Case 1
                            rtbOutput.SaveFile(dialog.FileName, RichTextBoxStreamType.RichText)

                        Case 2
                            rtbOutput.SaveFile(dialog.FileName, RichTextBoxStreamType.PlainText)
                        Case 3
                            gpxCalculator.WriteCSVfile(dialog.FileName)
                    End Select


                Catch ex As Exception
                    MessageBox.Show($"{My.Resources.Resource1.mBoxErrorCreatingCSV}: {dialog.FileName} " & ex.Message & vbCrLf, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using



    End Sub

    Private Sub btnOpenChart(sender As Object, e As EventArgs) Handles btnChartDistances.Click
        'what to display
        Dim yAxisData() As Double
        Dim yAxisLabel As String
        Dim xAxisData As Date() = gpxCalculator.layerStart.Select(Function(ts) ts).ToArray()
        Dim GrafText As String = rbTotDistance.Text

        If rbTotDistance.Checked Then
            yAxisData = gpxCalculator.totalDistances.Select(Function(ts) ts).ToArray()
            yAxisLabel = My.Resources.Resource1.Y_AxisLabelTotalLength
            GrafText = rbTotDistance.Text
        ElseIf rbDistances.Checked Then
            yAxisData = gpxCalculator.distances.Select(Function(ts) ts).ToArray()
            yAxisLabel = My.Resources.Resource1.Y_AxisLabelLength
            GrafText = rbDistances.Text
        ElseIf rbAge.Checked Then
            ' Filtrování y-hodnot (TotalHours) a x-hodnot (časové značky) pro body, kde TotalHours není nulová
            yAxisData = gpxCalculator.age.
    Where(Function(ts, index) ts.TotalHours <> 0). ' Podmínka pro filtrování TotalHours == 0
    Select(Function(ts) ts.TotalHours).
    ToArray()

            ' Filtrování x-hodnot (časové značky) podle stejných indexů jako yAxisData
            xAxisData = gpxCalculator.layerStart.
    Where(Function(ts, index) gpxCalculator.age(index).TotalHours <> 0).
    Select(Function(ts) ts).
    ToArray()
            yAxisLabel = My.Resources.Resource1.Y_AxisLabelAge
            GrafText = rbAge.Text
        ElseIf rbSpeed.Checked Then
            ' Načtení y-hodnot a filtrování hodnot, kde je y nulové
            yAxisData = gpxCalculator.speed.
    Where(Function(ts, index) gpxCalculator.speed(index) <> 0). ' Podmínka pro filtrování y == 0
    Select(Function(ts) ts).
    ToArray()
            ' Filtrování x-hodnot (časové značky) podle stejného indexu jako yAxisData
            xAxisData = gpxCalculator.layerStart.
    Where(Function(ts, index) gpxCalculator.speed(index) <> 0).
    Select(Function(ts) ts).
    ToArray()

            yAxisLabel = My.Resources.Resource1.Y_AxisLabelSpeed
            GrafText = rbSpeed.Text
        End If



        ' Vytvoření instance DistanceChart s filtrováním bodů, kde je y-hodnota nulová
        If Not gpxCalculator.distances Is Nothing Then
            Dim distanceChart As New DistanceChart(xAxisData, yAxisData, yAxisLabel, Me.dtpStartDate.Value, dtpEndDate.Value, Me.currentCulture)

            ' Zobrazení grafu
            distanceChart.Display(GrafText)
        Else
            MessageBox.Show("First you need to read the data from the gpx files")
        End If


    End Sub





    Public Sub ChangeLanguage(sender As Object, e As EventArgs) Handles mnuCzech.Click, mnuGerman.Click, mnuRussian.Click, mnuUkrainian.Click, mnuPolish.Click, mnuEnglish.Click
        Me.SuspendLayout()
        Dim cultureName As String = sender.Tag
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultureName)
        'Thread.CurrentThread.CurrentCulture = New CultureInfo(cultureName)

        Me.currentCulture = Thread.CurrentThread.CurrentUICulture

        Dim resources = New ComponentResourceManager(Me.GetType())
        resources.ApplyResources(Me, "$this")
        For Each ctrl As Control In Me.Controls
            resources.ApplyResources(ctrl, ctrl.Name)
        Next

        ' Lokalizace položek MenuStrip

        LocalizeMenuItems(MenuStrip1.Items, resources)

        SetTooltips()

        ReadHelp()

        Me.ResumeLayout()
    End Sub

    Private toolTipLabel As Label

    Private Sub ShowLabelToolTip(item As ToolStripMenuItem, toolTipText As String)
        If toolTipLabel IsNot Nothing Then toolTipLabel.Dispose()
        toolTipLabel = New Label With {
        .Text = toolTipText,
        .BackColor = Color.LightYellow,
        .AutoSize = True,
        .MaximumSize = New Size(300, 0), ' Maximální šířka
        .BorderStyle = BorderStyle.FixedSingle
    }
        Me.Controls.Add(toolTipLabel)

        Dim itemBounds = item.GetCurrentParent.Bounds


        toolTipLabel.Location = Me.PointToClient(New Point(Cursor.Position.X + 20, Cursor.Position.Y + 30))
        toolTipLabel.BringToFront()
    End Sub

    Private Sub HideLabelToolTip()
        If toolTipLabel IsNot Nothing Then
            toolTipLabel.Dispose()
            toolTipLabel = Nothing
        End If
    End Sub


    Private Sub LocalizeMenuItems(items As ToolStripItemCollection, resources As ComponentResourceManager)
        For Each item As ToolStripItem In items
            ' Zkus lokalizovat text aktuální položky
            resources.ApplyResources(item, item.Name)

            ' Pokud má položka podmenu, projdi i jeho položky
            If TypeOf item Is ToolStripMenuItem Then
                Dim menuItem As ToolStripMenuItem = DirectCast(item, ToolStripMenuItem)
                If menuItem.DropDownItems.Count > 0 Then
                    LocalizeMenuItems(menuItem.DropDownItems, resources)
                End If
            End If
        Next
        Dim currentCulture As String = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName
        Dim menuIcon As Image = Nothing
        Select Case currentCulture
            Case "cs-CZ", "cs"
                menuIcon = My.Resources.czech_flag

            Case "en-GB", "en", "en-US"
                menuIcon = My.Resources.en_flag
                mnuEnglish.Image = resizeImage(My.Resources.en_flag, Nothing, 18)
            Case "de-DE", "de"
                menuIcon = My.Resources.De_Flag
                mnuGerman.Image = resizeImage(My.Resources.De_Flag, Nothing, 18)
            Case "pl-PL", "pl"
                menuIcon = My.Resources.pl_flag
                mnuPolish.Image = resizeImage(My.Resources.pl_flag, Nothing, 18)
            Case "ru-RU", "ru"
                menuIcon = My.Resources.ru_flag
                mnuRussian.Image = resizeImage(My.Resources.ru_flag, Nothing, 18)
            Case "uk"
                menuIcon = My.Resources.uk_flag
                mnuUkrainian.Image = resizeImage(My.Resources.uk_flag, Nothing, 18)
            Case Else
                ' Výchozí obrázek (např. angličtina)
                menuIcon = My.Resources.en_flag
        End Select

        ' Nastavení obrázku na ToolStripMenuItem
        mnuLanguage.Image = resizeImage(menuIcon, Nothing, 18)
        mnuCzech.Image = resizeImage(My.Resources.czech_flag, Nothing, 18)
    End Sub

    Private Function resizeImage(menuIcon As Image, width As Integer, height As Integer) As Image

        If width = Nothing Then width = menuIcon.Width * height / menuIcon.Height
        Dim resizedImage As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(resizedImage)
            g.DrawImage(menuIcon, 0, 0, width, height)
        End Using
        Return resizedImage
    End Function




    Private Sub SetTooltips()



        ' Nastavení ToolTip pro jednotlivé ovládací prvky

        mnuSelect_directory_gpx_files.ToolTipText = Resource1.Tooltip_mnuDirectory
        mnuSelectBackupDirectory.ToolTipText = Resource1.Tooltip_mnuBackupDirectory
        mnuexportAs.ToolTipText = Resource1.Tooltip_ExportAs
        mnuPrependDateToFileName.ToolTipText = Resource1.Tooltip_mnuPrependDate
        'mnuTrimGPSNoise.ToolTipText = Resource1.Tooltip_mnuTrim

        AddHandler mnuTrimGPSNoise.MouseEnter, Sub() ShowLabelToolTip(mnuTrimGPSNoise, Resource1.Tooltip_mnuTrim)
        AddHandler mnuTrimGPSNoise.MouseLeave, Sub() HideLabelToolTip()


        ' Nastavení ToolTip pro jednotlivé ovládací prvky

        'ToolTip1.SetToolTip(btnChartDistances, Resource1.Tooltip_dtpStart)
        ToolTip1.SetToolTip(dtpStartDate, Resource1.Tooltip_dtpStart)
        ToolTip1.SetToolTip(dtpEndDate, Resource1.Tooltip_dtpEnd)


        ' Přidej další ovládací prvky, jak je potřeba

        ' Nastavení formátu dtp podle aktuální kultury
        Me.dtpStartDate.CustomFormat = $"'{My.Resources.Resource1.lblFrom}'  {Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern}"
        Me.dtpEndDate.CustomFormat = $"'{My.Resources.Resource1.lblTo}'   {Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern}"




    End Sub


    Private Sub chbTrimGpxFile(sender As Object, e As EventArgs) Handles mnuTrimGPSNoise.CheckedChanged
        My.Settings.TrimGPSnoise = mnuTrimGPSNoise.Checked

    End Sub


    Private Sub chbDateToName_CheckedChanged(sender As Object, e As EventArgs) Handles mnuPrependDateToFileName.CheckedChanged
        My.Settings.PrependDateToName = mnuPrependDateToFileName.Checked
    End Sub



    Private Sub mnuSelect_directory_gpx_files_Click(sender As Object, e As EventArgs) Handles mnuSelect_directory_gpx_files.Click, mnuSelectBackupDirectory.Click
        Dim folderDialog As New FolderBrowserDialog


        If sender Is Me.mnuSelect_directory_gpx_files Then
            folderDialog.SelectedPath = My.Settings.Directory
        ElseIf sender Is Me.mnuSelectBackupDirectory Then
            folderDialog.ShowNewFolderButton = True
            folderDialog.SelectedPath = My.Settings.BackupDirectory
        End If



        If folderDialog.ShowDialog() = DialogResult.OK Then

            If sender Is Me.mnuSelect_directory_gpx_files Then
                My.Settings.Directory = folderDialog.SelectedPath
            ElseIf sender Is Me.mnuSelectBackupDirectory Then
                My.Settings.BackupDirectory = folderDialog.SelectedPath
            End If

        End If

        My.Settings.Save()
        Me.StatusLabel1.Text = $"Directory: {ZkratCestu(My.Settings.Directory, 130)}" & vbCrLf & $"Backup Directory: {ZkratCestu(My.Settings.BackupDirectory, 130)}"

    End Sub


    Private Function ZkratCestu(cesta As String, maxDelka As Integer) As String
        ' Pokud je cesta krátká, není třeba ji upravovat
        If cesta.Length <= maxDelka Or maxDelka < 9 Then
            Return cesta
        End If

        ' Počet znaků, které ponecháme na začátku a na konci
        Dim pocetZnakuNaKazdeStrane As Integer = (maxDelka - 7) \ 2

        ' Vytvoříme zkrácenou cestu
        Dim zacatek As String = cesta.Substring(0, pocetZnakuNaKazdeStrane)
        Dim konec As String = cesta.Substring(cesta.Length - pocetZnakuNaKazdeStrane)

        Return zacatek & "  ...  " & konec
    End Function


End Class


