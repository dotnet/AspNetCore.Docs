//
// GET: /Dinners/Create

[Authorize]
public ActionResult Create() {
   ...
} 

//
// POST: /Dinners/Create

[AcceptVerbs(HttpVerbs.Post), Authorize]
public ActionResult Create(Dinner dinnerToCreate) {
   ...
}