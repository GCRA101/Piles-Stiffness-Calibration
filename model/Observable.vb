Public Interface Observable

    ' INTERFACE OBSERVABLE

    ' Essential interface of the Observer Pattern and that, once implemented in the Model,
    ' it allows it to notify all the registered observers as soon as a change occurs in
    ' its own state.

    Sub registerObservers(o As Observer)
    Sub removeObserver(o As Observer)
    Sub notifyObservers()


End Interface
