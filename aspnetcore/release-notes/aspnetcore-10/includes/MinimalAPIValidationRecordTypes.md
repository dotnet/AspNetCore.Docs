#### Validation with record types
<!-- https://github.com/dotnet/aspnetcore/pull/61193 -->
<!-- https://github.com/dotnet/aspnetcore/pull/61402 -->

Minimal APIs also support validation with C# record types. Record types can be validated using attributes from the <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace, similar to classes. For example:

```csharp
public record Product(
    [Required] string Name,
    [Range(1, 1000)] int Quantity);
```

When using record types as parameters in Minimal API endpoints, validation attributes are automatically applied in the same way as class types:

```csharp
app.MapPost("/products", (Product product) =>
{
    // Endpoint logic here
    return TypedResults.Ok(product);
});
```
