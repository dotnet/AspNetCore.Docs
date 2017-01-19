public ActionResult SearchIndex(string id) 
{ 
    string searchString = id; 
    var movies = from m in db.Movies 
                 select m; 
 
    if (!String.IsNullOrEmpty(searchString)) 
    { 
        movies = movies.Where(s => s.Title.Contains(searchString)); 
    } 
 
    return View(movies); 
}