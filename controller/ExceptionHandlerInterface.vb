''' <summary>
'''     <remarks>
'''         Interface that defines the methods that all the concrete classes of 
'''         type ExceptionHandler have to implement.
'''     </remarks>
''' </summary>

Public Interface ExceptionHandlerInterface

    Sub execute(Optional ex As Exception = Nothing)

End Interface
