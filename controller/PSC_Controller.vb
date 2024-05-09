Imports System.Reflection
Imports ETABSv1
Imports Newtonsoft.Json

Public Class PSC_Controller
	Implements ControllerInterface

	'ATTRIBUTES
	''References to Model and View
	Protected model As PSC_Model
	Protected view As PSC_View
	'References to CSI Plugin Objects
	Protected SapModel As cSapModel
	Protected ISapPlugin As cPluginCallback
	'//ActionListeners
	'Private CaricaProfiloListener caricaProfiloListener;
	'Private GiocaPartitaListener giocaPartitaListener;
	'Private CardsMouseListener cardsMouseListener;
	'Private PassaTurnoListener passaTurnoListener;
	'Private PescaCartaListener pescaCartaListener;
	'Private TimerListenerInterface turnoTimerListener;
	'Private UnoListener unoListener;
	'Private ColorButtonListener colorButtonListener;
	'ExceptionHandlers
	Private missingInputsHandler As MissingInputsHandler
	'EventListeners
	Private eventsListener As EventsListener
	'AudioManagers
	Private soundManager As SoundManager
	'FilePaths
	Private jsonFilePath As String
	Private pDispFilePath As String

	Public Sub New(SapModel As cSapModel, ISapPlugin As cPluginCallback)

		'Save CSI Plugin Objects
		Me.SapModel = SapModel
		Me.ISapPlugin = ISapPlugin
		Dim resourceNames As String()
		resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames()

		'Instantiate the Model
		Me.model = PSC_Model.getInstance()
		Me.model.setSapModel(Me.SapModel)
		'Instantiate the View
		Me.view = New PSC_View(Me.model, Me)
		'Istantiate AudioManagers
		Me.soundManager = SoundManager.getInstance()
		'Instantiate EventsListener
		Me.eventsListener = New EventsListener(Me, Me.view)
		'Instantiate ExceptionHandlers
		Me.createExceptionHandlers()
	End Sub


	Public Sub initialize() Implements ControllerInterface.initialize
		Me.view.createSplashScreen()
		Me.view.createAboutBox()
		Me.eventsListener.initializeAboutBox()
	End Sub

	Public Sub createExceptionHandlers()
		Me.missingInputsHandler = New MissingInputsHandler(Me)
	End Sub


	Public Sub processInputData()

		Dim pdispModel As New PDispModel(pDispFilePath)
			Me.model.initialize(Me.SapModel, pdispModel,
								Me.view.getViewInputs().cklbLoadCombos.SelectedItem.ToString(),
								Me.view.getViewInputs().cklbGroups.SelectedItem.ToString(),
								CInt(Me.view.getViewInputs().cbIterations.Items(Me.view.getViewInputs().cbIterations.SelectedIndex)),
								CDbl(Strings.Split(CStr(Me.view.getViewInputs().cbDispVariation.
								Items(Me.view.getViewInputs().cbDispVariation.SelectedIndex)), "%")(0)) / 100.0)

			Me.model.filterPointsByGroup()

			If Me.view.getViewInputs().rbRigid.Checked = True Then
				Dim restraintBools As Boolean() = {True, True, True, False, False, False}
				Me.model.setPointRestraints(restraintBools)
			ElseIf Me.view.getViewInputs().rbSpring.Checked = True Then
				Dim stiffnessValues As Double() = {0.0, 0.0, CDbl(Me.view.getViewInputs().tbStiffness.Text()), 0.0, 0.0, 0.0}
				Me.model.setPointStiffnessesFromValues(stiffnessValues)
			ElseIf Me.view.getViewInputs().rbImportFromFile.Checked = True Then
				Me.model.setPointStiffnessesFromJson(Me.getJsonFilePath())
			End If

	End Sub
	Public Sub runIteration() Implements ControllerInterface.runIteration
		Me.model.runIteration()
		Me.soundManager.play(Sound.ENDITERATION)
	End Sub

	Public Sub terminate() Implements ControllerInterface.terminate
		'CLOSE AND DISPOSE FORM
		Me.view.getViewInputs.Close()
		Me.view.getViewInputs.Dispose()
		'MEMORY RELEASE
		Me.ISapPlugin.Finish(0)
	End Sub

	Public Sub serialize() Implements ControllerInterface.serialize
		Me.model.serialize(Me.model.getPileObjsList())
	End Sub
	Public Sub deserialize() Implements ControllerInterface.deserialize
		Throw New NotImplementedException()
	End Sub
	Public Sub extractEtabsModelData()
		Me.model.ExtractEtabsModelData()
	End Sub


	Public Sub setSapModel(SapModel As cSapModel)
		Me.SapModel = SapModel
	End Sub
	Public Sub setISapPlugIn(ISapPlugin As cPluginCallback)
		Me.ISapPlugin = ISapPlugin
	End Sub
	Public Sub setSoundManager(soundManager As SoundManager)
		Me.soundManager = soundManager
	End Sub
	Public Sub setEventsListener(eventsListener As EventsListener)
		Me.eventsListener = eventsListener
	End Sub
	Public Sub setMissingInputsHandler(missingInputsHandler As MissingInputsHandler)
		Me.missingInputsHandler = missingInputsHandler
	End Sub
	Public Sub setJsonFilePath(jsonFilePath As String)
		Me.jsonFilePath = jsonFilePath
	End Sub
	Public Sub setpDispFilePath(pDispFilePath As String)
		Me.pDispFilePath = pDispFilePath
	End Sub


	Public Function getSapModel() As cSapModel
		Return Me.SapModel
	End Function
	Public Function getISapPlugIn() As cPluginCallback
		Return Me.ISapPlugin
	End Function
	Public Function getSoundManager() As SoundManager
		Return Me.soundManager
	End Function
	Public Function getEventsListener() As EventsListener
		Return Me.eventsListener
	End Function
	Public Function getMissingInputsHandler() As MissingInputsHandler
		Return Me.missingInputsHandler
	End Function
	Public Function getJsonFilePath() As String
		Return Me.jsonFilePath
	End Function
	Public Function getpDispFilePath() As String
		Return Me.pDispFilePath
	End Function

End Class
