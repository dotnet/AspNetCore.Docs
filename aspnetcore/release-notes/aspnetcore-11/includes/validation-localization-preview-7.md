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

Keys resolve against the model's own resources, and a miss falls back to the attribute's built-in message. When an attribute doesn't set `ErrorMessage`, conventional keys are tried from most to least specific, so the default message of an attribute can be translated once for the whole app:

```csharp
[ValidatableType]
public class ContactModel
{
    // Looks up 'ContactModel_Username_RequiredAttribute_Error', then
    // 'ContactModel_RequiredAttribute_Error', then 'RequiredAttribute_Error'.
    [Required]
    public string? Username { get; set; }
}
```

Use `ValidationOptions.LocalizerProvider` to resolve keys from a shared resource file instead:

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

For more information, see [Add localization support to Microsoft.Extensions.Validation (`dotnet/aspnetcore` #66646)](https://github.com/dotnet/aspnetcore/pull/66646). (Please don't comment on closed issues and PRs.)
