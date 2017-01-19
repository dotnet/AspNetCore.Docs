//
// GET: /Store/Details/5

public ActionResult Details(int id)
{
  var album = new Album { Title = "Sample Album" };

  return this.View(album);
}