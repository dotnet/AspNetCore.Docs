//
// GET: /StoreManager/Delete/5
 
public ActionResult Delete(int id)
{
    Album album = db.Albums.Find(id);
    return View(album);
}