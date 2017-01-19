Namespace MvcMovie
    Public Class HelloWorldController
        Inherits System.Web.Mvc.Controller
        '
        ' GET: /HelloWorld

        Function Index() As ActionResult
            Return View()
        End Function

        Public Function Welcome(ByVal name As String, Optional ByVal numTimes As Integer = 1) As ActionResult
            ViewBag.Message = "Hello " & name
            ViewBag.NumTimes = numTimes
            Return View()
        End Function

    End Class
End Namespace