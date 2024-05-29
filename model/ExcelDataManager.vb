Imports System.IO
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
    Public Sub write(worksheetName As String, data As List(Of PileObject), Optional headerTitle As String = "")

        '1. INITIALIZE EXCEL APPLICATION
        ExcelApp = New Excel.Application

        '2. OPEN/CREATE EXCEL WORKBOOK
        If filePath = "" Then
            ExcelWkb = ExcelApp.Workbooks.Add()
        ElseIf (filePath.Contains(".xlsx") Or filePath.Contains(".xlsm") Or filePath.Contains(".xls")) Then
            ExcelWkb = ExcelApp.Workbooks.Open(filePath)
        End If

        '3. OPEN/CREATE EXCEL WORKSHEET
        If ExcelWkb.Worksheets.Cast(Of Worksheet).Select(Function(wks) wks.Name).Contains(worksheetName) Then
            ExcelWks = ExcelWkb.Worksheets(worksheetName)
        Else
            ExcelWks = ExcelWkb.Worksheets.Add()
            ExcelWks.Name = worksheetName
        End If
        ExcelWks.Tab.ColorIndex = 6
        ExcelWks.Activate()

        '4. POSITION ACTIVE CELL
        If ExcelWks.Range("B4").Value = "" Then
            ExcelWks.Range("B4").Activate()
        Else
            ExcelWks.Range("B4").End(Excel.XlDirection.xlToRight).Offset(0, 1).Activate()
        End If

        '5. WRITE DATA IN THE WORKSHEET
        For i As Integer = 0 To data.Count() - 1 Step 1

            Dim pileObjData As Dictionary(Of String, String) = data(i).toDictionary()

            If i = 0 Then
                pileObjData.Keys().ToList().ForEach(Sub(key) ExcelApp.ActiveCell.Offset(0, 1).Value = CStr(key))
                If headerTitle <> "" Then
                    Dim headerRange As Range
                    headerRange = ExcelApp.Range(ExcelApp.ActiveCell.Offset(-1, 0),
                                             ExcelApp.ActiveCell.End(Excel.XlDirection.xlToRight).Offset(-1, 0))
                    headerRange.Merge()
                    headerRange.Value = headerTitle
                End If
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




End Class
