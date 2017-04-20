var count = db.QueryValue("SELECT COUNT(*) FROM Product");

var count = db.QueryValue("SELECT COUNT(*) FROM Product WHERE Price > @0", 20);