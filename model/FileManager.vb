Imports System.Windows.Forms

Module FileManager

    Public Function setNewFilePath(filePath As String, iterNum As Integer) As String

        Dim newFilePath As String
        Dim dateObj As Date = Date.Today

        Dim sep1() As Char = {"/", "\", "//"}
        Dim sep2() As Char = {"_"}

        With dateObj
            If filePath.Contains("PSI") = False Then
                newFilePath = filePath.Remove(filePath.IndexOf(filePath.Split(sep1).Last())) + "PSI" +
                            .Year.ToString + .Month.ToString("D2") +
                            .Day.ToString("D2") + "_" + "Iteration_" + CStr(iterNum) +
                            "_" + filePath.Split(sep1).Last()
            Else
                newFilePath = filePath.Remove(filePath.IndexOf(filePath.Split(sep2).Last())) + "PSI" +
                            .Year.ToString + .Month.ToString("D2") +
                            .Day.ToString("D2") + "_" + "Iteration_" + CStr(iterNum) +
                            "_" + filePath.Split(sep2).Last()
            End If
        End With

        Return newFilePath

    End Function


End Module
