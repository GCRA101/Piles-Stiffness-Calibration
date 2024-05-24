
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Piles_Stiffness_Iteration.model
Public Class PSC_View

	'ATTRIBUTES

	'References to Model and Controller
	Protected model As PSC_Model
	Protected controller As PSC_Controller
	'Main windows of the View
	Protected splashScreen As SplashScreen
	Protected aboutBox As AboutBox
	Protected viewInputs As ViewInputs

	'CONSTRUCTORS
	Public Sub New(model As PSC_Model, controller As PSC_Controller)
		Me.model = model
		Me.controller = controller
	End Sub

	'METHODS

	'CREATION of the VIEWS
	Public Sub createSplashScreen()
		Me.splashScreen = New SplashScreen(Me.model)
		Me.controller.getSoundManager().play(Sound.SPLASHSCREEN)
		Me.model.registerObserver(Me.splashScreen)
		System.Threading.Thread.Sleep(1000)
		Me.splashScreen.Show()
		splashScreen.Refresh()
		System.Threading.Thread.Sleep(5000)
		Me.model.removeObserver(Me.splashScreen)
		splashScreen.Close()
	End Sub
	Public Sub createAboutBox()
		Me.aboutBox = New AboutBox(Me.model)
		Me.model.registerObserver(Me.aboutBox)
		Me.model.notifyObservers()
		Me.aboutBox.txtDescription.Text = ControllerFileManager.getDocText(Document.APP_DESCRIPTION)
		Me.aboutBox.Show()
	End Sub
	Public Sub createViewInputs()
		Me.viewInputs = New ViewInputs(model, controller)
		Me.viewInputs.initialize()
		Me.model.removeObserver(Me.aboutBox)
		Me.model.registerObserver(Me.viewInputs)
		Me.controller.extractEtabsModelData()
		Me.viewInputs.Show()
		Me.aboutBox.Close()
	End Sub

	'SETTERS and GETTERS
	Public Sub setAboutBox(aboutBox As AboutBox)
		Me.aboutBox = aboutBox
	End Sub
	Public Sub setSplashScreen(splashScreen As SplashScreen)
		Me.splashScreen = splashScreen
	End Sub
	Public Sub setViewInputs(viewInputs As ViewInputs)
		Me.viewInputs = viewInputs
	End Sub
	Public Function getAboutBox() As AboutBox
		Return Me.aboutBox
	End Function
	Public Function getSplashScreen() As SplashScreen
		Return Me.splashScreen
	End Function
	Public Function getViewInputs() As ViewInputs
		Return Me.viewInputs
	End Function


End Class
