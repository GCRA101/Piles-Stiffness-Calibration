Public Class SpringObject
    Implements IComparable

    'ATTRIBUTES
    Private name As String
    Private values_N_mm As Double()

    'CONSTRUCTORS
    'Default
    Public Sub New()
        ReDim values_N_mm(5)
    End Sub
    'Overloaded 01
    Public Sub New(name As String)
        Me.name = name
        ReDim values_N_mm(5)
    End Sub
    'Overloaded 02
    Public Sub New(name As String, values As Double())
        Me.New(name)
        Me.values_N_mm = values
    End Sub

    'METHODS

    'Setters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setValues(values As Double())
        Me.values_N_mm = values
    End Sub
    Public Sub setU1(u1 As Double)
        Me.values_N_mm.SetValue(u1, 0)
    End Sub
    Public Sub setU2(u2 As Double)
        Me.values_N_mm.SetValue(u2, 1)
    End Sub
    Public Sub setU3(u3 As Double)
        Me.values_N_mm.SetValue(u3, 2)
    End Sub


    'Getters
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getValues() As Double()
        Return Me.values_N_mm
    End Function
    Public Function getU1() As Double
        Return Me.values_N_mm(0)
    End Function
    Public Function getU2() As Double
        Return Me.values_N_mm(1)
    End Function
    Public Function getU3() As Double
        Return Me.values_N_mm(2)
    End Function


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the name's corresponding hashcode plus the integer sum of the stiffness values u1,u2,u3,r1,r2,r3.
        Dim hash As Integer
        hash = CInt(Me.values_N_mm.Average())
        Return hash
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        '1. Check input Obj Data Type to match the present Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the SpringObject Class
        Dim spObj As SpringObject
        spObj = CType(obj, SpringObject)
        '3. Compare the two instances of the class giving precedence to the name and then to the other attributes
        If Me.name.GetHashCode > spObj.GetHashCode Then
            Return 1
        ElseIf Me.name.GetHashCode < spObj.GetHashCode Then
            Return -1
        Else
            If Me.values_N_mm.Sum() < spObj.getValues().Sum() Then
                Return -1
            ElseIf Me.values_N_mm.Sum() > spObj.getValues().Sum() Then
                Return 1
            End If
        End If
        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the SpringObject Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input Object to the SpringObject Class
        Dim spObj As SpringObject
        spObj = CType(obj, SpringObject)

        '3. Check if all attributes and name of the two objects are equal or not
        If Me.getName = spObj.getName And
           Me.values_N_mm Is spObj.getValues() Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
