### Async validation for minimal APIs

Minimal API validation now supports asynchronous validators end-to-end ([dotnet/aspnetcore #66487](https://github.com/dotnet/aspnetcore/pull/66487), [dotnet/aspnetcore #67183](https://github.com/dotnet/aspnetcore/pull/67183)). Preview 5 shipped the building blocks for asynchronous form validation in Blazor. Preview 6 adds new asynchronous `DataAnnotations` APIs in the base libraries (`AsyncValidationAttribute` and `IAsyncValidatableObject`), and `Microsoft.Extensions.Validation` now runs them when an endpoint validates a request. The full set of new base-library APIs, including `Validator.ValidateObjectAsync`, is covered in the [.NET libraries release notes](./libraries.md#asynchronous-validation-with-dataannotations).

The simplest way to add an asynchronous rule is a custom validation attribute. Derive from `AsyncValidationAttribute` and implement `IsValidAsync` to query a database or call a remote API without blocking a thread. The synchronous `IsValid` is abstract too; throw from it when the attribute validates asynchronously only:

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

public sealed class UniqueEmailAttribute : AsyncValidationAttribute
{
    // Synchronous IsValid. This attribute validates asynchronously only.
    protected override ValidationResult? IsValid(object? value, ValidationContext context) =>
        throw new InvalidOperationException("Validate this attribute with IsValidAsync.");

    protected override async Task<ValidationResult?> IsValidAsync(
        object? value, ValidationContext context, CancellationToken cancellationToken)
    {
        var users = context.GetRequiredService<IUserService>();
        if (value is string email && await users.EmailExistsAsync(email, cancellationToken))
        {
            return new ValidationResult("That email is already registered.");
        }

        return ValidationResult.Success;
    }
}
```

Apply `[UniqueEmail]` to a property like any built-in validation attribute.

For validation that spans several properties or the whole object, implement `IAsyncValidatableObject` and return results as an `IAsyncEnumerable<ValidationResult>`. Because `IAsyncValidatableObject` extends `IValidatableObject`, also implement the synchronous `Validate` method. When a type validates asynchronously only, throw from `Validate` so its validation isn't silently skipped by the synchronous APIs:

```csharp
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class ReservationRequest : IAsyncValidatableObject
{
    [Required]
    public string Email { get; set; } = "";

    public DateOnly Date { get; set; }

    // Synchronous IValidatableObject. This type validates asynchronously only.
    public IEnumerable<ValidationResult> Validate(ValidationContext context) =>
        throw new InvalidOperationException("Validate this type with ValidateAsync.");

    public async IAsyncEnumerable<ValidationResult> ValidateAsync(
        ValidationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var rooms = context.GetRequiredService<IRoomService>();
        if (!await rooms.HasAvailabilityAsync(Date, cancellationToken))
        {
            yield return new ValidationResult(
                "No rooms are available on that date.", [nameof(Date)]);
        }
    }
}
```

Register validation and the framework validates the request before the endpoint runs:

```csharp
builder.Services.AddValidation();

app.MapPost("/reservations", (ReservationRequest request) =>
    Results.Ok(request));
```

Validators run concurrently where possible: asynchronous attributes on the same member start together, collection items validate in parallel, and the framework preserves the existing ordering between member, type, and `IValidatableObject` validation.
