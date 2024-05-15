﻿
Imports ETABSv1
Imports Newtonsoft.Json


Imports pdispauto_20_1

''' <summary>
''' 
''' PSC_Model Concrete Class
''' 
''' <remarks>
''' <para> Concrete class and main class of the Model Package. </para>
''' <para> The class contains all the main data and methods for the running of the application.
''' The model is updated based on the actions of the user in the View via the MVC Design Pattern while the View
''' is updated based on the changes of the Model via the OBSERVER Design Pattern. </para>
''' 
''' <para> Desing Patterns: 
''' - OBSERVER
''' - MODEL-VIEW-CONTROLLER
''' - SINGLETON </para>
''' 
''' <para> Programming Techniques: 
''' - STREAMS </para>
''' 
''' </remarks>
''' 
''' </summary>

Public Class PSC_Model
    Implements Observable

    'ATTRIBUTES
    Private Shared instance As PSC_Model
    Private observers As List(Of Observer)
    Private jsonSerializer As JSONSerializer(Of List(Of PileObject))
    Private sapModel As ETABSv1.cSapModel
    Private pDispModel As PDispModel
    Private sapModelInitialPath As String
    Private pDispModelInitialPath As String
    Private etabsGroupNames As List(Of String)      'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private etabsLoadCaseNames As List(Of String)   'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private etabsLoadComboNames As List(Of String)  'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private etabsPointNames As List(Of String)      'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private selEtabsGroupName As String
    Private selEtabsLoadComboName As String
    Private iterNumMax As Integer
    Private convergenceFactor As Double
    Private pileObjs As List(Of PileObject)
    Private pileObjsInit As List(Of PileObject)
    Private pileObjsQueue As Queue(Of List(Of PileObject))
    Private ret As Integer
    Private iterNum As Integer = 0
    Private stepRun As Boolean = False
    Private iterationComplete As Boolean = False
    Private Const fixity As Double = 100000000

    ' CONSTRUCTOR - Private'
    Private Sub New()
        Me.observers = New List(Of Observer)
        Me.jsonSerializer = New JSONSerializer(Of List(Of PileObject))
        Me.pileObjsQueue = New Queue(Of List(Of PileObject))
    End Sub

    ' STATIC METHOD .getInstance() '
    Public Shared Function getInstance() As PSC_Model
        If (instance Is Nothing) Then
            instance = New PSC_Model()
        End If
        Return instance
    End Function

    ' METHDOS
    Public Sub registerObserver(o As Observer) Implements Observable.registerObserver
        Me.observers.Add(o)
    End Sub

    Public Sub removeObserver(o As Observer) Implements Observable.removeObserver
        Me.observers.Remove(o)
    End Sub
    Public Sub notifyObservers() Implements Observable.notifyObservers
        'Update all observers via Streams
        Me.observers.ForEach(Sub(o) o.update())
    End Sub


    Public Sub initialize(sapModel As ETABSv1.cSapModel, pDispFilePath As String, selEtabsLoadComboName As String,
                          selEtabsGroupName As String, iterNumMax As Integer, convergenceFactor As Double)

        Me.checkInputsData(sapModel, pDispFilePath, selEtabsLoadComboName, selEtabsGroupName, iterNumMax, convergenceFactor)

        Me.sapModel = sapModel
        Me.pDispModel = New PDispModel(pDispFilePath)
        Me.selEtabsLoadComboName = selEtabsLoadComboName
        Me.selEtabsGroupName = selEtabsGroupName
        Me.iterNumMax = iterNumMax
        Me.convergenceFactor = convergenceFactor
        Me.sapModelInitialPath = Me.sapModel.GetModelFilename(True)
        Me.pDispModelInitialPath = Me.pDispModel.getFilePath()


    End Sub

    Private Sub checkInputsData(sapModel As ETABSv1.cSapModel, pDispFilePath As String, selEtabsLoadComboName As String,
                                selEtabsGroupName As String, iterNumMax As Integer, convergenceFactor As Double)

        Dim exceptionMessage As String = ""

        If (sapModel Is Nothing) Then exceptionMessage += "ETABS Model is missing/not valid." + vbNewLine
        If pDispFilePath Is Nothing Then
            exceptionMessage += "PDisp Model is missing." + vbNewLine
        ElseIf Not pDispFilePath.Contains(".pdd") Then
            exceptionMessage += "PDisp Model is not valid." + vbNewLine
        End If
        If (selEtabsGroupName = "") Then exceptionMessage += "ETABS Group Name missing." + vbNewLine
        If (selEtabsLoadComboName = "") Then exceptionMessage += "ETABS Load Combo Name missing." + vbNewLine
        If (iterNumMax < 2) Then exceptionMessage += "Maximum Number of Iterations is too low." + vbNewLine
        If (convergenceFactor < 0) Then exceptionMessage += "Convergence Factor is not valid."

        If exceptionMessage <> "" Then Throw New MissingInputsException(exceptionMessage)
    End Sub

    Public Sub setSapModel(sapModel As ETABSv1.cSapModel)
        If (sapModel Is Nothing) Then Throw New MissingInputsException("ETABS Model is missing/not valid")
        Me.sapModel = sapModel
    End Sub
    Public Sub setPDispModel(pdispModel As PDispModel)
        If (pdispModel Is Nothing) Then Throw New MissingInputsException("PDisp Model is missing/not valid")
        Me.pDispModel = pdispModel
    End Sub

    Public Sub extractEtabsModelData()
        '1. Extract Etabs Model's GROUP NAMES
        Dim groupNumNames As Integer, groupNames As String()
        Me.sapModel.GroupDef.GetNameList(groupNumNames, groupNames)
        Me.etabsGroupNames = groupNames.ToList()
        '2. Extract Etabs Model's LOAD CASES
        Dim loadCasesNum As Integer, loadCasesNames As String()
        Me.sapModel.LoadCases.GetNameList(loadCasesNum, loadCasesNames)
        Me.etabsLoadCaseNames = loadCasesNames.ToList()
        '3. Extract Etabs Model's LOAD COMBO NAMES
        Dim lCombosNum As Integer, lComboNames As String()
        Me.sapModel.RespCombo.GetNameList(lCombosNum, lComboNames)
        Me.etabsLoadComboNames = lComboNames.ToList()
        '4. Extract Etabs Model's POINT NAMES
        Dim pointNumNames As Integer, pointNames As String()
        Me.sapModel.PointObj.GetNameList(pointNumNames, pointNames)
        Me.etabsPointNames = pointNames.ToList()
        '5. Notify Observers
        Me.notifyObservers()
    End Sub


    Public Sub filterPointsByGroup()
        Me.etabsPointNames = Me.etabsPointNames.Where(Function(ppName)
                                                          Dim groupNamesNum As Integer, groupNames As String()
                                                          sapModel.PointObj.GetGroupAssign(ppName, groupNamesNum, groupNames)
                                                          Return groupNames.Contains(Me.selEtabsGroupName)
                                                      End Function).ToList()
    End Sub

    Public Sub setPointRestraints(restraintBools As Boolean())

        If restraintBools Is Nothing Then Throw New MissingInputsException("Piles Restraint Boolean Arrays missing")

        'Unlock Etabs Model
        Me.sapModel.SetModelIsLocked(False)
        'Set Point Restraints via Streams...
        Me.etabsPointNames.ForEach(Function(ppName)
                                       Me.sapModel.PointObj.SetRestraint(ppName, restraintBools)
                                   End Function)
    End Sub

    Public Sub setPointStiffnessesFromValues(stiffnessValues As Double())

        If stiffnessValues Is Nothing Then Throw New MissingInputsException("Piles Stiffness Value missing")

        'Unlock Etabs Model
        Me.sapModel.SetModelIsLocked(False)
        'Set Point Springs via Streams...
        Me.etabsPointNames.ForEach(Function(ppName)
                                       Me.sapModel.PointObj.SetSpring(ppName, stiffnessValues)
                                   End Function)
    End Sub

    Public Sub setPointStiffnessesFromJson(jsonFilePath As String)

        If jsonFilePath = "" Then Throw New MissingInputsException("FilePath to Piles Stiffness JsonFile missing")

        'Unlock Etabs Model
        Me.sapModel.SetModelIsLocked(False)
        'Deserialize Json File
        Dim startPileObjsList As New List(Of PileObject)
        startPileObjsList = Me.deserialize(jsonFilePath)
        'Set Point Springs via Streams...
        Me.etabsPointNames.ToList().ForEach(Function(ppName)
                                                Dim Kvalues As Double() = startPileObjsList.Where(Function(plObj) (plObj.getName() = ppName)).
                                                                             Single().getStiffness().getValues()
                                                Me.sapModel.PointObj.SetSpring(ppName, Kvalues)
                                            End Function)
    End Sub


    Public Sub runIteration()

        Me.pDispModel.setVisibility(False)

        Do
            'Save ETABS Model
            sapModel.File.Save(FileManager.setNewFilePath(Me.sapModelInitialPath, Me.iterNum))
            'Run Iteration Step
            stepRun = False
            runIterationStep(Me.iterNum)
            stepRun = True
            'Save PDisp Model
            pDispModel.save(FileManager.setNewFilePath(Me.pDispModelInitialPath, Me.iterNum))
            'Serialize DataSet
            Me.serialize(Me.pileObjs)
            'Notify Observers
            Me.notifyObservers()
            'Increment iter count
            Me.iterNum += 1
        Loop While Me.iterNum < iterNumMax Or isConvergent(pileObjsQueue) = False

        Me.iterationComplete = True
        Me.notifyObservers()

        Me.pDispModel.close()

    End Sub


    Public Sub runIterationStep(iter As Integer) 'T(n)

        'UNLOCK THE ETABS MODEL
        sapModel.SetModelIsLocked(False)

        'ACTIVATE ALL LOAD CASES FOR RUNNING THE ANALYSIS
        ret = sapModel.Analyze.SetRunCaseFlag(Me.etabsLoadCaseNames(0), True, All:=True)

        'RUN THE ANALYSIS
        ret = sapModel.Analyze.RunAnalysis()   'θ(n)

        'ACTIVATE ONLY LOAD COMBO SELECTED BY THE USER
        sapModel.Results.Setup.DeselectAllCasesAndCombosForOutput()
        sapModel.Results.Setup.SetComboSelectedForOutput(Me.selEtabsLoadComboName)

        '1. Initialize/Reset List of PileObject Records for current iteration step
        Me.pileObjs = New List(Of PileObject)
        '2. Read Point Reactions from ETABS and assign them to PileObjects
        readPileObjsForces(Me.pileObjs)
        '3. Update PDisp Loads based on ETABS reactions
        updatePDispLoads(Me.pileObjs)
        '4. Perform Analysis
        pDispModel.analyse()
        '5. Read Point Displacements from PDisp and assign them to PileObjects
        readPileObjsDisplacements(Me.pileObjs)
        '6 Update the Piles Status based on the 
        updatePileObjsStatus(Me.pileObjs, Me.pileObjsInit)
        '7. Compute Point Stiffnesses and assign them to PileObjects
        computePileObjsStiffness(Me.pileObjs)
        '8. Add current list of PileObjects to Queue data structure
        pileObjsQueue.Enqueue(Me.pileObjs)
        '9. Update Etabs Point Springs
        updatePointSprings(Me.pileObjs)


    End Sub


    Public Function isConvergent(pileObjsQueue As Queue(Of List(Of PileObject))) As Boolean

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



    Private Sub readPileObjsForces(pileObjs As List(Of PileObject))

        'EXTRACT BASE POINT REACTIONS

        'Get reactions from points and assign them to PileObjs
        Dim itemTypeElm As ETABSv1.eItemTypeElm
        Dim numRes As Integer
        Dim obj, elm, loadCase, stepType As String()
        Dim stepNum As Double()
        Dim f1, f2, f3, m1, m2, m3 As Double()
        Dim f_1, f_2, f_3, m_1, m_2, m_3 As Double
        Dim ppX, ppY, ppZ As Double

        For i = 0 To etabsPointNames.Count - 1 Step 1
            ret = sapModel.Results.JointReact(etabsPointNames(i), itemTypeElm, numRes, obj, elm, loadCase,
                                             stepType, stepNum, f1, f2, f3, m1, m2, m3)
            ret = sapModel.PointObj.GetCoordCartesian(etabsPointNames(i), ppX, ppY, ppZ)

            f_1 = f1.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()
            f_2 = f2.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()
            f_3 = f3.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()

            pileObjs.Add(New PileObject(etabsPointNames(i), New PointObject(etabsPointNames(i), ppX, ppY, ppZ),
                         New PointLoads(New Double() {f_1, f_2, f_3})))
        Next

    End Sub



    Private Sub readPileObjsDisplacements(pileObjs As List(Of PileObject))

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
                                         Dim nameIndex As Integer = mldpNames.IndexOf(plObj.getLocation().getName())
                                         plObj.setDisplacements(New PointDisplacements(New Double() {
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispX) * 1000, 1),
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispY) * 1000, 1),
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispZ) * 1000, 1)}))
                                     End If
                                 End Function)
            Case PDispAnalysisMethod.BOUSSINESQ
                Dim BSQDispPoints As List(Of PDispBSQDispResult) = New ResultsPuller(Of PDispBSQDispResult)(pDispModel).pull()
                Dim bsqdpNames As List(Of String) = BSQDispPoints.Select(Function(bsqdp) (bsqdp.getResult().Name)).ToList()
                pileObjs.ForEach(Function(plObj)
                                     If (bsqdpNames.Contains(plObj.getLocation().getName())) Then
                                         Dim nameIndex As Integer = bsqdpNames.IndexOf(plObj.getLocation().getName())
                                         plObj.setDisplacements(New PointDisplacements(New Double() {0, 0,
                                            Math.Round(CDbl(BSQDispPoints(nameIndex).getResult().DispZ) * 1000, 1)}))
                                     End If
                                 End Function)
        End Select

        'Remove all pileObjs with Null Displacements as they are not present in the PDispModel
        Me.pileObjs = Me.pileObjs.Where(Function(po) po.getDisplacements() IsNot Nothing).ToList()

    End Sub


    Private Sub updatePileObjsStatus(pileObjs As List(Of PileObject), Optional initPileObjs As List(Of PileObject) = Nothing)

        If initPileObjs IsNot Nothing Then

            pileObjs.Sort()
            initPileObjs.Sort()

            pileObjs.ForEach(Sub(po)
                                 If initPileObjs.BinarySearch(po) <> -1 And
                                    po.getDisplacements.getU3() < initPileObjs(initPileObjs.BinarySearch(po)).getDisplacements.getU3() Then
                                     po.setStatus(PileStatus.UNLOADED)
                                 Else
                                     po.setStatus(PileStatus.LOADED)
                                 End If
                             End Sub)
        Else
            pileObjs.ForEach(Sub(po) po.setStatus(PileStatus.LOADED))
        End If
    End Sub

    Private Sub computePileObjsStiffness(pileObjs As List(Of PileObject))

        'COMPUTE SPRING STIFFNESSES

        pileObjs.ForEach(Function(plObj)
                             Dim springName = "Spring_" + plObj.getLocation().getName()
                             Dim zStiffness As Double
                             If plObj.getStatus = PileStatus.LOADED Then
                                 zStiffness = Math.Round(CDbl(plObj.getLoads().getF3()) /
                                                         CDbl(plObj.getDisplacements().getU3()), 1)
                             Else
                                 zStiffness = fixity
                             End If
                             Dim stiffnessValues() As Double = {0, 0, zStiffness}
                             plObj.setStiffness(New SpringObject(springName, stiffnessValues))
                         End Function)
    End Sub


    Private Sub updatePDispLoads(pileObjs As List(Of PileObject))

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

    End Sub


    Private Sub updatePointSprings(pileObjs As List(Of PileObject))

        ' ASSIGN COMPUTED STIFFNESSES TO ETABS BASE POINTS
        Me.sapModel.SetModelIsLocked(False)

        pileObjs.ForEach(Function(pileObj)
                             ret = Me.sapModel.PointObj.DeleteRestraint(pileObj.getLocation.getName())
                             ret = Me.sapModel.PointObj.SetSpring(pileObj.getLocation.getName(),
                                                                  pileObj.getStiffness().getValues())
                         End Function)

        Me.sapModel.View.RefreshView()

    End Sub


    Public Sub serialize(pileObjs As List(Of PileObject))
        ' SERIALIZE OUTPUTS IN A JSON FILE
        '1. Sort the PileObjects based on a user-defined Comparator
        pileObjs.Sort(Function(pileObj1, pileObj2) (pileObj1.getName().CompareTo(pileObj2.getName())))
        '2. Build the Json File Name depending on number of Iteration
        Dim jsonFilePath As String = Me.pDispModelInitialPath + "PilesObjsDataSet_Iter0" + CStr(Me.iterNum) + ".json"
        '3. Serialize the list of Pile Objects
        Me.jsonSerializer.serialize(pileObjs, jsonFilePath)

    End Sub

    Public Function deserialize(jsonFilePath As String) As List(Of PileObject)
        Return Me.jsonSerializer.deserialize(jsonFilePath)
    End Function


    Public Sub setPileObjs(pileObjs As List(Of PileObject))
        Me.pileObjs = pileObjs
    End Sub
    Public Sub setPileObjsInit(pileObjsInit As List(Of PileObject))
        Me.pileObjsInit = pileObjsInit
    End Sub
    Public Sub setEtabsGroupNames(etabsGroupNames As List(Of String))
        Me.etabsGroupNames = etabsGroupNames
    End Sub
    Public Sub setEtabsLoadComboNames(etabsLoadComboNames As List(Of String))
        Me.etabsLoadComboNames = etabsLoadComboNames
    End Sub
    Public Sub setSelEtabsGroupName(selEtabsGroupName As String)
        Me.selEtabsGroupName = selEtabsGroupName
    End Sub
    Public Sub setSelEtabsLoadComboName(selEtabsLoadComboName As String)
        Me.selEtabsLoadComboName = selEtabsLoadComboName
    End Sub
    Public Sub setEtabsPointNames(etabsPointNames As List(Of String))
        Me.etabsPointNames = etabsPointNames
    End Sub
    Public Sub setIterNumMax(iterNumMax As Integer)
        Me.iterNumMax = iterNumMax
    End Sub
    Public Sub setConvergenceFactor(convergenceFactor As Double)
        Me.convergenceFactor = convergenceFactor
    End Sub
    Public Sub setStepRun(stepRun As Boolean)
        Me.stepRun = stepRun
    End Sub


    Public Function getPileObjs() As List(Of PileObject)
        Return Me.pileObjs
    End Function
    Public Function getPileObjsInit() As List(Of PileObject)
        Return Me.pileObjsInit
    End Function
    Public Function getEtabsGroupNames() As List(Of String)
        Return Me.etabsGroupNames
    End Function
    Public Function getEtabsLoadComboNames() As List(Of String)
        Return Me.etabsLoadComboNames
    End Function
    Public Function getEtabsGroupName() As String
        Return Me.selEtabsGroupName
    End Function
    Public Function getEtabsLoadComboName() As String
        Return Me.selEtabsLoadComboName
    End Function
    Public Function getEtabsPointNames() As List(Of String)
        Return Me.etabsPointNames
    End Function
    Public Function getIterNumMax() As Integer
        Return Me.iterNumMax
    End Function
    Public Function getConvergenceFactor() As Double
        Return Me.convergenceFactor
    End Function
    Public Function getStepRun() As Boolean
        Return Me.stepRun
    End Function
    Public Function getIterationComplete() As Boolean
        Return Me.iterationComplete
    End Function
    Public Function getPileObjsList() As List(Of PileObject)
        Return Me.pileObjs
    End Function

End Class
