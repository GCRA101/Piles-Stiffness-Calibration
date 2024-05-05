''' <summary>
''' 
''' MODEL CLASS
''' 
''' Concrete class and main class of the Model Package.
''' The class contains all the main data and methods for the running of the application.
''' The model is updated based on the actions of the user in the View via the MVC Design Pattern while the View
''' is updated based on the changes of the Model via the OBSERVER Design Pattern.
''' 
''' Specific Techniques: 
''' - OBSERVER Design Pattern
''' - MODEL-VIEW-CONTROLLER Design Pattern
''' 
''' </summary>

Public Class PSC_Model
    Implements Observable

    Public Sub registerObservers(o As Observer) Implements Observable.registerObservers
        Throw New NotImplementedException()
    End Sub

    Public Sub removeObserver(o As Observer) Implements Observable.removeObserver
        Throw New NotImplementedException()
    End Sub

    Public Sub notifyObservers() Implements Observable.notifyObservers
        Throw New NotImplementedException()
    End Sub
End Class
