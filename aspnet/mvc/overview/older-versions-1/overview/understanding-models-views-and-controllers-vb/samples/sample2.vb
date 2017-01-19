<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index()
        ViewData("Title") = "Home Page"
        ViewData("Message") = "Welcome to ASP.NET MVC!"

        Return View()
    End Function

    Function About()
        ViewData("Title") = "About Page"

        Return View()
    End Function
End Class