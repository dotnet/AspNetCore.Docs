//
// GET: /StoreManager/Delete/5

public ActionResult Delete(int id)
{
     Album album = this.db.Albums.Find(id);

     if (album == null)
     {
          return this.HttpNotFound();
     }

     return this.View(album);
}