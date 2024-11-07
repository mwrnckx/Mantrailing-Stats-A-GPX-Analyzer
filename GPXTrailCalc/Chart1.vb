Imports System.Windows.Forms.DataVisualization.Charting

Public Class DistanceChart
    ' Vlastnosti pro data
    Private layerStart As DateTime()
    Private TotalDistances As Double()

    ' Konstruktor, který přijme data
    Public Sub New(layerStart As DateTime(), TotalDistances As Double())
        Me.layerStart = layerStart
        Me.TotalDistances = TotalDistances
    End Sub

    ' Metoda pro vytvoření a zobrazení grafu
    Public Sub Display()
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
        Dim series1 As New Series() With {
            .Name = "Total Distance Over Time",
            .ChartType = SeriesChartType.Line,
            .XValueType = ChartValueType.DateTime
        }

        Dim series2 As New Series() With {
            .Name = "",
            .ChartType = SeriesChartType.Point,
            .XValueType = ChartValueType.DateTime
        }

        ' Přidání dat do série
        For i As Integer = 0 To TotalDistances.Length - 1
            series1.Points.AddXY(layerStart(i), TotalDistances(i))
            series2.Points.AddXY(layerStart(i), TotalDistances(i))
        Next

        ' Přidání série do grafu
        chart.Series.Add(series1)
        chart.Series.Add(series2)

        ' Zobrazení formuláře
        chartForm.ShowDialog()
    End Sub
End Class

