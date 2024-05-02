Public Class PointLoads
    Implements IComparable

    'ATTRIBUTES **********************************************************
    Protected values_N As Double()


    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        ReDim values_N(5)
    End Sub
    'Overloaded
    Public Sub New(values As Double())
        Me.values_N = values
    End Sub



    'METHODS ****************************************************************

    'GETTERS and SETTERS *********************

    'Setters
    Public Sub setF1(f1 As Double)
        Me.values_N(0) = f1
    End Sub
    Public Sub setF2(f2 As Double)
        Me.values_N(1) = f2
    End Sub
    Public Sub setF3(f3 As Double)
        Me.values_N(2) = f3
    End Sub
    Public Sub setValues(values As Double())
        Me.values_N = values
    End Sub


    'Getters
    Public Function getF1() As Double
        Return Me.values_N(0)
    End Function
    Public Function getF2() As Double
        Return Me.values_N(1)
    End Function
    Public Function getF3() As Double
        Return Me.values_N(2)
    End Function
    Public Function getValues() As Double()
        Return values_N
    End Function


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the hascodes/values of the most significant attributes of the class instance
        Dim hash As Integer
        hash = CInt(Me.values_N.Average())
        Return hash
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Overridable Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Throw New NotImplementedException()
        '1. Check input Obj Data Type to match the Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the currentClass
        Dim nForcesObj As PointLoads
        nForcesObj = CType(obj, PointLoads)
        '3. Compare the two instances of the class giving precedence to the number of results
        If (Me.values_N.Sum() > nForcesObj.getValues().Sum()) Then
            Return 1
        ElseIf (Me.values_N.Sum() < nForcesObj.getValues().Sum()) Then
            Return -1
        End If

        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the current Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input object to the current Class
        Dim nForcesObj As NodalForces
        nForcesObj = CType(obj, NodalForces)

        '3. Check if main attributes are equal
        ' - Note : Equals method has to be used to compare all attributes since they are all Arrays/Lists so...other 
        '   data structures...they're not primitive type objects!
        If Me.getF1.Equals(nForcesObj.getF1) And Me.getF2.Equals(nForcesObj.getF2) And Me.getF3.Equals(nForcesObj.getF3) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
