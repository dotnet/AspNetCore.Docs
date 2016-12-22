if(IsPost && Validation.IsValid()){
    title = Request.Form["title"];
    genre = Request.Form["genre"];
    year = Request.Form["year"];

    var db = Database.Open("WebPagesMovies");
    var insertCommand = "INSERT INTO Movies (Title, Genre, Year) Values(@0, @1, @2)";
    db.Execute(insertCommand, title, genre, year);
    Response.Redirect("~/Movies");
}