---
title: ASP.NET Core Blazor advanced form validation
ai-usage: ai-assisted
author: guardrex
description: Learn how to implement validator components and remote validation for Blazor forms.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 09/22/2026
uid: blazor/forms/validation-advanced
---
# ASP.NET Core Blazor advanced form validation

[!INCLUDE[](~/includes/not-latest-version.md)]

This article demonstrates reusable validator components and remote validation. For common form validation APIs, including data annotations, direct <xref:Microsoft.AspNetCore.Components.Forms.EditContext> validation, message display, styling, state, and submit behavior, see <xref:blazor/forms/validation>.

:::moniker range=">= aspnetcore-10.0"

For model-based validation rules shared by Blazor and Minimal APIs, see <xref:fundamentals/validation>.

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

For browser validation in static server-side rendering (static SSR), see <xref:blazor/forms/validation-client-side>.

:::moniker-end

<span id="validator-components"></span>
<span id="business-logic-validation-with-a-validator-component"></span>
<span id="validate-with-editcontext-and-validationmessagestore"></span>
<span id="manual-validation-using-the-onvalidationrequested-event"></span>

## Build a validator component

A validator component encapsulates validation that uses a form's `EditContext` and <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore>. This is useful when the same validation behavior is used by several forms or when errors arrive from a service rather than from validation attributes on the model.

The component:

* Receives the form's `EditContext` as a cascading parameter.
* Creates a message store for its errors.
* Clears stale form errors when validation is requested.
* Clears a field's stale errors when the field changes.
* Exposes methods for displaying and clearing errors.
* Unsubscribes its event handlers when disposed.

`CustomValidation.razor`:

```razor
@implements IDisposable

@code {
    [CascadingParameter]
    private EditContext? CurrentEditContext { get; set; }

    private ValidationMessageStore messages = default!;

    protected override void OnInitialized()
    {
        if (CurrentEditContext is null)
        {
            throw new InvalidOperationException(
                "CustomValidation requires a cascading EditContext.");
        }

        messages = new ValidationMessageStore(CurrentEditContext);
        CurrentEditContext.OnValidationRequested +=
            HandleValidationRequested;
        CurrentEditContext.OnFieldChanged += HandleFieldChanged;
    }

    public void DisplayErrors(IDictionary<string, string[]> errors)
    {
        foreach (var error in errors)
        {
            messages.Add(
                CurrentEditContext!.Field(error.Key),
                error.Value);
        }

        CurrentEditContext!.NotifyValidationStateChanged();
    }

    public void ClearErrors()
    {
        messages.Clear();
        CurrentEditContext!.NotifyValidationStateChanged();
    }

    private void HandleValidationRequested(
        object? sender, ValidationRequestedEventArgs e) =>
        ClearErrors();

    private void HandleFieldChanged(
        object? sender, FieldChangedEventArgs e)
    {
        messages.Clear(e.FieldIdentifier);
        CurrentEditContext!.NotifyValidationStateChanged();
    }

    public void Dispose()
    {
        if (CurrentEditContext is not null)
        {
            CurrentEditContext.OnValidationRequested -=
                HandleValidationRequested;
            CurrentEditContext.OnFieldChanged -= HandleFieldChanged;
        }
    }
}
```

Place the component inside an `EditForm` and capture a component reference when the form or a service should display errors:

```razor
<EditForm Model="Model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <CustomValidation @ref="customValidation" />
    <ValidationSummary />

    ...
</EditForm>

@code {
    private CustomValidation? customValidation;
}
```

The component can be used alongside `DataAnnotationsValidator`. Each validator has its own message store associated with the same `EditContext`, and `ValidationMessage` and `ValidationSummary` display messages from both validators.

To implement a business rule inside the validator component instead of accepting external errors, run the rule from `HandleValidationRequested` or `HandleFieldChanged` and add its messages to `messages`. For a smaller example that performs this directly in a form component, see <xref:blazor/forms/validation#add-validation-through-editcontext>.

:::moniker range=">= aspnetcore-11.0"

<a id="asynchronous-validation"></a>

### Add asynchronous validation

The same component pattern supports asynchronous work:

<!-- UPDATE 11.0 - API Browser cross-ref

                   <xref:Microsoft.AspNetCore.Components.Forms.EditContext.RegisterAsyncFieldValidator%2A>
-->

* In an `OnValidationRequested` handler, call `e.AddAsyncValidator` to register form-level work. `EditForm` awaits it before invoking `OnValidSubmit` or `OnInvalidSubmit`.
* In an `OnFieldChanged` handler, call `RegisterAsyncFieldValidator` to start validation for that field. Starting another validation for the same field supersedes and cancels the previous operation.

For form-level asynchronous validation:

```csharp
private void HandleValidationRequested(
    object? sender, ValidationRequestedEventArgs e) =>
    e.AddAsyncValidator(ValidateAsync);

private async Task ValidateAsync(CancellationToken cancellationToken)
{
    var field = CurrentEditContext!.Field(nameof(Model.Username));
    messages.Clear(field);

    var available = await Http.GetFromJsonAsync<bool>(
        $"api/usernames/available?value={Uri.EscapeDataString(Model.Username)}",
        cancellationToken);

    if (!available)
    {
        messages.Add(field, "The username is already taken.");
    }

    CurrentEditContext.NotifyValidationStateChanged();
}
```

For field-level asynchronous validation:

```csharp
private void HandleFieldChanged(
    object? sender, FieldChangedEventArgs e)
{
    CurrentEditContext!.RegisterAsyncFieldValidator(
        e.FieldIdentifier,
        token => ValidateFieldAsync(e.FieldIdentifier, token));
}
```

Pass the supplied cancellation token to I/O. Clear prior messages before starting the operation, avoid publishing partial results after an exception, and call `NotifyValidationStateChanged` after updating messages.

An operation canceled because it was superseded or because the validation pass was canceled is discarded. Other exceptions place the field or form in the faulted state. For displaying pending and faulted state, see <xref:blazor/forms/validation#respond-to-validation-state>.

For a complete component that combines form-level and per-field asynchronous validation, see the following sample:

:::code language="razor" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/Components/UsernameUniquenessValidator.razor":::

For asynchronous validation attributes on the model, see <xref:fundamentals/validation#asynchronous-validation-support>.

:::moniker-end

Validator component code runs where the component runs. In Interactive WebAssembly, it runs in the browser, while it runs on the server over the circuit in Interactive Server.

:::moniker range=">= aspnetcore-8.0"

In static SSR, validator component code runs on the server during the form post and doesn't provide live .NET field validation between requests.

:::moniker-end

<a id="remote-validation-in-a-minimal-api"></a>
<a id="remote-validation-with-a-validator-component"></a>

## Remote validation from Interactive WebAssembly

Remote validation sends form data from an Interactive WebAssembly component to a server endpoint and adds returned field errors to the form's `EditContext`. It's useful when a rule requires private server data, an external service, or other logic that shouldn't run in the browser.

The form:

1. Runs data annotations validation locally.
1. Sends locally valid input to the endpoint from `OnValidSubmit`.
1. Receives field-keyed validation errors from the server.
1. Adds remote errors to the form through the validator component.

`OnValidSubmit` only means that local validation succeeded. Process or save the model only after remote validation also succeeds.

> [!IMPORTANT]
> Don't send private validation data or business rules to the browser. The server must validate every request independently because client-side validation can be bypassed.

:::moniker range=">= aspnetcore-11.0"

This example validates remotely when the form is submitted. For live per-field remote checks, use the asynchronous field-validation pattern from [Add asynchronous validation](#add-asynchronous-validation).

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

If the WebAssembly form is prerendered, its client-side services must also be available during prerendering. For the available approaches, see <xref:blazor/components/prerender#client-side-services-fail-to-resolve-during-prerendering>.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

### Validate with a Minimal API

Call <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> in the server project to validate supported endpoint parameters before the handler runs.

:::moniker-end

:::moniker range="= aspnetcore-10.0"

The <xref:Microsoft.Extensions.Validation?displayProperty=fullName> APIs used for generated validation metadata are experimental in .NET 10. For details, see <xref:fundamentals/validation#experimental-api-in-apps-that-target-net-10>.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

If the model is declared in the `.Client` project, register its generated validation metadata in both projects as described in <xref:fundamentals/validation#register-validation-across-assemblies>.

The endpoint adds a private business rule and returns errors keyed by model member name:

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

:::code language="csharp" source="~/../blazor-samples/11.0/BlazorWebAppRemoteValidation/BlazorWebAppRemoteValidation/Program.cs" id="snippet_ValidationEndpoint":::

:::moniker-end

:::moniker range="= aspnetcore-10.0"

```csharp
app.MapPost("/api/starships/validate", (StarshipModel model) =>
{
    Dictionary<string, string[]> errors = [];

    if (model.Classification == "Defense" &&
        string.IsNullOrWhiteSpace(model.Description))
    {
        errors[nameof(model.Description)] =
            ["A defense ship requires a description."];
    }

    if (errors.Count > 0)
    {
        return Results.ValidationProblem(errors);
    }

    return Results.NoContent();
});
```

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

Automatic validation rejects invalid data annotations before the handler runs. <xref:Microsoft.AspNetCore.Http.Results.ValidationProblem%2A> returns `400 Bad Request` with an `errors` property containing field-keyed messages. Successful validation returns `204 No Content`.

:::moniker-end

:::moniker range="< aspnetcore-10.0"

### Validate with an API controller

In a hosted Blazor WebAssembly solution, place the shared model in the `Shared` project and validate it with an API controller in the `Server` project. The `[ApiController]` attribute automatically rejects invalid data annotations before the action runs.

```csharp
[ApiController]
[Route("api/starships/validate")]
public class StarshipValidationController : ControllerBase
{
    [HttpPost]
    public IActionResult Validate(StarshipModel model)
    {
        if (model.Classification == "Defense" &&
            string.IsNullOrWhiteSpace(model.Description))
        {
            ModelState.AddModelError(
                nameof(model.Description),
                "A defense ship requires a description.");
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        return NoContent();
    }
}
```

Register and map controllers in the server project. The controller returns `400 Bad Request` with a `ValidationProblemDetails` response when validation fails and `204 No Content` when it succeeds.

:::moniker-end

### Call the endpoint and display errors

Register an `HttpClient` in the WebAssembly project with the app's base address:

:::moniker range=">= aspnetcore-11.0"

:::code language="csharp" source="~/../blazor-samples/11.0/BlazorWebAppRemoteValidation/BlazorWebAppRemoteValidation.Client/Program.cs" id="snippet_HttpClient":::

:::moniker-end

:::moniker range="< aspnetcore-11.0"

```csharp
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
```

:::moniker-end

Place the `CustomValidation` component from [Build a validator component](#build-a-validator-component) in the form:

:::moniker range=">= aspnetcore-11.0"

:::code language="razor" source="~/../blazor-samples/11.0/BlazorWebAppRemoteValidation/BlazorWebAppRemoteValidation.Client/Pages/Home.razor":::

:::moniker-end

:::moniker range="< aspnetcore-11.0"

```razor
@using System.Net
@using System.Net.Http.Json
@inject HttpClient Http

<EditForm Model="Model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <CustomValidation @ref="remoteErrors" />
    <ValidationSummary />

    ...
</EditForm>

@code {
    private StarshipModel Model { get; } = new StarshipModel();
    private CustomValidation? remoteErrors;

    private async Task Submit()
    {
        using var response = await Http.PostAsJsonAsync(
            "api/starships/validate", Model);

        if (response.IsSuccessStatusCode)
        {
            // Process or save the model.
            return;
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problem = await response.Content
                .ReadFromJsonAsync<ValidationProblemResponse>();

            if (problem is not null)
            {
                remoteErrors!.DisplayErrors(problem.Errors);
            }

            return;
        }

        response.EnsureSuccessStatusCode();
    }

    private sealed class ValidationProblemResponse
    {
        public Dictionary<string, string[]> Errors { get; set; } =
            new Dictionary<string, string[]>();
    }
}
```

:::moniker-end

The validator component clears a remote field error when that field changes, so the user can correct the value and submit again. Protect the endpoint according to the application's security requirements; authentication and authorization are outside the scope of this validation example.

:::moniker range=">= aspnetcore-11.0"

The [complete remote-validation sample](https://github.com/dotnet/blazor-samples/tree/main/11.0/BlazorWebAppRemoteValidation) includes the host endpoint, shared model, cross-assembly validation registration, validator component, and Interactive WebAssembly form.

:::moniker-end

:::moniker range="= aspnetcore-10.0"

The [.NET 10 remote-validation sample](https://github.com/dotnet/blazor-samples/tree/main/10.0/BlazorWebAppRemoteValidation) demonstrates the same validation flow in an Interactive Auto app with authentication and a server-side proxy.

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-11.0"

* <xref:blazor/forms/validation>
* <xref:blazor/forms/validation-client-side>
* <xref:fundamentals/validation>
* <xref:fundamentals/minimal-apis>

:::moniker-end

:::moniker range=">= aspnetcore-10.0 < aspnetcore-11.0"

* <xref:blazor/forms/validation>
* <xref:fundamentals/validation>
* <xref:fundamentals/minimal-apis>

:::moniker-end

:::moniker range="< aspnetcore-10.0"

<xref:blazor/forms/validation>

:::moniker-end
