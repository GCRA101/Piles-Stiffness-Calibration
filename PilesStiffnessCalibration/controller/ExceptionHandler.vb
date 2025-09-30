
''' <summary>
'''     <remarks>
'''         Abstract Class used to define common attributes, constructor and methods to be inherited
'''         by all concrete classes of type ExceptionHandler.
'''     </remarks>
''' </summary>

Public MustInherit Class ExceptionHandler
	Implements ExceptionHandlerInterface

	'ATTRIBUTES
	Protected controller As PSC_Controller
	Protected message As String

	'CONSTRUCTOR
	Public Sub New(controller As PSC_Controller)
		Me.controller = controller
	End Sub

	'METHODS
	Public Overridable Sub execute(Optional ex As Exception = Nothing) Implements ExceptionHandlerInterface.execute
		Throw New NotImplementedException()
	End Sub
End Class
