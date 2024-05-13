Public MustInherit Class PullBehaviour(Of T As PDispData)
    Implements PullData(Of T)

    'ATTRIBUTES
    Protected ret As Integer
    Protected pDispModel As PDispModel

    'CONSTRUCTORS
    'Overloaded
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub

    Public Overridable Function pull() As List(Of T) Implements PullData(Of T).pull
    End Function

End Class
