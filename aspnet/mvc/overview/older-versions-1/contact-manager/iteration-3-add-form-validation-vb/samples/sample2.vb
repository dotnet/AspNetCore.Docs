<AcceptVerbs(HttpVerbs.Post)> _
Function Create(<Bind(Exclude:="Id")> ByVal contactToCreate As Contact) As ActionResult
    ' Validation logic
    If contactToCreate.FirstName.Trim().Length = 0 Then
        ModelState.AddModelError("FirstName", "First name is required.")
    End If
    If contactToCreate.LastName.Trim().Length = 0 Then
        ModelState.AddModelError("LastName", "Last name is required.")
    End If
    If (contactToCreate.Phone.Length > 0 AndAlso Not Regex.IsMatch(contactToCreate.Phone, "((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
        ModelState.AddModelError("Phone", "Invalid phone number.")
    End If        
    If (contactToCreate.Email.Length > 0 AndAlso  Not Regex.IsMatch(contactToCreate.Email, "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
        ModelState.AddModelError("Email", "Invalid email address.")
    End If
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