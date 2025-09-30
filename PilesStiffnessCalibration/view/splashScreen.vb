Imports System.Runtime.Versioning
Imports ETABSv1
Imports Newtonsoft.Json.Converters

''' <summary>
''' 
''' <remarks>
''' <para> Concrete class representing the initial splashscreen window of the application. </para>
''' <para> The class implements the Observer functional interface that allows it to be updated with changes occurring in the Model
''' via the Observer Pattern.</para>
''' <para> The <see cref="update"/> method gets called as soon as the window gets loaded, allowing it to collect the application's assembly 
''' information that is stored in the Model <see cref="PSC_Model"/>
'''  </para>
''' 
''' <para> Desing Patterns: 
''' - OBSERVER </para>
''' 
''' </remarks>
''' </summary>

Public NotInheritable Class SplashScreen
    Implements Observer

    'ATTRIBUTES ***************************************************************************************
    Private model As PSC_Model

    'CONSTRUCTOR ************************************************************************************** 
    'Overloaded
    Public Sub New(model As PSC_Model)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.model = model
    End Sub

    'METHODS ******************************************************************************************
    Private Sub splashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  
        Me.update()
    End Sub

    Private Sub update() Implements Observer.update
        'Application Name
        lblApplicationName.Text = Me.model.getModelName()
        'Application Version
        Me.lblVersion.Text = Me.model.getModelVersion()
        'Copyright info
        Me.lblCopyright.Text = Me.model.getModelCopyRight()
    End Sub

End Class
