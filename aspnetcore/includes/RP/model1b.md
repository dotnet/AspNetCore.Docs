<!-- THIS INCLUDE USED BY MVC AND RP -->
Add the following properties to the `Movie` class:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Models/Movie.cs?name=snippet1)]

The `Movie` class contains:

* The `ID` field is required by the database for the primary key.
* `[DataType(DataType.Date)]`:  The [DataType](xref:System.ComponentModel.DataAnnotations.DataTypeAttribute) attribute specifies the type of the data (Date). With this attribute:

  * The user is not required to enter time information in the date field.
  * Only the date is displayed, not time information.

[DataAnnotations](/dotnet/api/system.componentmodel.dataannotations) are covered in a later tutorial.
