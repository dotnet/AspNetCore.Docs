//

// GET: /StoreManager/EditVM/5

public ActionResult EditVM(int id) {

    Album album = db.Albums.Find(id);

    if (album == null)

        return HttpNotFound();

    AlbumSelectListViewModel aslvm = new AlbumSelectListViewModel(album, db.Artists, db.Genres);

    return View(aslvm);

}