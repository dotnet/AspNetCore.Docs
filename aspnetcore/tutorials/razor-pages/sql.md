---
title: Part 4, work with a database
author: wadepickett
description: Part 4 of tutorial series on Razor Pages.
ms.author: wpickett
ms.date: 01/09/2026
uid: tutorials/razor-pages/sql
---

# Part 4 of tutorial series on Razor Pages

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Joe Audette](https://twitter.com/joeaudette)

:::moniker range=">= aspnetcore-10.0"

The `RazorPagesMovieContext` object handles the task of connecting to the database and mapping `Movie` objects to database records. Register the database context with the [Dependency Injection](xref:fundamentals/dependency-injection) container in `Program.cs`:

# [Visual Studio](#tab/visual-studio)

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Program.cs?name=snippet_di&highlight=8-9)]

# [Visual Studio Code](#tab/visual-studio-code)

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Program.cs?name=snippet_di_sl&highlight=7-8)]

---

The ASP.NET Core [Configuration](xref:fundamentals/configuration/index) system reads the `ConnectionString` key. For local development, the configuration gets the connection string from the `appsettings.json` file.

# [Visual Studio](#tab/visual-studio)

The generated connection string is similar to the following JSON:

[!code-json[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/appsettings.json?highlight=9-11)]

# [Visual Studio Code](#tab/visual-studio-code)

[!code-json[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/appsettings_SQLite.json?highlight=9-11)]

---

[!INCLUDE [managed-identities-test-non-production](~/includes/managed-identities-test-non-production.md)]

# [Visual Studio](#tab/visual-studio)

## SQL Server Express LocalDB

LocalDB is a lightweight version of the SQL Server Express database engine that's designed for program development. LocalDB starts on demand and runs in user mode, so there's no complex configuration. By default, LocalDB creates `*.mdf` database files in the `C:\Users\<user>\` directory.

1. From the **View** menu, open **SQL Server Object Explorer** (SSOX).

   :::image type="content" source="~/tutorials/razor-pages/sql/media/sql-server-object-explorer-vs2026.png" alt-text="View menu showing SQL Server Object Explorer option.":::

1. Right-click on the `Movie` table and select **View Designer**:

   :::image type="content" source="~/tutorials/razor-pages/sql/media/view-designer-vs2026.png" alt-text="Contextual menus open on Movie table.":::

   :::image type="content" source="~/tutorials/razor-pages/sql/media/movie-table-in-designer-vs2026.png" alt-text="Movie tables open in Designer.":::

   Note the key icon next to `ID`. By default, EF creates a property named `ID` for the primary key.

1. Right-click on the `Movie` table and select **View Data**:

   :::image type="content" source="~/tutorials/razor-pages/sql/media/view-movie-data-vs2026.png" alt-text="Movie table open showing table data.":::

# [Visual Studio Code](#tab/visual-studio-code)

## SQLite

The [SQLite](https://www.sqlite.org/) website states:

> SQLite is a self-contained, high-reliability, embedded, full-featured, public-domain, SQL Database engine. SQLite is the most used database engine in the world.

You can download many third-party tools to manage and view a SQLite database. The following image is from [DB Browser for SQLite](https://sqlitebrowser.org/). If you have a favorite SQLite tool, leave a comment on what you like about it.

:::image type="content" source="~/tutorials/first-mvc-app-xplat/working-with-sql/_static/dbb.png" alt-text="DB Browser for SQLite showing movie database.":::

> [!NOTE]
> For this tutorial, use the Entity Framework Core *migrations* feature where possible. Migrations updates the database schema to match changes in the data model. However, migrations can only make changes that the EF Core provider supports, and the SQLite provider's capabilities are limited. For example, adding a column is supported, but removing or changing a column isn't supported. If you create a migration to remove or change a column, the `ef migrations add` command succeeds but the `ef database update` command fails. Due to these limitations, this tutorial doesn't use migrations for SQLite schema changes. Instead, when the schema changes, the database is dropped and re-created.
>
>The workaround for the SQLite limitations is to manually write migrations code to perform a table rebuild when something in the table changes. A table rebuild involves:
>
>* Creating a new table.
>* Copying data from the old table to the new table.
>* Dropping the old table.
>* Renaming the new table.
>
>For more information, see the following resources:
> * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
> * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
> * [Data seeding](/ef/core/modeling/data-seeding)
> * [SQLite ALTER TABLE statement](https://sqlite.org/lang_altertable.html)

---

## Seed the database

<!-- Next version put it in the Data folder -->
Create a new class named `SeedData` in the *Models* folder with the following code:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Models/SeedData.cs?name=snippet_1)]

If the database contains any movies, the seed initializer returns and doesn't add any movies.

```csharp
if (context.Movie.Any())
{
    return;
}
```

<a name="si"></a>

### Add the seed initializer

Update `Program.cs` with the following highlighted code:

# [Visual Studio](#tab/visual-studio)

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/ProgramSeed.cs?name=snippet_all&highlight=3,13-18)]

# [Visual Studio Code](#tab/visual-studio-code)

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/ProgramSeed.cs?name=snippet_all_sl&highlight=3,13-18)]

---

In the preceding code, you modify `Program.cs` to do the following steps:

* Get a database context instance from the dependency injection (DI) container.
* Call the `seedData.Initialize` method, passing the database context instance.
* Dispose the context when the seed method completes. The [using statement](/dotnet/csharp/language-reference/keywords/using-statement) ensures the context is disposed.

The following exception occurs when you don't run `Update-Database`:

> `SqlException: Cannot open database "RazorPagesMovieContext-" requested by the login. The login failed.`
> `Login failed for user 'user name'.`

### Test the app

Delete all the records in the database so the seed method runs. Stop and start the app to seed the database. If the database isn't seeded, put a breakpoint on `if (context.Movie.Any())` and step through the code.

The app shows the seeded data:

:::image type="content" source="~/tutorials/razor-pages/sql/media/seed-data-in-app.png" alt-text="Movie application open in browser showing movie data.":::

## Next steps

> [!div class="step-by-step"]
> [Previous: Scaffolded Razor Pages](xref:tutorials/razor-pages/page)
> [Next: Update the pages](xref:tutorials/razor-pages/da1)

:::moniker-end

[!INCLUDE[](~/tutorials/razor-pages/sql/includes/sql9.md)]

[!INCLUDE[](~/tutorials/razor-pages/sql/includes/sql8.md)]

[!INCLUDE[](~/tutorials/razor-pages/sql/includes/sql7.md)]

[!INCLUDE[](~/tutorials/razor-pages/sql/includes/sql6.md)]

[!INCLUDE[](~/tutorials/razor-pages/sql/includes/sql5.md)]

[!INCLUDE[](~/tutorials/razor-pages/sql/includes/sql3.md)]
