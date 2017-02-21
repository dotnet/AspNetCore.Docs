if (!String.IsNullOrEmpty(searchString)) 
{ 
	movies = movies.Where(s => s.Title.Contains(searchString)); 
}