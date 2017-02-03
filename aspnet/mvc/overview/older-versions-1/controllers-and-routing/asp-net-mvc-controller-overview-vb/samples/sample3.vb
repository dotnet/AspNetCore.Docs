Public Class CustomerController
    Inherits System.Web.Mvc.Controller

    Function Details(ByVal id As Integer?)
        If Not id.HasValue Then
            Return RedirectToAction("Index")
        End If

        Return View()
    End Function
    Function Index()
        Return View()
    End Function

End Class