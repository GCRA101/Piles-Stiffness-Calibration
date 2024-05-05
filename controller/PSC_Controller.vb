Imports System.Reflection
Imports ETABSv1

Public Class PSC_Controller
	Implements ControllerInterface

	'ATTRIBUTES
	''References to Model and View
	Protected model As PSC_Model
	Protected view As PSC_View
	'References to CSI Plugin Objects
	Protected SapModel As cSapModel
	Protected ISapPlugin As cPluginCallback
	'Serializer'
	Protected jsonSerializer As JSONSerializer(Of PileObject)
	'//ActionListeners
	'Private CaricaProfiloListener caricaProfiloListener;
	'Private GiocaPartitaListener giocaPartitaListener;
	'Private CardsMouseListener cardsMouseListener;
	'Private PassaTurnoListener passaTurnoListener;
	'Private PescaCartaListener pescaCartaListener;
	'Private TimerListenerInterface turnoTimerListener;
	'Private UnoListener unoListener;
	'Private ColorButtonListener colorButtonListener;
	'//ExceptionHandlers
	'Private MazzoEsauritoHandler mazzoEsauritoHandler;
	'AudioManagers
	Private soundManager As SoundManager


	Public Sub New(SapModel As cSapModel, ISapPlugin As cPluginCallback)

		'Save CSI Plugin Objects
		Me.SapModel = SapModel
		Me.ISapPlugin = ISapPlugin
		Dim resourceNames As String()
		resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames()

		'Instantiate the Model
		Me.model = New PSC_Model()
		'Instantiate the View
		Me.view = New PSC_View(Me.model, Me)
		'Istantiate AudioManagers
		Me.soundManager = SoundManager.getInstance()

		'// 4. Creazione ActionListeners
		'this.creaListeners();
		'// 5. Creazione ExceptionHandlers
		'this.creaExceptionHandlers();}
	End Sub


	Public Sub initialize() Implements ControllerInterface.initialize
		Me.view.createSplashScreen()
		Me.view.createAboutBox()
	End Sub

	Public Sub runIteration() Implements ControllerInterface.runIteration
		Throw New NotImplementedException()
	End Sub

	Public Sub serialize() Implements ControllerInterface.serialize
		Throw New NotImplementedException()
	End Sub

	Public Sub deserialize() Implements ControllerInterface.deserialize
		Throw New NotImplementedException()
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

End Class
