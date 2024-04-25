Public MustInherit Class Puller

    'ATTRIBUTES
    Protected ret As Integer
    Protected pullBehaviour As PullBehaviour
    Protected pDispModel As PDispModel

    'CONSTRUCTORS
    'Overloaded
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub

    'METHODS
    'Setters and Getters
    Public Sub setPullBehaviour(pullBehaviour As PullBehaviour)
        Me.pullBehaviour = pullBehaviour
    End Sub
    Public Function getPullBehaviour() As PullBehaviour
        Return Me.pullBehaviour
    End Function


End Class
