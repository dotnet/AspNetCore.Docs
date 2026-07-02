---
title: Part 8, add validation
author: wadepickett
description: Part 8 of tutorial series on Razor Pages.
ms.author: wpickett
ms.date: 01/09/2026
uid: tutorials/razor-pages/validation
---
# Part 8 of tutorial series on Razor Pages

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-10.0"

In this section, you add validation logic to the `Movie` model. The app enforces the validation rules any time a user creates or edits a movie.

## Validation

A key tenet of software development is called [DRY](https://wikipedia.org/wiki/Don%27t_repeat_yourself) ("**D**on't **R**epeat **Y**ourself"). Razor Pages encourages development where you specify functionality once, and it's reflected throughout the app. DRY can help:

* Reduce the amount of code in an app.
* Make the code less error prone, and easier to test and maintain.

The validation support that Razor Pages and Entity Framework provide is a good example of the DRY principle:

* You declaratively specify validation rules in one place, in the model class.
* The app enforces rules everywhere.

## Validation in .NET 10

In .NET 10, the unified validation APIs are in the `Microsoft.Extensions.Validation` NuGet package. By using this package, you can use the validation APIs outside of ASP.NET Core HTTP scenarios.

To use the `Microsoft.Extensions.Validation` APIs:

* Add the following package reference:

  ```xml
  <PackageReference Include="Microsoft.Extensions.Validation" Version="10.0.1" />
  ```

  The functionality is the same but now requires an explicit package reference.

* Register validation services by using dependency injection:

    ```csharp
    builder.Services.AddValidation();
    ```

## Add validation rules to the movie model

The <xref:System.ComponentModel.DataAnnotations> namespace provides:

* A set of built-in validation attributes that you apply declaratively to a class or property.
* Formatting attributes like `[DataType]` that help with formatting and don't provide any validation.

Update the `Movie` class to take advantage of the built-in `[Required]`, `[StringLength]`, `[RegularExpression]`, and `[Range]` validation attributes.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Models/MovieDateRatingDA.cs?name=snippet1)]

The validation attributes specify behavior to enforce on the model properties they're applied to:

* The `[Required]` and `[MinimumLength]` attributes indicate that a property must have a value. Nothing prevents a user from entering white space to satisfy this validation.
* The `[RegularExpression]` attribute limits what characters can be input. In the preceding code, `Genre`:

  * Must only use letters.
  * The first letter must be uppercase. White spaces are allowed, while numbers and special characters aren't allowed.

* The `RegularExpression` `Rating`:

  * Requires that the first character be an uppercase letter.
  * Allows special characters and numbers in subsequent spaces. "PG-13" is valid for a rating, but fails for a `Genre`.

* The `[Range]` attribute constrains a value to within a specified range.
* The `[StringLength]` attribute can set a maximum length of a string property, and optionally its minimum length.
* Value types, such as `decimal`, `int`, `float`, `DateTime`, are inherently required and don't need the `[Required]` attribute.

The preceding validation rules are for demonstration. They aren't optimal for a production system. For example, the preceding rules prevent entering a movie with only two characters and don't allow special characters in `Genre`.

By having ASP.NET Core automatically enforce validation rules, you can:

* Make the app more robust.
* Reduce chances of saving invalid data to the database.

### Validation error UI in Razor Pages

Run the app and go to **Pages/Movies**.

Select the **Create New** link. Complete the form with some invalid values. When jQuery client-side validation detects the error, it displays an error message.

:::image type="content" source="~/tutorials/razor-pages/validation/media/validation-errors.png" alt-text="Movie view form with multiple jQuery client-side validation errors.":::

[!INCLUDE[](~/includes/localization/currency.md)]

Notice how the form automatically renders a validation error message in each field containing an invalid value. The errors are enforced both client-side, by using JavaScript and jQuery, and server-side, when a user has JavaScript disabled.

A significant benefit is that **no** code changes are necessary in the Create or Edit pages. Once you apply data annotations to the model, the validation UI is enabled. The Razor Pages you created in this tutorial automatically pick up the validation rules, by using validation attributes on the properties of the `Movie` model class. To test validation by using the Edit page, the same validation is applied.

The form data isn't posted to the server until there are no client-side validation errors. Verify form data isn't posted by one or more of the following approaches:

* Put a break point in the `OnPostAsync` method. Submit the form by selecting **Create** or **Save**. The break point is never hit.
* Use the [Fiddler tool](https://www.telerik.com/fiddler).
* Use the browser developer tools to monitor network traffic.

### Server-side validation

When JavaScript is disabled in the browser, submitting the form with errors posts the form to the server.

To test server-side validation:

1. Disable JavaScript in the browser. Use the browser's developer tools to disable JavaScript. If you can't disable JavaScript in the browser, try another browser.
1. Set a break point in the `OnPostAsync` method of the Create or Edit page.
1. Submit a form with invalid data.
1. Verify the model state is invalid.

   ```csharp
    if (!ModelState.IsValid)
    {
       return Page();
    }
   ```
  
Alternatively, [disable client-side validation on the server](xref:mvc/models/validation#disable-client-side-validation).

The following code shows a portion of the `Create.cshtml` page scaffolded earlier in the tutorial. The Create and Edit pages use this code to:

* Display the initial form.
* Redisplay the form in the event of an error.

[!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Pages/Movies/Create.cshtml?range=14-20)]

The [Input Tag Helper](xref:mvc/views/working-with-forms) uses the [DataAnnotations](/aspnet/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-6) attributes and produces HTML attributes needed for jQuery Validation on the client. The [Validation Tag Helper](xref:mvc/views/working-with-forms#the-validation-tag-helpers) displays validation errors. For more information, see [Validation](xref:mvc/models/validation).

The Create and Edit pages don't contain validation rules. The validation rules and the error strings are specified only in the `Movie` class. These validation rules automatically apply to Razor Pages that edit the `Movie` model.

When you need to change validation logic, change it only in the model. By defining validation logic in one place, you ensure consistent validation throughout the app. Validation in one place helps keep the code clean and makes it easier to maintain and update.

## Use DataType attributes

Examine the `Movie` class. The `System.ComponentModel.DataAnnotations` namespace provides formatting attributes in addition to the built-in set of validation attributes. The `[DataType]` attribute is applied to the `ReleaseDate` and `Price` properties.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Models/MovieDateRatingDA.cs?highlight=2,6&name=snippet2)]

The `[DataType]` attributes provide:

* Hints for the view engine to format the data.
* Attributes such as `<a>` for URLs and `<a href="mailto:EmailAddress.com">` for email.

Use the `[RegularExpression]` attribute to validate the format of the data. Use the `[DataType]` attribute to specify a data type that's more specific than the database intrinsic type. `[DataType]` attributes aren't validation attributes. In the sample app, only the date is displayed, without time.

The `DataType` enumeration provides many data types, such as `Date`, `Time`, `PhoneNumber`, `Currency`, `EmailAddress`, and more. 

The `[DataType]` attributes:

* Can enable the app to automatically provide type-specific features. For example, a `mailto:` link can be created for `DataType.EmailAddress`.
* Can provide a date selector `DataType.Date` in browsers that support HTML5.
* Emit HTML 5 `data-`, pronounced "data dash", attributes that HTML 5 browsers consume.
* Do **not** provide any validation.

`DataType.Date` doesn't specify the format of the date that's displayed. By default, the data field is displayed according to the default formats based on the server's `CultureInfo`.

The `[Column(TypeName = "decimal(18, 2)")]` data annotation is required so Entity Framework Core can correctly map `Price` to currency in the database. For more information, see [Data Types](/ef/core/modeling/relational/data-types).

The `[DisplayFormat]` attribute is used to explicitly specify the date format:

```csharp
[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
public DateTime ReleaseDate { get; set; }
```

The `ApplyFormatInEditMode` setting specifies that the formatting is applied when the value is displayed for editing. That behavior might not be wanted for some fields. For example, in currency values, the currency symbol is usually not wanted in the edit UI.

The `[DisplayFormat]` attribute can be used by itself, but it's generally a good idea to use the `[DataType]` attribute. The `[DataType]` attribute conveys the semantics of the data as opposed to how to render it on a screen. The `[DataType]` attribute provides the following benefits that aren't available with `[DisplayFormat]`:

* The browser can enable HTML5 features, for example to show a calendar control, the locale-appropriate currency symbol, email links, and more.
* By default, the browser renders data using the correct format based on its locale.
* The `[DataType]` attribute can enable the ASP.NET Core framework to choose the right field template to render the data. The `DisplayFormat`, if used by itself, uses the string template.

**Note:** jQuery validation doesn't work with the `[Range]` attribute and `DateTime`. For example, the following code always displays a client-side validation error, even when the date is in the specified range:

```csharp
[Range(typeof(DateTime), "1/1/1966", "1/1/2020")]
   ```

It's a best practice to avoid compiling hard dates in models, so using the `[Range]` attribute and `DateTime` is discouraged. Use [Configuration](xref:fundamentals/configuration/index) for date ranges and other values that are subject to frequent change rather than specifying it in code.

The following code shows combining attributes on one line:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Models/MovieDateRatingDAmult.cs?name=snippet1)]

[Get started with Razor Pages and EF Core](xref:data/ef-rp/intro) shows advanced EF Core operations with Razor Pages.

### Apply migrations

The DataAnnotations you apply to the class change the schema. For example, the DataAnnotations you apply to the `Title` field:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Models/MovieDateRatingDA.cs?name=snippet11)]

* Limit the characters to 60.
* Doesn't allow a `null` value.

The `Movie` table currently has the following schema:

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

The preceding schema changes don't cause EF to throw an exception. However, create a migration so the schema is consistent with the model.

# [Visual Studio](#tab/visual-studio)

From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
In the PMC, enter the following commands:

```powershell
Add-Migration New_DataAnnotations
Update-Database
```

`Update-Database` runs the `Up` method of the `New_DataAnnotations` class.

# [Visual Studio Code](#tab/visual-studio-code)

Use the following commands to add a migration for the new DataAnnotations:

```dotnetcli
dotnet ef migrations add New_DataAnnotations
dotnet ef database update
```

`dotnet ef database update` runs the `Up` method of the `New_DataAnnotations` class.

---

Examine the `Up` method:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Migrations/20230606012811_New_DataAnnotations.cs?name=snippet_1)]

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

### Publish to Azure

For information on deploying to Azure, see [Tutorial: Build an ASP.NET Core app in Azure with SQL Database](/azure/app-service/tutorial-dotnetcore-sqldb-app).

Thanks for completing this introduction to Razor Pages. [Get started with Razor Pages and EF Core](xref:data/ef-rp/intro) is an excellent follow up to this tutorial.

## Additional resources

* <xref:mvc/views/working-with-forms>
* <xref:fundamentals/localization>
* <xref:mvc/views/tag-helpers/intro>
* <xref:mvc/views/tag-helpers/authoring>

## Next steps

> [!div class="step-by-step"]
> [Previous: Add a new field](xref:tutorials/razor-pages/new-field)
:::moniker-end

[!INCLUDE[](~/tutorials/razor-pages/validation/includes/validation9.md)]

[!INCLUDE[](~/tutorials/razor-pages/validation/includes/validation8.md)]

[!INCLUDE[](~/tutorials/razor-pages/validation/includes/validation7.md)]

[!INCLUDE[](~/tutorials/razor-pages/validation/includes/validation6.md)]

[!INCLUDE[](~/tutorials/razor-pages/validation/includes/validation3-5.md)]
