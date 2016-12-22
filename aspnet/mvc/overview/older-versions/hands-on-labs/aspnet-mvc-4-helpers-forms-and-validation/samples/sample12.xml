//
// GET: /StoreManager/Create

public ActionResult Create()
{
     this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name");
     this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name");

     return this.View();
}