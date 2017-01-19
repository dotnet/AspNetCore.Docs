//
// POST: /Contact/Create

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create([Bind(Exclude = "Id")] Contact contactToCreate)
{
    // Validation logic
    if (contactToCreate.FirstName.Trim().Length == 0)
        ModelState.AddModelError("FirstName", "First name is required.");
    if (contactToCreate.LastName.Trim().Length == 0)
        ModelState.AddModelError("LastName", "Last name is required.");
    if (contactToCreate.Phone.Length > 0 && !Regex.IsMatch(contactToCreate.Phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
        ModelState.AddModelError("Phone", "Invalid phone number.");
    if (contactToCreate.Email.Length > 0 && !Regex.IsMatch(contactToCreate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
        ModelState.AddModelError("Email", "Invalid email address.");
    if (!ModelState.IsValid)
        return View();

    // Database logic
    try
    {
        _entities.AddToContactSet(contactToCreate);
        _entities.SaveChanges();
        return RedirectToAction("Index");
    }
    catch
    {
        return View();
    }
}