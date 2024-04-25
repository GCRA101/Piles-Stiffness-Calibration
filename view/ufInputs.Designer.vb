<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ufInputs
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ufInputs))
        Me.btnRunIteration = New System.Windows.Forms.Button()
        Me.lblProgrBar = New System.Windows.Forms.Label()
        Me.progrBar = New System.Windows.Forms.ProgressBar()
        Me.cbIterations = New System.Windows.Forms.ComboBox()
        Me.lblIterations = New System.Windows.Forms.Label()
        Me.cbDispVariation = New System.Windows.Forms.ComboBox()
        Me.lblDispVariation = New System.Windows.Forms.Label()
        Me.lblLoadCombos = New System.Windows.Forms.Label()
        Me.cklbLoadCombos = New System.Windows.Forms.CheckedListBox()
        Me.lblGroups = New System.Windows.Forms.Label()
        Me.cklbGroups = New System.Windows.Forms.CheckedListBox()
        Me.ofdPDispFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenPDispFile = New System.Windows.Forms.Button()
        Me.lblPDispFile = New System.Windows.Forms.Label()
        Me.pbETABSInputs = New System.Windows.Forms.PictureBox()
        Me.pbPDispInputs = New System.Windows.Forms.PictureBox()
        Me.gbPDispInputs = New System.Windows.Forms.GroupBox()
        Me.gbETABSInputs = New System.Windows.Forms.GroupBox()
        Me.rbRigid = New System.Windows.Forms.RadioButton()
        Me.rbSpring = New System.Windows.Forms.RadioButton()
        Me.rbImportFromFile = New System.Windows.Forms.RadioButton()
        Me.lblInitialStiffness = New System.Windows.Forms.Label()
        Me.btnOpenJSONFile = New System.Windows.Forms.Button()
        CType(Me.pbETABSInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPDispInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPDispInputs.SuspendLayout()
        Me.gbETABSInputs.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRunIteration
        '
        Me.btnRunIteration.Location = New System.Drawing.Point(110, 628)
        Me.btnRunIteration.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRunIteration.Name = "btnRunIteration"
        Me.btnRunIteration.Size = New System.Drawing.Size(165, 47)
        Me.btnRunIteration.TabIndex = 29
        Me.btnRunIteration.Text = "RUN ITERATION"
        Me.btnRunIteration.UseVisualStyleBackColor = True
        '
        'lblProgrBar
        '
        Me.lblProgrBar.AutoSize = True
        Me.lblProgrBar.Location = New System.Drawing.Point(28, 697)
        Me.lblProgrBar.Name = "lblProgrBar"
        Me.lblProgrBar.Size = New System.Drawing.Size(134, 16)
        Me.lblProgrBar.TabIndex = 28
        Me.lblProgrBar.Text = "Iteration in Progress..."
        '
        'progrBar
        '
        Me.progrBar.Location = New System.Drawing.Point(29, 717)
        Me.progrBar.Margin = New System.Windows.Forms.Padding(4)
        Me.progrBar.Maximum = 100000
        Me.progrBar.Name = "progrBar"
        Me.progrBar.Size = New System.Drawing.Size(317, 27)
        Me.progrBar.TabIndex = 27
        '
        'cbIterations
        '
        Me.cbIterations.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIterations.FormattingEnabled = True
        Me.cbIterations.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "10", "20", "50", "100"})
        Me.cbIterations.Location = New System.Drawing.Point(205, 114)
        Me.cbIterations.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbIterations.Name = "cbIterations"
        Me.cbIterations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbIterations.Size = New System.Drawing.Size(124, 23)
        Me.cbIterations.TabIndex = 26
        '
        'lblIterations
        '
        Me.lblIterations.AutoSize = True
        Me.lblIterations.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIterations.Location = New System.Drawing.Point(8, 117)
        Me.lblIterations.Name = "lblIterations"
        Me.lblIterations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIterations.Size = New System.Drawing.Size(175, 15)
        Me.lblIterations.TabIndex = 25
        Me.lblIterations.Text = "Max Num of Analysis Iterations:"
        '
        'cbDispVariation
        '
        Me.cbDispVariation.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDispVariation.FormattingEnabled = True
        Me.cbDispVariation.Items.AddRange(New Object() {"5%", "10%", "15%", "20%"})
        Me.cbDispVariation.Location = New System.Drawing.Point(205, 80)
        Me.cbDispVariation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbDispVariation.Name = "cbDispVariation"
        Me.cbDispVariation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbDispVariation.Size = New System.Drawing.Size(124, 23)
        Me.cbDispVariation.TabIndex = 31
        '
        'lblDispVariation
        '
        Me.lblDispVariation.AutoSize = True
        Me.lblDispVariation.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDispVariation.Location = New System.Drawing.Point(8, 83)
        Me.lblDispVariation.Name = "lblDispVariation"
        Me.lblDispVariation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispVariation.Size = New System.Drawing.Size(154, 15)
        Me.lblDispVariation.TabIndex = 30
        Me.lblDispVariation.Text = "Max Average Disp Variation:"
        '
        'lblLoadCombos
        '
        Me.lblLoadCombos.AutoSize = True
        Me.lblLoadCombos.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadCombos.Location = New System.Drawing.Point(7, 158)
        Me.lblLoadCombos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoadCombos.Name = "lblLoadCombos"
        Me.lblLoadCombos.Size = New System.Drawing.Size(99, 17)
        Me.lblLoadCombos.TabIndex = 35
        Me.lblLoadCombos.Text = "LOAD COMBOS"
        '
        'cklbLoadCombos
        '
        Me.cklbLoadCombos.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbLoadCombos.FormattingEnabled = True
        Me.cklbLoadCombos.Location = New System.Drawing.Point(9, 182)
        Me.cklbLoadCombos.Margin = New System.Windows.Forms.Padding(4)
        Me.cklbLoadCombos.Name = "cklbLoadCombos"
        Me.cklbLoadCombos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cklbLoadCombos.Size = New System.Drawing.Size(318, 94)
        Me.cklbLoadCombos.TabIndex = 34
        '
        'lblGroups
        '
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroups.Location = New System.Drawing.Point(9, 47)
        Me.lblGroups.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(58, 17)
        Me.lblGroups.TabIndex = 33
        Me.lblGroups.Text = "GROUPS"
        '
        'cklbGroups
        '
        Me.cklbGroups.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbGroups.FormattingEnabled = True
        Me.cklbGroups.Location = New System.Drawing.Point(9, 71)
        Me.cklbGroups.Margin = New System.Windows.Forms.Padding(4)
        Me.cklbGroups.Name = "cklbGroups"
        Me.cklbGroups.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cklbGroups.Size = New System.Drawing.Size(320, 76)
        Me.cklbGroups.TabIndex = 32
        '
        'ofdPDispFile
        '
        Me.ofdPDispFile.FileName = "ofdPDispFile"
        '
        'btnOpenPDispFile
        '
        Me.btnOpenPDispFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenPDispFile.Location = New System.Drawing.Point(205, 46)
        Me.btnOpenPDispFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenPDispFile.Name = "btnOpenPDispFile"
        Me.btnOpenPDispFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpenPDispFile.Size = New System.Drawing.Size(124, 28)
        Me.btnOpenPDispFile.TabIndex = 36
        Me.btnOpenPDispFile.Text = "Browse..."
        Me.btnOpenPDispFile.UseVisualStyleBackColor = True
        '
        'lblPDispFile
        '
        Me.lblPDispFile.AutoSize = True
        Me.lblPDispFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPDispFile.Location = New System.Drawing.Point(8, 52)
        Me.lblPDispFile.Name = "lblPDispFile"
        Me.lblPDispFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPDispFile.Size = New System.Drawing.Size(95, 15)
        Me.lblPDispFile.TabIndex = 37
        Me.lblPDispFile.Text = "Select PDisp File:"
        '
        'pbETABSInputs
        '
        Me.pbETABSInputs.Image = CType(resources.GetObject("pbETABSInputs.Image"), System.Drawing.Image)
        Me.pbETABSInputs.InitialImage = Nothing
        Me.pbETABSInputs.Location = New System.Drawing.Point(0, 0)
        Me.pbETABSInputs.Name = "pbETABSInputs"
        Me.pbETABSInputs.Size = New System.Drawing.Size(40, 35)
        Me.pbETABSInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbETABSInputs.TabIndex = 38
        Me.pbETABSInputs.TabStop = False
        '
        'pbPDispInputs
        '
        Me.pbPDispInputs.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.pbPDispInputs.Image = CType(resources.GetObject("pbPDispInputs.Image"), System.Drawing.Image)
        Me.pbPDispInputs.InitialImage = Nothing
        Me.pbPDispInputs.Location = New System.Drawing.Point(0, 0)
        Me.pbPDispInputs.Name = "pbPDispInputs"
        Me.pbPDispInputs.Size = New System.Drawing.Size(40, 35)
        Me.pbPDispInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPDispInputs.TabIndex = 39
        Me.pbPDispInputs.TabStop = False
        '
        'gbPDispInputs
        '
        Me.gbPDispInputs.Controls.Add(Me.pbPDispInputs)
        Me.gbPDispInputs.Controls.Add(Me.lblPDispFile)
        Me.gbPDispInputs.Controls.Add(Me.btnOpenPDispFile)
        Me.gbPDispInputs.Controls.Add(Me.cbDispVariation)
        Me.gbPDispInputs.Controls.Add(Me.lblDispVariation)
        Me.gbPDispInputs.Controls.Add(Me.cbIterations)
        Me.gbPDispInputs.Controls.Add(Me.lblIterations)
        Me.gbPDispInputs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPDispInputs.Location = New System.Drawing.Point(24, 447)
        Me.gbPDispInputs.Name = "gbPDispInputs"
        Me.gbPDispInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.gbPDispInputs.Size = New System.Drawing.Size(336, 152)
        Me.gbPDispInputs.TabIndex = 42
        Me.gbPDispInputs.TabStop = False
        Me.gbPDispInputs.Text = "PDISP Inputs"
        '
        'gbETABSInputs
        '
        Me.gbETABSInputs.Controls.Add(Me.btnOpenJSONFile)
        Me.gbETABSInputs.Controls.Add(Me.lblInitialStiffness)
        Me.gbETABSInputs.Controls.Add(Me.rbImportFromFile)
        Me.gbETABSInputs.Controls.Add(Me.rbSpring)
        Me.gbETABSInputs.Controls.Add(Me.rbRigid)
        Me.gbETABSInputs.Controls.Add(Me.cklbLoadCombos)
        Me.gbETABSInputs.Controls.Add(Me.lblLoadCombos)
        Me.gbETABSInputs.Controls.Add(Me.pbETABSInputs)
        Me.gbETABSInputs.Controls.Add(Me.cklbGroups)
        Me.gbETABSInputs.Controls.Add(Me.lblGroups)
        Me.gbETABSInputs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbETABSInputs.Location = New System.Drawing.Point(24, 32)
        Me.gbETABSInputs.Name = "gbETABSInputs"
        Me.gbETABSInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.gbETABSInputs.Size = New System.Drawing.Size(336, 400)
        Me.gbETABSInputs.TabIndex = 43
        Me.gbETABSInputs.TabStop = False
        Me.gbETABSInputs.Text = "ETABS Inputs"
        '
        'rbRigid
        '
        Me.rbRigid.AutoSize = True
        Me.rbRigid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbRigid.Location = New System.Drawing.Point(11, 306)
        Me.rbRigid.Name = "rbRigid"
        Me.rbRigid.Size = New System.Drawing.Size(156, 24)
        Me.rbRigid.TabIndex = 39
        Me.rbRigid.TabStop = True
        Me.rbRigid.Text = "All Rigid Supports"
        Me.rbRigid.UseVisualStyleBackColor = True
        '
        'rbSpring
        '
        Me.rbSpring.AutoSize = True
        Me.rbSpring.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbSpring.Location = New System.Drawing.Point(11, 336)
        Me.rbSpring.Name = "rbSpring"
        Me.rbSpring.Size = New System.Drawing.Size(156, 24)
        Me.rbSpring.TabIndex = 40
        Me.rbSpring.TabStop = True
        Me.rbSpring.Text = "All Same Stiffness"
        Me.rbSpring.UseVisualStyleBackColor = True
        '
        'rbImportFromFile
        '
        Me.rbImportFromFile.AutoSize = True
        Me.rbImportFromFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbImportFromFile.Location = New System.Drawing.Point(11, 366)
        Me.rbImportFromFile.Name = "rbImportFromFile"
        Me.rbImportFromFile.Size = New System.Drawing.Size(216, 24)
        Me.rbImportFromFile.TabIndex = 41
        Me.rbImportFromFile.TabStop = True
        Me.rbImportFromFile.Text = "Import from Serialized File"
        Me.rbImportFromFile.UseVisualStyleBackColor = True
        '
        'lblInitialStiffness
        '
        Me.lblInitialStiffness.AutoSize = True
        Me.lblInitialStiffness.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitialStiffness.Location = New System.Drawing.Point(9, 286)
        Me.lblInitialStiffness.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInitialStiffness.Name = "lblInitialStiffness"
        Me.lblInitialStiffness.Size = New System.Drawing.Size(230, 17)
        Me.lblInitialStiffness.TabIndex = 42
        Me.lblInitialStiffness.Text = "INITIAL PILES STIFFNESS ASSUMPTION"
        '
        'btnOpenJSONFile
        '
        Me.btnOpenJSONFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenJSONFile.Location = New System.Drawing.Point(251, 367)
        Me.btnOpenJSONFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenJSONFile.Name = "btnOpenJSONFile"
        Me.btnOpenJSONFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpenJSONFile.Size = New System.Drawing.Size(76, 24)
        Me.btnOpenJSONFile.TabIndex = 40
        Me.btnOpenJSONFile.Text = "Browse..."
        Me.btnOpenJSONFile.UseVisualStyleBackColor = True
        '
        'ufInputs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 780)
        Me.Controls.Add(Me.gbETABSInputs)
        Me.Controls.Add(Me.gbPDispInputs)
        Me.Controls.Add(Me.btnRunIteration)
        Me.Controls.Add(Me.lblProgrBar)
        Me.Controls.Add(Me.progrBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ufInputs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "a"
        CType(Me.pbETABSInputs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPDispInputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPDispInputs.ResumeLayout(False)
        Me.gbPDispInputs.PerformLayout()
        Me.gbETABSInputs.ResumeLayout(False)
        Me.gbETABSInputs.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRunIteration As Windows.Forms.Button
    Friend WithEvents lblProgrBar As Windows.Forms.Label
    Friend WithEvents progrBar As Windows.Forms.ProgressBar
    Friend WithEvents cbIterations As Windows.Forms.ComboBox
    Friend WithEvents lblIterations As Windows.Forms.Label
    Friend WithEvents cbDispVariation As Windows.Forms.ComboBox
    Friend WithEvents lblDispVariation As Windows.Forms.Label
    Friend WithEvents lblLoadCombos As Windows.Forms.Label
    Friend WithEvents cklbLoadCombos As Windows.Forms.CheckedListBox
    Friend WithEvents lblGroups As Windows.Forms.Label
    Friend WithEvents cklbGroups As Windows.Forms.CheckedListBox
    Friend WithEvents ofdPDispFile As Windows.Forms.OpenFileDialog
    Friend WithEvents btnOpenPDispFile As Windows.Forms.Button
    Friend WithEvents lblPDispFile As Windows.Forms.Label
    Friend WithEvents pbETABSInputs As Windows.Forms.PictureBox
    Friend WithEvents pbPDispInputs As Windows.Forms.PictureBox
    Friend WithEvents gbPDispInputs As Windows.Forms.GroupBox
    Friend WithEvents gbETABSInputs As Windows.Forms.GroupBox
    Friend WithEvents lblInitialStiffness As Windows.Forms.Label
    Friend WithEvents rbImportFromFile As Windows.Forms.RadioButton
    Friend WithEvents rbSpring As Windows.Forms.RadioButton
    Friend WithEvents rbRigid As Windows.Forms.RadioButton
    Friend WithEvents btnOpenJSONFile As Windows.Forms.Button
End Class
