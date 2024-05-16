Imports System.Windows.Forms

Module FileManager

    Public Function setNewFilePath(filePath As String, iterNum As Integer) As String

        Dim newFilePath As String
        Dim dateObj As Date = Date.Today

        Dim sep() As Char = {"/", "\", "//"}

        With dateObj
            newFilePath = filePath.Remove(filePath.IndexOf(filePath.Split(sep).Last())) + "PSCT" +
                        .Year.ToString + .Month.ToString("D2") +
                        .Day.ToString("D2") + "_" + "Iteration_" + CStr(iterNum) +
                        "_" + filePath.Split(sep).Last()

        End With

        Return newFilePath

    End Function


End Module
