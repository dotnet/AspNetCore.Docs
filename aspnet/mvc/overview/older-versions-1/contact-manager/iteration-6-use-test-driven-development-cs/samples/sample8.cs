public ActionResult Create(Group groupToCreate)
{
    // Validation logic
    if (groupToCreate.Name.Trim().Length == 0)
    {
        ModelState.AddModelError("Name", "Name is required.");
        return View("Create");
    }
    
    // Database logic
    _groups.Add(groupToCreate);
    return RedirectToAction("Index");
}