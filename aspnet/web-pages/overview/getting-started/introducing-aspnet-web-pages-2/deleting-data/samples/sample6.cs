if(IsPost && !Request["buttonDelete"].IsEmpty()){
	movieId = Request.Form["movieId"];
	var db = Database.Open("WebPagesMovies");
	var deleteCommand = "DELETE FROM Movies WHERE ID = @0";
	db.Execute(deleteCommand, movieId);
	Response.Redirect("~/Movies");
}