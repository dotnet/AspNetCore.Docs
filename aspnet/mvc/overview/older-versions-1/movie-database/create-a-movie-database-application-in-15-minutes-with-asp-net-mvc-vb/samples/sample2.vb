Public Class HomeController

        Inherits System.Web.Mvc.Controller 

        Private _db As New MoviesDBEntities() 

        Function Index() As ActionResult

            Return View(_db.MovieSet.ToList())

        End Function

    End Class