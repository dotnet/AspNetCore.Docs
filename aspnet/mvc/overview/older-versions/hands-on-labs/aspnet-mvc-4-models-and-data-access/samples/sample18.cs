// GET: /Store/
public ActionResult Details(int id)
{
	var album = this.storeDB.Albums.Find(id);

	if (album == null)
	{
		return this.HttpNotFound();
	}

	return this.View(album);
}