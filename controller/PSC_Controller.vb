Public Class Controller
    Implements ControllerInterface

	'ATTRIBUTES
	''References to Model and View
	Protected model As model
	Protected view As View
	'Serializer'
	Protected jsonSerializer As JSONSerializer(Of PileObject)
	//ActionListeners
	Private CaricaProfiloListener caricaProfiloListener;
	Private GiocaPartitaListener giocaPartitaListener;
	Private CardsMouseListener cardsMouseListener;
	Private PassaTurnoListener passaTurnoListener;
	Private PescaCartaListener pescaCartaListener;
	Private TimerListenerInterface turnoTimerListener;
	Private UnoListener unoListener;
	Private ColorButtonListener colorButtonListener;
	//ExceptionHandlers
	Private MazzoEsauritoHandler mazzoEsauritoHandler;
	'AudioManagers
	Private soundManager As SoundManager



	Public Sub New()
		'Instantiate the Model
		Me.model = New model()
		'Instantiate the View
		Me.view = New View()

		// 3. Istanziazione AudioManagers
		this.soundsManager = SoundsManager.getInstance();
		this.musicManager = MusicManager.getInstance();
		// 4. Creazione ActionListeners
		this.creaListeners();
		// 5. Creazione ExceptionHandlers
		this.creaExceptionHandlers();}
	End Sub


	Public Sub initialize() Implements ControllerInterface.initialize
		Dim splashScreen As SplashScreen, aboutBox As AboutBox
		splashScreen = New SplashScreen()
		aboutBox = New AboutBox()
		splashScreen.Show()
		splashScreen.Refresh()
		System.Threading.Thread.Sleep(4000)
		splashScreen.Close()
		aboutBox.Show()
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
End Class
