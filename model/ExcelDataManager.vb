Imports System.IO
Imports System.Security.Cryptography
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel


Public Class ExcelDataManager

    'ATTRIBUTES
    Private ExcelApp As Excel.Application
    Private ExcelWkb As Excel.Workbook
    Private ExcelWks As Excel.Worksheet

    Private filePath As String

    'CONSTRUCTORS
    Public Sub New(Optional filePath As String = "")
        If filePath <> "" And Not (filePath.Contains(".xlsx") Or filePath.Contains(".xlsm") Or filePath.Contains(".xls")) Then
            Throw New InvalidFilePathException("The filepath provided doesn't correspond to an excel file.")
        End If
        Me.filePath = filePath
    End Sub

    'METHODS

    Public Sub initialize()
        '1. INITIALIZE EXCEL APPLICATION
        ExcelApp = New Excel.Application
        ExcelApp.Visible = True

        '2. OPEN/CREATE EXCEL WORKBOOK
        If filePath = "" Then
            ExcelWkb = ExcelApp.Workbooks.Add()
        ElseIf (filePath.Contains(".xlsx") Or filePath.Contains(".xlsm") Or filePath.Contains(".xls")) Then
            ExcelWkb = ExcelApp.Workbooks.Open(filePath)
        End If
    End Sub

    Public Sub write(worksheetName As String, data As List(Of PileObject), Optional headerTitle As String = "")

        '1. OPEN/CREATE EXCEL WORKSHEET
        If ExcelWks Is Nothing Then
            If ExcelWkb.Worksheets.Cast(Of Worksheet).Select(Function(wks) wks.Name).Contains(worksheetName) Then
                ExcelWks = ExcelWkb.Worksheets(worksheetName)
            Else
                ExcelWks = ExcelWkb.Worksheets.Add()
                ExcelWks.Name = worksheetName
                ExcelWkb.Sheets("Sheet1").Delete()
            End If
            ExcelWks.Tab.ColorIndex = 6
            ExcelWks.Activate()
        End If

        '2. POSITION ACTIVE CELL
        If ExcelWks.Range("B4").Value = "" Then
            ExcelWks.Range("B4").Activate()
        Else
            ExcelWks.Range("B4").End(Excel.XlDirection.xlToRight).Offset(0, 1).Activate()
        End If

        '3. WRITE DATA IN THE WORKSHEET
        For i As Integer = 0 To data.Count() - 1 Step 1

            Dim pileObjData As Dictionary(Of String, String) = data(i).toDictionary()

            If i = 0 Then
                Dim k As Integer = 0
                pileObjData.Keys().ToList().ForEach(Sub(key)
                                                        ExcelApp.ActiveCell.Offset(0, k).Value = CStr(key)
                                                        k += 1
                                                    End Sub)
                If headerTitle <> "" Then
                    Dim headerRange As Range
                    headerRange = ExcelApp.Range(ExcelApp.ActiveCell.Offset(-1, 0),
                                             ExcelApp.ActiveCell.End(Excel.XlDirection.xlToRight).Offset(-1, 0))
                    headerRange.Merge()
                    headerRange.Value = headerTitle
                    formatRange(headerRange, ExcelRangeType.HEADER_PRIMARY)
                End If

                Dim subHeaderRange As Range = ExcelApp.Range(ExcelApp.ActiveCell,
                                                ExcelApp.ActiveCell.End(Excel.XlDirection.xlToRight))
                formatRange(subHeaderRange, ExcelRangeType.HEADER_SECONDARY)

            End If

            For j As Integer = 0 To pileObjData.Count() - 1 Step 1
                ExcelApp.ActiveCell.Offset(i + 1, j).Value = pileObjData.Values(j)
            Next

        Next

    End Sub

    Public Sub setFilePath(filePath As String)
        If filePath <> "" And Not (filePath.Contains(".xlsx") Or filePath.Contains(".xlsm") Or filePath.Contains(".xls")) Then
            Throw New InvalidFilePathException("The filepath provided doesn't correspond to an excel file.")
        End If
        Me.filePath = filePath
    End Sub


    Public Sub dispose()
        If Me.filePath <> "" Then
            ExcelWkb.Save()
            ExcelWkb.Close()
            ExcelApp = Nothing
        End If
    End Sub


    Public Sub formatRange(range As Range, excelRangeType As ExcelRangeType)

        Select Case excelRangeType
            Case ExcelRangeType.HEADER_PRIMARY
                formatRange(range, "Segoe UI", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexNone, Excel.XlPattern.xlPatternLinearGradient, 90,
                            Excel.XlThemeColor.xlThemeColorAccent6, False)
            Case ExcelRangeType.HEADER_SECONDARY
                formatRange(range:=range, interiorColor:=19)
            Case ExcelRangeType.NORMAL
                formatRange(range:=range)
        End Select

    End Sub

    Private Sub formatRange(range As Range, Optional fontName As String = "Segoe UI", Optional fontSize As Integer = 10, Optional fontBold As Boolean = False,
                            Optional textHorAlignment As Excel.XlHAlign = Excel.XlHAlign.xlHAlignCenter, Optional textVertAlignment As Excel.XlVAlign = Excel.XlVAlign.xlVAlignCenter,
                            Optional borderLineStyle As Excel.XlLineStyle = Excel.XlLineStyle.xlContinuous, Optional borderLineWeight As Excel.XlBorderWeight = Excel.XlBorderWeight.xlThin,
                            Optional interiorColor As Excel.XlColorIndex = Excel.XlColorIndex.xlColorIndexNone, Optional interiorPattern As Excel.XlPattern = Excel.XlPattern.xlPatternNone,
                            Optional gradientDegree As Integer = 0, Optional gradientThemeColor As Excel.XlThemeColor = Excel.XlThemeColor.xlThemeColorDark1,
                            Optional autoFit As Boolean = True)


        With range.Font
            .Name = fontName
            .Bold = fontBold
            .Size = fontSize
        End With

        With range
            .HorizontalAlignment = textHorAlignment
            .VerticalAlignment = textVertAlignment
        End With


        If interiorPattern <> XlPattern.xlPatternNone Then
            With range.Interior
                .ColorIndex = interiorColor
                .Pattern = interiorPattern
                .Gradient.Degree = gradientDegree
                .Gradient.ColorStops.Add(0).ThemeColor = gradientThemeColor
                .Gradient.ColorStops.Add(0).TintAndShade = 0.400006103701895
            End With
        End If

        Dim edgeTypes As String() = {XlBordersIndex.xlEdgeLeft, XlBordersIndex.xlEdgeTop,
                                     XlBordersIndex.xlEdgeRight, XlBordersIndex.xlEdgeBottom}

        edgeTypes.ToList().ForEach(Sub(edgeType)
                                       With range.Borders(edgeType)
                                           .LineStyle = borderLineStyle
                                           .Weight = borderLineWeight
                                       End With
                                   End Sub)

        If autoFit Then range.EntireColumn.AutoFit()

    End Sub


    Public Sub createChart()

        Dim chartFactory As New ExcelChartFactory(ExcelWkb)
        Dim forcesData, displData, stiffnessData As Range
        Dim forcesRangeAddress As String = "", displRangeAddress As String = "", stiffnessRangeAddress As String = ""
        Dim seriesNamesRange As Excel.Range
        Dim seriesValuesRange As Excel.Range
        Dim seriesNames As New List(Of String)
        Dim refCell As Range


        refCell = ExcelWks.Range("D5")

        While refCell.Text <> ""
            forcesRangeAddress += ExcelWks.Range(refCell, refCell.End(XlDirection.xlDown)).Address + ","
            refCell = refCell.Offset(0, 5)
        End While

        forcesRangeAddress = forcesRangeAddress.Remove(forcesRangeAddress.Length - 1)
        forcesData = ExcelWks.Range(forcesRangeAddress)


        refCell = ExcelWks.Range("F5")

        While refCell.Text <> ""
            displRangeAddress += ExcelWks.Range(refCell, refCell.End(XlDirection.xlDown)).Address + ","
            refCell = refCell.Offset(0, 5)
        End While

        displRangeAddress = displRangeAddress.Remove(displRangeAddress.Length - 1)
        displData = ExcelWks.Range(displRangeAddress)


        refCell = ExcelWks.Range("E5")

        While refCell.Text <> ""
            stiffnessRangeAddress += ExcelWks.Range(refCell, refCell.End(XlDirection.xlDown)).Address + ","
            refCell = refCell.Offset(0, 5)
        End While

        stiffnessRangeAddress = stiffnessRangeAddress.Remove(stiffnessRangeAddress.Length - 1)
        stiffnessData = ExcelWks.Range(stiffnessRangeAddress)



        seriesNamesRange = ExcelWks.Range(ExcelWks.Range("B3"),
                                          ExcelWks.Range("B3").Offset(0, 100))

        For Each cell As Excel.Range In seriesNamesRange
            If cell.Value <> "" Then
                seriesNames.Add(cell.Value)
            End If
        Next

        seriesValuesRange = ExcelWks.Range(ExcelWks.Range("B5"),
                                           ExcelWks.Range("B5").End(XlDirection.xlDown))

        Dim seriesValuesRangeAddress As String = "='" + ExcelWks.Name + "'!" + seriesValuesRange.Address

        chartFactory.create(Excel.XlChartType.xlColumnClustered, "Pile Loads Fz [KN]", "Pile Labels",
                            forcesData, "Fz [KN]", seriesNames, seriesValuesRangeAddress, "Fz BarChart", 23)

        chartFactory.create(Excel.XlChartType.xlColumnClustered, "Pile Displacements Dz [mm]", "Pile Labels",
                            displData, "Dz [mm]", seriesNames, seriesValuesRangeAddress, "Dz BarChart", 45)

        chartFactory.create(Excel.XlChartType.xlColumnClustered, "Pile Stiffnesses Kz [KN/mm]", "Pile Labels",
                            stiffnessData, "Kz [KN/mm]", seriesNames, seriesValuesRangeAddress, "Kz BarChart", 43)



    End Sub



End Class