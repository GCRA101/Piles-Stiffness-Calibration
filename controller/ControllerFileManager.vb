Imports System.Windows.Forms

Module ControllerFileManager

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
