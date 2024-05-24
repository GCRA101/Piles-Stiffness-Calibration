Imports System.IO
Imports System.Reflection

Public NotInheritable Class AboutBox
    Implements Observer

    'ATTRIBUTES
    Private model As PSC_Model

    'CONSTRUCTOR
    'Overloaded
    Public Sub New(model As PSC_Model)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.model = model
    End Sub

    Private Sub aboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        ApplicationTitle = "Piles Stiffness Calibration Tool"
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        Me.update()
        ' Place the AboutBox at the centre of the Screen
        Me.CenterToScreen()
    End Sub

    Private Sub update() Implements Observer.update
        Me.lblProductName.Text = Me.model.getModelName()
        Me.lblVersion.Text = Me.model.getModelVersion()
        Me.lblCopyRight.Text = Me.model.getModelCopyRight()
        Me.lblCompanyName.Text = Me.model.getModelOwner()
        Me.txtDescription.Text = ControllerFileManager.getDocText(Document.APP_DESCRIPTION)
    End Sub
End Class
