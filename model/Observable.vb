
''' <summary>
''' 
''' Interface OBSERVABLE
''' 
''' Essential Interface of the Observer Pattern And that, once implemented In the Model,
''' it allows it To notify all the registered observers As soon As a change occurs In
''' its own state.
''' 
''' </summary>

Public Interface Observable

    Sub registerObserver(o As Observer)
    Sub removeObserver(o As Observer)
    Sub notifyObservers()

End Interface
