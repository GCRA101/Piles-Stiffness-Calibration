
''' <summary>
''' 
''' Enumeration made from a number of identification constants for different types of Excel range.
''' Each Constant is associated to a specific range formatting style. 
''' Whenever an Excel range has to be formatted as per one of the styles represented by the 
''' constants of this Enum, it's sufficient to pass the enum constant as input and the formatRange()
''' method will run the algorithnm assigning the proper format to the range.
''' 
''' </summary>


Public Enum ExcelRangeType

    HEADER_PRIMARY
    HEADER_SECONDARY
    NORMAL

End Enum
