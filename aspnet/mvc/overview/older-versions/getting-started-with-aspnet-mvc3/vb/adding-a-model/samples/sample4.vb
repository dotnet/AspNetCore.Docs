Imports System.Data.Entity

Public Class Movie
        Public Property ID() As Integer
        Public Property Title() As String
        Public Property ReleaseDate() As Date
        Public Property Genre() As String
        Public Property Price() As Decimal
End Class

Public Class MovieDBContext
    Inherits DbContext
    Public Property Movies() As DbSet(Of Movie)
End Class