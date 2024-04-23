Public Class PushBehaviour
    Implements PushData

    'ATTRIBUTES
    Protected ret As Integer
    Protected pDispModel As PDispModel

    'CONSTRUCTORS
    'Default
    Public Sub New()
    End Sub
    'Overloaded
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub


    'METHODS
    Public Sub push(overwrite As Boolean) Implements PushData.push
        Throw New NotImplementedException()
    End Sub
End Class
