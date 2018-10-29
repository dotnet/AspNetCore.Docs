Delete all the records in the DB. You can do this with the delete links in the browser or from SSOX.

Replace the contents of *MvcMovieContext.cs* in the *Data* folder with the following code:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie21/Data/MvcMovieContext.cs?name=snippet_1)]

Build the solution.

From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.

<!-- following image shared with uid: tutorials/razor-pages/model -->
  ![PMC menu](~/tutorials/first-mvc-app/adding-model/_static/pmc.png)

In the PMC, enter the following commands:

```powershell
Add-Migration SeedData
Update-Database
```

The `Add-Migration` command create the necessary code to seed the database. The `HasData` define the seed data in `OnModelCreating`, that is transformed into migration commands that perform inserts in the database when the migration executes.

<a name="si"></a>
### Test the app

Run the app and tap the **Mvc Movie** link. The app shows the seeded data.

![MVC Movie application open in Microsoft Edge showing movie data](~/tutorials/first-mvc-app/working-with-sql/_static/m55.png)