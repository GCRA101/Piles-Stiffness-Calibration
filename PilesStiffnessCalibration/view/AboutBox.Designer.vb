<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.RichTextBox()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblCopyRight = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.panelImage = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel.Controls.Add(Me.lblProductName, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.lblVersion, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.lblCopyRight, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.lblCompanyName, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.btnOK, 1, 5)
        Me.TableLayoutPanel.Controls.Add(Me.panelImage, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.txtDescription, 0, 4)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 11)
        Me.TableLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(607, 435)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(503, 403)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        '
        'txtDescription
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.txtDescription, 2)
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescription.Location = New System.Drawing.Point(4, 176)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(599, 209)
        Me.txtDescription.TabIndex = 2
        Me.txtDescription.Text = ""
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCompanyName.Location = New System.Drawing.Point(208, 129)
        Me.lblCompanyName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.lblCompanyName.MaximumSize = New System.Drawing.Size(0, 21)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(395, 21)
        Me.lblCompanyName.TabIndex = 0
        Me.lblCompanyName.Text = "Company Name"
        Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCopyRight
        '
        Me.lblCopyRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCopyRight.Location = New System.Drawing.Point(208, 86)
        Me.lblCopyRight.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.lblCopyRight.MaximumSize = New System.Drawing.Size(0, 21)
        Me.lblCopyRight.Name = "lblCopyRight"
        Me.lblCopyRight.Size = New System.Drawing.Size(395, 21)
        Me.lblCopyRight.TabIndex = 0
        Me.lblCopyRight.Text = "Copyright"
        Me.lblCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVersion
        '
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblVersion.Location = New System.Drawing.Point(208, 43)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.lblVersion.MaximumSize = New System.Drawing.Size(0, 21)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(395, 21)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductName
        '
        Me.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProductName.Location = New System.Drawing.Point(208, 0)
        Me.lblProductName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.lblProductName.MaximumSize = New System.Drawing.Size(0, 21)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(395, 21)
        Me.lblProductName.TabIndex = 0
        Me.lblProductName.Text = "Product Name"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panelImage
        '
        Me.panelImage.BackgroundImage = CType(resources.GetObject("panelImage.BackgroundImage"), System.Drawing.Image)
        Me.panelImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelImage.Location = New System.Drawing.Point(4, 4)
        Me.panelImage.Margin = New System.Windows.Forms.Padding(4)
        Me.panelImage.Name = "panelImage"
        Me.TableLayoutPanel.SetRowSpan(Me.panelImage, 4)
        Me.panelImage.Size = New System.Drawing.Size(192, 164)
        Me.panelImage.TabIndex = 1
        '
        'AboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(631, 457)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox"
        Me.Padding = New System.Windows.Forms.Padding(12, 11, 12, 11)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AboutBox"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel As Windows.Forms.TableLayoutPanel
    Friend WithEvents lblProductName As Windows.Forms.Label
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents lblCopyRight As Windows.Forms.Label
    Friend WithEvents lblCompanyName As Windows.Forms.Label
    Friend WithEvents btnOK As Windows.Forms.Button
    Friend WithEvents panelImage As Windows.Forms.Panel
    Friend WithEvents txtDescription As Windows.Forms.RichTextBox
End Class
