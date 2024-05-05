
Imports Piles_Stiffness_Iteration.model
Public Class View

	'ATTRIBUTES

	'References to Model and Controller
	Protected model As Piles_Stiffness_Iteration.model
	Protected controller As Controller
	'Main windows of the View
	Protected splashScreen As SplashScreen
	Protected aboutBox As AboutBox
	Protected viewInputs As ViewInputs

	'CONSTRUCTORS
	Public Sub New(model As model, controller As Controller)
		Me.model = model
		Me.controller = controller
	End Sub

	'METHODS

	'CREATION of the VIEWS
	Public Sub createSplashScreen()
		Me.splashScreen = New SplashScreen()
	End Sub

	Public Sub createAboutBox()
		Me.aboutBox = New AboutBox()
	End Sub

	Public void creaViewMenu() {
		this.viewMenu=New ViewMenu(this.model,this.controller);
		// Registrazione View come observer di Model		
		this.model.registerObserver(this.viewMenu);}
	
	Public void creaViewGame() {
		this.viewGame=New ViewGame(this.model, this.controller);
		// Registrazione View come observer di Model		
		this.model.registerObserver(this.viewGame);}
	
	Public void creaViewColorChoose() {
		this.viewColorChoose=New ViewColorChoose(this.model,this.controller);}
	
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
