Public MustInherit Class Puller

    'ATTRIBUTES
    Protected ret As Integer
    Protected pullBehaviour As PullBehaviour

    'CONSTRUCTORS
    'Default

    'METHODS
    'Setters and Getters
    Public Sub setPullBehaviour(pullBehaviour As PullBehaviour)
        Me.pullBehaviour = pullBehaviour
    End Sub
    Public Function getPullBehaviour() As PullBehaviour
        Return Me.pullBehaviour
    End Function


End Class
