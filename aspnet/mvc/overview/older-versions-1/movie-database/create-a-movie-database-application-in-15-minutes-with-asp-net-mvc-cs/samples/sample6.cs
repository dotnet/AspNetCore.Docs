//

// GET: /Home/Edit/5 

public ActionResult Edit(int id)

{

	var movieToEdit = (from m in _db.MovieSet

					   where m.Id == id

					   select m).First(); 

	return View(movieToEdit);

} 

//

// POST: /Home/Edit/5 

[AcceptVerbs(HttpVerbs.Post)]

public ActionResult Edit(Movie movieToEdit)

{ 

	var originalMovie = (from m in _db.MovieSet

						 where m.Id == movieToEdit.Id

						 select m).First(); 

	if (!ModelState.IsValid)

		return View(originalMovie);

		_db.ApplyPropertyChanges(originalMovie.EntityKey.EntitySetName, movieToEdit);

		_db.SaveChanges(); 

		return RedirectToAction("Index");

}