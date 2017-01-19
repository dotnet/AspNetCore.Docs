Public Class CustomerController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Customer/

    Function Index() As ActionResult
        Return View()
    End Function

    '
    ' GET: /Customer/Details/5

    Function Details(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    '
    ' GET: /Customer/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Customer/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add insert logic here
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Customer/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    '
    ' POST: /Customer/Edit/5

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function
End Class