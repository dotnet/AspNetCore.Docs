---
title: ASP.NET Core Blazor advanced form validation
ai-usage: ai-assisted
author: guardrex
description: Learn how to control Blazor form validation directly with EditContext, validator components, and remote validation.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 08/17/2026
uid: blazor/forms/validation-advanced
---
# ASP.NET Core Blazor advanced form validation

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to take direct control of Blazor form validation using <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, validator components, and remote validation.

The techniques in this article are for scenarios that validation attributes on the model can't express, most commonly when validation messages come from outside the model, such as a web API response or a business rule that requires server-side data.

For validation with data annotations attributes and the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component, see <xref:blazor/forms/validation>. Writing custom rules as attributes on the model is simpler than the approaches in this article. For more information, see [Custom attributes](xref:mvc/models/validation#custom-attributes).

## Validate with `EditContext` and `ValidationMessageStore`

An <xref:Microsoft.AspNetCore.Components.Forms.EditForm> instance can use declared <xref:Microsoft.AspNetCore.Components.Forms.EditContext> and <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> instances to validate form fields. A handler for the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> event of the <xref:Microsoft.AspNetCore.Components.Forms.EditContext> executes custom validation logic. The handler's result updates the <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> instance.

This approach is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a [validator component](#validator-components) is recommended where an independent model class is used across several components.

:::moniker range=">= aspnetcore-8.0 < aspnetcore-11.0"

In Blazor Web Apps, client-side validation requires an active Blazor SignalR circuit. Client-side validation isn't available to forms in components that have adopted static server-side rendering (static SSR). Forms that adopt static SSR are validated on the server after the form is submitted.

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

In Blazor Web Apps that use interactive render modes (Server, WebAssembly, or Auto), client-side validation runs through the live <xref:Microsoft.AspNetCore.Components.Forms.EditContext> pipeline as in earlier releases. Forms that adopt static server-side rendering (static SSR) gain client-side validation automatically when a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component is present in the form. For details, see <xref:blazor/forms/validation-client-side>.

:::moniker-end

In the following component, the `HandleValidationRequested` handler method clears any existing validation messages by calling <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore.Clear%2A?displayProperty=nameWithType> before validating the form.

`Starship8.razor`:

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/Starship8.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship8.razor":::

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-8"
@implements IDisposable
@inject ILogger<Starship8> Logger

<h2>Holodeck Configuration</h2>

<EditForm EditContext="editContext" OnValidSubmit="Submit">
    <div>
        <label>
            <InputCheckbox @bind-Value="Model!.Subsystem1" />
            Safety Subsystem
        </label>
    </div>
    <div>
        <label>
            <InputCheckbox @bind-Value="Model!.Subsystem2" />
            Emergency Shutdown Subsystem
        </label>
    </div>
    <div>
        <ValidationMessage For="() => Model!.Options" />
    </div>
    <div>
        <button type="submit">Update</button>
    </div>
</EditForm>

@code {
    private EditContext? editContext;

    public Holodeck? Model { get; set; }

    private ValidationMessageStore? messageStore;

    protected override void OnInitialized()
    {
        Model ??= new();
        editContext = new(Model);
        editContext.OnValidationRequested += HandleValidationRequested;
        messageStore = new(editContext);
    }

    private void HandleValidationRequested(object? sender,
        ValidationRequestedEventArgs args)
    {
        messageStore?.Clear();

        // Custom validation logic
        if (!Model!.Options)
        {
            messageStore?.Add(() => Model.Options, "Select at least one.");
        }
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public class Holodeck
    {
        public bool Subsystem1 { get; set; }
        public bool Subsystem2 { get; set; }
        public bool Options => Subsystem1 || Subsystem2;
    }

    public void Dispose()
    {
        if (editContext is not null)
        {
            editContext.OnValidationRequested -= HandleValidationRequested;
        }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship8.razor":::
-->

:::moniker-end

## Manual validation using the `OnValidationRequested` event

You can manually validate a form with a custom event handler assigned to the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested%2A?displayProperty=nameWithType> event to manage a <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore>.

The Blazor framework provides the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to attach additional validation support to forms based on [validation attributes (data annotations)](xref:mvc/models/validation#validation-attributes). 

Recalling the earlier `Starship8` component example, the `HandleValidationRequested` method is assigned to <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested%2A>, where you can perform manual validation in C# code. A few changes demonstrate combining the existing manual validation with data annotations validation via a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> and a validation attribute applied to the `Holodeck` model.

Reference the <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace in the component's Razor directives at the top of the component definition file:

```razor
@using System.ComponentModel.DataAnnotations
```

Add an `Id` property to the `Holodeck` model with a validation attribute to limit the string's length to six characters:

```csharp
[StringLength(6)]
public string? Id { get; set; }
```

Add a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component (`<DataAnnotationsValidator />`) to the form. Typically, the component is placed immediately under the `<EditForm>` tag, but you can place it anywhere in the form:

```razor
<DataAnnotationsValidator />
```

Change the form's submit behavior in the `<EditForm>` tag from <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit>, which ensures that the form is valid before executing the assigned event handler method:

```diff
- OnSubmit="Submit"
+ OnValidSubmit="Submit"
```

In the `<EditForm>`, add a field for the `Id` property:

```razor
<div>
    <label>
        <InputText @bind-Value="Model!.Id" />
        ID (6 characters max)
    </label>
    <ValidationMessage For="() => Model!.Id" />
</div>
```

After making the preceding changes, the form's behavior matches the following specification:

* The data annotations validation on the `Id` property doesn't trigger a validation failure when the `Id` field merely loses focus. The validation executes when the user selects the **`Update`** button.
* Any manual validation that you want to perform in the `HandleValidationRequested` method assigned to the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested%2A> event executes when the user selects the form's **`Update`** button. In the existing code of the `Starship8` component example, the user must select either or both of the checkboxes to validate the form.
* The form doesn't process the `Submit` method until both the data annotations and manual validation pass.

## Validator components

Validator components support form validation by managing a <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> for a form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.

The Blazor framework provides the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to attach validation support to forms based on [validation attributes (data annotations)](xref:mvc/models/validation#validation-attributes). You can create custom validator components to process validation messages for different forms on the same page or the same form at different steps of form processing (for example, client validation followed by server-side validation in a Blazor Web App). The validator component example shown in this section, `CustomValidation`, is used in the following sections of this article:

* [Business logic validation with a validator component](#business-logic-validation-with-a-validator-component)
* [Remote validation with a validator component](#remote-validation-with-a-validator-component)

Of the [data annotation built-in validators](xref:mvc/models/validation#built-in-attributes), only the [`[Remote]` validation attribute](xref:mvc/models/validation#remote-attribute) isn't supported in Blazor.

> [!NOTE]
> Custom data annotation validation attributes can be used instead of custom validator components in many cases. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation in a Blazor Web App, any custom attributes applied to the model must be executable on the server. For more information, see <xref:blazor/forms/validation#custom-validation-rules>.

Create a validator component from <xref:Microsoft.AspNetCore.Components.ComponentBase>:

* The form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> is a [cascading parameter](xref:blazor/components/cascading-values-and-parameters) of the component.
* When the validator component is initialized, a new <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> is created to maintain a current list of form errors.
* The message store receives errors when developer code in the form's component calls the `DisplayErrors` method. The errors are passed to the `DisplayErrors` method in a [`Dictionary<string, List<string>>`](xref:System.Collections.Generic.Dictionary%602). In the dictionary, the key is the name of the form field that has one or more errors. The value is the error list.
* Messages are cleared when any of the following have occurred:
  * Validation is requested on the <xref:Microsoft.AspNetCore.Components.Forms.EditContext> when the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> event is raised. All of the errors are cleared.
  * A field changes in the form when the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> event is raised. Only the errors for the field are cleared.
  * The `ClearErrors` method is called by developer code. All of the errors are cleared.

Update the namespace in the following class to match your app's namespace.

`CustomValidation.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/CustomValidation.cs":::

> [!IMPORTANT]
> Specifying a namespace is **required** when deriving from <xref:Microsoft.AspNetCore.Components.ComponentBase>. Failing to specify a namespace results in a build error:
>
> > :::no-loc text="Tag helpers cannot target tag name '\<global namespace>.{CLASS NAME}' because it contains a ' ' character.":::
>
> The `{CLASS NAME}` placeholder is the name of the component class. The custom validator example in this section specifies the example namespace `BlazorSample`.

> [!NOTE]
> Anonymous lambda expressions are registered event handlers for <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> and <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> in the preceding example. It isn't necessary to implement <xref:System.IDisposable> and unsubscribe the event delegates in this scenario. For more information, see <xref:blazor/components/component-disposal>.

## Business logic validation with a validator component

For general business logic validation, use a [validator component](#validator-components) that receives form errors in a dictionary.

Basic validation is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a validator component is recommended where an independent model class is used across several components.

In the following example:

* A shortened version of the `Starfleet Starship Database` form (`Starship3` component) of the [Example form](xref:blazor/forms/input-components#example-form) section of the *Input components* article is used that only accepts the starship's classification and description. Data annotation validation isn't triggered on form submission because the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component isn't included in the form.
* The `CustomValidation` component from the [Validator components](#validator-components) section of this article is used.
* The validation requires a value for the ship's description (`Description`) if the user selects the "`Defense`" ship classification (`Classification`).

When validation messages are set in the component, they're added to the validator's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> and shown in the <xref:Microsoft.AspNetCore.Components.Forms.EditForm>'s validation summary.

`Starship9.razor`:

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/Starship9.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship9.razor":::

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-9"
@inject ILogger<Starship9> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="Model" OnValidSubmit="Submit">
    <CustomValidation @ref="customValidation" />
    <ValidationSummary />
    <div>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </div>
    <div>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@code {
    private CustomValidation? customValidation;

    public Starship? Model { get; set; }

    protected override void OnInitialized() =>
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private void Submit()
    {
        customValidation?.ClearErrors();

        var errors = new Dictionary<string, List<string>>();

        if (Model!.Classification == "Defense" &&
                string.IsNullOrEmpty(Model.Description))
        {
            errors.Add(nameof(Model.Description),
                new() { "For a 'Defense' ship classification, " +
                "'Description' is required." });
        }

        if (errors.Any())
        {
            customValidation?.DisplayErrors(errors);
        }
        else
        {
            Logger.LogInformation("Submit called: Processing the form");
        }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship9.razor":::
-->

:::moniker-end

> [!NOTE]
> As an alternative to using [validation components](#validator-components), data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation in a Blazor Web App, the attributes must be executable on the server. For more information, see <xref:blazor/forms/validation#custom-validation-rules>.

:::moniker range=">= aspnetcore-11.0"

## Asynchronous validation

<xref:Microsoft.AspNetCore.Components.Forms.EditContext> exposes an asynchronous validation pipeline that custom validator components and custom submit handlers use to run validation work that performs I/O, such as calling a server endpoint to check a value's uniqueness.

<!-- UPDATE 11.0 - API Browser cross-links

<xref:Microsoft.AspNetCore.Components.Forms.EditContext.ValidateAsync%2A>
<xref:Microsoft.AspNetCore.Components.Forms.EditContext.RegisterAsyncFieldValidator%2A>
<xref:Microsoft.AspNetCore.Components.Forms.ValidationRequestedEventArgs.AddAsyncValidator%2A>

-->

The pipeline is built around the following API:

* `ValidationRequestedEventArgs.AddAsyncValidator`: registers asynchronous work to run as part of the current validation pass. Called from an <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> handler, typically to validate the form as a whole on submit.
* `EditContext.RegisterAsyncFieldValidator`: registers asynchronous work for a single field. Registering a new validation for a field cancels and replaces the field's current pending validation.
* `EditContext.ValidateAsync`: an asynchronous counterpart to <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A> that invokes the registered validators and awaits them. It accepts a <xref:System.Threading.CancellationToken>.

<xref:Microsoft.AspNetCore.Components.Forms.EditForm> awaits any registered asynchronous work before invoking <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit%2A>. Forms with only synchronous validators continue to work without changes.

To author asynchronous rules as data annotations attributes on the model instead of writing a validator component, see <xref:fundamentals/validation#asynchronous-validation-support>. The built-in <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component runs asynchronous attributes without any additional configuration.

> [!IMPORTANT]
> Asynchronous work can only be registered during an asynchronous validation pass. If a form is validated with the obsolete synchronous <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A> method, `AddAsyncValidator` throws an <xref:System.InvalidOperationException> that directs the caller to `ValidateAsync`. This guarantees that an asynchronous validator is never silently skipped.

### Form-level async validation

Subscribe to <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> and call `AddAsyncValidator` from the handler to run asynchronous work whenever the form is validated as a whole. The framework invokes the registered validator with the validation pass's cancellation token, which should be passed to any I/O that the validator performs.

In the following example, a custom validator component checks a username against a remote endpoint when the form is submitted:

```razor
@implements IDisposable
@inject HttpClient Http

@code {
    [CascadingParameter]
    private EditContext? CurrentEditContext { get; set; }

    [Parameter, EditorRequired]
    public RegistrationModel Model { get; set; } = default!;

    private ValidationMessageStore? _messages;

    protected override void OnInitialized()
    {
        ArgumentNullException.ThrowIfNull(CurrentEditContext);
        _messages = new ValidationMessageStore(CurrentEditContext);
        CurrentEditContext.OnValidationRequested += OnValidationRequested;
    }

    private void OnValidationRequested(
        object? sender, ValidationRequestedEventArgs e) =>
        e.AddAsyncValidator(ValidateUsernameAsync);

    private async Task ValidateUsernameAsync(CancellationToken token)
    {
        var field = CurrentEditContext!.Field(nameof(Model.Username));
        _messages!.Clear(field);

        var available = await Http.GetFromJsonAsync<bool>(
            $"api/usernames/available?value={Uri.EscapeDataString(Model.Username)}",
            token);

        if (!available)
        {
            _messages.Add(field, "The username is already taken.");
        }

        CurrentEditContext!.NotifyValidationStateChanged();
    }

    public void Dispose()
    {
        if (CurrentEditContext is not null)
        {
            CurrentEditContext.OnValidationRequested -= OnValidationRequested;
        }
    }
}
```

Place the component inside an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> alongside the form's inputs. Because <xref:Microsoft.AspNetCore.Components.Forms.EditForm> awaits the asynchronous validators before invoking <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit%2A>, the submit handler runs only after the remote check completes successfully:

```razor
<EditForm Model="Model" OnValidSubmit="RegisterAsync">
    <UsernameUniquenessValidator Model="Model" />
    <InputText @bind-Value="Model.Username" />
    <ValidationMessage For="() => Model.Username" />
    <button type="submit">Register</button>
</EditForm>
```

### Per-field async validation

For asynchronous work that should run when the user edits a single field, call `RegisterAsyncFieldValidator` with the field's <xref:Microsoft.AspNetCore.Components.Forms.FieldIdentifier> and a validator that starts the work. The framework tracks each validation so that the field's pending and faulted state can be queried and displayed independently of other fields.

The <xref:Microsoft.AspNetCore.Components.Forms.EditContext> owns the cancellation token source. If the user edits the same field again while a check is in flight, the prior validation is canceled and superseded automatically, so there's no token source for the component to create, cancel, or dispose.

Add the following members to the validator component shown in the previous section to re-run the uniqueness check whenever the `Username` field changes:

```csharp
protected override void OnInitialized()
{
    ArgumentNullException.ThrowIfNull(CurrentEditContext);
    _messages = new ValidationMessageStore(CurrentEditContext);
    CurrentEditContext.OnValidationRequested += OnValidationRequested;
    CurrentEditContext.OnFieldChanged += OnFieldChanged;
}

private void OnFieldChanged(object? sender, FieldChangedEventArgs e)
{
    if (e.FieldIdentifier.FieldName != nameof(RegistrationModel.Username))
    {
        return;
    }

    CurrentEditContext!.RegisterAsyncFieldValidator(
        e.FieldIdentifier,
        token => CheckAsync(e.FieldIdentifier, token));
}

private async Task CheckAsync(FieldIdentifier field, CancellationToken token)
{
    _messages!.Clear(field);

    var available = await Http.GetFromJsonAsync<bool>(
        $"api/usernames/available?value={Uri.EscapeDataString(Model.Username)}",
        token);

    if (!available)
    {
        _messages.Add(field, "The username is already taken.");
    }

    CurrentEditContext!.NotifyValidationStateChanged();
}

public void Dispose()
{
    if (CurrentEditContext is not null)
    {
        CurrentEditContext.OnValidationRequested -= OnValidationRequested;
        CurrentEditContext.OnFieldChanged -= OnFieldChanged;
    }
}
```

Write the validator as an `async` method so that an exception thrown before the first `await` is captured into the returned task rather than thrown from `RegisterAsyncFieldValidator`. To cancel from an additional source, create a linked token source inside the validator with <xref:System.Threading.CancellationTokenSource.CreateLinkedTokenSource%2A>.

Validators should clear prior messages for the field up front, as the preceding example does, and avoid writing partial results on a path that might throw.

### Cancellation and faults

A validation that's canceled because it was superseded, or because the caller's token was canceled, is discarded silently and doesn't change the field's faulted state.

A validation that fails for any other reason places the field in the *faulted* state. This includes a validation that completes as canceled due to an unrelated source, such as an <xref:System.Net.Http.HttpClient> or database timeout. Such a cancellation is treated as an infrastructure fault rather than as success, so a field is never reported as valid because its validation didn't finish.

For how to display pending and faulted state in the UI, see <xref:blazor/forms/validation#display-pending-and-faulted-validation-state>.

### Calling `ValidateAsync` from a custom submit handler

When a form uses <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> instead of <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit%2A>, call `ValidateAsync` from the handler to await any registered asynchronous work before deciding whether to proceed:

```razor
<EditForm EditContext="_editContext" OnSubmit="HandleSubmitAsync">
    <UsernameUniquenessValidator Model="Model" />
    <InputText @bind-Value="Model.Username" />
    <button type="submit">Register</button>
</EditForm>

@code {
    private EditContext _editContext = default!;

    protected override void OnInitialized() =>
        _editContext = new EditContext(Model);

    private async Task HandleSubmitAsync()
    {
        if (await _editContext.ValidateAsync(CancellationToken.None))
        {
            await RegisterAsync();
        }
    }
}
```

The synchronous <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A> method is obsolete as of .NET 11. Call `ValidateAsync` instead. `Validate` continues to work for forms that only have synchronous validators, but it throws an <xref:System.InvalidOperationException> if a handler attempts to register asynchronous work during the pass.

### Async validation across rendering modes

The asynchronous validation API is the same in every Blazor rendering mode. Validator code runs wherever the component runs: in the browser for Interactive WebAssembly, on the server for Interactive Server, and on the server during the form POST for static SSR. Static SSR renders the full response after asynchronous validation completes.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

## Remote validation in a Minimal API

In a [Minimal API](xref:fundamentals/minimal-apis), call the <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> extension method for [data annotation validation of model types](xref:mvc/models/validation#validation-attributes) for all web API endpoints:

```csharp
builder.Services.AddValidation();
```

The implementation automatically discovers types that are defined in Minimal API handlers or as base types of types defined in Minimal API handlers. An endpoint filter performs validation on these types and is added for each endpoint.

Built-in validation also supports [custom validation attributes](xref:mvc/models/validation#custom-attributes).

For more information, see <xref:fundamentals/minimal-apis#enable-built-in-validation-support-for-minimal-apis>.

:::moniker-end

## Remote validation with a validator component

:::moniker range=">= aspnetcore-10.0"

*This section demonstrates remote validation using a Blazor Web App (global Interactive Auto render mode) and a Minimal API.*

Remote validation is supported in addition to Blazor Web App client/server-side validation:

* Process client validation in the form with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.
* When the form passes client validation (<xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit> is called), send the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Model?displayProperty=nameWithType> to a backend Minimal API for remote validation.
* Process remote model validation:
  * Data annotations validation with built-in support for Minimal APIs.
  * Custom validation logic.
* Send validation errors, if any, back to the client.
* Either disable the form on success or display the errors so that the user can correct any problems with the form's field values.

Basic validation is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a *validator component* is recommended where an independent model class is used across several components. The approach demonstrated by the following guidance uses a validator component.

The following example is based on:

* A Blazor Web App with global Interactive Auto components created from the [Blazor Web App project template](xref:blazor/project-structure).
* A `CustomValidation` component to handle adding model errors to the form's validation message store for display in the UI.
* A [Minimal API](xref:fundamentals/minimal-apis) project that validates:
  * Data annotations validation attributes on the model class (<xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A>), including for [custom validation attributes](xref:mvc/models/validation#custom-attributes).
  * Custom validation logic that determines if a description form field (`Description`) has a value if the user selects a particular classification in another form field (`Defense` classification).

The validation for the `Defense` ship classification only occurs on the server because the upcoming form doesn't perform the same validation client-side when the form is submitted to the server. Remote validation without client validation is common in apps that require private business logic validation of user input on the server. For example, private information from data stored for a user might be required to validate user input. Private data is never sent to the client for client validation.

> [!NOTE]
> For more information on security pertaining to the following example, see the following resources:
>
> * <xref:blazor/security/blazor-web-app-entra>
> * <xref:blazor/security/index> (and the other articles in the Blazor *Security and Identity* node)
> * [Microsoft identity platform documentation](/entra/identity-platform/)

Create a `Starship` folder in the `.Client` project of the Blazor Web App.

Place the following `StarshipModel` model (`StarshipModel.cs`) into the `Starship` folder ***and*** into the Minimal API project of the solution.

> [!NOTE]
> If you choose to place one copy of the `StarshipModel` into a shared class library project for use by both the Blazor Web App and the Minimal API project, confirm that the shared class library uses the shared framework or add the [`System.ComponentModel.Annotations` package](https://www.nuget.org/packages/System.ComponentModel.Annotations) to the shared project. This ensures that the model has access to data annotations.
>
> [!INCLUDE[](~/includes/package-reference.md)]

In the two `StarshipModel` classes, set the namespace (`{NAMESPACE}`) appropriately for each project (for example, `BlazorSample.Client.Starship` in the Blazor Web App and `MinimalApiJwt.Models` in the Minimal API project). Some developers prefer to use a different folder scheme. If you position the classes in the projects in different locations, set the namespaces appropriately.

`Starship/StarshipModel.cs` (Blazor Web App) or `Models/StarshipModel.cs` (Minimal API project):

```csharp
using System.ComponentModel.DataAnnotations;

namespace {NAMESPACE};

public class StarshipModel
{
    [Required]
    [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
    public string? Id { get; set; }

    public string? Description { get; set; }

    [Required]
    public string? Classification { get; set; }

    [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
    public int MaximumAccommodation { get; set; }

    [Required]
    [Range(typeof(bool), "true", "true", ErrorMessage = "Approval required.")]
    public bool IsValidatedDesign { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }
}
```

Add an interface for a form validation service to the `.Client` project in the `Starship` folder. The interface is used to register validation services in the Blazor Web App.

`Starship/IFormValidation.cs`:

```csharp
namespace BlazorSample.Client.Starship;

public interface IFormValidation
{
    Task<IDictionary<string, string[]>> ValidateStarshipFormAsync(
        StarshipModel starship);
}
```

Add a client form validator class to the `.Client` project's `Starship` folder. The client form validator is used when the app is running on the client. The validator class posts to the Blazor Web App endpoint, which then proxies to the Minimal API.

`Starship/ClientFormValidation.cs`:

```csharp
using System.Net.Http.Json;

namespace BlazorSample.Client.Starship;

internal sealed class ClientFormValidation(HttpClient httpClient) : IFormValidation
{
    public async Task<IDictionary<string, string[]>> ValidateStarshipFormAsync(
        StarshipModel starship)
    {
        Dictionary<string, string[]> genericError = new()
        {
            {
                "Validation Error", 
                ["An unexpected client error occurred during validation."]
            }
        };

        try
        {
            using var response = await httpClient.PostAsJsonAsync(
                "/starship-validation", starship);

            if (response.IsSuccessStatusCode)
            {
                var deserializedResponseContent = 
                    await response.Content.ReadFromJsonAsync
                        <IDictionary<string, string[]>>();

                return deserializedResponseContent ?? genericError;
            }
        }
        catch (Exception ex)
        {
            // Log exception
        }

        return genericError;
    }
}
```

Confirm or update the namespace of the preceding class.

Create a `Starship` folder in the server project of the Blazor Web App.

In the Blazor Web App, create a server form validator that implements the `IFormValidation` interface. Place the server form validator class in the server-side `Starship` folder. The server form validator is used when the Blazor Web App is running on the server. The validator class posts the form's model to the backend Minimal API for processing.

`Starship/ServerFormValidation.cs`:

```csharp
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using BlazorSample.Client.Starship;

namespace BlazorSample.Starship;

internal sealed class ServerFormValidation(
    IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory) 
    : IFormValidation
{
    public async Task<IDictionary<string, string[]>> ValidateStarshipFormAsync(
        StarshipModel starship)
    {
        Dictionary<string, string[]> genericError = new()
        {
            {
                "Validation Error",
                ["An unexpected server error occurred during validation."]
            }
        };

        try
        {
            if (httpContextAccessor.HttpContext is null)
            {
                throw new Exception("HttpContext not available");
            }

            var request = new HttpRequestMessage(HttpMethod.Post, 
                "https://localhost:7277/api-starship-validation")
            {
                Content = new StringContent(JsonSerializer.Serialize(starship), 
                    System.Text.Encoding.UTF8, "application/json")
            };

            var accessToken = 
                await httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            using var httpClient = httpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            if (response?.StatusCode == HttpStatusCode.NoContent)
            {
                return new Dictionary<string, string[]>();
            }

            if (response?.StatusCode == HttpStatusCode.BadRequest)
            {
                var content = await response.Content.ReadAsStringAsync();

                var deserialized =
                    JsonSerializer.Deserialize<ValidationProblemDetails>(
                        content,
                        new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return deserialized?.Errors ?? genericError;
            }

            return genericError;
        }
        catch (Exception ex)
        {
            // Log exception
        }

        return genericError;
    }
}
```

In the `Program` file of the Blazor Web App:

* Register the server form validator (`ServerFormValidation`) for the `IFormValidation` interface in the DI container.
* The server form validator is used on the server to call `ValidateStarshipFormAsync` for form validation.

```csharp
builder.Services.AddScoped<IFormValidation, ServerFormValidation>();

...

app.MapPost("/starship-validation", (IFormValidation formValidator, 
    StarshipModel model) =>
{
    return formValidator.ValidateStarshipFormAsync(model);
}).RequireAuthorization();
```

The `.Client` project of a Blazor Web App must register an <xref:System.Net.Http.HttpClient> for HTTP POST requests to the Minimal API. Add the following to the `.Client` project's `Program` file:

```csharp
builder.Services.AddHttpClient<IFormValidation, ClientFormValidation>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
```

The preceding example sets the base address with `builder.HostEnvironment.BaseAddress` (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress%2A?displayProperty=nameWithType>), which gets the base address for the app and is typically derived from the `<base>` tag's `href` value in the host page.

In the `Program` file of the `MinimalApiJwt` project, add the following starship form validation endpoint. The endpoint validates that the model's `Description` property has a value when the model's `Classification` property is `Defense`. If validation fails, a `ValidationProblem` returns a dictionary with the failed field and a description of the error. If validation passes, a *204 - No Content* response is issued. In a typical production app, any number of custom form model checks are made, and the validation errors dictionary can include multiple failures (`string[]` value) for each model property.

In the `Program` file of the Minimal API project:

```csharp
app.MapPost("/api-starship-validation", (
    StarshipModel model, ILogger<Program> logger) =>
{
    Dictionary<string, string[]> errors = [];

    if (model.Classification == "Defense" && string.IsNullOrEmpty(model.Description))
    {
        errors.Add(nameof(model.Description), 
            ["For a 'Defense' ship, 'Description' is required."]);
    }

    if (errors.Count > 0)
    {
        return Results.ValidationProblem(
            errors: errors,
            detail: "One or more validation errors occurred.",
            instance: typeof(Program).Assembly.GetName().Name,
            title: "Validation Errors",
            type: "https://tools.ietf.org/html/rfc9110#section-15.5.1");
    }

    return Results.NoContent();

}).RequireAuthorization();
```

Also in the `Program` file of the Minimal API, register [built-in validation services](xref:fundamentals/minimal-apis#validation-support-in-minimal-apis):

```csharp
builder.Services.AddValidation();
```

Built-in validation automatically intercepts the endpoint request and validates the types that the endpoint receives. If the model fails validation, the framework returns a *400 - Bad Request* response with error details without executing the endpoint's code. If you don't want to implement built-in model validation, don't use the preceding line of code in the Minimal API's `Program` file.

In the `.Client` project, add the following `CustomValidation` component. When the component's `DisplayErrors` method is called with a set of validation errors, the errors are added to the parent component's edit context validation message store. Errors are cleared from the edit context by calling the `ClearErrors` method.

`CustomValidation.cs`:

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSample.Client;

public class CustomValidation : ComponentBase
{
    private ValidationMessageStore? messageStore;

    [CascadingParameter]
    private EditContext? CurrentEditContext { get; set; }

    protected override void OnInitialized()
    {
        if (CurrentEditContext is null)
        {
            throw new InvalidOperationException(
                $"{nameof(CustomValidation)} requires a cascading " +
                $"parameter of type {nameof(EditContext)}. " +
                $"For example, you can use {nameof(CustomValidation)} " +
                $"inside an {nameof(EditForm)}.");
        }

        messageStore = new(CurrentEditContext);

        CurrentEditContext.OnValidationRequested += (s, e) =>
            messageStore?.Clear();
        CurrentEditContext.OnFieldChanged += (s, e) =>
            messageStore?.Clear(e.FieldIdentifier);
    }

    public void DisplayErrors(IDictionary<string, string[]> errors)
    {
        if (CurrentEditContext is not null)
        {
            foreach (var err in errors)
            {
                messageStore?.Add(CurrentEditContext.Field(err.Key), err.Value);
            }

            CurrentEditContext.NotifyValidationStateChanged();
        }
    }

    public void ClearErrors()
    {
        messageStore?.Clear();
        CurrentEditContext?.NotifyValidationStateChanged();
    }
}
```

In the `.Client` project, the `Starfleet Starship Database` form is updated to show validation errors with help of the `CustomValidation` component. When validation messages are returned, they're added to the `CustomValidation` component's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore>. The errors are available in the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> for display by the form's validation summary. Confirm or update the namespace for `BlazorSample.Client.Starship`.

Note that the form requires authorization, so the user must be signed into the app to navigate to the form.

> [!NOTE]
> Forms based on <xref:Microsoft.AspNetCore.Components.Forms.EditForm> automatically enable [antiforgery support](xref:blazor/forms/index#antiforgery-support).

`Pages/Starship10.razor` in the `.Client` project:

```razor
@page "/starship-10"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using BlazorSample.Client.Starship
@attribute [Authorize]
@inject IFormValidation FormValidation
@inject ILogger<Starship10> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm FormName="Starship10" Model="Model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <CustomValidation @ref="customValidation" />
    <ValidationSummary />
    <div>
        <label>
            Identifier: 
            <InputText @bind-Value="Model!.Id" disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification" disabled="@disabled">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </div>
    <div>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" disabled="@disabled" />
        </label>
    </div>
    <div>
        <button type="submit" disabled="@disabled">Submit</button>
    </div>
    <div style="@messageStyles">
        @message
    </div>
</EditForm>

@code {
    private CustomValidation? customValidation;
    private bool disabled;
    private string? message;
    private string messageStyles = "visibility:hidden";

    [SupplyParameterFromForm]
    private StarshipModel? Model { get; set; }

    protected override void OnInitialized() => 
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private async Task Submit(EditContext editContext)
    {
        customValidation?.ClearErrors();

        try
        {
            var validationProblemDetails = 
                await FormValidation.ValidateStarshipFormAsync(
                    (StarshipModel)editContext.Model);

            if (validationProblemDetails?.Count > 0)
            {
                customValidation?.DisplayErrors(validationProblemDetails);
            }
            else
            {
                disabled = true;
                messageStyles = "color:green";
                message = "The form has been processed.";
            }
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Form processing error.");
            disabled = true;
            messageStyles = "color:red";
            message = "There was an error processing the form.";
        }
    }
}
```

> [!NOTE]
> As an alternative to the use of a [validation component](#validator-components), custom data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. For more information, see <xref:blazor/forms/validation#custom-validation-rules>.

To reach the form easily, add the following entry to the `NavMenu` component (`Layout/NavMenu.razor`) in the `.Client` project:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="starship-10">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Starship
    </NavLink>
</div>
```

When automatic model binding validation fails on the server, the framework returns a [default bad request response](xref:web-api/index#default-badrequest-response) with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. The response contains more data than just the validation errors, as shown in the following example when all of the fields of the `Starfleet Starship Database` form aren't submitted and the form fails validation:

```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Id": ["The Id field is required."],
    "Classification": ["The Classification field is required."],
    "IsValidatedDesign": ["This form disallows unapproved ships."],
    "MaximumAccommodation": ["Accommodation invalid (1-100000)."]
  }
}
```

> [!NOTE]
> To demonstrate the preceding JSON responses, you must either disable the form's client validation to permit empty field form submission or use a tool to send a request directly to the Minimal API, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/).

If automatic type validation passes but the custom validation fails, the following JSON response is received from the Minimal API:

```json
{
    "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
    "title": "One or more validation errors occurred.",
    "instance": "MinimalApiJwt",
    "status": 400,
    "errors": {
      "Description": ["For a 'Defense' ship, 'Description' is required."]
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-10.0"

*This section is focused on Blazor Web App scenarios, but the approach for any type of app that uses server-side validation with web API adopts the same general approach.*

Remote validation is supported in addition to Blazor Web App client-side and server-side validation:

* Process client validation in the form with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.
* When the form passes client validation (<xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit> is called), send the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Model?displayProperty=nameWithType> to a backend server API for form processing.
* Process model validation on the server.
* The server API includes both the built-in framework data annotations validation and custom validation logic supplied by the developer. If validation passes on the server, process the form and send back a success status code ([`200 - OK`](https://developer.mozilla.org/docs/Web/HTTP/Status/200)). If validation fails, return a failure status code ([`400 - Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status/400)) and the field validation errors.
* Either disable the form on success or display the errors.

Basic validation is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a validator component is recommended where an independent model class is used across several components.

The following example is based on:

* A Blazor Web App with Interactive WebAssembly components created from the [Blazor Web App project template](xref:blazor/project-structure).
* The `Starship` model  (`Starship.cs`) of the [Example form](xref:blazor/forms/input-components#example-form) section of the *Input components* article.
* The `CustomValidation` component shown in the [Validator components](#validator-components) section.

Place the `Starship` model (`Starship.cs`) into a shared class library project so that both the client and server projects can use the model. Add or update the namespace to match the namespace of the shared app (for example, `namespace BlazorSample.Shared`). Since the model requires data annotations, confirm that the shared class library uses the shared framework or add the [`System.ComponentModel.Annotations` package](https://www.nuget.org/packages/System.ComponentModel.Annotations) to the shared project.

[!INCLUDE[](~/includes/package-reference.md)]

In the main project of the Blazor Web App, add a controller to process starship validation requests and return failed validation messages. Update the namespaces in the last `using` statement for the shared class library project and the `namespace` for the controller class. In addition to client and server data annotations validation, the controller validates that a value is provided for the ship's description (`Description`) if the user selects the `Defense` ship classification (`Classification`).

The validation for the `Defense` ship classification only occurs on the server in the controller because the upcoming form doesn't perform the same validation client-side when the form is submitted to the server. Remote validation is common in apps that require private business logic validation of user input. For example, private information from data stored for a user might be required to validate user input. Private data obviously can't be sent to the client for client validation.

> [!NOTE]
> The `StarshipValidation` controller in this section uses Microsoft Identity 2.0. The Web API only accepts tokens for users that have the "`API.Access`" scope for this API. Additional customization is required if the API's scope name is different from `API.Access`.
>
> For more information on security, see:
>
> * <xref:blazor/security/index> (and the other articles in the Blazor *Security and Identity* node)
> * [Microsoft identity platform documentation](/entra/identity-platform/)

`Controllers/StarshipValidation.cs`:

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlazorSample.Shared;

namespace BlazorSample.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class StarshipValidationController(
    ILogger<StarshipValidationController> logger) 
    : ControllerBase
{
    static readonly string[] scopeRequiredByApi = [ "API.Access" ];

    [HttpPost]
    public async Task<IActionResult> Post(Starship model)
    {
        HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

        try
        {
            if (model.Classification == "Defense" && 
                string.IsNullOrEmpty(model.Description))
            {
                ModelState.AddModelError(nameof(model.Description),
                    "For a 'Defense' ship " +
                    "classification, 'Description' is required.");
            }
            else
            {
                logger.LogInformation("Processing the form asynchronously");

                // async ...

                return Ok(ModelState);
            }
        }
        catch (Exception ex)
        {
            logger.LogError("Validation Error: {Message}", ex.Message);
        }

        return BadRequest(ModelState);
    }
}
```

Confirm or update the namespace of the preceding controller (`BlazorSample.Server.Controllers`) to match the app's controllers' namespace.

When a model binding validation error occurs on the server, an [`ApiController`](xref:web-api/index) (<xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute>) normally returns a [default bad request response](xref:web-api/index#default-badrequest-response) with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. The response contains more data than just the validation errors, as shown in the following example when all of the fields of the `Starfleet Starship Database` form aren't submitted and the form fails validation:

```json
{
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Id": [ "The Id field is required." ],
    "Classification": [ "The Classification field is required." ],
    "IsValidatedDesign": [ "This form disallows unapproved ships." ],
    "MaximumAccommodation": [ "Accommodation invalid (1-100000)." ]
  }
}
```

> [!NOTE]
> To demonstrate the preceding JSON response, you must either disable the form's client validation to permit empty field form submission or use a tool to send a request directly to the server API, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/).

If the server API returns the preceding default JSON response, it's possible for the client to parse the response in developer code to obtain the children of the `errors` node for forms validation error processing. It's inconvenient to write developer code to parse the file. Parsing the JSON manually requires producing a [`Dictionary<string, List<string>>`](xref:System.Collections.Generic.Dictionary%602) of errors after calling <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A>. Ideally, the server API should only return the validation errors, as the following example shows:

```json
{
  "Id": [ "The Id field is required." ],
  "Classification": [ "The Classification field is required." ],
  "IsValidatedDesign": [ "This form disallows unapproved ships." ],
  "MaximumAccommodation": [ "Accommodation invalid (1-100000)." ]
}
```

To modify the server API's response to make it only return the validation errors, change the delegate that's invoked on actions that are annotated with <xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute> in the `Program` file. For the API endpoint (`/StarshipValidation`), return a <xref:Microsoft.AspNetCore.Mvc.BadRequestObjectResult> with the <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>. For any other API endpoints, preserve the default behavior by returning the object result with a new <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>.

Add the <xref:Microsoft.AspNetCore.Mvc?displayProperty=fullName> namespace to the top of the `Program` file in the main project of the Blazor Web App:

```csharp
using Microsoft.AspNetCore.Mvc;
```

In the `Program` file, add or update the following <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> extension method and add the following call to <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.ConfigureApiBehaviorOptions%2A>:

```csharp
builder.Services.AddControllersWithViews()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            if (context.HttpContext.Request.Path == "/StarshipValidation")
            {
                return new BadRequestObjectResult(context.ModelState);
            }
            else
            {
                return new BadRequestObjectResult(
                    new ValidationProblemDetails(context.ModelState));
            }
        };
    });
```

If you're adding controllers to the main project of the Blazor Web App for the first time, map controller endpoints when you place the preceding code that registers services for controllers. The following example uses default controller routes:

```csharp
app.MapDefaultControllerRoute();
```

> [!NOTE]
> The preceding example explicitly registers controller services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> to automatically [mitigate Cross-Site Request Forgery (XSRF/CSRF) attacks](xref:security/anti-request-forgery). If you merely use <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A>, antiforgery isn't enabled automatically.

For more information on controller routing and validation failure error responses, see the following resources:

* <xref:mvc/controllers/routing>
* <xref:fundamentals/error-handling-api#validation-failure-error-response>

In the `.Client` project, add the `CustomValidation` component shown in the [Validator components](#validator-components) section. Update the namespace to match the app (for example, `namespace BlazorSample.Client`).

In the `.Client` project, the `Starfleet Starship Database` form is updated to show validation errors with help of the `CustomValidation` component. When validation messages are returned, they're added to the `CustomValidation` component's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore>. The errors are available in the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> for display by the form's validation summary.

In the following component, update the namespace of the shared project (`@using BlazorSample.Shared`) to the shared project's namespace. Note that the form requires authorization, so the user must be signed into the app to navigate to the form.

`Starship10.razor`:

> [!NOTE]
> Forms based on <xref:Microsoft.AspNetCore.Components.Forms.EditForm> automatically enable [antiforgery support](xref:blazor/forms/index#antiforgery-support). The controller should use <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> to register controller services and automatically enable antiforgery support for the web API.

```razor
@page "/starship-10"
@rendermode InteractiveWebAssembly
@using System.Net
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using BlazorSample.Shared
@attribute [Authorize]
@inject HttpClient Http
@inject ILogger<Starship10> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm FormName="Starship10" Model="Model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <CustomValidation @ref="customValidation" />
    <ValidationSummary />
    <div>
        <label>
            Identifier: 
            <InputText @bind-Value="Model!.Id" disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification" disabled="@disabled">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </div>
    <div>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" disabled="@disabled" />
        </label>
    </div>
    <div>
        <button type="submit" disabled="@disabled">Submit</button>
    </div>
    <div style="@messageStyles">
        @message
    </div>
</EditForm>

@code {
    private CustomValidation? customValidation;
    private bool disabled;
    private string? message;
    private string messageStyles = "visibility:hidden";

    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized() => 
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private async Task Submit(EditContext editContext)
    {
        customValidation?.ClearErrors();

        try
        {
            using var response = await Http.PostAsJsonAsync<Starship>(
                "StarshipValidation", (Starship)editContext.Model);

            var errors = await response.Content
                .ReadFromJsonAsync<Dictionary<string, List<string>>>() ?? 
                new Dictionary<string, List<string>>();

            if (response.StatusCode == HttpStatusCode.BadRequest && 
                errors.Any())
            {
                customValidation?.DisplayErrors(errors);
            }
            else if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Validation failed. Status Code: {response.StatusCode}");
            }
            else
            {
                disabled = true;
                messageStyles = "color:green";
                message = "The form has been processed.";
            }
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
        }
        catch (Exception ex)
        {
            Logger.LogError("Form processing error: {Message}", ex.Message);
            disabled = true;
            messageStyles = "color:red";
            message = "There was an error processing the form.";
        }
    }
}
```

The `.Client` project of a Blazor Web App must also register an <xref:System.Net.Http.HttpClient> for HTTP POST requests to a backend web API controller. Confirm or add the following to the `.Client` project's `Program` file:

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
```

The preceding example sets the base address with `builder.HostEnvironment.BaseAddress` (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress%2A?displayProperty=nameWithType>), which gets the base address for the app and is typically derived from the `<base>` tag's `href` value in the host page.

> [!NOTE]
> As an alternative to the use of a [validation component](#validator-components), custom data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. For more information, see <xref:blazor/forms/validation#custom-validation-rules>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section is focused on hosted Blazor WebAssembly scenarios, but the approach for any type of app that uses server-side validation with web API adopts the same general approach.*

Remote validation is supported in addition to server-side validation in a hosted Blazor WebAssembly app:

* Process client validation in the form with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.
* When the form passes client validation (<xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit> is called), send the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Model?displayProperty=nameWithType> to a backend server API for form processing.
* Process model validation on the server.
* The server API includes both the built-in framework data annotations validation and custom validation logic supplied by the developer. If validation passes on the server, process the form and send back a success status code ([`200 - OK`](https://developer.mozilla.org/docs/Web/HTTP/Status/200)). If validation fails, return a failure status code ([`400 - Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status/400)) and the field validation errors.
* Either disable the form on success or display the errors.

Basic validation is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a validator component is recommended where an independent model class is used across several components.

The following example is based on:

* A hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) created from the [Blazor WebAssembly project template](xref:blazor/project-structure). The approach is supported for any of the secure hosted Blazor solutions described in the [hosted Blazor WebAssembly security documentation](xref:blazor/security/webassembly/index#implementation-guidance).
* The `Starship` model  (`Starship.cs`) of the [Example form](xref:blazor/forms/input-components#example-form) section of the *Input components* article.
* The `CustomValidation` component shown in the [Validator components](#validator-components) section.

Place the `Starship` model (`Starship.cs`) into the solution's **`Shared`** project so that both the client and server apps can use the model. Add or update the namespace to match the namespace of the shared app (for example, `namespace BlazorSample.Shared`). Since the model requires data annotations, add the [`System.ComponentModel.Annotations` package](https://www.nuget.org/packages/System.ComponentModel.Annotations) to the **`Shared`** project.

[!INCLUDE[](~/includes/package-reference.md)]

In the **:::no-loc text="Server":::** project, add a controller to process starship validation requests and return failed validation messages. Update the namespaces in the last `using` statement for the **`Shared`** project and the `namespace` for the controller class. In addition to client and server data annotations validation, the controller validates that a value is provided for the ship's description (`Description`) if the user selects the `Defense` ship classification (`Classification`).

The validation for the `Defense` ship classification only occurs on the server in the controller because the upcoming form doesn't perform the same validation client-side when the form is submitted to the server. Remote validation is common in apps that require private business logic validation of user input on the server. For example, private information from data stored for a user might be required to validate user input. Private data obviously can't be sent to the client for client validation.

> [!NOTE]
> The `StarshipValidation` controller in this section uses Microsoft Identity 2.0. The Web API only accepts tokens for users that have the "`API.Access`" scope for this API. Additional customization is required if the API's scope name is different from `API.Access`.
>
> For more information on security, see:
>
> * <xref:blazor/security/index> (and the other articles in the Blazor *Security and Identity* node)
> * [Microsoft identity platform documentation](/entra/identity-platform/)

`Controllers/StarshipValidation.cs`:

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlazorSample.Shared;

namespace BlazorSample.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class StarshipValidationController(
    ILogger<StarshipValidationController> logger) 
    : ControllerBase
{
    static readonly string[] scopeRequiredByApi = new[] { "API.Access" };

    [HttpPost]
    public async Task<IActionResult> Post(Starship model)
    {
        HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

        try
        {
            if (model.Classification == "Defense" && 
                string.IsNullOrEmpty(model.Description))
            {
                ModelState.AddModelError(nameof(model.Description),
                    "For a 'Defense' ship " +
                    "classification, 'Description' is required.");
            }
            else
            {
                logger.LogInformation("Processing the form asynchronously");

                // async ...

                return Ok(ModelState);
            }
        }
        catch (Exception ex)
        {
            logger.LogError("Validation Error: {Message}", ex.Message);
        }

        return BadRequest(ModelState);
    }
}
```

Confirm or update the namespace of the preceding controller (`BlazorSample.Server.Controllers`) to match the app's controllers' namespace.

When a model binding validation error occurs on the server, an [`ApiController`](xref:web-api/index) (<xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute>) normally returns a [default bad request response](xref:web-api/index#default-badrequest-response) with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. The response contains more data than just the validation errors, as shown in the following example when all of the fields of the `Starfleet Starship Database` form aren't submitted and the form fails validation:

```json
{
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Id": [ "The Id field is required." ],
    "Classification": [ "The Classification field is required." ],
    "IsValidatedDesign": [ "This form disallows unapproved ships." ],
    "MaximumAccommodation": [ "Accommodation invalid (1-100000)." ]
  }
}
```

> [!NOTE]
> To demonstrate the preceding JSON response, you must either disable the form's client validation to permit empty field form submission or use a tool to send a request directly to the server API, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/).

If the server API returns the preceding default JSON response, it's possible for the client to parse the response in developer code to obtain the children of the `errors` node for forms validation error processing. It's inconvenient to write developer code to parse the file. Parsing the JSON manually requires producing a [`Dictionary<string, List<string>>`](xref:System.Collections.Generic.Dictionary%602) of errors after calling <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A>. Ideally, the server API should only return the validation errors, as the following example shows:

```json
{
  "Id": [ "The Id field is required." ],
  "Classification": [ "The Classification field is required." ],
  "IsValidatedDesign": [ "This form disallows unapproved ships." ],
  "MaximumAccommodation": [ "Accommodation invalid (1-100000)." ]
}
```

To modify the server API's response to make it only return the validation errors, change the delegate that's invoked on actions that are annotated with <xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute> in the `Program` file. For the API endpoint (`/StarshipValidation`), return a <xref:Microsoft.AspNetCore.Mvc.BadRequestObjectResult> with the <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>. For any other API endpoints, preserve the default behavior by returning the object result with a new <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>.

Add the <xref:Microsoft.AspNetCore.Mvc?displayProperty=fullName> namespace to the top of the `Program` file in the **:::no-loc text="Server":::** app:

```csharp
using Microsoft.AspNetCore.Mvc;
```

In the `Program` file, locate the <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> extension method and add the following call to <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.ConfigureApiBehaviorOptions%2A>:

```csharp
builder.Services.AddControllersWithViews()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            if (context.HttpContext.Request.Path == "/StarshipValidation")
            {
                return new BadRequestObjectResult(context.ModelState);
            }
            else
            {
                return new BadRequestObjectResult(
                    new ValidationProblemDetails(context.ModelState));
            }
        };
    });
```

> [!NOTE]
> The preceding example explicitly registers controller services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> to automatically [mitigate Cross-Site Request Forgery (XSRF/CSRF) attacks](xref:security/anti-request-forgery). If you merely use <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A>, antiforgery isn't enabled automatically.

In the **:::no-loc text="Client":::** project, add the `CustomValidation` component shown in the [Validator components](#validator-components) section. Update the namespace to match the app (for example, `namespace BlazorSample.Client`).

In the **:::no-loc text="Client":::** project, the `Starfleet Starship Database` form is updated to show validation errors with help of the `CustomValidation` component. When validation messages are returned, they're added to the `CustomValidation` component's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore>. The errors are available in the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> for display by the form's validation summary.

In the following component, update the namespace of the **`Shared`** project (`@using BlazorSample.Shared`) to the shared project's namespace. Note that the form requires authorization, so the user must be signed into the app to navigate to the form.

`Starship10.razor`:

```razor
@page "/starship-10"
@using System.Net
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using BlazorSample.Shared
@attribute [Authorize]
@inject HttpClient Http
@inject ILogger<Starship10> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="Model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <CustomValidation @ref="customValidation" />
    <ValidationSummary />
    <div>
        <label>
            Identifier: 
            <InputText @bind-Value="Model!.Id" disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification" disabled="@disabled">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </div>
    <div>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" 
                disabled="@disabled" />
        </label>
    </div>
    <div>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" disabled="@disabled" />
        </label>
    </div>
    <div>
        <button type="submit" disabled="@disabled">Submit</button>
    </div>
    <div style="@messageStyles">
        @message
    </div>
</EditForm>

@code {
    private CustomValidation? customValidation;
    private bool disabled;
    private string? message;
    private string messageStyles = "visibility:hidden";
    
    public Starship? Model { get; set; }

    protected override void OnInitialized() => 
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private async Task Submit(EditContext editContext)
    {
        customValidation?.ClearErrors();

        try
        {
            using var response = await Http.PostAsJsonAsync<Starship>(
                "StarshipValidation", (Starship)editContext.Model);

            var errors = await response.Content
                .ReadFromJsonAsync<Dictionary<string, List<string>>>() ?? 
                new Dictionary<string, List<string>>();

            if (response.StatusCode == HttpStatusCode.BadRequest && 
                errors.Any())
            {
                customValidation?.DisplayErrors(errors);
            }
            else if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Validation failed. Status Code: {response.StatusCode}");
            }
            else
            {
                disabled = true;
                messageStyles = "color:green";
                message = "The form has been processed.";
            }
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
        }
        catch (Exception ex)
        {
            Logger.LogError("Form processing error: {Message}", ex.Message);
            disabled = true;
            messageStyles = "color:red";
            message = "There was an error processing the form.";
        }
    }
}
```

> [!NOTE]
> As an alternative to the use of a [validation component](#validator-components), custom data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. For more information, see <xref:blazor/forms/validation#custom-validation-rules>.

> [!NOTE]
> The remote validation approach in this section is suitable for any of the hosted Blazor WebAssembly solution examples in this documentation set:
>
> * [Microsoft Entra ID (ME-ID)](xref:blazor/security/webassembly/hosted-with-microsoft-entra-id)
> * [Azure Active Directory (AAD) B2C](xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c)
> * [Identity Server](xref:blazor/security/webassembly/hosted-with-identity-server)

:::moniker-end

## Additional resources

* <xref:blazor/forms/validation>
* <xref:blazor/forms/index>
* <xref:mvc/models/validation>

:::moniker range=">= aspnetcore-10.0"

* <xref:fundamentals/validation>

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

* <xref:blazor/forms/validation-client-side>

:::moniker-end

