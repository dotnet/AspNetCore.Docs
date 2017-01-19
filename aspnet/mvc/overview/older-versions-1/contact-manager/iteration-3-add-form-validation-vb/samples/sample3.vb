Public Class ContactController
    Inherits System.Web.Mvc.Controller

    Private _entities As New ContactManagerDBEntities()

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

    '
    ' GET: /Contact

    Function Index() As ActionResult
        Return View(_entities.ContactSet.ToList())
    End Function

    '
    ' GET: /Contact/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Contact/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(<Bind(Exclude:="Id")> ByVal contactToCreate As Contact) As ActionResult
        ' Validation logic
        ValidateContact(contactToCreate)
        If Not ModelState.IsValid Then
            Return View()
        End If

        ' Database logic
        Try
            _entities.AddToContactSet(contactToCreate)
            _entities.SaveChanges()
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Contact/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult
        Dim contactToEdit = (from c in _entities.ContactSet _
                           where c.Id = id _
                           select c).FirstOrDefault()

        Return View(contactToEdit)
    End Function

    '
    ' POST: /Contact/Edit/5

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal contactToEdit As Contact) As ActionResult
        ' Validation logic
        ValidateContact(contactToEdit)
        If Not ModelState.IsValid Then
            Return View()
        End If

        ' Database logic
        Try
            Dim originalContact = (from c in _entities.ContactSet _
                             where c.Id = contactToEdit.Id _
                             select c).FirstOrDefault()
            _entities.ApplyPropertyChanges(originalContact.EntityKey.EntitySetName, contactToEdit)
            _entities.SaveChanges()
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Contact/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
        Dim contactToDelete = (from c in _entities.ContactSet _
                           where c.Id = id _
                           select c).FirstOrDefault()

        Return View(contactToDelete)
    End Function

    '
    ' POST: /Contact/Delete/5

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Delete(ByVal contactToDelete As Contact) As ActionResult
        Try
            Dim originalContact = (from c in _entities.ContactSet _
                             where c.Id = contactToDelete.Id _
                             select c).FirstOrDefault()
            _entities.DeleteObject(originalContact)
            _entities.SaveChanges()
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

End Class