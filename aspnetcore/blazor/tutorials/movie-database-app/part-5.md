---
title: Build a Blazor movie database app (Part 5 - Add validation)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how metadata (data annotations) of the movie model is used to validate user input in the forms that create and edit movies.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/26/2024
uid: blazor/tutorials/movie-database-app/part-5
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 5 - Add validation)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the fifth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the tutorial series explains how metadata of the `Movie` model is used to validate user input in the forms that create and edit movies.

## Validation using data annotations

Validation rules are specified on a model class using *data annotations*. The following list shows some of the <xref:System.ComponentModel.DataAnnotations> attributes for user input validation of public properties in a form's model:

* [`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute): Require that the user provide a value.
* [`[StringLength]`](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute): Specifies the minimum and maximum length of characters. Note that a `MinimumLength` passed to the attribute doesn't make the string required (apply the [`[Required]` attribute](xref:System.ComponentModel.DataAnnotations.RequiredAttribute)).
* [`[RegularExpression]`](xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute): Specify a pattern to match for the user's input.
* [`[Range]`](xref:System.ComponentModel.DataAnnotations.RangeAttribute): Specify the minimum and maximum values.

Value types, such as `decimal`, `int`, `float`, `DateOnly`, `TimeOnly`, and `DateTime`, are inherently required. Placing a [`[Required]` attribute](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) on value types isn't necessary.

Additional data annotations that you can use in your forms are covered by the Blazor reference documentation.

## Add validation to the `Movie` model

Add the following data annotations to the `Movie` class properties. To update all of the properties at once, you can copy and paste the entire `Models/Movie.cs` file, which appears after the following code example.

```diff
+ [Required]
+ [StringLength(60, MinimumLength = 3)]
  public string? Title { get; set; }

+ [Required]
* [StringLength(30)]
+ [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$")]
  public string? Genre { get; set; }

+ [Range(0, 100)]
  [DataType(DataType.Currency)]
  [Column(TypeName = "decimal(18, 2)")]
  public decimal Price { get; set; }
```

<!-- HOLD for a later version of the tutorial
     when QuickGrid has display name support per
     https://github.com/dotnet/aspnetcore/issues/49147.

     Add to the diff:

     + [Display(Name = "Release Date")]
       public DateOnly ReleaseDate { get; set; }

     And the following text:
     
     The [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute) with a <xref:System.ComponentModel.DataAnnotations.DisplayAttribute.Name> is used to present the name of the property as `Release Date`, which includes a space.

     Update the following example to include the added attribute. Setting the Title
     on the QG component won't be necessary, so that instruction can be removed.
-->

`Models/Movie.cs` file after the preceding data annotations are applied to the properties:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebAppMovies.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }

    public DateOnly ReleaseDate { get; set; }

    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$")]
    public string? Genre { get; set; }

    [Range(0, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}
```

The preceding validation rules are merely for demonstration and aren't optimal for a production system. For example, the preceding validation prevents entering a movie with only one or two characters and doesn't allow additional special characters for a movie's genre.

## Create an EF Core migration and update the database

A data model schema defines how data is organized and connected within a relational database.

Adding the data annotations to the `Movie` class in the preceding section doesn't automatically result in matching changes to the database's schema.

Review the annotations applied to the `Title` property:

```csharp
[Required]
[StringLength(60, MinimumLength = 3)]
public string? Title { get; set; }
```

The difference between the model property and the database's schema are summarized in the following table. Neither constraint matches after the data annotation is applied to the `Movie` model.

Constraint | Model `Title` property | Database `Title` column
--- | :---: | :---:
Maximum length | 60 characters | Byte pairs up to ~2 GB&dagger;<br>[`NVARCHAR (MAX)`](/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql)
Required | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span><br>[`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) | <span aria-hidden="true">❌</span><span class="visually-hidden">No</span><br>`NULL` is permitted in the column.

&dagger;Database character columns are defined by *size* (byte pairs). One byte-pair per character is used for characters defined in the Unicode range 0 to 65,535. However, individual characters outside of that Unicode range take multiple byte-pairs to store, so the actual number of characters that a column can store is arbitrary. The important concept for our purposes in comparing the `Title` property of the `Movie` model and the database schema for the `Title` column is that ~2 GB of stored byte-pairs in the database far exceeds the 60 character limit set for the property. The database schema *should be adjusted downward* to match the app's constraint.

To match the `Movie` model's `Title` property length in the app, the database should indicate `NVARCHAR (60)` for the size of the `Title` column. The schema difference doesn't cause EF Core to throw an exception when the app is used because a user posting a 60 character movie title fits within the database's ~2 GB byte-pair limit for a movie title. However, consider the reverse situation where a model property is given a constraint larger than what the database permits and the user posts a string too long for a database character column: An exception is thrown by the database or data is truncated when the user posts the value. You should always keep the app's models aligned with the database's schema because a misaligned schema can cause exceptions and the storage of incorrect data.

Although the `Title` property is a [nullable reference type (NRT)](/dotnet/csharp/nullable-references#nullable-variable-annotations), as indicated by the `?` on the `string` type (`string?`), the database shouldn't store a `NULL` value in its `Title` column due to the model's `Required` constraint. When the database's schema is updated in the next step, the database's `Title` column should reflect `NOT NULL` for the `Title` column to match the property. The important concept is that just because a model property is an NRT and can hold a `null` value in code doesn't mean that the database column's schema should be nullable (`NULL` permitted). These are independent conditions used for different purposes: NRTs are used to prevent coding errors with nullable types, while the database schema reflects the exact type and size of stored data.

To align the model and the database schema, create and apply an EF Core *database migration* with a migration name that identifies the migration changes. The migration name is similar to a commit message in a version control system. In the following command examples, the migration name "`NewMovieDataAnnotations`" reflects that new data annotations are added to the `Movie` model.

> [!IMPORTANT]
> Make sure that the app isn't running for the next steps.
>
> Stopping the app when using Visual Studio only requires you to close the browser's window.
>
> When using VS Code, close the browser's window and stop the app in VS Code with **Run** > **Stop Debugging** or by pressing <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard.
>
> When using the .NET CLI, close the browser's window and stop the app in the command shell with <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS).

:::zone pivot="vs"

In Visual Studio **Solution Explorer**, double-click **Connected Services**. In the **Service Dependencies** area, select the ellipsis (`...`) followed by **Add migration** in the **SQL Server Express LocalDB** area.

Give the migration a **Migration name** of `NewMovieDataAnnotations` to describe the migration. Wait for the database context to load in the **DbContext class names** field. Select **Finish** to create the migration. Select the **Close** button when the operation completes.

Select the ellipsis (`...`) again followed by the **Update database** command.

The **Update database with the latest migration** dialog opens. Wait for the **DbContext class names** field to update and for prior migrations to load. Select the **Finish** button. Select the **Close** button when the operation completes.

:::zone-end

:::zone pivot="vsc"

Use the following command in the **Terminal** (**Terminal** menu > **New Terminal**) to add a migration for the new data annotations:

```dotnetcli
dotnet ef migrations add NewMovieDataAnnotations
```

To apply the migration to the database, execute the following command:

```dotnetcli
dotnet ef database update
```

:::zone-end

:::zone pivot="cli"

To add a migration for the new data annotations, execute the following command in a command shell opened to the project's root folder:

```dotnetcli
dotnet ef migrations add NewMovieDataAnnotations
```

To apply the migration to the database, execute the following command:

```dotnetcli
dotnet ef database update
```

:::zone-end

After applying the migration, the model property and the database's schema match, as summarized in the following table.

Constraint | Model `Title` property | Database `Title` column
--- | :---: | :---:
Maximum length | 60 characters | Sixty (60) byte pairs are permitted&dagger;.<br>[`NVARCHAR (60)`](/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql)
Required | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span><br>[`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span><br>`NOT NULL` is indicated for the column.

&dagger;Sixty (60) byte pairs is 60 characters if one byte-pair per character is used to store the movie title, which is true when using characters defined in the Unicode range 0 to 65,535.

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* <xref:mvc/views/working-with-forms>
* <xref:fundamentals/localization>
* <xref:mvc/views/tag-helpers/intro>
* <xref:mvc/views/tag-helpers/authoring>
* [Migrations overview (EF Core documentation)](/ef/core/managing-schemas/migrations/)
* [nchar and nvarchar (Transact-SQL) (SQL Server documentation)](/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql#remarks)
* [Blazor enhanced forms](xref:blazor/forms/index#enhanced-form-handling)

## Next steps

> [!div class="step-by-step"]
> [Previous: Work with a database](xref:blazor/tutorials/movie-database-app/part-4)
> [Next: Add search](xref:blazor/tutorials/movie-database-app/part-6)
