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

This part of the series covers adding metadata (data annotations) to the `Movie` model to validate user input in the forms that create and edit movies.



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

Validation rules are specified on a model class using *data annotations*.

<xref:System.ComponentModel.DataAnnotations> are a broad set of attribute classes that define metadata about a model's properties that are used to implement additional features or functionality. They're placed above a model's property with the following format, where the `{ANNOTATION}` placeholder is the annotation name:

```csharp
[{ANNOTATION}]
```

Multiple annotations can appear on multiple lines, or they can appear on the same line separated by commas:

```csharp
[{ANNOTATION_1}]
[{ANNOTATION_2}]
[{ANNOTATION_3}, {ANNOTATION_4}, [{ANNOTATION_5}]
```

The following list includes commonly used <xref:System.ComponentModel.DataAnnotations> attributes for user input validation of public properties on a form's model:

<!-- 
     I'm concerned about telling readers that they can just look at 
     the DA API to see all of them because I know that they don't all 
     work OOB (e.g., [Display(Name="xxx")]). I've opened an issue to 
     work on this further in the Blazor forms validation article: 
     https://github.com/dotnet/AspNetCore.Docs/issues/32639
-->

* [`[Compare]`](xref:System.ComponentModel.DataAnnotations.CompareAttribute): Validates that two properties in a model match.
* [`[CreditCard]`](xref:System.ComponentModel.DataAnnotations.CreditCardAttribute): Validates that the property has a credit card format according to the [Luhn algorithm](https://wikipedia.org/wiki/Luhn_algorithm).
* [`[EmailAddress]`](xref:System.ComponentModel.DataAnnotations.EmailAddressAttribute): Validates that the property has an email format.
* [`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute): Require that the user provide a value.
* [`[StringLength]`](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute): Specify the maximum string length.
* [`[Phone]`](xref:System.ComponentModel.DataAnnotations.PhoneAttribute): Validates that the property has a telephone number format.
* [`[RegularExpression]`](xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute): Specify a pattern to match for the user's input. In the following example, `Genre` must:
  * start with an uppercase letter.
  * Only consist of letters, parentheses, spaces, and dashes.
* [`[Range]`](xref:System.ComponentModel.DataAnnotations.RangeAttribute): Specify the minimum and maximum values.
* [`[Url]`](xref:System.ComponentModel.DataAnnotations.UrlAttribute): Validates that the property has a URL format.

Value types, such as `decimal`, `int`, `float`, and `DateTime`, are inherently required, so placing a [`[Required]` attribute](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) on value types isn't necessary.

Add the following data annotations to the `Movie` class properties:

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

The preceding validation rules are merely for demonstration and aren't optimal for a production system. For example, the preceding validation prevents entering a movie with only two characters, doesn't allow additional special characters in `Genre`, and requires that movies cost at least 1 full unit of a particular currency, such as one dollar, euro, or yen.

Because the app only processes validation server-side, submitting the form with errors posts the form to the server without any client-side indication that there are errors in the user's entries.

## Apply migrations

A data model schema defines how data is organized and connected within a relational database.

The data annotations applied to the `Movie` class in the preceding section change the model's *schema*, but they don't automatically make matching changes to the database's schema.

For example, the annotations applied to the `Title` field limit the length to 60 characters with a minimum of three characters:

```csharp
[Required, StringLength(60, MinimumLength = 3)]
public string? Title { get; set; }
```

The `Movie` table's `CREATE TABLE` statement indicates the table's schema:

* The column (field) names are in brackets. Example: `[Title]` for the title column.
* The database type follows the column name. Example: `INT` for an integer.
* An `IDENTITY` property indicates an automatically-numbered column, typically used to key the data in the table with a unique value for each row (entity). Example: `IDENTITY (1, 1)` starts numbering rows at 1 and increments by 1 for each added row.
* The nullability of the column is indicated. Example: `NULL` permits a field of a row to have no value.
* Other keywords are indicated, such as constraints (`CONSTRAINT`) on the keys of the table.

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

The `Title` column is a nullable value much larger than 60 characters, as indicated by [`NVARCHAR (MAX) NULL`](/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql), which differs from the model's schema.

To match the `Movie` model's schema in the app, it should indicate `NVARCHAR (60)` and `NOT NULL` for the `Title` column. The schema difference doesn't cause EF Core to throw an exception when the app is used. However, you should always keep the schemas aligned because a misaligned schema can cause errors and data anomalies. To align the schemas, create and apply an EF Core *database migration*.

:::zone pivot="vs"

From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console**.

In the console, enter the following command:

```powershell
Add-Migration New_DataAnnotations
```

:::zone-end

:::zone pivot="vsc"

Use the following commands to add a migration for the new Data Annotations:

```dotnetcli
dotnet ef migrations add New_DataAnnotations
```

:::zone-end

:::zone pivot="cli"

Use the following commands to add a migration for the new Data Annotations:

```dotnetcli
dotnet ef migrations add New_DataAnnotations
```

:::zone-end

The name `New_DataAnnotations` is a freeform descriptor that you can use to specify what the migration is changing. In this case, new data annotations are applied.

:::zone pivot="vs"

To apply the migration to the database, execute the following command in the **Package Manager Console**:

```
Update-Database
```

:::zone-end

:::zone pivot="vsc"

To apply the migration to the database, execute the following command in a command shell:

```dotnetcli
dotnet ef database update
```

:::zone-end

:::zone pivot="cli"

To apply the migration to the database, execute the following command in a command shell:

```dotnetcli
dotnet ef database update
```

:::zone-end

The updated `CREATE TABLE` statement indicates the revised schema:

```sql
CREATE TABLE [dbo].[Movie] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (60)   DEFAULT (N'') NOT NULL,
    [ReleaseDate] DATETIME2 (7)   NOT NULL,
    [Genre]       NVARCHAR (30)   DEFAULT (N'') NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

The `Title` column is now a non-nullable, 60 character field (`NVARCHAR (60)` with `NOT NULL`), which matches the database (`[Required, StringLength(60, MinimumLength = 3)]`). The `DEFAULT` constraint indicates a default value with `N''` representing a Unicode empty string. Not all EF Core releases include the `DEFAULT` constraint when generating a `CREATE TABLE` statement.

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
