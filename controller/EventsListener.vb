Imports Piles_Stiffness_Calibration.model
Imports Piles_Stiffness_Calibration.view

Public Class EventsListener

    Private controller As PSC_Controller
    Private view As PSC_View
    Private WithEvents aboutBoxOKButton As Windows.Forms.Button

    Public Sub New(controller As PSC_Controller, view As PSC_View)
        Me.controller = controller
        Me.view = view
    End Sub


    Public Sub initializeAboutBox()
        Me.aboutBoxOKButton = Me.view.getAboutBox().OKButton
    End Sub


    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aboutBoxOKButton.Click
        Me.controller.getSoundManager().play(Sound.CLICKBUTTON)
        view.createViewInputs()
    End Sub

End Class
