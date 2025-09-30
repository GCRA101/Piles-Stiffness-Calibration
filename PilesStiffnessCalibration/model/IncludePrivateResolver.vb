Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization
Imports System.Reflection

Public Class IncludePrivateResolver
    Inherits DefaultContractResolver

    Protected Overrides Function CreateProperties(type As Type, memberSerialization As MemberSerialization) As IList(Of JsonProperty)
        Dim props = MyBase.CreateProperties(type, memberSerialization)
        ' Include private fields
        Dim privateFields = type.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance)
        For Each field In privateFields
            Dim jsonProperty = MyBase.CreateProperty(field, memberSerialization)
            jsonProperty.Writable = True
            jsonProperty.Readable = True
            props.Add(jsonProperty)
        Next
        Return props
    End Function
End Class