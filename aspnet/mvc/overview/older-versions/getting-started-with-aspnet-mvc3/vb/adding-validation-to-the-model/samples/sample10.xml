Public Class Movie
    Public Property ID() As Integer

    <Required(ErrorMessage:="Title is required")>
    Public Property Title() As String

    <Required(ErrorMessage:="Date is required")>
    <DataType(DataType.Date)>
    Public Property ReleaseDate() As Date

    <Required(ErrorMessage:="Genre must be specified")>
    Public Property Genre() As String

    <Required(ErrorMessage:="Price Required"), Range(1, 100, ErrorMessage:="Price must be between $1 and $100")>
    <DataType(DataType.Currency)>
    Public Property Price() As Decimal

    <StringLength(5)>
    Public Property Rating() As String
End Class