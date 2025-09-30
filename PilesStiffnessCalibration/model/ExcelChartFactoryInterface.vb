Imports System.IO
Imports System.Security.Cryptography
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

''' <summary>
'''     <remarks>
'''         Interface that defines the methods that all the concrete classes 
'''         responsible for the creation of Excel charts must implement.
'''     </remarks>
''' </summary>

Public Interface ExcelChartFactoryInterface

    Sub setChartType(chartType As Excel.XlChartType)
    Sub setChartTitle(title As String, Optional hasTitle As Boolean = True)
    Sub setChartAxis(axisTitle As String, axisType As Excel.XlAxisType, axisGroup As Excel.XlAxisGroup,
                     sourceData As Excel.Range, labelsPosition As Excel.XlDataLabelPosition)
    Sub setChartSeries(names As List(Of String), valuesRangeAddress As String, labelsOrientation As XlOrientation, labelsFontSize As Integer)
    Sub setChartFormatThreeD()
    Sub setTabProperties(name As String, color As Excel.XlColorIndex)

End Interface
