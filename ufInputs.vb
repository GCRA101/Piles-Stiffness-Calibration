Imports ETABSv1
Imports pdispauto_20_1
Imports Piles_Stiffness_Iteration.model
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class ufInputs

    ' ATTRIBUTES ****************************************************************************************

    Private SapModel As cSapModel = Nothing
    Private ISapPlugin As cPluginCallback = Nothing
    Private pDispFilePath As String
    Private iterNumMax As Integer
    Private convergenceFactor As Single
    Private ret As Integer
    Private loadComboName, groupName As String
    Private pDispModel As PDispModel
    Private iter As Integer


    ' CONSTRUCTORS **************************************************************************************
    Public Sub New(ByRef SapModel As cSapModel, ByRef ISapPlugin As cPluginCallback)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SapModel = SapModel
        Me.ISapPlugin = ISapPlugin
    End Sub






    Private Sub ufInputs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        extractDataSourceFile()
    End Sub


    Private Sub InitializeForm()

        Me.cklbGroups.Items.Clear()
        Me.cklbLoadCombos.Items.Clear()

        For Each comp As Component In gbPDispInputs.Controls
            If CStr(comp.GetType().Name) = "ComboBox" Then
                Dim cbBox = CType(comp, ComboBox)
                cbBox.SelectedIndex = 0
            End If
        Next

        Me.btnOpenPDispFile.Enabled = True

    End Sub



    Private Sub extractDataSourceFile()

        'EXTRACT GROUP NAMES

        Dim groupsNum As Integer
        Dim groupNames As String()
        Me.SapModel.GroupDef.GetNameList(groupsNum, groupNames)

        With Me.cklbGroups
            .CheckOnClick = True
            .Items.AddRange(groupNames)
            .ClearSelected()
        End With


        'EXTRACT LOAD COMBOS

        Dim lCombosNum As Integer
        Dim lComboNames As String()
        Me.SapModel.RespCombo.GetNameList(lCombosNum, lComboNames)


        With Me.cklbLoadCombos
            .CheckOnClick = True
            .Items.AddRange(lComboNames)
            .ClearSelected()
        End With

    End Sub


    Private Function getSelectedFile(dialogTitle As String) As String

        Dim fileName As String = Nothing

        With ofdPDispFile
            .Title = dialogTitle
            .InitialDirectory = "C:\"
            .Multiselect = False
            .Filter = "PDisp Files|*.pdd"
            Dim dialogResult As DialogResult = .ShowDialog()
            If dialogResult = Windows.Forms.DialogResult.OK Then
                fileName = .FileName
            End If
        End With

        Return fileName

    End Function

    Private Function setNewFilePath(filePath As String, iterNum As Integer) As String
        Dim newFilePath As String
        Dim dateObj As Date = Date.Today

        Dim sep() As Char = {"/", "\", "//"}

        With dateObj
            newFilePath = filePath.Remove(filePath.IndexOf(filePath.Split(sep).Last())) + "PSI" +
                            .Year.ToString + .Month.ToString("D2") +
                            .Day.ToString("D2") + "_" + "Iteration_" + CStr(iterNum) + "_" + filePath.Split(sep).Last()
        End With

        Return newFilePath

    End Function

    Private Sub btnOpenPDispFile_Click(sender As Object, e As EventArgs) Handles btnOpenPDispFile.Click

        pDispFilePath = getSelectedFile("Select PDisp File")

        If ((pDispFilePath <> "")) Then
            Me.btnOpenPDispFile.Enabled = False
        End If
    End Sub

    Private Sub btnRunIteration_Click(sender As Object, e As EventArgs) Handles btnRunIteration.Click

        loadComboName = Me.cklbLoadCombos.SelectedItem.ToString()
        groupName = Me.cklbGroups.SelectedItem.ToString()

        iterNumMax = CInt(Me.cbIterations.Items(cbIterations.SelectedIndex))
        convergenceFactor = CDbl(Strings.Split(CStr(Me.cbDispVariation.Items(cbDispVariation.SelectedIndex)), "%")(0)) / 100.0

        Dim progrBarStep As Integer = (Me.progrBar.Maximum - Me.progrBar.Minimum) \ iterNumMax

        'Open PDisp File
        pDispModel = New PDispModel(pDispFilePath)

        iter = 0

        While iter < iterNumMax
            'Save Models
            SapModel.File.Save(setNewFilePath(SapModel.GetModelFilename(True), iter))
            pDispModel.save(setNewFilePath(pDispFilePath, iter))
            'Run Iteration
            runIteration()
            'Save Models
            'SapModel.File.Save()
            'ret = PdispObj.Save()
            iter += 1
            Me.progrBar.Increment(progrBarStep)
            Me.Refresh()
        End While

        Me.lblProgrBar.Text = "ITERATIONS COMPLETED!"
        Me.Refresh()

        'MEMORY RELEASE
        Me.ISapPlugin.Finish(0)
        pDispModel.close()

        'CLOSE AND DISPOSE FORM
        Me.Close()
        Me.Dispose()
    End Sub


    Public Sub runIteration() 'T(n)


        'UNLOCK THE ETABS MODEL
        SapModel.SetModelIsLocked(False)

        'EXTRACT LOAD CASES
        Dim loadCasesNum As Integer
        Dim loadCasesNames As String()
        ret = SapModel.LoadCases.GetNameList(loadCasesNum, loadCasesNames)

        'ACTIVATE ALL LOAD CASES FOR RUNNING THE ANALYSIS
        ret = SapModel.Analyze.SetRunCaseFlag(loadCasesNames(0), True, All:=True)

        'RUN THE ANALYSIS
        ret = SapModel.Analyze.RunAnalysis()   'θ(n)

        'ACTIVATE ONLY LOAD COMBO SELECTED BY THE USER
        SapModel.Results.Setup.DeselectAllCasesAndCombosForOutput()
        SapModel.Results.Setup.SetComboSelectedForOutput(loadComboName)

        'EXTRACT BASE POINT REACTIONS

        Dim groupObjsNum As Integer, groupObjsTypes As Integer(), groupObjsNames As String()
        Dim pointNames As List(Of String)
        ret = SapModel.GroupDef.GetAssignments(groupName, groupObjsNum, groupObjsTypes, groupObjsNames)
        For i As Integer = 0 To groupObjsTypes.Length - 1 Step 1
            If groupObjsTypes(i) = 1 Then
                pointNames.Add(groupObjsNames(i))
            End If
        Next



        Dim itemTypeElm As ETABSv1.eItemTypeElm
        Dim numRes As Integer
        Dim obj, elm, loadCase, stepType As String()
        Dim stepNum As Double()
        Dim f1, f2, f3, m1, m2, m3 As Double()
        Dim ppX, ppY, ppZ As Double
        Dim ppMatch As Boolean

        Dim ppDataSet As List(Of PointDataSet)

        For i = 0 To pointNames.Count - 1 Step 1
            ret = SapModel.Results.JointReact(pointNames(i), itemTypeElm, numRes, obj, elm, loadCase,
                                             stepType, stepNum, f1, f2, f3, m1, m2, m3)
            ret = SapModel.PointObj.GetCoordCartesian(pointNames(i), ppX, ppY, ppZ)

            ppDataSet.Add(New PointDataSet(New PointObj(pointNames(i), ppX, ppY, ppZ),
                                                    New PointReactions(numRes, obj, elm, loadCase,
                                                                       stepType, stepNum, f1, f2, f3, m1, m2, m3)))
        Next

        pDispModel.setVisibility(True)

        Dim loadsPuller As LoadsPuller = New LoadsPuller(pDispModel, PDispLoadType.RECT)
        Dim pDispRectLoads As List(Of PDispRectLoad)
        pDispRectLoads = loadsPuller.pull().Cast(Of PDispRectLoad)

        'Update RectLoads based on new loads from ETABS
        pRectLoads.ForEach(Function(rectLoad)
                               Dim ppLoad As Double
                               ppLoad = ppDataSet.Where(Function(ppData) ppData.getPoint().getName() = rectLoad.Name).
                                                                 Select(Function(ppData) ppData.getReactions.getF3()(0)).
                                                                 First()
                               ppLoad = ppLoad / (rectLoad.Width * rectLoad.Length)
                               rectLoad.Normal = ppLoad
                           End Function)
        'Push updated RectLoads back in PDisp
        For i As Integer = 0 To nDisps - 1
            ret = PdispObj.SetRectLoad(i + 1, pRectLoads(i))
        Next
        'Perform Analysis
        ret = PdispObj.Analyse()

        'Get Disp Point Boussinesq/Mindlin Result
        Dim pMethodCode As Short
        Dim pMethodName As String
        Dim pDispResM As PdispMindlinResult
        Dim pDispResB As PDispBSQResult
        PdispObj.AnalysisMethod(pMethodCode)
        If pMethodCode = 0 Then
            pMethodName = "Mindlin"
            For i As Integer = 0 To nDisps - 1
                ret = PdispObj.GetMindlinResult_DispPoint(i + 1, pDispResM)
                ppDataSet.ForEach(Function(ppData)
                                      If ppData.getPoint().getName() = pDispResM.Name Then
                                          Dim springName = "Spring_" + ppData.getPoint().getName()
                                          Dim zStiffness As Double = CDbl(pDispResM.DispZ)
                                          Dim stiffnessValues() As Double = {0, 0, zStiffness, 0, 0, 0}
                                          ppData.setSpringProperty(New SpringProperty(springName, stiffnessValues))

                                      End If
                                  End Function)
            Next
        Else
            pMethodName = "Boussinesq"
            For i As Integer = 0 To nDisps - 1
                ret = PdispObj.GetBoussResult_DispPoint(i + 1, pDispResB)
                ppDataSet.ForEach(Function(ppData)
                                      If ppData.getPoint().getName() = pDispResB.Name Then
                                          Dim springName = "Spring_" + ppData.getPoint().getName()
                                          Dim dispZ As Double = CDbl(pDispResB.DispZ)
                                          Dim zStiffness As Double = CDbl(ppData.getReactions.getF3()(0) / dispZ)
                                          Dim stiffnessValues() As Double = {0, 0, zStiffness, 0, 0, 0}
                                          ppData.setSpringProperty(New SpringProperty(springName, stiffnessValues))
                                      End If
                                  End Function)
            Next
        End If

        ppDataSet.ForEach(Function(ppData)
                              ret = SapModel.PointObj.DeleteRestraint(ppData.getPoint.getName())
                              ret = SapModel.PointObj.SetSpring(ppData.getPoint.getName(), ppData.getSpringProperty.getStiffnessValues())
                          End Function)

        'Computational Cost
        'T(n) = θ(n)+θ(1)+n*θ(m*logm)+θ(1)++θ(n)=θ(n*m*logm)


    End Sub





End Class