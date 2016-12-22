//

// POST: /StoreManager/Create

[HttpPost]

public ActionResult Create(Album album)

{

    if (ModelState.IsValid)

    {

        db.Albums.Add(album);

        db.SaveChanges();

        return RedirectToAction("Index");  

    }

    ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name",

        album.GenreId);

    ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name",

        album.ArtistId);

    return View(album);

}