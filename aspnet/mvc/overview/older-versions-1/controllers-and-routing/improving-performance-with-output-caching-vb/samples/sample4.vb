Public Class UserController
    Inherits System.Web.Mvc.Controller

    <OutputCache(Duration:=3600, VaryByParam:="none", Location:=OutputCacheLocation.Client, NoStore:=True)> _
    Function GetName()
        Return "Hi " & User.Identity.Name
    End Function

End Class