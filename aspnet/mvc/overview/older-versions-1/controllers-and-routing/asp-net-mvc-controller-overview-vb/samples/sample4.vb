Public Class StatusController
    Inherits System.Web.Mvc.Controller

    Function Index()
        Return Content("Hello World!")
    End Function

End Class