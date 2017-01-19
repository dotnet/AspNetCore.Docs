<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    <OutputCache(Duration:=60, VaryByParam:="none")> _
    Function Index()
        Return View()
    End Function

End Class