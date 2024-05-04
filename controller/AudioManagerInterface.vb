Public Interface AudioManagerInterface

    'AUDIOMANAGERINTERFACE

    'interface that defines the methods that all the concrete classes of 
    'type AudioManager have to implement.

    Sub play(fileName As String)
    Sub setActive(bool As Boolean)
    Function isActive() As Boolean


End Interface
