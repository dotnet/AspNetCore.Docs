'
' GET: /Home/Delete/5

Function Delete(ByVal id As Integer) As ActionResult
    Dim contactToDelete = (from c in _entities.ContactSet _
                       where c.Id = id _
                       select c).FirstOrDefault()

    Return View(contactToDelete)
End Function

'
' POST: /Home/Delete/5

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