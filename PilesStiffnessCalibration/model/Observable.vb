
''' <summary>
''' 
''' <remarks>
''' <para>
''' Essential Interface of the Observer Pattern and that, once implemented in the Model,
''' it allows it to notify all the registered observers as soon as a change occurs in
''' its own state. 
''' </para>
''' </remarks>
''' 
''' </summary>

Public Interface Observable

    Sub registerObserver(o As Observer)
    Sub removeObserver(o As Observer)
    Sub notifyObservers()

End Interface
