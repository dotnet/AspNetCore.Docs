Public Class ProductController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Product/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Product/Create

     _
    Function Create( ByVal productToCreate As Product) As ActionResult

        If Not ModelState.IsValid Then
            Return View()
        End If

        Return RedirectToAction("Index")

    End Function

End Class