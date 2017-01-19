selectCommand = "SELECT * FROM Movies WHERE Genre = @0";
selectedData = db.Query(selectCommand, Request.QueryString["searchGenre"]);