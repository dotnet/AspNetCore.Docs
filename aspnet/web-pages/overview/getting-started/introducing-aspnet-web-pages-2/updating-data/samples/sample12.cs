if(IsPost){
	Validation.RequireField("title", "You must enter a title");
	Validation.RequireField("genre", "Genre is required");
	Validation.RequireField("year", "You haven't entered a year");
	Validation.RequireField("movieid", "No movie ID was submitted!");

	title = Request.Form["title"];
	genre = Request.Form["genre"];
	year = Request.Form["year"];
	movieId = Request.Form["movieId"];

	if(Validation.IsValid()){
		var db = Database.Open("WebPagesMovies");
		var updateCommand = "UPDATE Movies SET Title=@0, Genre=@1, Year=@2 WHERE Id=@3";
		db.Execute(updateCommand, title, genre, year, movieId);
		Response.Redirect("~/Movies");
   }
}