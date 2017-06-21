<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index()
        Return View()
    End Function

    <Authorize(Roles:="Managers")> _
    Function CompanySecrets()
        Return View()
    End Function


    <Authorize(Users:="redmond\swalther")> _
    Function StephenSecrets()
        Return View()
    End Function

End Class