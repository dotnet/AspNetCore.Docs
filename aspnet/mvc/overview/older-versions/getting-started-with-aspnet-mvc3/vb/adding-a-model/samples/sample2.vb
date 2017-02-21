Public Class MovieDBContext
    Inherits DbContext
    Public Property Movies() As DbSet(Of Movie)
End Class