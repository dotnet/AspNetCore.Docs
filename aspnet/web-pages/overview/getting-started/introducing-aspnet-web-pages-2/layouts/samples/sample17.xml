@{
    Layout = "~/_Layout.cshtml";
    Page.Title = "Edit a Movie";

    var title = "";
    var genre = "";
    var year = "";
    var movieId = "";

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
            else{
                Validation.AddFormError("No movie was selected.");
                // If you are using a version of ASP.NET Web Pages 2 that's
                // earlier than the RC release, comment out the preceding
                // statement and uncomment the following one.
                //ModelState.AddFormError("No movie was selected.");
            }
        }
        else{
            Validation.AddFormError("No movie was selected.");
            // If you are using a version of ASP.NET Web Pages 2 that's
            // earlier than the RC release, comment out the preceding
            // statement and uncomment the following one.
            //ModelState.AddFormError("No movie was selected.");
        }
    }

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
}

<h2>Edit a Movie</h2>
@Html.ValidationSummary()
<form method="post">
<fieldset>
    <legend>Movie Information</legend>

    <p><label for="title">Title:</label>
        <input type="text" name="title" value="@title" /></p>

    <p><label for="genre">Genre:</label>
        <input type="text" name="genre" value="@genre" /></p>

    <p><label for="year">Year:</label>
        <input type="text" name="year" value="@year" /></p>

    <input type="hidden" name="movieid" value="@movieId" />

    <p><input type="submit" name="buttonSubmit" value="Submit Changes" /></p>
</fieldset>
</form>
<p><a href="~/Movies">Return to movie listing</a></p>