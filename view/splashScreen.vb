Imports System.Runtime.Versioning
Imports Newtonsoft.Json.Converters

Public NotInheritable Class SplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub splashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        lblApplicationName.Text = "Piles Stiffness Calibration Tool"

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.

        lblVersion.Text = "Version: " + CStr(My.Application.Info.Version.Major) + CStr(My.Application.Info.Version.Minor)

        'Copyright info
        lblCopyright.Text = "Copyright @ Buro Happold Ltd Inc.2024"

    End Sub

End Class
