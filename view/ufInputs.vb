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

Public Class ufInputs

    ' ATTRIBUTES ****************************************************************************************

    Private SapModel As cSapModel = Nothing
    Private ISapPlugin As cPluginCallback = Nothing
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

        tbStiffness.Enabled = False
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


    Private Function getSelectedFile(ofd As OpenFileDialog, dialogTitle As String, filter As String) As String

        Dim fileName As String = Nothing

        With ofd
            .Title = dialogTitle
            .InitialDirectory = "C:\"
            .Multiselect = False
            .Filter = filter
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

        pDispFilePath = getSelectedFile(ofdPDispFile, "Select PDisp File", "PDisp Files|*.pdd")

        If ((pDispFilePath <> "")) Then
            Me.btnOpenPDispFile.Enabled = False
        End If
    End Sub

    Private Sub btnRunIteration_Click(sender As Object, e As EventArgs) Handles btnRunIteration.Click

        '1. COLLECT INPUTS FROM THE USER 
        'Load Combo Name
        loadComboName = Me.cklbLoadCombos.SelectedItem.ToString()
        'Group Name
        groupName = Me.cklbGroups.SelectedItem.ToString()
        'Max Num of Iterations
        iterNumMax = CInt(Me.cbIterations.Items(cbIterations.SelectedIndex))
        'Convergence Factor
        convergenceFactor = CDbl(Strings.Split(CStr(Me.cbDispVariation.Items(cbDispVariation.SelectedIndex)), "%")(0)) / 100.0

        Dim progrBarStep As Integer = (Me.progrBar.Maximum - Me.progrBar.Minimum) \ iterNumMax

        'Open PDisp File
        pDispModel = New PDispModel(pDispFilePath)


        'Initialize PileObjects Queue
        pileObjsQueue = New Queue(Of List(Of PileObject))


        Dim numNames As Integer, ppNames As String()
        SapModel.PointObj.GetNameList(numNames, ppNames)
        ppNames.ToList().Where(Function(ppName)
                                   Dim groupNamesNum As Integer, groupNames As String()
                                   SapModel.PointObj.GetGroupAssign(ppName, groupNamesNum, groupNames)
                                   Return groupNames.Contains(ppName)
                               End Function).ToList()

        If rbRigid.Checked = True Then
            Dim restraintBools As Boolean() = {True, True, True, False, False, False}
            ppNames.ToList().ForEach(Function(ppName)
                                         SapModel.PointObj.SetRestraint(ppName, restraintBools)
                                     End Function)
        ElseIf rbSpring.Checked = True Then
            Dim stiffnessValues As Double() = {0.0, 0.0, CDbl(tbStiffness.Text()), 0.0, 0.0, 0.0}
            ppNames.ToList().ForEach(Function(ppName)
                                         SapModel.PointObj.SetSpring(ppName, stiffnessValues)
                                     End Function)

        ElseIf rbImportFromFile.Checked = True Then
            startPileObjsList = jsonSerializer.deserialize(jsonFilePath)
            ppNames.ToList().ForEach(Function(ppName)
                                         Dim Kvalues As Double() = startPileObjsList.Where(Function(plObj) (plObj.getName() = ppName)).
                                                                                 Single().getStiffness().getValues()
                                         SapModel.PointObj.SetSpring(ppName, Kvalues)
                                     End Function)
        End If


        iter = 0
        Do
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
        Loop While iter < iterNumMax Or IsConvergent(pileObjsQueue) = False

        Me.lblProgrBar.Text = "ITERATIONS COMPLETED!"
        Me.Refresh()

        'MEMORY RELEASE
        Me.ISapPlugin.Finish(0)
        pDispModel.close()

        'CLOSE AND DISPOSE FORM
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cklbGroups_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles cklbGroups.ItemCheck

        For i As Integer = 0 To cklbGroups.Items.Count - 1 Step 1
            If (i <> e.Index) Then
                cklbGroups.SetItemChecked(i, False)
            End If
        Next

    End Sub

    Private Sub cklbLoadCombos_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles cklbLoadCombos.ItemCheck

        For i As Integer = 0 To cklbLoadCombos.Items.Count - 1 Step 1
            If (i <> e.Index) Then
                cklbLoadCombos.SetItemChecked(i, False)
            End If
        Next
    End Sub

    Private Sub rbSpring_CheckedChanged(sender As Object, e As EventArgs) Handles rbSpring.CheckedChanged
        If rbSpring.Checked Then
            tbStiffness.Enabled = True
        Else
            tbStiffness.Enabled = False
        End If
    End Sub

    Private Sub btnOpenJSONFile_Click(sender As Object, e As EventArgs) Handles btnOpenJSONFile.Click
        jsonFilePath = getSelectedFile(ofdJsonFile, "Select Json File", "Json Files|*.json")
        If ((jsonFilePath <> "")) Then
            Me.btnOpenJSONFile.Enabled = False
        End If
    End Sub


    Public Function IsConvergent(pileObjsQueue As Queue(Of List(Of PileObject))) As Boolean

        '1. INITIALIZE AUXILIARY LIST
        Dim plΔKList As List(Of Double) = New List(Of Double)

        '2. SORT THE FIRST/LAST LISTS OF THE QUEUE BASED ON THE ADDIGNED COMPARATOR
        pileObjsQueue.First().Sort()
        pileObjsQueue.Last().Sort()

        '3. CALCULATE THE RATE INCREASE/DECREASE OF STIFFNESS FOR EACH PILE
        plΔKList = pileObjsQueue.Last().Select(Function(plObj)
                                                   'Search 
                                                   Dim i As Integer = pileObjsQueue.First().BinarySearch(plObj)
                                                   Dim Kprev As Double = pileObjsQueue.First()(i).getStiffness().getU3()
                                                   Dim Knext As Double = plObj.getStiffness().getU3()
                                                   Dim ΔK As Double = Math.Abs(Knext - Kprev) / Kprev
                                                   Return ΔK
                                               End Function).ToList()

        '4. DEQUEUE FIRST/PREVIOUS LIST OF THE QUEUE
        pileObjsQueue.Dequeue()

        '5. RETURN BOOL
        ' True if the max increase/decrease is smaller than the convergenceFactor...
        If (plΔKList.Max() < convergenceFactor) Then Return True
        ' False if not...
        Return False

    End Function


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

        'Get Points belonging to selected group
        Dim groupObjsNum As Integer, groupObjsTypes As Integer(), groupObjsNames As String()
        Dim pointNames As List(Of String) = New List(Of String)
        ret = SapModel.GroupDef.GetAssignments(groupName, groupObjsNum, groupObjsTypes, groupObjsNames)
        For i As Integer = 0 To groupObjsTypes.Length - 1 Step 1
            If groupObjsTypes(i) = 1 Then
                pointNames.Add(groupObjsNames(i))
            End If
        Next


        'Get reactions from points and assign them to PileObjs
        Dim itemTypeElm As ETABSv1.eItemTypeElm
        Dim numRes As Integer
        Dim obj, elm, loadCase, stepType As String()
        Dim stepNum As Double()
        Dim f1, f2, f3, m1, m2, m3 As Double()
        Dim f_1, f_2, f_3, m_1, m_2, m_3 As Double
        Dim ppX, ppY, ppZ As Double
        Dim ppMatch As Boolean

        Dim pileObjs As List(Of PileObject) = New List(Of PileObject)

        For i = 0 To pointNames.Count - 1 Step 1
            ret = SapModel.Results.JointReact(pointNames(i), itemTypeElm, numRes, obj, elm, loadCase,
                                             stepType, stepNum, f1, f2, f3, m1, m2, m3)
            ret = SapModel.PointObj.GetCoordCartesian(pointNames(i), ppX, ppY, ppZ)

            f_1 = f1.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()
            f_2 = f2.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()
            f_3 = f3.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()

            pileObjs.Add(New PileObject(pointNames(i), New PointObject(pointNames(i), ppX, ppY, ppZ),
                         New PointLoads(New Double() {f_1, f_2, f_3})))
        Next


        pDispModel.setVisibility(True)


        'UPDATE PDISP LOADS

        Dim rectLoadsPuller As LoadsPuller(Of PDispRectLoad) = New LoadsPuller(Of PDispRectLoad)(pDispModel)
        Dim loadsPusher As LoadsPusher(Of PDispRectLoad) = New LoadsPusher(Of PDispRectLoad)(pDispModel)
        Dim pDispRectLoads As List(Of PDispRectLoad) = rectLoadsPuller.pull()

        'Update RectLoads based on new loads from ETABS
        pDispRectLoads.ForEach(Function(pDispRectLoad)
                                   Dim ppLoad As Double
                                   ppLoad = pileObjs.Where(Function(plObj) plObj.getLocation().getName() = pDispRectLoad.getLoad().Name).
                                                                 Select(Function(plObj) plObj.getLoads().getF3()).
                                                                 FirstOrDefault()
                                   If ppLoad <> 0 Then
                                       ppLoad = ppLoad / (pDispRectLoad.getLoad().Width * pDispRectLoad.getLoad().Length)
                                       Dim rectLoad As RectLoad
                                       rectLoad = pDispRectLoad.getLoad()
                                       rectLoad.Normal = ppLoad
                                       pDispRectLoad.setLoad(rectLoad)
                                   End If
                               End Function)

        'Push updated RectLoads back in PDisp
        loadsPusher.push(pDispRectLoads, True)


        'RUN PDISP ANALYSIS

        'Perform Analysis
        pDispModel.analyse()


        'GET PDISP DISPLACEMENTS and COMPUTE SPRING STIFFNESSES

        'Get Disp Point Boussinesq/Mindlin Result
        Dim pMethod As PDispAnalysisMethod
        pDispModel.getPDispApp().AnalysisMethod(pMethod)

        Select Case pMethod
            Case PDispAnalysisMethod.MINDLIN
                Dim MLDispPoints As List(Of PDispMLDispResult) = New ResultsPuller(Of PDispMLDispResult)(pDispModel).pull()
                Dim mldpNames As List(Of String) = MLDispPoints.Select(Function(mldp) (mldp.getResult().Name)).ToList()
                pileObjs.ForEach(Function(plObj)
                                     If (mldpNames.Contains(plObj.getLocation().getName())) Then
                                         Dim springName = "Spring_" + plObj.getLocation().getName()
                                         Dim nameIndex As Integer = mldpNames.IndexOf(plObj.getLocation().getName())
                                         plObj.setDisplacements(New PointDisplacements(New Double() {
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispX) * 1000, 1),
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispY) * 1000, 1),
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispZ) * 1000, 1)}))
                                         Dim zStiffness As Double = Math.Round(CDbl(plObj.getLoads().getF3()) / CDbl(plObj.getDisplacements().getU3()), 1)
                                         Dim stiffnessValues() As Double = {0, 0, zStiffness}
                                         plObj.setStiffness(New SpringObject(springName, stiffnessValues))
                                     End If
                                 End Function)
            Case PDispAnalysisMethod.BOUSSINESQ
                Dim BSQDispPoints As List(Of PDispBSQDispResult) = New ResultsPuller(Of PDispBSQDispResult)(pDispModel).pull()
                Dim bsqdpNames As List(Of String) = BSQDispPoints.Select(Function(bsqdp) (bsqdp.getResult().Name)).ToList()
                pileObjs.ForEach(Function(plObj)
                                     If (bsqdpNames.Contains(plObj.getLocation().getName())) Then
                                         Dim springName = "Spring_" + plObj.getLocation().getName()
                                         Dim nameIndex As Integer = bsqdpNames.IndexOf(plObj.getLocation().getName())
                                         plObj.setDisplacements(New PointDisplacements(New Double() {0, 0,
                                            Math.Round(CDbl(BSQDispPoints(nameIndex).getResult().DispZ) * 1000, 1)}))
                                         Dim zStiffness As Double = Math.Round(CDbl(plObj.getLoads().getF3()) / CDbl(plObj.getDisplacements().getU3()), 1)
                                         Dim stiffnessValues() As Double = {0, 0, zStiffness}
                                         plObj.setStiffness(New SpringObject(springName, stiffnessValues))
                                     End If
                                 End Function)
        End Select


        ' ENQUEUE PILE OBJS DATA IN A QUEUE
        pileObjsQueue.Enqueue(pileObjs)



        ' SERIALIZE OUTPUTS IN A JSON FILE
        '1. Sort the PileObjects based on a user-defined Comparator
        pileObjs.Sort(Function(pileObj1, pileObj2) (pileObj1.getName().CompareTo(pileObj2.getName())))
        '2. Build the Json File Name depending on number of Iteration
        Dim jsonFilePath As String = pDispFilePath + "PilesObjsDataSet_Iter0" + CStr(iter) + ".json"
        '3. Serialize the list of Pile Objects
        jsonSerializer.serialize(pileObjs, jsonFilePath)


        ' ASSIGN COMPUTED STIFFNESSES TO ETABS BASE POINTS
        ret = SapModel.SetModelIsLocked(False)

        pileObjs.ForEach(Function(pileObj)
                             ret = SapModel.PointObj.DeleteRestraint(pileObj.getLocation.getName())
                             ret = SapModel.PointObj.SetSpring(pileObj.getLocation.getName(), pileObj.getStiffness().getValues())
                         End Function)

        'Computational Cost
        'T(n) = θ(n)+θ(1)+n*θ(m*logm)+θ(1)++θ(n)=θ(n*m*logm)


    End Sub




End Class