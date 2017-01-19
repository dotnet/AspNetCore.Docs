[HttpPost] 
public string SearchIndex(FormCollection fc, string searchString) 
{ 
    return "<h3> From [HttpPost]SearchIndex: " + searchString + "</h3>"; 
}