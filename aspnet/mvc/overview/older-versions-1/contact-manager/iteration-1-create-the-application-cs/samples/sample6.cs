//
// GET: /Home/Edit/5

public ActionResult Edit(int id)
{
    var contactToEdit = (from c in _entities.ContactSet
                           where c.Id == id
                           select c).FirstOrDefault();

    return View(contactToEdit);
}

//
// POST: /Home/Edit/5

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Edit(Contact contactToEdit)
{
    if (!ModelState.IsValid)
        return View();

    try
    {
        var originalContact = (from c in _entities.ContactSet
                             where c.Id == contactToEdit.Id
                             select c).FirstOrDefault();
        _entities.ApplyPropertyChanges(originalContact.EntityKey.EntitySetName, contactToEdit);
        _entities.SaveChanges();
        return RedirectToAction("Index");
    }
    catch
    {
        return View();
    }
}
}