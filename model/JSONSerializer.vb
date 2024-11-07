Imports System.IO
Imports Newtonsoft.Json


''' <summary>
''' 
''' JSONSerializer Concrete Class
''' 
''' <remarks>
''' <para> Generic Type Concrete Class responsible for serializing and deserializing json files. </para>
''' <para> The class allows to hide the list of calls to Newtonsoft library functions within the two methods
''' <see cref="serialize"/> and <see cref="deserialize"/>. </para>
''' <para> This allows to make the code easy to read client side. </para>
''' 
''' <typeparam name="T">
''' The base item type. Must implement IComparable.
''' </typeparam>
'''
''' <para> Desing Patterns: 
''' - FACADE </para>
''' 
''' <para> Programming Techniques: 
''' - GENERIC TYPES
''' - SERIALIZATION </para>
''' 
''' </remarks>
''' 
''' </summary>

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

    'Deserialize
    Public Function deserialize(jsonFilePath As String) As T
        Dim jsonText As String = File.ReadAllText(jsonFilePath)
        Return JsonConvert.DeserializeObject(Of T)(jsonText, jsonSettings)
    End Function

End Class
