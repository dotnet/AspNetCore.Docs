### Validation support in Minimal APIs

Support for validation in Minimal APIs is now available. This feature allows you to request validation of data sent to your API endpoints. Enabling validation allows the ASP.NET Core runtime to perform any validations defined on the:

* Query
* Header
* Request body

Validations are defined using attributes in the [`DataAnnotations`](xref:System.ComponentModel.DataAnnotations) namespace. Developers customize the behavior of the validation system by:

* Creating custom [`[Validation]`](xref:System.ComponentModel.DataAnnotations.ValidationAttribute) attribute implementations.
* Implementing the [`IValidatableObject`](xref:System.ComponentModel.DataAnnotations.IValidatableObject) interface for complex validation logic.

If validation fails, the runtime returns a 400 Bad Request response with details of the validation errors.

#### Enable built-in validation support for Minimal APIs

Enable the built-in validation support for Minimal APIs by calling the `AddValidation` extension method to register the required services in the service container for your application:

```csharp
builder.Services.AddValidation();
```

The implementation automatically discovers types that are defined in Minimal API handlers or as base types of types defined in Minimal API handlers. An endpoint filter performs validation on these types and is added for each endpoint.

Validation can be disabled for specific endpoints by using the `DisableValidation` extension method, as in the following example:

```csharp
app.MapPost("/products",
    ([EvenNumber(ErrorMessage = "Product ID must be even")] int productId, [Required] string name)
        => TypedResults.Ok(productId))
    .DisableValidation();
```

> [!NOTE]
> Several small improvements and fixes have been made to the Minimal APIs validation generator introduced in ASP.NET Core for .NET 10. To support future enhancements, the underlying validation resolver APIs are now marked as experimental. The top-level `AddValidation` APIs and the built-in validation filter remain stable and non-experimental.
