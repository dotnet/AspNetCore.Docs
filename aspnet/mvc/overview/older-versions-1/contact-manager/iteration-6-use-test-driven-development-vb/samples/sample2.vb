Public Class GroupController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim groups = new List(Of Group)
        Return View(groups)
    End Function

End Class