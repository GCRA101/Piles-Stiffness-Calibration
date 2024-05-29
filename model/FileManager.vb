Imports System.IO
Imports System.Windows.Forms

Module FileManager


    Public Function setDatedFolderPath(folderPath As String, subFolderName As String)
        Dim dateObj As Date = Date.Today
        Dim datedFolderPath As String = ""

        With dateObj
            datedFolderPath = folderPath + .Year.ToString + .Month.ToString("D2") +
                                .Day.ToString("D2") + .Hour.ToString() + .Minute.ToString() + "_" + subFolderName
        End With

        Return datedFolderPath

    End Function


    Public Function setNewFilePath(oldFilePath As String, iterNum As Integer) As String

        Dim newFilePath As String
        Dim dateObj As Date = Date.Today

        Dim sep() As Char = {"/", "\", "//"}

        With dateObj
            newFilePath = oldFilePath.Remove(oldFilePath.IndexOf(oldFilePath.Split(sep).Last())) + "PSCT" +
                        .Year.ToString + .Month.ToString("D2") +
                        .Day.ToString("D2") + "_" + .Hour.ToString() + .Minute.ToString() + "_" + "Iteration_" + CStr(iterNum) +
                        "_" + oldFilePath.Split(sep).Last()

        End With

        Return newFilePath

    End Function

    Public Function setNewFilePath(oldFilePath As String, destinationFolderPath As String, iterNum As Integer) As String

        Dim newFilePath As String
        Dim dateObj As Date = Date.Today

        Dim sep() As Char = {"/", "\", "//"}

        With dateObj
            newFilePath = destinationFolderPath + "PSCT" + .Year.ToString + .Month.ToString("D2") +
                            .Day.ToString("D2") + "_" + "Iteration_" + CStr(iterNum) +
                             "_" + Path.GetFileName(oldFilePath)
        End With

        Return newFilePath

    End Function



End Module
