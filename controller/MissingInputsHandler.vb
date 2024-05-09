Public Class MissingInputsHandler
    Inherits ExceptionHandler

    'CONSTRUCTOR
    Public Sub New(controller As PSC_Controller)
        MyBase.New(controller)
    End Sub

    'METHODS
    Public Overrides Sub execute(Optional ex As Exception = Nothing)
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.WARNING)

        If ex IsNot Nothing Then
            Me.message = ex.Message
            MsgBox(Me.message, vbOKOnly + vbCritical, "WARNING")
        End If

    End Sub


End Class
