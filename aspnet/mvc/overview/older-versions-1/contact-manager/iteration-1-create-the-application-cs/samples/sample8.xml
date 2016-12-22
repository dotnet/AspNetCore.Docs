//
// GET: /Home/Delete/5

public ActionResult Delete(int id)
{
    var contactToDelete = (from c in _entities.ContactSet
                         where c.Id == id
                         select c).FirstOrDefault();

    return View(contactToDelete);
}

//
// POST: /Home/Delete/5

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Delete(Contact contactToDelete)
{
    try
    {
        var originalContact = (from c in _entities.ContactSet
                               where c.Id == contactToDelete.Id
                               select c).FirstOrDefault();

        _entities.DeleteObject(originalContact);
        _entities.SaveChanges();
        return RedirectToAction("Index");
    }
    catch
    {
        return View();
    }
}