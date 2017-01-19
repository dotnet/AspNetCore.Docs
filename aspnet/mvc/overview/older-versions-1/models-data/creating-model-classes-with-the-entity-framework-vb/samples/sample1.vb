<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private _db As MoviesDBEntities

    Public Sub New()
        _db = New MoviesDBEntities()
    End Sub

    Public Function Index()
        ViewData.Model = _db.MovieSet.ToList()
        Return View()
    End Function

End Class