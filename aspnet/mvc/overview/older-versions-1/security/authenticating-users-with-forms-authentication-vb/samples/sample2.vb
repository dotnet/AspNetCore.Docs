<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index()
        Return View()
    End Function

    <Authorize()> _
    Function CompanySecrets()
        Return View()
    End Function


    <Authorize(Users:="Stephen")> _
    Function StephenSecrets()
        Return View()
    End Function

    <Authorize(Roles:="Administrators")> _
    Function AdministratorSecrets()
        Return View()
    End Function

End Class