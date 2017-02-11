@{
    Layout = "~/_Layout.cshtml";
    Page.Title = "Add a Movie";

    Validation.RequireField("title", "You must enter a title");
    Validation.RequireField("genre", "Genre is required");
    Validation.RequireField("year", "You haven't entered a year");

    var title = "";
    var genre = "";
    var year = "";

    if(IsPost){
        if(Validation.IsValid()){
            title = Request.Form["title"];
            genre = Request.Form["genre"];
            year = Request.Form["year"];

            var db = Database.Open("WebPagesMovies");
            var insertCommand = "INSERT INTO Movies (Title, Genre, Year) VALUES(@0, @1, @2)";
            db.Execute(insertCommand, title, genre, year);

            Response.Redirect("~/Movies");
        }
    }
}

<h2>Add a Movie</h2>
@Html.ValidationSummary()
<form method="post">
<fieldset>
    <legend>Movie Information</legend>
    <p><label for="title">Title:</label>
        <input type="text" name="title" value="@Request.Form["title"]" />
        @Html.ValidationMessage("title")

    <p><label for="genre">Genre:</label>
        <input type="text" name="genre" value="@Request.Form["genre"]" />
        @Html.ValidationMessage("genre")

    <p><label for="year">Year:</label>
        <input type="text" name="year" value="@Request.Form["year"]" />
        @Html.ValidationMessage("year")

    <p><input type="submit" name="buttonSubmit" value="Add Movie" /></p>
</fieldset>
</form>