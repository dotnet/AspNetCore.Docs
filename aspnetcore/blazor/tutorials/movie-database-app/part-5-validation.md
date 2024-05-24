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
* [`[StringLength]`](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute): Specifies the minimum and maximum length of characters. Note that a `MinimumLength` passed to the attribute doesn't make the string required (apply the [`[Required]` attribute](xref:System.ComponentModel.DataAnnotations.RequiredAttribute)).
* [`[Phone]`](xref:System.ComponentModel.DataAnnotations.PhoneAttribute): Validates that the property has a telephone number format.
* [`[RegularExpression]`](xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute): Specify a pattern to match for the user's input. In the following example, `Genre` must start with an uppercase letter and only consist of letters, parentheses, spaces, and dashes.
* [`[Range]`](xref:System.ComponentModel.DataAnnotations.RangeAttribute): Specify the minimum and maximum values.
* [`[Url]`](xref:System.ComponentModel.DataAnnotations.UrlAttribute): Validates that the property has a URL format.

Value types, such as `decimal`, `int`, `float`, and `DateTime`, are inherently required, so placing a [`[Required]` attribute](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) on value types isn't necessary.

Add the following data annotations to the `Movie` class properties. To update all of the properties at once, you can copy and paste the entire `Models/Movie.cs` file.

```diff
+ [Required, StringLength(60, MinimumLength = 3)]
  public string? Title { get; set; }

+ [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$"), Required, StringLength(30)]
  public string? Genre { get; set; }

+ [Range(1, 100)]
  public decimal Price { get; set; }
```

`Models/Movie.cs` file after updates:

```csharp
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models
{
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
}
```

The preceding validation rules are merely for demonstration and aren't optimal for a production system. For example, the preceding validation prevents entering a movie with only two characters, doesn't allow additional special characters in `Genre`, and requires that movies cost at least 1 full unit of a particular currency, such as one dollar, euro, or yen.

Because the app only processes validation server-side, submitting the form with errors posts the form to the server without any client-side indication that there are errors in the user's entries.

## Apply migrations

A data model schema defines how data is organized and connected within a relational database.

Adding the data annotations to the `Movie` class in the preceding section doesn't automatically result in matching changes to the database's schema.

Review the annotations applied to the `Title` field:

```csharp
[Required, StringLength(60, MinimumLength = 3)]
public string? Title { get; set; }
```

The difference between the model property and the database's schema are summarized in the following table. Neither constraint matches after the data annotation is applied to the `Movie` model.

Constraint | Model `Title` property | Database `Title` column
::: | ::: | :::
Maximum length | 60 characters | Byte pairs up to ~2 GB&dagger;<br>[`NVARCHAR (MAX)`](/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql)
Required | <span aria-hidden="true">✔️</span><span class="visually-hidden">Yes</span><br>[`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) | <span aria-hidden="true">❌</span><span class="visually-hidden">No</span><br>`NULL` is permitted in the column.

&dagger;Database character columns are defined by *size* (byte pairs). One byte-pair per character is used for characters defined in the Unicode range 0 to 65,535. However, individual characters outside of that Unicode range take multiple byte-pairs to store, so the actual number of characters that a column can store is arbitrary. The important concept for our purposes in comparing the `Title` property of the `Movie` model and the database schema for the `Title` column is that ~2 GB of stored byte-pairs in the database far exceeds the 60 character limit set for the property. The database schema *should be adjusted downward* to match the app's constraint.

To match the `Movie` model's `Title` property length in the app, the database should indicate `NVARCHAR (60)` for the size of the `Title` column. The schema difference doesn't cause EF Core to throw an exception when the app is used because a user posting a 60 character movie title fits within the database's ~2 GB byte-pair limit for a movie title. However, consider the reverse situation where a model property is given a constraint larger than what the database permits and the user posts a string too long for a database character column: An exception is thrown by the database or data is truncated when the user posts the value. You should always keep the app's models aligned with the database's schema because a misaligned schema can cause exceptions and the storage of incorrect data.

Although the `Title` property is a [nullable reference type (NRT)](/dotnet/csharp/nullable-references#nullable-variable-annotations), as indicated by the `?` on the `string` type (`string?`), the database shouldn't store a `NULL` value in its `Title` column due to the model's `Required` constraint. When the database's schema is updated in the next step, the database's `Title` column should reflect `NOT NULL` for the `Title` column to match the property. The important concept is that just because a model property is an NRT and can hold a `null` value in code doesn't mean that the database column's schema should be nullable (`NULL` permitted). These are independent conditions used for different purposes: NRTs are used to prevent coding errors with nullable types, while the database schema reflects exactly the type and size of stored data.

To align the model and the database schema, create and apply an EF Core *database migration* with a migration name that identifies the migration changes. The migration name is similar to a commit message in a version control system. In the following command examples, the migration name "`NewMovieDataAnnotations`" reflects that new data annotations are added to the `Movie` model.

:::zone pivot="vs"

From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console**.

In the console, enter the following command:

```powershell
Add-Migration NewMovieDataAnnotations
```

:::zone-end

:::zone pivot="vsc"

Use the following command in a command shell to add a migration for the new Data Annotations:

```dotnetcli
dotnet ef migrations add NewMovieDataAnnotations
```

:::zone-end

:::zone pivot="cli"

Use the following command in a command shell to add a migration for the new Data Annotations:

```dotnetcli
dotnet ef migrations add NewMovieDataAnnotations
```

:::zone-end

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

After applying the migration, the model property and the database's schema match, as summarized in the following table.

Constraint | Model `Title` property | Database `Title` column
::: | ::: | :::
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

## Next steps

> [!div class="step-by-step"]
> [Previous: Work with a database](xref:blazor/tutorials/movie-database/database)
> [Next: Add search](xref:blazor/tutorials/movie-database/search)



> [Previous: Add a new field](xref:blazor/tutorials/movie-database/new-field)
> [Next: Add interactivity](xref:blazor/tutorials/movie-database/interactivity)
