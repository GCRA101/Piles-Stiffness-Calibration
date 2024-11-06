Imports Newtonsoft.Json

Public Class PileObject
    Implements IComparable

    'ATTRIBUTES
    Private name As String
    Private location As PointObject
    Private status As PileStatus
    Private loads As PointLoads
    Private displacements As PointDisplacements
    Private stiffness As SpringObject
    Private diameter_m, length_m As Double

    'CONSTRUCTORS
    'Default
    Public Sub New()
    End Sub
    'Overloaded 1
    Public Sub New(name As String)
        Me.name = name
    End Sub
    'Overloaded 2
    <JsonConstructor>
    Public Sub New(name As String, Optional location As PointObject = Nothing, Optional status As PileStatus = PileStatus.UNLOADED,
                   Optional loads As PointLoads = Nothing, Optional displacements As PointDisplacements = Nothing,
                   Optional stiffness As SpringObject = Nothing, Optional diameter As Double = Nothing, Optional length As Double = Nothing)
        Me.name = name
        Me.location = location
        Me.status = status
        Me.loads = loads
        Me.displacements = displacements
        Me.stiffness = stiffness
        Me.diameter_m = diameter
        Me.length_m = length
    End Sub


    'METHODS

    'Setters and Getters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setLocation(location As PointObject)
        Me.location = location
    End Sub
    Public Sub setStatus(status As PileStatus)
        Me.status = status
    End Sub
    Public Sub setLoads(loads As PointLoads)
        Me.loads = loads
    End Sub
    Public Sub setDisplacements(displacements As PointDisplacements)
        Me.displacements = displacements
    End Sub
    Public Sub setStiffness(stiffness As SpringObject)
        Me.stiffness = stiffness
    End Sub
    Public Sub setDiameter(diameter As Double)
        Me.diameter_m = diameter
    End Sub
    Public Sub setLength(length As Double)
        Me.length_m = length
    End Sub


    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getLocation() As PointObject
        Return Me.location
    End Function
    Public Function getStatus() As PileStatus
        Return Me.status
    End Function
    Public Function getLoads() As PointLoads
        Return Me.loads
    End Function
    Public Function getDisplacements() As PointDisplacements
        Return Me.displacements
    End Function
    Public Function getStiffness() As SpringObject
        Return Me.stiffness
    End Function
    Public Function getDiameter() As Double
        Return Me.diameter_m
    End Function
    Public Function getLength() As Double
        Return Me.length_m
    End Function

    Public Function toDictionary() As Dictionary(Of String, String)

        Dim pileObjectDict As New Dictionary(Of String, String) From
            {{"Pile Name", Me.name},
             {"Status", Me.status},
             {"Fz [KN]", CStr(CDbl(Me.loads.getF3()) / 1000)},
             {"Kz [KN/mm]", CStr(CDbl(Me.stiffness.getU3()) / 1000)},
             {"dz [mm]", CStr(Me.displacements.getU3())}}

        Return pileObjectDict

    End Function

    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the hashcodes of the different attributes of the class
        Dim hash As Integer
        hash = Me.name.GetHashCode() + Me.location.GetHashCode + Me.loads.GetHashCode + Me.stiffness.GetHashCode() +
                Me.displacements.GetHashCode() + CInt(Me.diameter_m + Me.length_m)
        Return hash
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Overridable Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        '1. Check input Obj Data Type to match the present Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the PileObject Class
        Dim plObj As PileObject
        plObj = CType(obj, PileObject)
        '3. Compare the two instances of the class giving precedence to the name and then to the other attributes
        If Me.name > plObj.getName() Then
            Return 1
        ElseIf Me.name < plObj.getName() Then
            Return -1
        ElseIf Me.location.CompareTo(plObj.location) <> 0 Then
            Return Me.location.CompareTo(plObj.location)
        End If
        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the PileObject Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input Object to the PileObject Class
        Dim plObj As PileObject
        plObj = CType(obj, PileObject)

        '3. Check if all attributes and name of the two objects are equal or not
        If Me.name = plObj.getName() And Me.location.Equals(plObj.getLocation()) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
