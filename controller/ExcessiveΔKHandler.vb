Public Class ExcessiveΔKHandler
    Inherits ExceptionHandler

    'CONSTRUCTOR
    Public Sub New(controller As PSC_Controller)
        MyBase.New(controller)
    End Sub

    'METHODS
    Public Overrides Sub execute(Optional ex As Exception = Nothing)

        If ex Is Nothing Then
            Return
        End If

        If ex.GetType() Is GetType(ExcessiveΔKException) Then

            Dim exΔK As ExcessiveΔKException = DirectCast(ex, ExcessiveΔKException)

            'Extract the Error message and add further text at the end to anticipate list of piles affected by the issue
            Me.message = ex.Message + vbNewLine + "Affected Pile Objects are the following ones: " + vbNewLine
            'Add the list of Pile Objects affected by the issue
            exΔK.getPileObjs().Select(Function(po) po.getName()).ToList().ForEach(Function(poName) Me.message + poName + ", ")
            'Remove last comma and space from the string message
            Me.message.Remove(Me.message.Count - 2)
            'Display the Warning MessageBox Window
            MsgBox(Me.message, vbOKOnly + vbCritical, "WARNING - EXCESSIVE STIFFNESS VARIATION")
        End If

    End Sub


End Class
