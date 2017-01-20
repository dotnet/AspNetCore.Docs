@{
    Layout = "~/_Layout.cshtml";
    Page.Title = "Delete a Movie";

    var title = "";
    var genre = "";
    var year = "";
    var movieId = "";

    if(!IsPost){
        if(!Request.QueryString["ID"].IsEmpty() && Request.QueryString["ID"].AsInt() > 0){
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
                Validation.AddFormError("No movie was found for that ID.");
                // If you are using a version of ASP.NET Web Pages 2 that's
                // earlier than the RC release, comment out the preceding
                // statement and uncomment the following one.
                //ModelState.AddFormError("No movie was found for that ID.");
            }
        }
        else{
            Validation.AddFormError("No movie was found for that ID.");
            // If you are using a version of ASP.NET Web Pages 2 that's
            // earlier than the RC release, comment out the preceding
            // statement and uncomment the following one.
            //ModelState.AddFormError("No movie was found for that ID.");
        }
    }

    if(IsPost && !Request["buttonDelete"].IsEmpty()){
        movieId = Request.Form["movieId"];
        var db = Database.Open("WebPagesMovies");
        var deleteCommand = "DELETE FROM Movies WHERE ID = @0";
        db.Execute(deleteCommand, movieId);
        Response.Redirect("~/Movies");
    }

}

<h2>Delete a Movie</h2>
@Html.ValidationSummary()
<p><a href="~/Movies">Return to movie listing</a></p>

<form method="post">
<fieldset>
<legend>Movie Information</legend>

<p><span>Title:</span>
    <span>@title</span></p>

<p><span>Genre:</span>
    <span>@genre</span></p>

<p><span>Year:</span>
    <span>@year</span></p>

<input type="hidden" name="movieid" value="@movieId" />
<p><input type="submit" name="buttonDelete" value="Delete Movie" /></p>
</fieldset>
</form>