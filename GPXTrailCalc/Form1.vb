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


    Private Sub SaveCSVFile(sender As Object, e As EventArgs) Handles mnuSaveAsCsvFile.Click
        If gpxCalculator.distances.Count < 1 Then
            MessageBox.Show(My.Resources.Resource1.mBoxMissingData)
            Return
        End If

        Dim csvFileName As String = "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") 'Path.Combine(directoryPath, "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") & ".csv")

        Using dialog As New SaveFileDialog()
            dialog.Filter = "Soubory csv|*.csv"
            dialog.CheckFileExists = True 'když existuje zeptá se 
            dialog.AddExtension = True
            dialog.InitialDirectory = My.Settings.Directory
            dialog.Title = "Save as CSV"
            dialog.FileName = csvFileName

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

    Private Sub SaveRtfFile(sender As Object, e As EventArgs) Handles mnuSaveAsRtf.Click
        If gpxCalculator.distances.Count < 1 Then
            MessageBox.Show(My.Resources.Resource1.mBoxMissingData)
            Return
        End If

        Dim rtfFileName As String = "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") 'Path.Combine(directoryPath, "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") & ".csv")

        Using dialog As New SaveFileDialog()
            dialog.Filter = "Soubory RTF|*.rtf"
            'dialog.CheckFileExists = True 'když existuje zeptá se 
            dialog.AddExtension = True
            dialog.InitialDirectory = My.Settings.Directory
            dialog.Title = "Save as RTF"
            dialog.FileName = rtfFileName

            ' Načti obsah RichTextBoxu jako RTF text
            Dim rtfText As String = rtbOutput.Rtf

            ' Najdi začátek RTF hlavičky a vlož vlastnosti pro A4 naležato
            Dim upravenyRtf As String = rtfText.Replace("\rtf1", "\rtf1\ansi\paperw11907\paperh8267\landscape\margl1440\margr1440\margt1440\margb1440")




            If dialog.ShowDialog() = DialogResult.OK Then

                Debug.WriteLine($"Selected file: {dialog.FileName}")
                'Ulož upravený RTF text zpět do souboru



                Try
                    'IO.File.WriteAllText(dialog.FileName, upravenyRtf)
                    rtbOutput.SaveFile(dialog.FileName, RichTextBoxStreamType.RichText)
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

        Me.ResumeLayout()
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

        mnuSelect_directory_gpx_files.ToolTipText = Resource1.Tooltip_txtDirectory
        mnuSelectBackupDirectory.ToolTipText = Resource1.Tooltip_txtBackupDirectory
        'TODO
        mnuSaveAsCsvFile.ToolTipText = Resource1.Tooltip_ExportAsCSV


        ' Nastavení ToolTip pro jednotlivé ovládací prvky

        ToolTip1.SetToolTip(btnChartDistances, Resource1.Tooltip_txtDirectory)


        ' Přidej další ovládací prvky, jak je potřeba

        ' Nastavení formátu dtp podle aktuální kultury
        Me.dtpStartDate.CustomFormat = $"'{My.Resources.Resource1.lblFrom}'  {Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern}"
        Me.dtpEndDate.CustomFormat = $"'{My.Resources.Resource1.lblTo}'   {Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern}"




    End Sub


    'Private Sub btnCS_Click(sender As Object, e As EventArgs) Handles btnCS.Click
    '    ChangeLanguage("cs") ' Nastaví češtinu
    'End Sub

    'Private Sub btnEng_Click(sender As Object, e As EventArgs) Handles btnEng.Click
    '    ChangeLanguage("en") ' Nastaví angličtinu
    'End Sub

    'Private Sub btnDe_Click(sender As Object, e As EventArgs) Handles btnDe.Click
    '    ChangeLanguage("de") ' Nastaví češtinu
    'End Sub
    'Private Sub btnRu_Click(sender As Object, e As EventArgs) Handles btnRu.Click
    '    ChangeLanguage("ru") ' Nastaví češtinu
    'End Sub
    'Private Sub btnPl_Click(sender As Object, e As EventArgs) Handles btnPl.Click
    '    ChangeLanguage("pl") ' Nastaví češtinu
    'End Sub

    'Private Sub btnUK_Click(sender As Object, e As EventArgs) Handles btnUK.Click
    '    ChangeLanguage("uk")
    'End Sub

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

