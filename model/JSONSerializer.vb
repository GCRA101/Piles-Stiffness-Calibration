Imports System.IO
Imports Newtonsoft.Json

'MAIN FIGURES *************************************
'Use of GENERIC TYPES
'Use of SERIALIZATION (JSON Format)

Public Class JSONSerializer(Of T)

    'ATTRIBUTES
    Private filePath As String
    Private jsonSettings As JsonSerializerSettings

    'CONSTRUCTORS
    Public Sub New()
        Me.jsonSettings = New JsonSerializerSettings() With {
            .ContractResolver = New IncludePrivateResolver()}
    End Sub


    'METHODS

    'Serialize
    Public Sub serialize(obj As T, jsonFilePath As String)
        Dim jsonText As String = JsonConvert.SerializeObject(obj, Formatting.Indented, jsonSettings)
        File.WriteAllText(jsonFilePath, jsonText)
    End Sub

    'Deserlize
    Public Function deserialize(jsonFilePath As String) As T

        Dim jsonText As String = File.ReadAllText(jsonFilePath)
        Return JsonConvert.DeserializeObject(jsonText, jsonSettings)

    End Function

End Class
