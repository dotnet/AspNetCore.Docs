---
title: Model Binding in ASP.NET Core
author: tdykstra
description: Learn how model binding in ASP.NET Core works and how to customize its behavior.
ms.assetid: 0be164aa-1d72-4192-bd6b-192c9c301164
ms.author: tdykstra
ms.date: 11/13/2018
uid: mvc/models/model-binding
---

# Model Binding in ASP.NET Corem

This article explains what model binding is, how it works, and how to customize its behavior.


[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/mvc/models/model-binding/samples) ([how to download](xref:index#how-to-download-a-sample)).

## What is Model binding

Controllers and Razor pages work with data that comes from HTTP requests. For example, route data may provide a record key, and posted form fields may provide values for the properties of the model. Writing code to retrieve each of these values and convert them from strings to .NET types would be tedious and error-prone. Model binding automates this process. The model binding system:

* Retrieves data from various sources such as route data, form fields, and query strings.
* Provides the data to controllers and Razor pages in method parameters and public properties.
* Converts string data to .NET types.
* Updates properties of complex types.

## Example

Suppose the following action meethod handles the following URL:

```csharp
[HttpGet("{id}")]
public ActionResult<Pet> GetById(int id, bool dogsOnly)
{
    ...
}
```

```
http://contoso.com/api/pets/2?DogsOnly=true
```

Model binding goes though the following steps after the routing system selects the action method:

* Finds the first parameter of `GetByID` to bind, an integer named `id`.
* Looks through the available sources in the HTTP request and finds `id` = "2" in route data.
* Converts the string "2" into integer 2.
* Finds the next parameter of `GetByID` to bind, a boolean named `dogsOnly`.
* Looks through the sources and finds `DogsOnly` = "true" in the query string. Name matching is not case-sensitive.
* Converts the string "true" into boolean `true`.

The framework then calls the `GetById` method, passing in 2 for the `id` parameter, and `true` for the `dogsOnly` parameter.

In the preceding example, the model binding targets are method parameters that are simple types. Targets may also be the properties of a complex type. After each property is successfully bound, [model validation](xref:mvc/models/validation) occurs for that property. The record of what data is bound to the model, and any binding or validation errors, is stored in [ControllerBase.ModelState](xref:Microsoft.AspNetCore.Mvc.ControllerBase.ModelState) or [PageModel.ModelState](xref:Microsoft.AspNetCore.Mvc.ControllerBase.ModelState). To find out if this process was successful, the app checks the [ModelState.IsValid](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.IsValid) flag.

## Targets

The targets that model binding tries to find values for include the following:

* Parameters of the controller action method that a request is routed to.
* Parameters of the Razor Pages handler method that a request is routed to. 
* Public properties of a Razor Pages `PageModel` class.

### Binding to Razor page properties

The `[BindProperty]` attribute tells model binding to target a property of a Razor Pages `PageModel` class:

```csharp
public class EditModel : PageModel
{
    ...
    [BindProperty]
    public Instructor Instructor { get; set; }
    ...
}
```

In ASP.NET Core 2.1 and later, the `[BindProperties]` attribute on a `PageModel` class tells model binding to target all public properties of that class:

```csharp
[BindProperties]
public class EditModel : PageModel
{
    ...
    public Instructor Instructor { get; set; }
    ...
}
```

By default, model binding doesn't update `PageModel` properties for HTTP GET requests, even when these attributes are used. To change this behavior, set the `SupportsGet` property to `true`:

```csharp
[BindProperty(SupportsGet = true)]
public Instructor Instructor { get; set; }
```

## Sources

Model binding automatically gets data in the form of key-value pairs from the following sources in an HTTP request:

1. Form fields (`Request.Form`)
1. The request body (`Request.Body`)
1. Route data (`RouteData.Values`)
1. Query string parameters (`Request.QueryString`)
1. Uploaded files (`Request.Files`)

For each target, sources are scanned in this order, with the following exceptions:

* Form fields and request body data are used only for properties of complex types.
* The request body is used automatically only by controllers that have the `[ApiController]` attribute. See [Binding source parameter inference](xref:web-api/index#binding-source-parameter-inference).
* Route data is used only for simple types.
* Uploaded files are bound only to target types that implement `IFormFile` or `IEnumerable<IFormFile>`.

If the default behavior doesn't give the right results, you can use attributes to specify the sources to use for any given target. 

### [FromHeader] attribute

Gets values from HTTP headers. For some headers you can't make a C# parameter or property name that matches the header name because the header name has a hyphen in it.  In these cases, provide the header name to the attribute constructor:

```csharp
public IActionResult Read([FromHeader(Name ="Accept-Language")] string language)
{
    ...
}
```

### [FromQuery] attribute

Gets values from the query string. The attribute must be added to model properties individually (not to the model class).

```csharp
public class Criteria
{
    [FromQuery(Name = "first_name")]
    public string FirstName { get; set; }
}
```

### [FromRoute] attribute

Gets values from route data.

### [FromForm] attribute

Gets values from posted form fields.

### [FromBody] attribute

Gets values from the request body.  The data is parsed by using input formatters specific to the content type of the request.

Don't apply `[FromBody]` to more than one one parameter per action method. The ASP.NET Core runtime delegates the responsibility of reading the request stream to the input formatter. Once the request stream is read, it's no longer available to be read again for binding other `[FromBody]` parameters.

Input formatters are covered [later in this article](#input-formatters).

### [FromServices] attribute

Gets an instance of a type from the [dependency injection](xref:fundamentals/dependency-injection) container. An alternative to constructor injection that uses fewer resources when you need a service only if a particular method is called.

### Additional sources

You can write and register custom value providers that get data for model binding from other sources. For example, you might want data from cookies or session state. To get data from a new source, create classes that implement `IValueProvider` and `IValueProviderFactory`, and register the factory class in `Startup.ConfigureServices`.

Here's a sample value provider that provides two hard-coded key-value pairs:

[!code-csharp[](model-binding/samples/2.x/MyValueProvider.cs)]

Here's the factory class:

[!code-csharp[](model-binding/samples/2.x/MyValueProviderFactory.cs)]

And here's the registration code in `Startup.ConfigureServices`:

[!code-csharp[](model-binding/samples/2.x/Startup.cs?name=snippet_ValueProvider&highlight=3)]

The code shown puts the custom value provider after all the built-in value providers.  To make it the first in the list, call `Insert(0, new CustomValueProviderFactory())` instead of `Add`.

## No source for a target

By default, `ModelState.IsValid` is not set to `true` if no value is found for a target. The target is set to null or a default value:

* Nullable simple types are set to `null`.
* Non-nullable value types are set to `default(T)`. For example, a parameter `int id` is set to 0.
* Complex Types: model binding creates an instance of a class with the default constructor without setting properties.
* Arrays are set to `Array.Empty<T>()`, except that `byte[]` arrays are set to `null`.

 For information about how to change this behavior, see [[BindRequired] attribute](#bindrequired-attribute) later in this article.

## Type conversion errors

If a source is found but can't be converted into the target type, model state is flagged as invalid. The target is set to null or a default value, as noted in the previous section.

In an API controller that is decorated with the `[ApiController]` attribute, invalid model state results in an automatic HTTP 400 response.

In a Razor page, redisplay the page with an error message:

[!code-csharp[](model-binding/samples/2.x/Pages/Instructors/Create.cshtml.cs&name=snippet_HandleMBError&highlight=3-6)]

In production, client-side validation catches most bad data that would otherwise be submitted to a Razor page form. This validation makes it hard to trigger the preceding highlighted code even deliberately. The sample app includes a **Submit with Invalid Date** button that puts bad data in the **Hire Date** field and submits the form to show how this code for redisplaying the page works.

## Simple types

The simple types that the model binder can convert source strings into include the following:

* [Boolean](xref:System.ComponentModel.BooleanConverter)
* [Char](xref:System.ComponentModel.CharConverter)
* [DateTime](xref:System.ComponentModel.DateTimeConverter)
* [DateTimeOffset](xref:System.ComponentModel.DateTimeOffsetConverter)
* [Decimal](xref:System.ComponentModel.DecimalConverter)
* [Double](xref:System.ComponentModel.DoubleConverter)
* [Enum](xref:System.ComponentModel.EnumConverter)
* [Guid](xref:System.ComponentModel.GuidConverter)
* [Int16](xref:System.ComponentModel.Int16Converter), [Int32](xref:System.ComponentModel.Int132Converter), [Int64](xref:System.ComponentModel.Int64Converter)
* [Single](xref:System.ComponentModel.SingleConverter)
* [TimeSpan]](xref:System.ComponentModel.TimeSpanConverter)
* [UInt16](xref:System.ComponentModel.UInt16Converter), [UInt32](xref:System.ComponentModel.UInt132Converter), [UInt64](xref:System.ComponentModel.UInt64Converter)
* [Uri](xref:System.ComponentModel.UriConverter)
* [Version](xref:System.ComponentModel.VersionConverter)

## Complex types

A complex type must have a public default constructor and public writable properties to bind. When model binding occurs, the class is instantiated using the public default constructor. 

For each property of the complex type, model binding looks through the sources for the name pattern *prefix.property_name*. If nothing is found it looks for just *property_name* without the prefix.

For binding to a parameter, the prefix is the parameter name. For binding to a `PageModel` public property, the prefix is the public property name.

For example, suppose the complex type is the following `Instructor` class:

  ```csharp
  public class Instructor
  {
      public int ID { get; set; }
      public string LastName { get; set; }
      public string FirstName { get; set; }
      public DateTime HireDate { get; set; }
  }
  ```

### Binding to a method parameter

If the action or handler method signature is this:

  ```csharp
  public IActionResult OnPost(int? id, Instructor instructorToUpdate)
  ```

Model binding looks through the sources for the key `instructorToUpdate.ID`. If that isn't found, it looks for `ID` without a prefix. The process is repeated for each `Instructor` property.

### Binding to a PageModel public property

If the `PageModel` class has this:

```csharp
[BindProperty]
public Instructor Instructor { get; set; }
```

Model binding looks through the sources for the key `Instructor.ID`. If that isn't found, it looks for `ID` without a prefix. The process is repeated for each `Instructor` property.

## Collections

For collection targets, model binding looks for matches to *parameter_name* or *PageModel_public_property_name*. Multiple instances of the same name in source data are translated to successive elements of the collection. For example:

* The parameter is `int[] selectedCourses`.

  ```csharp
  public IActionResult OnPost(int? id, int[] selectedCourses)
  ```

* The form data is `selectedCourses=1050&selectedCourses=2000`.

* Model binding passes an array of two items to the selectedCourses parameter:

  * selectedCourses[0]=1050
  * selectedCourses[1]=2000

## Dictionaries

For `Dictionary` targets, model binding looks for matches to *parameter_name* or *PageModel_public_property_name*.  The form data can be in either of two formats:

* dictionary_name[key0]=value&dictionary_name[key1]=value&...
* dictionary_name[0].Key=key&dictionary_name[0].Value=value&dictionary_name[1].Key=key&dictionary_name[1].Value=value&...

For example:

* The target parameter is `selectedCourses`:

  ```csharp
  public IActionResult OnPost(int? id, Dictionary<int, string> selectedCourses)
  ```

* The posted form data can look like one of the following examples:

  ```
  selectedCourses[1050]=Chemistry&selectedCourses[4022]=Microeconomics&
  selectedCourses[4041]=Macroeconomics
  ```

  ```
  selectedCourses[0].Key=1050&selectedCourses[0].Value=Chemistry&
  selectedCourses[1].Key=4022&selectedCourses[1].Value=Microeconomics&
  selectedCourses[2].Key=4041&selectedCourses[2].Value=Macroeconomics
  ```

## Special data types

There are some special data types that model binding can handle.

### IFormFile

An uploaded file included in the HTTP request.  Also supported is `IEnumerable<IFormFile>` for multiple files.

### CancellationToken

Used to cancel activity in asynchronous controllers.

### FormCollection

Used to retrieve all the values from posted form data.

## [BindRequired] attribute

Can only be applied to model properties, not to method parameters. It causes model binding to add a model state error if binding cannot occur. However, the attribute has no effect if you're posting a JSON body, since the input formatter will provide a default value before binding occurs.

For more information, see the discussion of the [Required] attribute in [Model validation](xref:mvc/models/validation#required-attribute).

## [BindNever] attribute

Can only be applied to model properties, not to method parameters. It prevents model binding from setting a property.

## [Bind] attribute

Specifies which properties of a model should be included in model binding. For example:

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(
    [Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
{
    ...
}
```

The attribute lets you specify fields to be included or fields to be excluded. In the preceding example, model binding would ignore the `Student.ID` property.

The `[Bind]` attribute is one way to protect against overposting in *create* scenarios. It doesn't work so well in edit scenarios because excluded properties are set to null or a default value instead of being left unchanged. For more information, see [Security note about overposting](xref:data/ef-mvc/crud#security-note-about-overposting).

## Input formatters

Data in the request body can be in JSON, XML, or some other format. To parse this data, model binding uses an *input formatter* that is configured to handle a particular content type. By default, ASP.NET Core includes a `JsonInputFormatter` class for handling JSON data. You can add other formatters for other content types.

ASP.NET Core selects input formatters based on the [Content-Type header](https://www.w3.org/Protocols/rfc1341/4_Content-Type.html) and the type of the target parameter, unless there's an attribute applied to the target specifying otherwise.

To use the built-in XML input formatter:

* Install the `Microsoft.AspNetCore.Mvc.Formatters.Xml` NuGet package.

* In `Startup.ConfigureServices`, call `AddXmlSerializerFormatters`.

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .AddXmlSerializerFormatters();
    }
    ```
    
* Apply the `Consumes` attribute to controller classes, action methods, or handler methods that should expect XML in the request body.

```csharp
[HttpPost]
[Consumes("application/xml")]
public ActionResult<Pet> Create(Pet pet)
{
    ...
}
```

## Exclude specified types from model binding

The model binding and validation systems' behavior is driven by [ModelMetadata](/dotnet/api/microsoft.aspnetcore.mvc.modelbinding.modelmetadata). You can customize `ModelMetadata` by adding a details provider to [MvcOptions.ModelMetadataDetailsProviders](xref:Microsoft.AspNetCore.Mvc.MvcOptions.ModelMetadataDetailsProviders). Built-in details providers are available for disabling model binding or validation for specified types.

To disable model binding on all models of a specified type, add an <xref:Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider> in `Startup.ConfigureServices`. For example, to disable model binding on all models of type `System.Version`:

```csharp
services.AddMvc().AddMvcOptions(options =>
    options.ModelMetadataDetailsProviders.Add(
        new ExcludeBindingMetadataProvider(typeof(System.Version))));
```

To disable validation on properties of a specified type, add a <xref:Microsoft.AspNetCore.Mvc.ModelBinding.SuppressChildValidationMetadataProvider> in `Startup.ConfigureServices`. For example, to disable validation on properties of type `System.Guid`:

```csharp
services.AddMvc().AddMvcOptions(options =>
    options.ModelMetadataDetailsProviders.Add(
        new SuppressChildValidationMetadataProvider(typeof(System.Guid))));
```

## Custom model binders

You can extend model binding by writing a custom model binder and using the `[ModelBinder]` attribute to select it for a given target. Learn more about [custom model binding](xref:advanced/custom-model-binding).

## Manual model binding

Model binding can be invoked manually by using the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync*> method. The method is defined on both `ControllerBase` and `PageModel` classes. Method overloads let you specify the prefix and value provider to use. The method returns `false` if model binding fails.

```csharp
if (await TryUpdateModelAsync<Instructor>(
    instructorToUpdate,
    "Instructor",
    i => i.FirstMidName, i => i.LastName,
    i => i.HireDate, i => i.OfficeAssignment))
{
    ... 
    return RedirectToPage("./Index");
}
...
return Page();
```

## Additional resources

* <xref:mvc/models/validation>
* <xref:mvc/advanced/custom-model-binding>