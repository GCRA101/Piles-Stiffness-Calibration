''' <summary>
'''     Interface AUDIOMANAGER
'''     <remarks>
'''         Interface that defines the methods that all the concrete classes of 
'''         type AudioManager have to implement.
'''     </remarks>
''' </summary>

Public Interface AudioManagerInterface

    Sub play(filePath As String)
    Sub setActive(bool As Boolean)
    Function isActive() As Boolean

End Interface
