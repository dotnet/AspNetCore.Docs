public ActionResult Details(int id)
 {
    var album = new Album { Title = "Album " + id };
    return View(album);
 }