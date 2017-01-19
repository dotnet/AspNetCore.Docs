//
// POST: /StoreManager/Delete/5

[HttpPost]
public ActionResult Delete(int id, FormCollection collection)
{
     Album album = this.db.Albums.Find(id);
     this.db.Albums.Remove(album);
     this.db.SaveChanges();

     return this.RedirectToAction("Index"); 
}