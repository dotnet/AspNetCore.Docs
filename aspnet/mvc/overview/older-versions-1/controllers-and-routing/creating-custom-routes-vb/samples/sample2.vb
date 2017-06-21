Public Class ArchiveController
    Inherits System.Web.Mvc.Controller
    Function Entry(ByVal entryDate As DateTime)
        Return "You requested the entry from " & entryDate.ToString()
    End Function
End Class