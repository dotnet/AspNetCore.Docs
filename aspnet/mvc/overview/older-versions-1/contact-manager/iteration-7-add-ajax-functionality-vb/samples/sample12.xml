<AcceptVerbs(HttpVerbs.Delete), ActionName("Delete")> _
Public Function AjaxDelete(ByVal id As Integer) As ActionResult
    ' Get contact and group
    Dim contactToDelete = _service.GetContact(id)
    Dim selectedGroup = _service.GetGroup(contactToDelete.Group.Id)

    ' Delete from database
    _service.DeleteContact(contactToDelete)

    ' Return Contact List
    Return PartialView("ContactList", selectedGroup)
End Function