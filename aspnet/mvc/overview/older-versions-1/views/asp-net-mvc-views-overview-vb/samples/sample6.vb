Public Class ProductController
    Inherits System.Web.Mvc.Controller

    Function Index()
        ViewData("message") = "Hello World!"
        Return View()
    End Function

End Class