Create a new class named `SeedData` in the *Models* folder. Replace the generated code with the following:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/SeedData.cs?name=snippet_1)]

If there are any movies in the DB, the seed initializer returns and no movies are added.

```csharp
if (context.Movie.Any())
{
    return;   // DB has been seeded.
}
```

<a name="si"></a>
### Add the seed initializer

Replace the contents of *Program.cs* with the following code:

# [ASP.NET Core 2.0](#tab/aspnetcore20/)

Add the seed initializer to the `Main` method in the *Program.cs* file:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Program.cs?highlight=6,14-32)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x/)

Add the seed initializer to the end of the `Configure` method in the *Startup.cs* file.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Startup.cs?highlight=9&name=snippet_seed)]

---

<a name="si"></a>
### Test the app

* Delete all the records in the DB. You can do this with the delete links in the browser or from SSOX.
* Force the app to initialize (call the methods in the `Startup` class) so the seed method runs. To force initialization, IIS Express must be stopped and restarted. You can do this with any of the following approaches:

  * Right click the IIS Express system tray icon in the notification area and tap **Exit** or **Stop Site**

    ![IIS Express system tray icon](~/tutorials/first-mvc-app/working-with-sql/_static/iisExIcon.png)

    ![Contextual menu](~/tutorials/first-mvc-app/working-with-sql/_static/stopIIS.png)

    * If you were running VS in non-debug mode, press F5 to run in debug mode
    * If you were running VS in debug mode, stop the debugger and press F5

The app shows the seeded data.

![MVC Movie application open in Microsoft Edge showing movie data](~/tutorials/first-mvc-app/working-with-sql/_static/m55.png)