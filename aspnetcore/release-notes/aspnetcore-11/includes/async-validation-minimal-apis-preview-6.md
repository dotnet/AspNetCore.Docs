### Async validation for minimal APIs

Minimal API validation supports asynchronous validators end-to-end. The base libraries add the asynchronous DataAnnotations APIs `AsyncValidationAttribute`, `IAsyncValidatableObject`, and `Validator.ValidateObjectAsync`, and `Microsoft.Extensions.Validation` runs them when an endpoint validates a request.

<!-- TODO: Update `AsyncValidationAttribute`, `IAsyncValidatableObject`, and `Validator.ValidateObjectAsync` to <xref:> once API docs are published. -->

Asynchronous validation lets a validation rule do real work, such as a database lookup or a remote API call, without blocking a thread. A model implements `IAsyncValidatableObject` and returns validation results as an `IAsyncEnumerable<ValidationResult>`. Because `IAsyncValidatableObject` extends `IValidatableObject`, also implement the synchronous `Validate` method. When a type validates asynchronously only, throw from `Validate` so it isn't silently validated through the synchronous APIs:

```csharp
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class ReservationRequest : IAsyncValidatableObject
{
    [Required]
    public string Email { get; set; } = "";

    public DateOnly Date { get; set; }

    // IValidatableObject (synchronous) — this type validates asynchronously only.
    public IEnumerable<ValidationResult> Validate(ValidationContext context) =>
        throw new NotSupportedException("Validate this type with ValidateAsync.");

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

Validators run concurrently where possible: asynchronous attributes on the same member start together, collection items validate in parallel, and the framework preserves the existing ordering between member, type, and `IValidatableObject` validation. For attribute-based rules, derive from `AsyncValidationAttribute` and override its `IsValidAsync` method.

Thank you [@Youssef1313](https://github.com/Youssef1313) for the implementation work on this feature!
