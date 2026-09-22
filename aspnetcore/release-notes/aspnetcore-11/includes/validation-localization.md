### Validation localization is built in

`Microsoft.Extensions.Validation` localizes validation messages and display names without a separate package. Calling `AddLocalization` to register an `IStringLocalizerFactory`, followed by `AddValidation`, activates localization automatically. The validation source generator emits the localization lookup into your assembly.

<!-- TODO: Update `AddValidation`, `ValidationOptions.LocalizerProvider`, and `IValidationMessageFormatter` to <xref:> once API docs are published. -->

```csharp
builder.Services.AddLocalization();
builder.Services.AddValidation();
```

```csharp
[ValidatableType]
public class CustomerModel
{
    [Display(Name = "CustomerName")]          // resource key for the display name
    [Required(ErrorMessage = "NameRequired")] // resource key for the message
    public string? Name { get; set; }
}
```

By default, keys resolve against the resources of the type that declares the validated member. An explicit `ErrorMessage` value, such as `NameRequired` in the preceding example, is the first resource key that localization tries. When an attribute doesn't specify `ErrorMessage`, localization instead tries built-in resource-name conventions from most to least specific:

1. `{DeclaringType}_{MemberName}_{AttributeType}_Error`
1. `{DeclaringType}_{AttributeType}_Error`
1. `{AttributeType}_Error`

For example, a `[Required]` attribute on `CustomerModel.Name` resolves against `CustomerModel_Name_RequiredAttribute_Error`, `CustomerModel_RequiredAttribute_Error`, or the shared `RequiredAttribute_Error` resource. This allows the default message of an attribute to be translated once for the whole app. If no resource resolves, validation falls back to the attribute's built-in message. Use `ValidationOptions.LocalizerProvider` to resolve keys from a shared resource file instead:

```csharp
builder.Services.AddValidation(options =>
{
    options.LocalizerProvider = (_, factory) => factory.Create(typeof(ValidationMessages));
});
```

Localized strings don't have to come from resource files. Registering a custom `IStringLocalizerFactory` switches validation messages to that factory's backing store, such as a database or JSON files. A user-registered factory takes precedence over the default resource file implementation:

```csharp
builder.Services.AddSingleton<IStringLocalizerFactory, DbStringLocalizerFactory>();
builder.Services.AddValidation();
```

Attributes that already localize themselves (`ErrorMessageResourceType`, `[Display(ResourceType = ...)]`) bypass the pipeline entirely. A custom attribute that needs to substitute its own values into the message template can implement `IValidationMessageFormatter`:

```csharp
public sealed class DivisibleByAttribute : ValidationAttribute, IValidationMessageFormatter
{
    public int Divisor { get; init; }

    public string FormatMessage(CultureInfo culture, string template, string displayName)
        => string.Format(culture, template, displayName, Divisor); // {0} = name, {1} = divisor
}
```

The same localization rules apply to validation for minimal APIs and Blazor, so a message localizes identically wherever the model is used.

Complete feature coverage is available in the following articles:

* <xref:fundamentals/validation?view=aspnetcore-11.0#localize-validation-messages>
* <xref:fundamentals/minimal-apis?view=aspnetcore-11.0#localizing-validation-messages>

For more information, see [Add localization support to Microsoft.Extensions.Validation (`dotnet/aspnetcore` #66646)](https://github.com/dotnet/aspnetcore/pull/66646).
