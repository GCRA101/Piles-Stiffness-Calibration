Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel


''' <summary>
''' 
''' <remarks>
''' <para> Concrete class responsible for creating Excel Charts. </para>
''' <para> The class is assigned with the reference to an excel workbook file and creates charts
''' inside of it based on multiple input criteria. 
''' All the utility methods required to create the chart and assign specific properties to it
''' are hidden within the public method <see cref="ExcelChartFactory.create(Excel.XlChartType, 
''' String, String, Range, String, List(Of String), String, String, Excel.XlColorIndex)"/> 
''' in line with the FACADE Pattern </para>
''' 
''' <para>Design Patterns:
''' - FACTORY PATTERN
''' - FACADE PATTERN </para>
''' 
''' 
''' </remarks>
''' </summary>



Public Class ExcelChartFactory
    Implements ExcelChartFactoryInterface

    'ATTRIBUTES
    Private excelWkb As Workbook
    Private chart As Chart


    'CONSTRUCTOR
    'Overloaded
    Public Sub New(excelWkb As Workbook)
        Me.excelWkb = excelWkb
    End Sub


    'METHODS

    Public Sub create(chartType As Excel.XlChartType, chartTitle As String, xAxisTitle As String,
                      xAxisSourceData As Range, yAxisTitle As String, seriesNames As List(Of String),
                      seriesValuesRangeAddress As String, tabName As String, tabColor As Excel.XlColorIndex)

        Me.addChart(tabName, tabColor)
        Me.excelWkb.Sheets(tabName).Move(After:=Me.excelWkb.Sheets(Me.excelWkb.Sheets.Count))
        Me.setChartType(chartType)
        Me.setChartTitle(chartTitle)
        Me.setChartAxis(xAxisTitle, Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary, xAxisSourceData,
                        Excel.XlDataLabelPosition.xlLabelPositionOutsideEnd)

        Me.setChartSeries(seriesNames, seriesValuesRangeAddress, XlOrientation.xlUpward, 7)

        Me.setChartFormatThreeD()

    End Sub


    Private Sub addChart(name As String, color As Excel.XlColorIndex, Optional deleteOtherCharts As Boolean = False)
        'Delete pre-existing Charts
        If deleteOtherCharts Then Me.excelWkb.Charts.Delete()
        'Create new Chart
        Me.chart = excelWkb.Charts.Add()
        'Assign Name and Color to Tab
        Me.chart.Name = name
        Me.chart.Tab.ColorIndex = color
    End Sub


    'Methods Implemented from Interface ChartFactoryInterface
    Public Sub setTabProperties(name As String, color As Excel.XlColorIndex) Implements ExcelChartFactoryInterface.setTabProperties
        Throw New NotImplementedException()
    End Sub

    Public Sub setChartType(chartType As Excel.XlChartType) Implements ExcelChartFactoryInterface.setChartType
        Me.chart.ChartType = chartType
    End Sub

    Public Sub setChartTitle(title As String, Optional hasTitle As Boolean = True) Implements ExcelChartFactoryInterface.setChartTitle
        Me.chart.HasTitle = hasTitle
        Me.chart.ChartTitle.Text = title
    End Sub

    Public Sub setChartAxis(axisTitle As String, axisType As Excel.XlAxisType, axisGroup As Excel.XlAxisGroup, sourceData As Range, labelsPosition As Excel.XlDataLabelPosition) Implements ExcelChartFactoryInterface.setChartAxis

        If axisType = Excel.XlAxisType.xlCategory Then
            Me.chart.SetElement(MsoChartElementType.msoElementPrimaryCategoryAxisTitleAdjacentToAxis)
        Else
            Me.chart.SetElement(MsoChartElementType.msoElementPrimaryValueAxisTitleAdjacentToAxis)
        End If

        Me.chart.Axes(axisType, axisGroup).AxisTitle.Text = axisTitle
        Me.chart.SetSourceData(sourceData)
    End Sub

    Public Sub setChartSeries(names As List(Of String), valuesRangeAddress As String, labelsOrientation As Excel.XlOrientation, labelsFontSize As Integer) Implements ExcelChartFactoryInterface.setChartSeries

        For i As Integer = 0 To names.Count - 1 Step 1
            With Me.chart.FullSeriesCollection(i + 1)
                .Name = names(i)
                .XValues = valuesRangeAddress
            End With
        Next

    End Sub

    Public Sub setChartFormatThreeD() Implements ExcelChartFactoryInterface.setChartFormatThreeD

        For i As Integer = 0 To Me.chart.SeriesCollection.Count() - 1 Step 1
            With Me.chart.FullSeriesCollection(i + 1).Format.ThreeD
                .BevelTopType = MsoBevelType.msoBevelCircle
                .BevelTopInset = 2
                .BevelTopDepth = 2
            End With
        Next

    End Sub


End Class
