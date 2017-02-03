<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    <OutputCache(Duration:=10, VaryByParam:="none")> _
    Function Index()
        Return View()
    End Function

End Class