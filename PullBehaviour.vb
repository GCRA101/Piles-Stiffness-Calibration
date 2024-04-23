Public MustInherit Class PullBehaviour
    Implements PullData

    'ATTRIBUTES
    Protected ret As Integer
    Protected pDispModel As PDispModel

    'CONSTRUCTORS
    'Overloaded
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub

    Public Overridable Function Getpull() As List(Of PDispData) Implements PullData.Getpull
    End Function
End Class
