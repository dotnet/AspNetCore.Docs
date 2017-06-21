public ActionResult Edit(int id)
{
    Album album = this.db.Albums.Find(id);

    if (album == null)
    {
         return this.HttpNotFound();
    }

    this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
    this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

    return this.View(album);
}