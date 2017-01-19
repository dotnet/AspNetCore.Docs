Namespace MvcMovie
    Public Class HelloWorldController
        Inherits System.Web.Mvc.Controller

        Public Function Index() As String
            Return "This is my default action..."
        End Function

        Public Function Welcome() As String
            Return "This is the Welcome action method..."
        End Function

    End Class
End Namespace