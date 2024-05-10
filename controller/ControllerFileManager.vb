Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Media
Imports System.Reflection
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

    Public Function getDocText(doc As Document) As String
        Dim resourceName As String = FilePathRetriever.getPath(doc)

        ' Get the stream for the embedded resource
        Dim stream As Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
        If stream Is Nothing Then
            Throw New FileNotFoundException("The specified resource was not found.", resourceName)
        End If

        ' Return the text content from the stream
        Dim reader As New System.IO.StreamReader(stream)
        Return reader.ReadToEnd()

    End Function



End Module
