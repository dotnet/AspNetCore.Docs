Public Class ContactController
    Inherits System.Web.Mvc.Controller

    Private _service As IContactManagerService 

    Sub New()
        _service = new ContactManagerService(New ModelStateWrapper(ModelState))
    End Sub

    Sub New(service As IContactManagerService)
        _service = service
    End Sub

    Function Index() As ActionResult
        Return View(_service.ListContacts())
    End Function

    Function Create() As ActionResult
        Return View()
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(<Bind(Exclude:="Id")> ByVal contactToCreate As Contact) As ActionResult
        If _service.CreateContact(contactToCreate) Then
            Return RedirectToAction("Index")        
        End If
        Return View()
    End Function

    Function Edit(ByVal id As Integer) As ActionResult
        Return View(_service.GetContact(id))
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal contactToEdit As Contact) As ActionResult
        If _service.EditContact(contactToEdit) Then
            Return RedirectToAction("Index")        
        End If
        Return View()
    End Function

    Function Delete(ByVal id As Integer) As ActionResult
        Return View(_service.GetContact(id))
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Delete(ByVal contactToDelete As Contact) As ActionResult
        If _service.DeleteContact(contactToDelete) Then
            return RedirectToAction("Index")
        End If
        Return View()
    End Function

End Class