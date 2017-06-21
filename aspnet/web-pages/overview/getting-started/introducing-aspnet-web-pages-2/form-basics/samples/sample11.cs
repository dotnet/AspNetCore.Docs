if(!Request.QueryString["searchTitle"].IsEmpty() ) {
    selectCommand = "SELECT * FROM Movies WHERE Title LIKE @0";
    searchTerm = "%" + Request["searchTitle"] + "%";
}