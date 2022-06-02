<!-- USED in RP and MVC tutorial for .NET 5 and earlier-->

## Add validation rules to the movie model

The DataAnnotations namespace provides a set of built-in validation attributes that are applied declaratively to a class or property. DataAnnotations also contains formatting attributes like `DataType` that help with formatting and don't provide any validation.

Update the `Movie` class to take advantage of the built-in `Required`, `StringLength`, `RegularExpression`, and `Range` validation attributes.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie22/Models/MovieDateRatingDA.cs?name=snippet1)]

The validation attributes specify behavior that you want to enforce on the model properties they're applied to:

* The `Required` and `MinimumLength` attributes indicate that a property must have a value; but nothing prevents a user from entering white space to satisfy this validation.
* The `RegularExpression` attribute is used to limit what characters can be input. In the preceding code, "Genre":

  * Must only use letters.
  * The first letter is required to be uppercase. White spaces are allowed while numbers, and special
   characters are not allowed.

* The `RegularExpression` "Rating":

  * Requires that the first character be an uppercase letter.
  * Allows special characters and numbers in subsequent spaces. "PG-13" is valid for a rating, but fails for a "Genre".

* The `Range` attribute constrains a value to within a specified range.
* The `StringLength` attribute lets you set the maximum length of a string property, and optionally its minimum length.
* Value types (such as `decimal`, `int`, `float`, `DateTime`) are inherently required and don't need the `[Required]` attribute.

Having validation rules automatically enforced by ASP.NET Core helps make your app more robust. It also ensures that you can't forget to validate something and inadvertently let bad data into the database.
