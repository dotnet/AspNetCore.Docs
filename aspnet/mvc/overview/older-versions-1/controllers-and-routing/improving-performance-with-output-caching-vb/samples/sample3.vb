Public Class BadUserController
    Inherits System.Web.Mvc.Controller

    <OutputCache(Duration:=3600, VaryByParam:="none")> _
    Function Index()
        Return "Hi " & User.Identity.Name
    End Function

End Class