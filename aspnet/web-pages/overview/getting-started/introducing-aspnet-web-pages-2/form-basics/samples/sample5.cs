if(!Request.QueryString["searchGenre"].IsEmpty() ) { 
    searchTerm = Request.QueryString["searchGenre"];
    selectCommand = "SELECT * FROM Movies WHERE Genre = @0";
    selectedData = db.Query(selectCommand, searchTerm);
}