Public Class ContactController
    Inherits System.Web.Mvc.Controller

    Private _repository As IContactManagerRepository 

    Sub New()
        Me.New(new EntityContactManagerRepository())
    End Sub

    Sub New(repository As IContactManagerRepository)
        _repository = repository
    End Sub

    Protected Sub ValidateContact(contactToValidate As Contact)
        If contactToValidate.FirstName.Trim().Length = 0 Then
            ModelState.AddModelError("FirstName", "First name is required.")
        End If
        If contactToValidate.LastName.Trim().Length = 0 Then
            ModelState.AddModelError("LastName", "Last name is required.")
        End If
        If (contactToValidate.Phone.Length > 0 AndAlso Not Regex.IsMatch(contactToValidate.Phone, "((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            ModelState.AddModelError("Phone", "Invalid phone number.")
        End If        
        If (contactToValidate.Email.Length > 0 AndAlso  Not Regex.IsMatch(contactToValidate.Email, "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            ModelState.AddModelError("Email", "Invalid email address.")
        End If
    End Sub

    Function Index() As ActionResult
        Return View(_repository.ListContacts())
    End Function

    Function Create() As ActionResult
        Return View()
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(<Bind(Exclude:="Id")> ByVal contactToCreate As Contact) As ActionResult
        ' Validation logic
        ValidateContact(contactToCreate)
        If Not ModelState.IsValid Then
            Return View()
        End If

        ' Database logic
        Try
            _repository.CreateContact(contactToCreate)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    Function Edit(ByVal id As Integer) As ActionResult
        Return View(_repository.GetContact(id))
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal contactToEdit As Contact) As ActionResult
        ' Validation logic
        ValidateContact(contactToEdit)
        If Not ModelState.IsValid Then
            Return View()
        End If

        ' Database logic
        Try
            _repository.EditContact(contactToEdit)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    Function Delete(ByVal id As Integer) As ActionResult
        Return View(_repository.GetContact(id))
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Delete(ByVal contactToDelete As Contact) As ActionResult
        Try
            _repository.DeleteContact(contactToDelete)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

End Class