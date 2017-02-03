'
' GET: /Home/Create

Function Create() As ActionResult
    Return View()
End Function

'
' POST: /Home/Create

<AcceptVerbs(HttpVerbs.Post)> _
Function Create(<Bind(Exclude:="Id")> ByVal contactToCreate As Contact) As ActionResult
    If Not ModelState.IsValid Then
        Return View()
    End If

    Try
        _entities.AddToContactSet(contactToCreate)
        _entities.SaveChanges()
        Return RedirectToAction("Index")
    Catch
        Return View()
    End Try
End Function