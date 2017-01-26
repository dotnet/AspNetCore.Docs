if(!IsPost){
	if(!Request.QueryString["ID"].IsEmpty() && Request.QueryString["ID"].IsInt()) {
        movieId = Request.QueryString["ID"];
        var db = Database.Open("WebPagesMovies");
        var dbCommand = "SELECT * FROM Movies WHERE ID = @0";
        var row = db.QuerySingle(dbCommand, movieId);

        if(row != null) {
            title = row.Title;
            genre = row.Genre;
            year = row.Year;
        }
        else {
            Validation.AddFormError("No movie was found for that ID.");
        }
    }
    else {
        Validation.AddFormError("No movie was selected.");
    }
}