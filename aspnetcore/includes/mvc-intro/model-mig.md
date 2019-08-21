The database update command generates the following warning: 

   "No type was specified for the decimal column 'Price' on entity type 'Movie'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'."

You can ignore that warning, it will be fixed in a later tutorial.

The database schema is based on the model specified in the `MvcMovieContext` class (in the *Data/MvcMovieContext.cs* file). The `InitialCreate` argument is the migration name. Any name can be used, but by convention, a name is selected that describes the migration.

The `Update-Database` command runs the `Up` method in the *Migrations/{time-stamp}_InitialCreate.cs* file, which creates the database.