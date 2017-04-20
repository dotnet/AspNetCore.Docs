<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index()
        Return View()
    End Function

    Function Details()
        Return RedirectToAction("Index")
    End Function
End Class