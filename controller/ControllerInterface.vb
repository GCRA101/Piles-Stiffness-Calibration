''' <summary>
'''     <remarks>
'''         <para>Interface that defines the methods that all the concrete classes of 
'''         type Controller have to implement.</para>
'''     </remarks>
''' </summary>

Public Interface ControllerInterface

    Sub initialize()
    Sub runIteration()
    Sub serialize()
    Sub deserialize()
    Sub createExceptionHandlers()
    Sub terminate()

End Interface
