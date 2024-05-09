Imports System.Runtime.Serialization

Public Class MissingInputsException
    Inherits Exception

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
