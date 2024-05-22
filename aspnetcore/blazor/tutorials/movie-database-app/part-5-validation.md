---
title: Build a Blazor movie database app (Part 5 - Add validation)
author: guardrex
description: This part of the Blazor movie database app tutorial explains ...
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/06/2024
uid: blazor/tutorials/movie-database/validation
---
# Build a Blazor movie database app (Part 5 - Add validation)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the fifth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the series covers annotating the movie model 

In this section, validation logic is added to the `Movie` model. The validation rules are enforced any time a user creates or edits a movie.

## Data annotations

*Data annotations* are attribute classes that are used to define metadata about a model's properties that are used to implement additional features or functionality. Data annotations above a model's property use the following format, where the `{ANNOTATION}` placeholder is the annotation:

```csharp
[{ANNOTATION}]
```

Multiple annotations can appear on multiple lines, or they can appear on the same line separated by commas:

```csharp
[{ANNOTATION_1}]
[{ANNOTATION_2}]
[{ANNOTATION_3}, {ANNOTATION_4}, [{ANNOTATION_5}]
```

<!-- HOLD becuase I think DataType no-ops in Blazor
     Also, I'm not sure if remark on cultureinfo is correct

Open the app's `Movie` model (`Models/Movie.cs`) and inspect the `ReleaseDate` property:

```csharp
[DataType(DataType.Date)]
public DateTime ReleaseDate { get; set; }
```

The [`[DataType]` attribute](xref:System.ComponentModel.DataAnnotations.DataTypeAttribute) specifies the name of an additional type to associate with `ReleaseDate`. In this case, the type of data is a date (<xref:System.ComponentModel.DataAnnotations.DataType.Date?displayProperty=nameWithType>). By default, the data field is displayed according to the default formats based on the server's `CultureInfo`.

For more information, see [Data Types](/ef/core/modeling/relational/data-types).
-->

<!-- HOLD for a later version of the tutorial
     when QuickGrid has display name support
     Dan's issue: https://github.com/dotnet/aspnetcore/issues/49147

Add the [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute) attribute to the `ReleaseDate` property with a <xref:System.ComponentModel.DataAnnotations.DisplayAttribute.Name> to present the name of the property as `Release Date`, which includes a space. You have a choice on placing attributes on separate lines or on the same line. Select one of the approaches and use it consistently throughout the app. The following examples place attributes in alphabetical order.

* Place attributes on separate lines:

  ```csharp
  [DataType(DataType.Date)]
  [Display(Name = "Release Date")]
  public DateTime ReleaseDate { get; set; }
  ```
  
* Place attributes on the same line separated by commas:

  ```csharp
  [DataType(DataType.Date), Display(Name = "Release Date")]
  public DateTime ReleaseDate { get; set; }
  ```
-->

## Validation

Validation rules are specified on the model class to enforce them for forms in the app.

The following <xref:System.ComponentModel.DataAnnotations> attributes are applied to class properties to supply metadata for validation:

* [`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute): Require that the user provide a value.
* [`[StringLength]`](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute): Specify the maximum string length.
* [`[RegularExpression]`](xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute): Specify a pattern to match for the user's input. In the following example, `Genre` must:
  * start with an uppercase letter.
  * Only consist of letters, parentheses, spaces, and dashes.
* [`[Range]`](xref:System.ComponentModel.DataAnnotations.RangeAttribute): Specify the minimum and maximum values.

> [!NOTE]
> Value types, such as `decimal`, `int`, `float`, and `DateTime`, are inherently required and don't require the [`[Required]` attribute](xref:System.ComponentModel.DataAnnotations.RequiredAttribute).

Add the following annotations to the `Movie` class properties:

```diff
+ [Required, StringLength(60, MinimumLength = 3)]
  public string? Title { get; set; }

+ [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$"), Required, StringLength(30)]
  public string? Genre { get; set; }

+ [Range(1, 100)]
  public decimal Price { get; set; }
```

To update all of the properties at once, you can copy and paste the following file contents into `Models/Movie.cs`. The following code uses a [C# file scoped namespace](/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces) to reduce the level of indentation by placing the namespace on one line and dropping the braces around the properties:

```csharp
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models;

public class Movie
{
   public int Id { get; set; }

   [Required, StringLength(60, MinimumLength = 3)]
   public string? Title { get; set; }

   [DataType(DataType.Date)]
   public DateTime ReleaseDate { get; set; }

   [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$"), Required, StringLength(30)]
   public string? Genre { get; set; }

   [Range(1, 100)]
   public decimal Price { get; set; }
}
```

The preceding validation rules are merely for demonstration and aren't optimal for a production system. For example, the preceding validation prevents entering a movie with only two characters, doesn't allow additional special characters in `Genre`, and requires that movies cost at least 1 unit of currency.

## Server-side validation

Submitting the form with errors posts the form to the server without any client-side indication that there are errors in the user's entries.

## Apply migrations

The Data Annotations applied to the `Movie` class change the schema. For example, the annotations applied to the `Title` field limit the length to 60 characters with a minimum of three characters:

```csharp
[Required, StringLength(60, MinimumLength = 3)]
public string? Title { get; set; }
```

However, the `Movie` table in the database currently has the following schema:

```sql
CREATE TABLE [dbo].[Movie] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX)  NULL,
    [ReleaseDate] DATETIME2 (7)   NOT NULL,
    [Genre]       NVARCHAR (MAX)  NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [Rating]      NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([ID] ASC)
);
```

You can see that the `Title` field is a nullable `NVARCHAR(MAX)` type, which differs from the model's schema. The schema difference doesn't cause EF Core to throw an exception. However, create a migration to make the schema consistent between the model and the database.

:::zone pivot="vs"

From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.

In the console, enter the following commands:

```powershell
Add-Migration New_DataAnnotations
Update-Database
```

`Update-Database` runs the `Up` method of the `New_DataAnnotations` class.

:::zone-end

:::zone pivot="vsc"

Use the following commands to add a migration for the new Data Annotations:

```dotnetcli
dotnet ef migrations add New_DataAnnotations
dotnet ef database update
```

`dotnet ef database update` runs the `Up` method of the `New_DataAnnotations` class.

:::zone-end

:::zone pivot="cli"

Use the following commands to add a migration for the new Data Annotations:

```dotnetcli
dotnet ef migrations add New_DataAnnotations
dotnet ef database update
```

`dotnet ef database update` runs the `Up` method of the `New_DataAnnotations` class.

:::zone-end

Examine the following part of the `Up` method:

```csharp
migrationBuilder.AlterColumn<string>(
    name: "Title",
    table: "Movie",
    type: "nvarchar(60)",
    maxLength: 60,
    nullable: false,
    oldClrType: typeof(string),
    oldType: "nvarchar(max)");

migrationBuilder.AlterColumn<string>(
    name: "Rating",
    table: "Movie",
    type: "nvarchar(5)",
    maxLength: 5,
    nullable: false,
    oldClrType: typeof(string),
    oldType: "nvarchar(max)");

migrationBuilder.AlterColumn<string>(
    name: "Genre",
    table: "Movie",
    type: "nvarchar(30)",
    maxLength: 30,
    nullable: false,
    oldClrType: typeof(string),
    oldType: "nvarchar(max)");
```

The updated `Movie` table has the following schema:

```sql
CREATE TABLE [dbo].[Movie] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (60)   NOT NULL,
    [ReleaseDate] DATETIME2 (7)   NOT NULL,
    [Genre]       NVARCHAR (30)   NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [Rating]      NVARCHAR (5)    NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([ID] ASC)
);
```

Now, the database's schema reflects the `Title` field as a non-nullable `NVARCHAR(60)`.

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* <xref:mvc/views/working-with-forms>
* <xref:fundamentals/localization>
* <xref:mvc/views/tag-helpers/intro>
* <xref:mvc/views/tag-helpers/authoring>

## Next steps

> [!div class="step-by-step"]
> [Previous: Work with a database](xref:blazor/tutorials/movie-database/database)
> [Next: Add search](xref:blazor/tutorials/movie-database/search)



> [Previous: Add a new field](xref:blazor/tutorials/movie-database/new-field)
> [Next: Add interactivity](xref:blazor/tutorials/movie-database/interactivity)
