[AcceptVerbs(HttpVerbs.Delete)]
[ActionName("Delete")]
public ActionResult AjaxDelete(int id)
{
    // Get contact and group
    var contactToDelete = _service.GetContact(id);
    var selectedGroup = _service.GetGroup(contactToDelete.Group.Id);

    // Delete from database
    _service.DeleteContact(contactToDelete);

    // Return Contact List
    return PartialView("ContactList", selectedGroup);
}