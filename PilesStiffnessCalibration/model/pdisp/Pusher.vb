Public Class Pusher

    'ATTRIBUTES
    Protected ret As Integer
    Protected pushBehaviour As PushBehaviour
    Protected pDispModel As PDispModel

    'CONSTRUCTORS
    'Default

    'METHODS
    'Setters and Getters
    Public Sub setPushBehaviour(pushBehaviour As PushBehaviour)
        Me.pushBehaviour = pushBehaviour
    End Sub
    Public Function getPushBehaviour() As PushBehaviour
        Return Me.pushBehaviour
    End Function


End Class
