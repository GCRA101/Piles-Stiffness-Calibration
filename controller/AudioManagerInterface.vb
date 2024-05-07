
''' <summary>
''' Interface AUDIOMANAGER
''' 
'''Interface that defines the methods that all the concrete classes of 
'''type AudioManager have to implement.
''' 
''' </summary>

Public Interface AudioManagerInterface

    Sub play(filePath As String)
    Sub setActive(bool As Boolean)
    Function isActive() As Boolean

End Interface
