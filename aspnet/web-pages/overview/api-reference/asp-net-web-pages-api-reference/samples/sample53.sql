db.Execute("INSERT INTO Data (Name) VALUES ('Smith')");

db.Execute("INSERT INTO Data (Name) VALUES (@0)", "Smith");