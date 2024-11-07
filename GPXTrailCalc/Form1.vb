Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form1
    Dim directoryPath As String
    Private gpxCalculator As GPXDistanceCalculator


    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Try
            'send directoryPath to gpxCalculator
            gpxCalculator.Calculate(directoryPath, dtpStartDate.Value, dtpEndDate.Value, chbDateToName.Checked)
            Me.btnChartDistances.Visible = True
            Me.btnOpenDataFile.Visible = True
            Me.rbTotDistance.Visible = True
            Me.rbDistances.Visible = True
            Me.rbAge.Visible = True
            Me.rbSpeed.Visible = True

        Catch ex As Exception
            MessageBox.Show("Data retrieval failed")
        End Try

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim folderDialog As New FolderBrowserDialog()
        folderDialog.SelectedPath = txtDirectory.Text
        If folderDialog.ShowDialog() = DialogResult.OK Then
            txtDirectory.Text = folderDialog.SelectedPath
        End If
    End Sub

    Private Sub txtDirectory_TextChanged(sender As Object, e As EventArgs) Handles txtDirectory.TextChanged
        directoryPath = txtDirectory.Text
    End Sub

    Private Sub btnOpenDataFile_Click(sender As Object, e As EventArgs) Handles btnOpenDataFile.Click
        Dim csvFileName As String = "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") 'Path.Combine(directoryPath, "GPX_File_Data_" & Today.ToString("yyyy-MM-dd") & ".csv")

        Dim csvFilePath As String = gpxCalculator.SaveAsCsvFile(csvFileName)

        If File.Exists(csvFilePath) Then
            Try
                Process.Start(csvFilePath)
            Catch ex As Exception
                MessageBox.Show($"An error occurred while creating the CSV file:{csvFilePath} " & ex.Message & vbCrLf, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub btnOpenChart(sender As Object, e As EventArgs) Handles btnChartDistances.Click
        'what to display
        Dim yAxisData() As Double
        If rbTotDistance.Checked Then
            yAxisData = gpxCalculator.totalDistances.Select(Function(ts) ts).ToArray()
        ElseIf rbDistances.Checked Then
            yAxisData = gpxCalculator.distances.Select(Function(ts) ts).ToArray()
        ElseIf rbAge.Checked Then
            yAxisData = gpxCalculator.age.Select(Function(ts) ts.TotalHours).ToArray()
        ElseIf rbSpeed.Checked Then
            yAxisData = gpxCalculator.speed.Select(Function(ts) ts).ToArray()
        End If

        ' Vytvoření instance DistanceChart s daty
        If Not gpxCalculator.distances Is Nothing Then
            Dim distanceChart As New DistanceChart(gpxCalculator.layerStart.Select(Function(ts) ts).ToArray(), yAxisData)

            ' Zobrazení grafu
            distanceChart.Display()
        Else
            MessageBox.Show("First you need to read the data from the gpx files")
        End If


    End Sub

End Class

