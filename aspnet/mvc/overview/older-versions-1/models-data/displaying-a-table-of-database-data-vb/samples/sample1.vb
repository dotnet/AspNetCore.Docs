Public Class MovieController

    Inherits System.Web.Mvc.Controller 

    '

    ' GET: /Movie/ 

    Function Index() As ActionResult

        Dim entities As New MoviesDBEntities()

        Return View(entities.MovieSet.ToList())

    End Function 

End Class