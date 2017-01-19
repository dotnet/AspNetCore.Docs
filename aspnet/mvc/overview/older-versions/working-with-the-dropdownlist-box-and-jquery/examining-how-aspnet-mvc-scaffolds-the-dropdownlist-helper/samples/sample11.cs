//

// GET: /StoreManager/Create

public ActionResult Create() {

    SetGenreArtistViewBag();

    return View();

}

//

// POST: /StoreManager/Create

[HttpPost]

public ActionResult Create(Album album) {

    if (ModelState.IsValid) {

        db.Albums.Add(album);

        db.SaveChanges();

        return RedirectToAction("Index");

    }

    SetGenreArtistViewBag(album.GenreId, album.ArtistId);

    return View(album);

}

//

// GET: /StoreManager/Edit/5

public ActionResult Edit(int id) {

    Album album = db.Albums.Find(id);

    SetGenreArtistViewBag(album.GenreId, album.ArtistId);

    return View(album);

}

//

// POST: /StoreManager/Edit/5

[HttpPost]

public ActionResult Edit(Album album) {

    if (ModelState.IsValid) {

        db.Entry(album).State = EntityState.Modified;

        db.SaveChanges();

        return RedirectToAction("Index");

    }

    SetGenreArtistViewBag(album.GenreId, album.ArtistId);

    return View(album);

}