//
// POST: /StoreManager/Delete/5
[HttpPost, ActionName("Delete")]
public ActionResult DeleteConfirmed(int id)
{            
    Album album = db.Albums.Find(id);
    db.Albums.Remove(album);
    db.SaveChanges();
    return RedirectToAction("Index");
}