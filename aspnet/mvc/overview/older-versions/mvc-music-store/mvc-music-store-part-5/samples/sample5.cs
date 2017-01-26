//
// GET: /StoreManager/Details/5
public ViewResult Details(int id)
{
	Album album = db.Albums.Find(id);
	return View(album);
}