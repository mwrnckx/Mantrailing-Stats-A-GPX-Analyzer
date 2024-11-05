Imports System.IO
Public Class Form1
    Dim directoryPath As String



    Private gpxCalculator As GPXDistanceCalculator


    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        'send directoryPath to gpxCalculator
        gpxCalculator.Calculate(directoryPath, dtpStartDate.Value, dtpEndDate.Value, chbCSVFile.Checked, chbDateOfCreation.Checked, chbDateToName.Checked)
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
        If File.Exists(gpxCalculator.CsvFilesDirectoryPath) Then
            Process.Start(gpxCalculator.CsvFilesDirectoryPath)
        Else
            MessageBox.Show("The data file has not been created yet, check that you want to create it and start the calculation")
        End If
    End Sub


End Class

