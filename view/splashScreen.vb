Imports System.Runtime.Versioning
Imports ETABSv1
Imports Newtonsoft.Json.Converters

Public NotInheritable Class SplashScreen
    Implements Observer

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

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

    Private Sub splashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  
        Me.update()

    End Sub

    Private Sub update() Implements Observer.update
        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).
        lblApplicationName.Text = Me.model.getModelName()
        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        Me.lblVersion.Text = Me.model.getModelVersion()
        'Copyright info
        Me.lblCopyright.Text = Me.model.getModelCopyRight()
    End Sub

End Class
