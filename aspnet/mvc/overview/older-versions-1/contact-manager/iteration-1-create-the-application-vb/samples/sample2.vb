Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private _entities As New ContactManagerDBEntities()

    '
    ' GET: /Home/

    Function Index() As ActionResult
        Return View(_entities.ContactSet.ToList())
    End Function
…