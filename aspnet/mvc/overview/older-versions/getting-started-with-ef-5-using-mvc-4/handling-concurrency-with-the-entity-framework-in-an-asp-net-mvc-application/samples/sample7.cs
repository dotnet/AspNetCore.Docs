var entry = ex.Entries.Single();
var clientValues = (Department)entry.Entity;
var databaseValues = (Department)entry.GetDatabaseValues().ToObject();