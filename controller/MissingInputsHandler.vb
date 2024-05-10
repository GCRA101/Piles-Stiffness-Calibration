Imports ETABSv1

Public Class MissingInputsHandler
    Inherits ExceptionHandler

    'CONSTRUCTOR
    Public Sub New(controller As PSC_Controller)
        MyBase.New(controller)
    End Sub

    'METHODS
    Public Overrides Sub execute(Optional ex As Exception = Nothing)

        If ex IsNot Nothing Then
            Me.message = ex.Message
            MsgBox(Me.message, vbOKOnly + vbCritical, "WARNING - MISSING INPUTS")
        End If

    End Sub


End Class
