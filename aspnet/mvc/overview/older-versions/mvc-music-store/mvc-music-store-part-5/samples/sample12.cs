//
// POST: /StoreManager/Edit/5
[HttpPost]
public ActionResult Edit(Album album)
{
	if (ModelState.IsValid)
	{
		db.Entry(album).State = EntityState.Modified;
		db.SaveChanges();
		return RedirectToAction("Index");
	}
	ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
	ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
	return View(album);
}