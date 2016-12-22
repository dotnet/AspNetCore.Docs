//
// POST: /Product/Create

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create([Bind(Exclude="Id")] Product productToCreate)
{
    // Validation logic
    if (productToCreate.Name.Trim().Length == 0)
        ModelState.AddModelError("Name", "Name is required.");
    if (productToCreate.Description.Trim().Length == 0)
        ModelState.AddModelError("Description", "Description is required.");
    if (productToCreate.UnitsInStock