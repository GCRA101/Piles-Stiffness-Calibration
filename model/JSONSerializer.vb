Imports System.IO
Imports Newtonsoft.Json

Public Class JSONSerializer

    'ATTRIBUTES
    Private filePath As String
    Private instance As JSONSerializer


    'CONSTRUCTORS
    Private Sub New()
    End Sub

    'METHODS

    Public Function getInstance() As JSONSerializer
        If instance Is Nothing Then
            instance = New JSONSerializer()
        End If
        Return instance
    End Function

    Public Sub serialize(obj As Object, jsonFilePath As String)
        Dim jsonText As String = JsonConvert.SerializeObject(obj)
        File.WriteAllText(jsonFilePath, jsonText)
    End Sub


End Class
