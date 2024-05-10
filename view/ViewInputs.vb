Imports ETABSv1
Imports Newtonsoft.Json
Imports pdispauto_20_1
Imports Piles_Stiffness_Iteration.model
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Contexts
Imports System.Runtime.Serialization
Imports System.Windows.Forms

Public Class ViewInputs
    Implements Observer

    ' ATTRIBUTES ****************************************************************************************

    Private model As PSC_Model
    Private controller As PSC_Controller
    Private pDispFilePath, jsonFilePath As String
    Private iterNumMax As Integer
    Private convergenceFactor As Single
    Private ret As Integer
    Private loadComboName, groupName As String
    Private pDispModel As PDispModel
    Private iter As Integer
    Private pileObjsQueue As Queue(Of List(Of PileObject))
    Private startPileObjsList As List(Of PileObject)
    Private jsonSerializer As JSONSerializer(Of List(Of PileObject))
    Private progrBarStep As Integer



    ' CONSTRUCTORS **************************************************************************************
    Public Sub New(model As PSC_Model, controller As PSC_Controller)
        Me.model = model
        Me.controller = controller
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Sub initialize()

        Me.cklbGroups.Items.Clear()
        Me.cklbLoadCombos.Items.Clear()

        Me.rbRigid.Checked = True

        For Each comp As Component In gbPDispInputs.Controls
            If CStr(comp.GetType().Name) = "ComboBox" Then
                Dim cbBox = CType(comp, ComboBox)
                cbBox.SelectedIndex = 0
            End If
        Next

        tbStiffness.Enabled = False
        btnOpenJSONFile.Enabled = False

        Me.btnOpenPDispFile.Enabled = True

    End Sub


    Private Sub update() Implements Observer.update

        'Update CheckBoxes with Group/LoadCombo Names

        With Me.cklbGroups
            .CheckOnClick = True
            .Items.AddRange(Me.model.getEtabsGroupNames.ToArray())
            .ClearSelected()
        End With

        With Me.cklbLoadCombos
            .CheckOnClick = True
            .Items.AddRange(Me.model.getEtabsLoadComboNames.ToArray())
            .ClearSelected()
        End With

        Dim iterNumMax As Integer = Me.model.getIterNumMax()

        If iterNumMax <> 0 Then
            Me.progrBarStep = (Me.progrBar.Maximum - Me.progrBar.Minimum) \ iterNumMax
        End If

        If Me.model.getStepRun() = True Then
            Me.progrBar.Increment(progrBarStep)
        End If

        If Me.model.getIterationComplete = True Then
            Me.lblProgrBar.Text = "ITERATION COMPLETE!"
        End If

    End Sub

End Class