var db = Database.Open("WebPagesMovies");
var selectedData = db.Query("SELECT * FROM Movies");
var grid = new WebGrid(source: selectedData);