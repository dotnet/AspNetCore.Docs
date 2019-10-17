## Add initial migration and update the database

* Open a command prompt and navigate to the project directory. (The directory containing the *Startup.cs* file).

* Run the following commands in the command prompt:

  ```dotnetcli
  dotnet restore
  dotnet ef migrations add Initial
  dotnet ef database update
  ```

  [.NET Core](/dotnet/core/tools/index) is a cross-platform implementation of .NET. Here is what these commands do:

  * [dotnet restore](/dotnet/core/tools/dotnet-restore): Downloads the NuGet packages specified in the *.csproj* file.
  * `dotnet ef migrations add Initial` Runs the Entity Framework .NET Core CLI migrations command and creates the initial migration. The parameter after "add" is a name that you assign to the migration. Here you're naming the migration "Initial" because it's the initial database migration. This operation creates the *Data/Migrations/\<date-time>_Initial.cs* file containing the migration commands to add the *Movie* table to the database.
  * `dotnet ef database update`  Updates the database with the migration we just created.

You'll learn about the database and connection string in the next tutorial. You'll learn about data model changes in the [Add a field](xref:tutorials/first-mvc-app/new-field) tutorial.
