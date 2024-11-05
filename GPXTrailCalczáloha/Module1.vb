Imports System.Xml
Imports System.IO
Imports System.Globalization
Imports System.Text.RegularExpressions ' Added for working with Match type
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Collections.Generic

Module GPXDistanceCalculator

    ' Constants for converting degrees to radians and Earth's radius
    Const PI As Double = 3.14159265358979
    Const EARTH_RADIUS As Double = 6371 ' Earth's radius in kilometers


    ' Function to convert degrees to radians
    Private Function DegToRad(degrees As Double) As Double
        Return degrees * PI / 180
    End Function

    ' Function to calculate the distance between two GPS points using the Haversine formula
    Private Function HaversineDistance(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double) As Double
        Dim dLat As Double = DegToRad(lat2 - lat1)
        Dim dLon As Double = DegToRad(lon2 - lon1)

        Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(DegToRad(lat1)) * Math.Cos(DegToRad(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))

        Return EARTH_RADIUS * c ' Result in kilometers
    End Function

    ' Function to read the time from the first <time> node in the GPX file
    ' If <time> node doesnt exist tries to read date from file name and creates <time> node
    Private Function GetgpxTimes(ByRef gpxFilePath As String) As DateTime()
        Dim xmlDoc As New XmlDocument()
        Try
            xmlDoc.Load(gpxFilePath)
        Catch ex As Exception
            ' Adding a more detailed exception message
            Debug.WriteLine("Error: " & ex.Message)
            ' TODO: Replace direct access to Form1 with a better method for separating logic
            Form1.txtWarnings.AppendText($"File {gpxFilePath} could not be read: " & ex.Message & Environment.NewLine)
        End Try

        Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
        namespaceManager.AddNamespace("gpx", "http://www.topografix.com/GPX/1/1") ' GPX namespace URI
        Dim trksegNodes As XmlNodeList = xmlDoc.SelectNodes("//gpx:trkseg", namespaceManager)

        Dim dateTimeValue(1) As DateTime
        Dim firstTimeNode As XmlNode = xmlDoc.SelectSingleNode("//gpx:time", namespaceManager)

        Dim secondTimeNode As XmlNode
        If trksegNodes.Count > 1 Then
            secondTimeNode = trksegNodes(1).SelectNodes("gpx:trkpt/gpx:time", namespaceManager)(0)
            DateTime.TryParse(secondTimeNode.InnerText, dateTimeValue(1))

        End If


        Dim dateTimeFromFileName As DateTime
        Dim filename As String = Path.GetFileNameWithoutExtension(gpxFilePath)
        If Regex.IsMatch(filename, "^\d{4}-\d{2}-\d{2}") Then
            ' Extrahování data z názvu souboru
            Dim dateMatch As Match = Regex.Match(filename, "^\d{4}-\d{2}-\d{2}")
            If dateMatch.Success Then
                ' Převedení nalezeného řetězce na DateTime
                dateTimeFromFileName = DateTime.ParseExact(dateMatch.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            End If
        End If

        'zkontroluje, zda je datum v názvu správné

        ' Check if the <time> node exists and has a valid value
        If firstTimeNode IsNot Nothing AndAlso DateTime.TryParse(firstTimeNode.InnerText, dateTimeValue(0)) Then
            'zkontroluje, zda je datum v názvu správné
            If dateTimeFromFileName <> Date.MinValue AndAlso dateTimeFromFileName.Date.ToShortDateString <> dateTimeValue(0).Date.ToShortDateString Then
                ' Nahrazení staré hodnoty za novou v názvu souboru
                Dim newFileName As String = Regex.Replace(filename, "^\d{4}-\d{2}-\d{2}", dateTimeValue(0).ToString("yyyy-MM-dd"))
                Dim newFilePath As String = Path.Combine(Form1.directoryPath, newFileName & ".gpx")
                File.Move(gpxFilePath, newFilePath)
                Form1.txtWarnings.AppendText($"Renamed file: {Path.GetFileName(gpxFilePath)} to {Path.GetFileName(newFilePath)}.{Environment.NewLine}")
                gpxFilePath = newFilePath
            End If

        ElseIf dateTimeFromFileName <> Date.MinValue Then

            'pokusí se odečíst datum z názvu souboru a vytvořit uzel <time>
            ' Převedení nalezeného řetězce na DateTime
            dateTimeValue(0) = dateTimeFromFileName
            AddTimeNodeToFirstTrkpt(gpxFilePath, dateTimeValue.ToString("yyyy-MM-dd" & "T" & "hh:mm:ss" & "Z"))
            Form1.txtWarnings.AppendText($" <time> node with Date from file name created: {dateTimeValue.ToString("yyyy-MM-dd")}" & "in file: {filename}")


        Else
            ' If the node doesn't exist or isn't a valid date, return the default DateTime value


        End If

        Return dateTimeValue

    End Function

    Private Function CalculateAge(gpxfilePath As String, dateTimeValue() As DateTime, description As String) As String
        Dim age As String = ""
        Dim ageFromTime As String = ""
        Dim ageFromComments As String = ""

        If dateTimeValue(1) <> Date.MinValue AndAlso dateTimeValue(0) <> Date.MinValue Then
            Try
                ageFromTime = (dateTimeValue(1) - dateTimeValue(0)).TotalHours.ToString("F2")
            Catch ex As Exception
            End Try
        End If

        ageFromComments = FindTheAgeinComments(description)

        'Add age to comments
        If ageFromComments Is Nothing And Not ageFromTime Is Nothing Then
            ' Najde řetězec "Trail:" a nahradí ho řetězcem "Trail:" & AgeFromTime
            Dim newDescription As String = description.Replace("Trail:", "Trail: " & ageFromTime & " hod")
            SetDescription(gpxfilePath, newDescription)
        End If
        If Not String.IsNullOrWhiteSpace(ageFromTime) Then
            Return ageFromTime
        ElseIf Not String.IsNullOrWhiteSpace(ageFromComments) Then
            Return ageFromComments
        Else Return ""
        End If
        Return ""
    End Function




    Public Function FindTheAgeinComments(inputText As String) As String
        ' Upravený regulární výraz pro nalezení čísla, které může být i desetinné
        Dim regex As New Regex("\b\d+[.,]?\d*\s*(h(odin(y|a))?|hod|min(ut)?)\b", RegexOptions.IgnoreCase)
        Dim match As Match = regex.Match(inputText)

        If match.Success Then
            Dim nalezenyCas As String = match.Value
            ' Převede desetinnou tečku nebo čárku na standardní tečku pro parsování
            Dim casString As String = Regex.Match(nalezenyCas, "\d+[.,]?\d*").Value.Replace(",", ".")
            Dim casCislo As Double = Double.Parse(casString, CultureInfo.InvariantCulture)

            If nalezenyCas.Contains("h") Then
                Return casCislo.ToString("F2")
            ElseIf nalezenyCas.Contains("min") Then
                casCislo /= 60
                Return casCislo.ToString("F2")
            End If
        End If

        ' Pokud nebyl čas nalezen, vrátí Nothing
        Return Nothing
    End Function



    Sub AddTimeNodeToFirstTrkpt(gpxFilePath As String, timeValue As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(gpxFilePath)

        ' Vytvoření Namespace Manageru pro správnou práci s jmenným prostorem GPX
        Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
        namespaceManager.AddNamespace("gpx", "http://www.topografix.com/GPX/1/1")

        ' Vyhledání prvního uzlu <trkpt>
        Dim firstTrkptNode As XmlNode = xmlDoc.SelectSingleNode("//gpx:trkpt", namespaceManager)

        If firstTrkptNode IsNot Nothing Then
            ' Vytvoření nového uzlu <time>
            Dim timeNode As XmlElement = xmlDoc.CreateElement("time", "http://www.topografix.com/GPX/1/1")
            timeNode.InnerText = timeValue

            ' Přidání uzlu <time> do prvního <trkpt>
            firstTrkptNode.AppendChild(timeNode)

            ' Uložení změn zpět do souboru
            xmlDoc.Save(gpxFilePath)
            Debug.WriteLine("Časový uzel byl úspěšně přidán.")
        Else
            Debug.WriteLine("Uzel <trkpt> nebyl nalezen.")
        End If
    End Sub
    ' Function to read the <link> description from the first <trk> node in the GPX file
    Private Function Getlink(gpxFilePath As String) As String
        Dim xmlDoc As New XmlDocument()

        Try
            xmlDoc.Load(gpxFilePath)
        Catch ex As Exception
            ' Adding a more detailed exception message
            Debug.WriteLine("Error: " & ex.Message)
            ' TODO: Replace direct access to Form1 with a better method for separating logic
            Form1.txtWarnings.AppendText($"File {gpxFilePath} could not be read: " & ex.Message & Environment.NewLine)
        End Try

        Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
        namespaceManager.AddNamespace("gpx", "http://www.topografix.com/GPX/1/1") ' GPX namespace URI

        ' Find the first <trk> node and its <desc> subnode

        Dim linkNodes As XmlNodeList = xmlDoc.SelectNodes("//gpx:link", namespaceManager)

        For Each linkNode As XmlNode In linkNodes
            ' Zpracování každého uzlu <link>

            If linkNode IsNot Nothing AndAlso linkNode.Attributes("href") IsNot Nothing Then
                Dim linkHref As String = linkNode.Attributes("href").Value
                If linkHref.Contains("youtu") Then
                    Return linkHref
                Else
                    Return Nothing
                End If

            Else
                Return Nothing
            End If
        Next
        Return Nothing
    End Function

    ' Function to read the <desc> description from the first <trk> node in the GPX file
    Private Function GetDescription(gpxFilePath As String) As String
        Dim xmlDoc As New XmlDocument()

        Try
            xmlDoc.Load(gpxFilePath)
        Catch ex As Exception
            ' Adding a more detailed exception message
            Debug.WriteLine("Error: " & ex.Message)
            ' TODO: Replace direct access to Form1 with a better method for separating logic
            Form1.txtWarnings.AppendText($"File {gpxFilePath} could not be read: " & ex.Message & Environment.NewLine)
        End Try

        Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
        namespaceManager.AddNamespace("gpx", "http://www.topografix.com/GPX/1/1") ' GPX namespace URI

        ' Find the first <trk> node and its <desc> subnode
        Dim descNode As XmlNode = xmlDoc.SelectSingleNode("/gpx:gpx/gpx:trk[1]/gpx:desc", namespaceManager)

        If descNode IsNot Nothing Then
            Return descNode.InnerText
        Else
            Return "" '"The <desc> node was not found."
        End If
    End Function

    ' Function to set the <desc> description from the first <trk> node in the GPX file
    Private Function SetDescription(gpxFilePath As String, newDescription As String) As Boolean
        Dim xmlDoc As New XmlDocument()

        Try
            xmlDoc.Load(gpxFilePath)
        Catch ex As Exception
            ' Adding a more detailed exception message
            Debug.WriteLine("Error: " & ex.Message)
            ' TODO: Replace direct access to Form1 with a better method for separating logic
            Form1.txtWarnings.AppendText($"File {gpxFilePath} could not be read: " & ex.Message & Environment.NewLine)
            Return False
        End Try

        Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
        namespaceManager.AddNamespace("gpx", "http://www.topografix.com/GPX/1/1") ' GPX namespace URI

        ' Find the first <trk> node and its <desc> subnode
        Dim descNode As XmlNode = xmlDoc.SelectSingleNode("/gpx:gpx/gpx:trk[1]/gpx:desc", namespaceManager)
        Try
            descNode.InnerText = newDescription
            xmlDoc.Save(gpxFilePath)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    ' Function to read and calculate the length of only the first segment from the GPX file
    Private Function CalculateFirstSegmentDistance(gpxFilePath As String) As Double
        Dim totalLengthOfFirst_trkseg As Double = 0.0
        Dim lat1, lon1, lat2, lon2 As Double
        Dim firstPoint As Boolean = True

        ' Load the GPX file
        Dim xmlDoc As New XmlDocument()

        Try
            xmlDoc.Load(gpxFilePath)
        Catch ex As Exception
            ' Adding a more detailed exception message
            Debug.WriteLine("Error: " & ex.Message)
            ' TODO: Replace direct access to Form1 with a better method for separating logic
            Form1.txtWarnings.AppendText($"File {gpxFilePath} could not be read: " & ex.Message & Environment.NewLine)
        End Try

        ' Create an XML Namespace Manager with the GPX namespace definition
        Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
        namespaceManager.AddNamespace("gpx", "http://www.topografix.com/GPX/1/1") ' GPX namespace URI

        ' Select the first track segment (<trkseg>) using the namespace
        Dim firstSegment As XmlNode = xmlDoc.SelectSingleNode("//gpx:trkseg", namespaceManager)

        ' If the segment exists, calculate its length
        If firstSegment IsNot Nothing Then
            ' Select all track points in the first segment (<trkpt>)
            Dim trackPoints As XmlNodeList = firstSegment.SelectNodes("gpx:trkpt", namespaceManager)

            ' Calculate the distance between each point in the first segment
            For Each point As XmlNode In trackPoints
                Try
                    ' Check if attributes exist and load them as Double
                    If point.Attributes("lat") IsNot Nothing AndAlso point.Attributes("lon") IsNot Nothing Then
                        Dim lat As Double = Convert.ToDouble(point.Attributes("lat").Value, Globalization.CultureInfo.InvariantCulture)
                        Dim lon As Double = Convert.ToDouble(point.Attributes("lon").Value, Globalization.CultureInfo.InvariantCulture)

                        If firstPoint Then
                            ' Initialize the first point
                            lat1 = lat
                            lon1 = lon
                            firstPoint = False
                        Else
                            ' Calculate the distance between the previous and current point
                            lat2 = lat
                            lon2 = lon
                            totalLengthOfFirst_trkseg += HaversineDistance(lat1, lon1, lat2, lon2)

                            ' Move the current point into lat1, lon1 for the next iteration
                            lat1 = lat2
                            lon1 = lon2
                        End If
                    End If
                Catch ex As Exception
                    ' Adding a more detailed exception message
                    Debug.WriteLine("Error: " & ex.Message)
                    ' TODO: Replace direct access to Form1 with a better method for separating logic
                    Form1.txtWarnings.AppendText("Error processing point: " & ex.Message & Environment.NewLine)
                End Try
            Next
        Else
            ' TODO: Replace direct access to Form1 with a better method for separating logic
            Form1.txtWarnings.AppendText("No segment found in GPX file: " & gpxFilePath & Environment.NewLine)
        End If

        Return totalLengthOfFirst_trkseg ' Result in kilometers
    End Function

    ' Get a list of all GPX files in the specified directory
    Public Function GetgpxFiles(directorypath As String) As String()
        Try
            Dim gpxFiles() As String = Directory.GetFiles(directorypath, "*.gpx")
            ' Functions for sorting an array alphabetically
            Array.Sort(gpxFiles)
            Return gpxFiles
        Catch ex As Exception
            ' Adding a more detailed exception message
            Debug.WriteLine("Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    ' Function to process all GPX files in the directory and store the lengths of the first segments in a list,
    ' filtering by file creation date
    Public Function GetDistances(directoryPath As String, startDate As DateTime, endDate As DateTime) As List(Of Double)
        Dim firstSegmentDistances As New List(Of Double)

        ' Process each file
        For Each gpxFilePath As String In Form1.gpxFiles
            ' Filter files by creation date
            Dim creationDate As DateTime = GetgpxTimes(gpxFilePath)(0)
            If creationDate >= startDate AndAlso creationDate <= endDate Then
                ' If the file falls within the specified range, calculate the length of the first segment
                Dim distance As Double = CalculateFirstSegmentDistance(gpxFilePath)
                firstSegmentDistances.Add(distance)
                Form1.txtOutput.AppendText(Path.GetFileNameWithoutExtension(gpxFilePath) & " Date: " & creationDate.Date.ToString("yyyy-MM-dd") & "  Distance: " & distance.ToString("F2") & " km" & Environment.NewLine)
            End If
        Next

        Return firstSegmentDistances
    End Function

    Public Function SumFirstSegmentDistances(distances As List(Of Double)) As Double
        Dim totalDistance As Double = 0.0

        For Each distance As Double In distances
            totalDistance += distance
        Next

        Return totalDistance
    End Function

    Public Sub ChangeAttributesAndFilenames(directoryPath As String)

        ' For all files in the folder
        For Each filePath As String In Form1.gpxFiles
            Dim fileName As String = Path.GetFileNameWithoutExtension(filePath)
            Dim fileExtension As String = Path.GetExtension(filePath)
            Dim dateFromTime As DateTime = GetgpxTimes(filePath)(0)

            Dim newFileName As String = $"{dateFromTime:yyyy-MM-dd}{fileName}{fileExtension}"
            Dim newFilePath As String = Path.Combine(directoryPath, newFileName)


            ' Check if the file needs renaming
            If Not Regex.IsMatch(fileName, "^\d{4}-\d{2}-\d{2}") Then
                If Form1.chbDateToName.Checked Then
                    If File.Exists(newFilePath) Then
                        ' Handle existing files
                        Dim userInput As String = InputBox($"File {newFilePath} already exists. Enter a new name:")
                        If Not String.IsNullOrEmpty(userInput) Then
                            newFilePath = Path.Combine(directoryPath, userInput & fileExtension)
                        Else
                            Form1.txtWarnings.AppendText($"New name for {newFilePath} was not provided.{Environment.NewLine}")
                            Continue For ' Skip to the next file
                        End If
                    End If
                    File.Move(filePath, newFilePath)
                    Form1.txtWarnings.AppendText($"Renamed file: {Path.GetFileName(filePath)} to {Path.GetFileName(newFilePath)}.{Environment.NewLine}")
                    filePath = newFilePath 'kvůli změně atributů
                End If
            End If


            'change of attributes
            ' Setting the file creation date
            File.SetCreationTime(filePath, dateFromTime)
            ' Setting the last modified file date
            File.SetLastWriteTime(filePath, dateFromTime)

        Next
    End Sub

    Public Sub WriteCSVfile(csvFilePath As String, distances As List(Of Double))
        Try

            Dim totalDistances(distances.Count - 1) As Double
            Dim descriptions(distances.Count - 1) As String
            Dim fileDates As New List(Of DateTime())()
            Dim Age(distances.Count - 1) As String

            ' Create the CSV file and write headers
            Using writer As New StreamWriter(csvFilePath, False, System.Text.Encoding.UTF8)
                writer.WriteLine("File Name;Date;Age/h;Distance/km;Total Distance;Description;Video")

                For i As Integer = 0 To distances.Count - 1
                    Dim fileName As String = Path.GetFileNameWithoutExtension(Form1.gpxFiles(i))
                    fileDates.Add(GetgpxTimes(Form1.gpxFiles(i)))




                    descriptions(i) = GetDescription(Form1.gpxFiles(i))
                    Age(i) = CalculateAge(Form1.gpxFiles(i), fileDates(i), descriptions(i))
                    If i = 0 Then
                        totalDistances(i) = distances(i)
                    Else
                        totalDistances(i) = totalDistances(i - 1) + distances(i)
                    End If
                    Dim link As String = Getlink(Form1.gpxFiles(i))
                    If Not link Is Nothing Then link = $"=HYPERTEXTOVÝ.ODKAZ(""{link}"")"

                    ' Write each row in the CSV file
                    writer.WriteLine($"{fileName};{fileDates(i)(0).ToString("yyyy-MM-dd")};{Age(i)};{distances(i):F2};{totalDistances(i):F2};{descriptions(i)};{link}")
                Next

                ' Write the total distance at the end of the CSV file
                writer.WriteLine($"Total;;; {totalDistances(distances.Count - 1):F2}")
            End Using

            DisplayChart(fileDates, totalDistances)

            Form1.txtWarnings.AppendText($"CSV file created: {csvFilePath}.{Environment.NewLine}")
        Catch ex As Exception
            Form1.txtWarnings.AppendText($"Error creating CSV file: {ex.Message}{Environment.NewLine}")
        End Try
    End Sub


    ' Funkce pro vytvoření a zobrazení grafu
    Public Sub DisplayChart(fileDates As List(Of DateTime()), totalDistances As Double())
        ' Vytvoření nového formuláře pro zobrazení grafu
        Dim chartForm As New Form()
        chartForm.Text = "Distance Chart"
        chartForm.Size = New Size(800, 600)

        ' Vytvoření a nastavení komponenty Chart
        Dim chart As New Chart()
        chart.Dock = DockStyle.Fill
        chartForm.Controls.Add(chart)

        ' Nastavení oblasti grafu
        Dim chartArea As New ChartArea()
        chartArea.AxisX.Title = "Date"
        chartArea.AxisY.Title = "Total Distance/km"
        chartArea.AxisX.LabelStyle.Format = "yyyy-MM-dd"
        chart.ChartAreas.Add(chartArea)

        ' Vytvoření série dat
        Dim series1, series2 As New Series()
        series1.Name = "Total Distance Over Time"
        series1.ChartType = SeriesChartType.Line
        series1.XValueType = ChartValueType.DateTime

        series2.Name = ""
        series2.ChartType = SeriesChartType.Point
        series2.XValueType = ChartValueType.DateTime

        ' Přidání dat do série
        For i As Integer = 0 To totalDistances.Length - 1
            series1.Points.AddXY(fileDates(i)(0), totalDistances(i))
            series2.Points.AddXY(fileDates(i)(0), totalDistances(i))
        Next

        ' Přidání série do grafu
        chart.Series.Add(series1)
        chart.Series.Add(series2)

        ' Zobrazení formuláře
        chartForm.ShowDialog()
    End Sub

    ' in gpx files, splits a track with two segments into two separate tracks
    Sub SplitTrackIntoTwo(gpxfiles As String())

        For Each gpxfilepath In gpxfiles
            'Loading an existing GPX file
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(gpxfilepath)

            Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
            namespaceManager.AddNamespace("gpx", "http://www.topografix.com/GPX/1/1") ' GPX namespace URI

            ' Najdi první uzel <trk>
            Dim trkNode As XmlNode = xmlDoc.SelectSingleNode("//gpx:trk", namespaceManager)

            If trkNode IsNot Nothing Then
                ' Najdi všechny <trkseg> uvnitř <trk>
                Dim trkSegNodes As XmlNodeList = trkNode.SelectNodes("gpx:trkseg", namespaceManager)

                If trkSegNodes.Count > 1 Then
                    ' Vytvoř nový uzel <trk>
                    Dim newTrkNode As XmlNode = xmlDoc.CreateElement("trk")

                    ' Přesuň druhý <trkseg> do nového <trk>
                    Dim secondTrkSeg As XmlNode = trkSegNodes(1)
                    trkNode.RemoveChild(secondTrkSeg)
                    newTrkNode.AppendChild(secondTrkSeg)

                    ' Přidej nový <trk> do dokumentu hned po prvním
                    trkNode.ParentNode.InsertAfter(newTrkNode, trkNode)
                    xmlDoc.Save(gpxfilepath)
                    Form1.txtWarnings.AppendText($"Track in file {gpxfilepath} was successfully split.")
                End If
            End If


            ' traverses all <wpt> nodes in the GPX file and overwrites the value of <name> nodes to "-předmět":
            ' Find all <wpt> nodes using the namespace
            Dim wptNodes As XmlNodeList = xmlDoc.SelectNodes("//gpx:wpt", namespaceManager)

            ' Go through each <wpt> node
            For Each wptNode As XmlNode In wptNodes
                ' Najdi uzel <name> uvnitř <wpt> s použitím namespace
                Dim nameNode As XmlNode = wptNode.SelectSingleNode("gpx:name", namespaceManager)

                If nameNode IsNot Nothing AndAlso nameNode.InnerText <> "předmět" Then
                    ' Přepiš hodnotu <name> na "předmět"
                    nameNode.InnerText = "předmět"
                    xmlDoc.Save(gpxfilepath)
                End If
            Next

            ' Ulož aktualizovaný GPX soubor



        Next
    End Sub

End Module

