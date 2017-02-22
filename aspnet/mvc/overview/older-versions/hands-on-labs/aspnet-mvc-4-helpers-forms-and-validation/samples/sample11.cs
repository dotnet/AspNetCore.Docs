[HttpPost]
public ActionResult Edit(Album album)
{
     if (ModelState.IsValid)
     {
          this.db.Entry(album).State = EntityState.Modified;
          this.db.SaveChanges();

          return this.RedirectToAction("Index");
     }

     this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
     this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

     return this.View(album);
}