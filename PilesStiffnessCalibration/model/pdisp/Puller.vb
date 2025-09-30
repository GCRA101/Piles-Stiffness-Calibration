Public MustInherit Class Puller(Of T As PDispData)

    'ATTRIBUTES
    Protected ret As Integer
    Protected pullBehaviour As PullBehaviour(Of T)
    Protected pDispModel As PDispModel

    'CONSTRUCTORS
    'Overloaded
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub

    'METHODS
    'Setters and Getters
    Public Sub setPullBehaviour(pullBehaviour As PullBehaviour(Of T))
        Me.pullBehaviour = pullBehaviour
    End Sub
    Public Function getPullBehaviour() As PullBehaviour(Of T)
        Return Me.pullBehaviour
    End Function


End Class
