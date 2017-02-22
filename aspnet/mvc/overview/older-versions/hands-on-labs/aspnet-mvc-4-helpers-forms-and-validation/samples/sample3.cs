//
// GET: /StoreManager/

public ActionResult Index()
{
    var albums = this.db.Albums.Include(a => a.Genre).Include(a => a.Artist)
         .OrderBy(a => a.Price);

    return this.View(albums.ToList());
}