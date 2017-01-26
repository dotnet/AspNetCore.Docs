public ActionResult Details(int id)
{
    var album = storeDB.Albums.Find(id);
 
    return View(album);
}