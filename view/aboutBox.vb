Public NotInheritable Class AboutBox

    Private Sub aboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        ApplicationTitle = "Piles Stiffness Calibration Tool"
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.lblProductName.Text = "Piles Stiffness Calibration Tool"
        Me.lblVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.lblCopyRight.Text = "Copyright @ Buro Happold Ltd Inc.2024"
        Me.lblCompanyName.Text = "Buro Happold Ltd"
        Me.txtDescription.Text = My.Application.Info.Description

        Me.CenterToScreen()
    End Sub

End Class
