public ActionResult Delete(int id)
{
    // Get movie to delete
    var movieToDelete = _db.MovieSet.First(m => m.Id == id);

    // Delete 
    _db.DeleteObject(movieToDelete);
    _db.SaveChanges();

    // Show Index view
    return RedirectToAction("Index");
}