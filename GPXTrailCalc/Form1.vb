Imports System.IO
Public Class Form1
    Public directoryPath As String
    Public gpxFiles As String()
    Dim distances As List(Of Double)
    Dim totalDistance As Double
    Shared csvFilePath As String



    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Try
            ' Fix file attributes and names
            gpxFiles = GetgpxFiles(directoryPath)



            SplitTrackIntoTwo(gpxFiles) 'in gpx files, splits a track with two segments into two separate tracks

            ChangeAttributesAndFilenames(directoryPath)
            gpxFiles = GetgpxFiles(directoryPath) 'znovu načíst kvůli změnám názvů!

            ' Get the entered values
            Dim startDate As DateTime = dtpStartDate.Value
            Dim endDate As DateTime = dtpEndDate.Value

            ' Validate that the directory is not empty
            If String.IsNullOrEmpty(directoryPath) Then
                ' Input validation
                MessageBox.Show("Please select a directory.")
                Return
            End If

            ' Start calculation using the values
            distances = GPXDistanceCalculator.GetDistances(directoryPath, startDate, endDate)

            ' Calculate the sum of all first segment lengths
            totalDistance = GPXDistanceCalculator.SumFirstSegmentDistances(distances)

            ' Display results



            Me.txtOutput.AppendText(vbCrLf & "Processed period: from " & startDate.ToString("dd.MM.yy") & " to " & endDate.ToString("dd.MM.yy") &
                vbCrLf & "All gpx files from directory: " & directoryPath & vbCrLf &
                vbCrLf & "Total number of processed GPX files, thus trails: " & distances.Count &
                vbCrLf &
                vbCrLf & vbCrLf & "Total Route Distance: " & totalDistance.ToString("F2") & " km")

        Catch ex As Exception
            MessageBox.Show("An error occurred while processing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If chbCSVFile.Checked Then
            Try
                csvFilePath = Path.Combine(directoryPath, "GPX_File_Data.csv")
                WriteCSVfile(csvFilePath, distances)
                ChangeAttributesAndFilenames(directoryPath) 'ještě jednou změnit atributy, protože se možná zapisovalo do filů
            Catch ex As Exception
                MessageBox.Show("An error occurred while creating the CSV file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
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
        If File.Exists(csvFilePath) Then
            Process.Start(csvFilePath)
        Else
            MessageBox.Show("The data file has not been created yet, check that you want to create it and start the calculation")
        End If
    End Sub


End Class

