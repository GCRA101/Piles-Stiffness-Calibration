''' <summary>
''' 
''' <remarks>
''' <para> Concrete class containing sets of translational displacement values u1,u2,u3 in mm. </para>
''' </remarks>
''' </summary>

Public Class PointDisplacements
    Implements IComparable

    'ATTRIBUTES **********************************************************
    Private values_mm As Double()


    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        ReDim values_mm(5)
    End Sub
    'Overloaded
    Public Sub New(values As Double())
        Me.values_mm = values
    End Sub



    'METHODS ****************************************************************

    'GETTERS and SETTERS *********************

    'Setters
    Public Sub setU1(u1 As Double)
        Me.values_mm(0) = u1
    End Sub
    Public Sub setU2(u2 As Double)
        Me.values_mm(1) = u2
    End Sub
    Public Sub setU3(u3 As Double)
        Me.values_mm(2) = u3
    End Sub
    Public Sub setValues(values As Double())
        Me.values_mm = values
    End Sub
    'Getters
    Public Function getU1() As Double
        Return Me.values_mm(0)
    End Function
    Public Function getU2() As Double
        Return Me.values_mm(1)
    End Function
    Public Function getU3() As Double
        Return Me.values_mm(2)
    End Function
    Public Function getValues() As Double()
        Return Me.values_mm
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
        hash = CInt(Me.values_mm.Average())
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
        Dim nDispsObj As PointDisplacements
        nDispsObj = CType(obj, PointDisplacements)
        '3. Compare the two instances of the class giving precedence to the number of results
        If (Me.values_mm.Sum() > nDispsObj.getValues.Sum()) Then
            Return 1
        ElseIf (Me.values_mm.Sum() < nDispsObj.getValues.Sum()) Then
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
        Dim nDispsObj As PointDisplacements
        nDispsObj = CType(obj, PointDisplacements)

        '3. Check if main attributes are equal
        ' - Note : Equals method has to be used to compare all attributes since they are all Arrays/Lists so...other 
        '   data structures...they're not primitive type objects!
        If (Me.getU1.Equals(nDispsObj.getU1) And Me.getU2.Equals(nDispsObj.getU2) And Me.getU3.Equals(nDispsObj.getU3)) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
