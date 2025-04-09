### Validation support in Minimal APIs

<!-- https://github.com/captainsafia/minapi-validation-support -->

Support for validation in Minimal APIs is now available. This feature allows you to request validation of data
sent to your API endpoints. When validation is enabled, the ASP.NET Core runtime will perform any validations
defined on query, header, and route parameters, as well as on the request body.
Validations can be defined using attributes in the `System.ComponentModel.DataAnnotations` namespace.
Developers can customize the behavior of the validation system by:

- creating custom [ValidationAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute?view=net-9.0) implementations
- implement the [IValidatableObject](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.ivalidatableobject?view=net-9.0) interface for complex validation logic

When validation fails, the runtime will return a 400 Bad Request response with
details of the validation errors.

To enable built-in validation support for minimal APIs, call the `AddValidation` extension method to register
the required services into the service container for your application.

```csharp
builder.Services.AddValidation();
```

The implementation automatically discovers types that are defined in minimal API handlers or as base types of types defined in minimal API handlers. Validation is then performed on these types by an endpoint filter that is added for each endpoint.

Validation can be disabled for specific endpoints by using the `DisableValidation` extension method.

```csharp
app.MapPost("/products",
    ([EvenNumber(ErrorMessage = "Product ID must be even")] int productId, [Required] string name)
        => TypedResults.Ok(productId))
    .DisableValidation();
```