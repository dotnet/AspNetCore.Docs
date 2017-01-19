'
' GET: /Home/Edit/5

Function Edit(ByVal id As Integer) As ActionResult
    Dim contactToEdit = (from c in _entities.ContactSet _
                       where c.Id = id _
                       select c).FirstOrDefault()

    Return View(contactToEdit)
End Function

'
' POST: /Home/Edit/5

<AcceptVerbs(HttpVerbs.Post)> _
Function Edit(ByVal contactToEdit As Contact) As ActionResult
    If Not ModelState.IsValid Then
        Return View()
    End If

    Try
        Dim originalContact = (from c in _entities.ContactSet _
                         where c.Id = contactToEdit.Id _
                         select c).FirstOrDefault()
        _entities.ApplyPropertyChanges( originalContact.EntityKey.EntitySetName, contactToEdit)
        _entities.SaveChanges()
        Return RedirectToAction("Index")
    Catch
        Return View()
    End Try
End Function