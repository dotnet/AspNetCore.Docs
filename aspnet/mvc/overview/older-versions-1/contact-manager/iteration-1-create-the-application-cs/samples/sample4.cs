//
// GET: /Home/Create

public ActionResult Create()
{
    return View();
} 

//
// POST: /Home/Create

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create([Bind(Exclude = "Id")] Contact contactToCreate)
{
    if (!ModelState.IsValid)
        return View();

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