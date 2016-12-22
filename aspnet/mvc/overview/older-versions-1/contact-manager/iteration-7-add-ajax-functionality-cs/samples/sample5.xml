public ActionResult Index(int? id)
{
    // Get selected group
    var selectedGroup = _service.GetGroup(id);
    if (selectedGroup == null)
        return RedirectToAction("Index", "Group");

    // Normal Request
    if (!Request.IsAjaxRequest())
    {
        var model = new IndexModel
        {
            Groups = _service.ListGroups(),
            SelectedGroup = selectedGroup
        };
        return View("Index", model);
    }

    // Ajax Request
    return PartialView("ContactList", selectedGroup);
}