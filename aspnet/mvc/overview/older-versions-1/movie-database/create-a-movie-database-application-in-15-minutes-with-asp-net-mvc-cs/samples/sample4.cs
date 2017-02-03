//

// GET: /Home/Create 

public ActionResult Create()

{

	return View();

}  

//

// POST: /Home/Create 

[AcceptVerbs(HttpVerbs.Post)]

public ActionResult Create([Bind(Exclude="Id")] Movie movieToCreate)

{

	 if (!ModelState.IsValid)

		return View(); 

	_db.AddToMovieSet(movieToCreate);

	_db.SaveChanges(); 

	return RedirectToAction("Index");

}