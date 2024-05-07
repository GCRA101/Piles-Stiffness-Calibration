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


    Public Function getFilePath(ofd As OpenFileDialog, dialogTitle As String, filter As String) As String

        Dim fileName As String = Nothing

        With ofd
            .Title = dialogTitle
            .InitialDirectory = "C:\"
            .Multiselect = False
            .Filter = filter
            Dim dialogResult As DialogResult = .ShowDialog()
            If dialogResult = Windows.Forms.DialogResult.OK Then
                fileName = .FileName
            End If
        End With

        Return fileName

    End Function



End Module
