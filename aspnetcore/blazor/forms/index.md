---
title: ASP.NET Core Blazor forms overview
author: guardrex
description: Learn how to use forms in Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/forms/index
---
# ASP.NET Core Blazor forms overview

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use forms in Blazor.

## Input components and forms

The Blazor framework supports forms and provides built-in input components:

:::moniker range=">= aspnetcore-8.0"

* Bound to an object or model that can use [data annotations](xref:mvc/models/validation).
  * HTML forms with the `<form>` element.
  * <xref:Microsoft.AspNetCore.Components.Forms.EditForm> components.
* [Built-in input components](xref:blazor/forms/input-components).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* An <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component bound to an object or model that can use [data annotations](xref:mvc/models/validation).
* [Built-in input components](xref:blazor/forms/input-components).

:::moniker-end

> [!NOTE]
> Unsupported ASP.NET Core validation features are covered in the [Unsupported validation features](#unsupported-validation-features) section.

The <xref:Microsoft.AspNetCore.Components.Forms?displayProperty=fullName> namespace provides:

* Classes for managing form elements, state, and validation.
* Access to built-in :::no-loc text="Input*"::: components.

A project created from the Blazor project template includes the namespace by default in the app's `_Imports.razor` file, which makes the namespace available to the app's Razor components.

:::moniker range=">= aspnetcore-8.0"

Standard HTML forms are supported. Create a form using the normal HTML `<form>` tag and specify an `@onsubmit` handler for handling the submitted form request.

`StarshipPlainForm.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/StarshipPlainForm.razor":::

In the preceding `StarshipPlainForm` component:

* The form is rendered where the `<form>` element appears. The form is named with the [`@formname`](xref:mvc/views/razor#formname) directive attribute, which uniquely identifies the form to the Blazor framework.
* The model is created in the component's `@code` block and held in a public property (`Model`). The `[SupplyParameterFromForm]` attribute indicates that the value of the associated property should be supplied from the form data. Data in the request that matches the property's name is bound to the property.
* The <xref:Microsoft.AspNetCore.Components.Forms.InputText> component is an input component for editing string values. The `@bind-Value` directive attribute binds the `Model.Id` model property to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.Value%2A> property.
* The `Submit` method is registered as a handler for the <!-- <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> --> `@onsubmit` callback. The handler is called when the form is submitted by the user.

> [!IMPORTANT]
> Always use the [`@formname`](xref:mvc/views/razor#formname) directive attribute with a unique form name.

Blazor enhances page navigation and form handling by intercepting the request in order to apply the response to the existing DOM, preserving as much of the rendered form as possible. The enhancement avoids the need to fully load the page and provides a much smoother user experience, similar to a single-page app (SPA), although the component is rendered on the server. For more information, see <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>.

[Streaming rendering](xref:blazor/components/rendering#streaming-rendering) is supported for plain HTML forms.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

The preceding example includes antiforgery support by including an <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryToken> component in the form. Antiforgery support is explained further in the [Antiforgery support](#antiforgery-support) section of this article.

To submit a form based on another element's DOM events, for example `oninput` or `onblur`, use JavaScript to submit the form ([`submit` (MDN documentation)](https://developer.mozilla.org/docs/Web/API/HTMLFormElement/submit)).

Instead of using plain forms in Blazor apps, a form is typically defined with Blazor's built-in form support using the framework's <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component. The following Razor component demonstrates typical elements, components, and Razor code to render a webform using an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

A form is defined using the Blazor framework's <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component. The following Razor component demonstrates typical elements, components, and Razor code to render a webform using an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component.

:::moniker-end

`Starship1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship1.razor":::

In the preceding `Starship1` component:

* The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component is rendered where the `<EditForm>` element appears. The form is named with the [`@formname`](xref:mvc/views/razor#formname) directive attribute, which uniquely identifies the form to the Blazor framework.
* The model is created in the component's `@code` block and held in a public property (`Model`). The property is assigned to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> parameter. The `[SupplyParameterFromForm]` attribute indicates that the value of the associated property should be supplied from the form data. Data in the request that matches the property's name is bound to the property.
* The <xref:Microsoft.AspNetCore.Components.Forms.InputText> component is an [input component](xref:blazor/forms/input-components) for editing string values. The `@bind-Value` directive attribute binds the `Model.Id` model property to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.Value%2A> property.
* The `Submit` method is registered as a handler for the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> callback. The handler is called when the form is submitted by the user.

> [!IMPORTANT]
> Always use the [`@formname`](xref:mvc/views/razor#formname) directive attribute with a unique form name.

Blazor enhances page navigation and form handling for <xref:Microsoft.AspNetCore.Components.Forms.EditForm> components. For more information, see <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>.

[Streaming rendering](xref:blazor/components/rendering#streaming-rendering) is supported for <xref:Microsoft.AspNetCore.Components.Forms.EditForm>.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-1"
@inject ILogger<Starship1> Logger

<EditForm Model="Model" OnSubmit="Submit">
    <InputText @bind-Value="Model!.Id" />
    <button type="submit">Submit</button>
</EditForm>

@code {
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit()
    {
        Logger.LogInformation("Model.Id = {Id}", Model?.Id);
    }

    public class Starship
    {
        public string? Id { get; set; }
    }
}
```

In the preceding `Starship1` component:

* The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component is rendered where the `<EditForm>` element appears.
* The model is created in the component's `@code` block and held in a private field (`model`). The field is assigned to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> parameter.
* The <xref:Microsoft.AspNetCore.Components.Forms.InputText> component is an input component for editing string values. The `@bind-Value` directive attribute binds the `Model.Id` model property to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.Value%2A> property&dagger;.
* The `Submit` method is registered as a handler for the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> callback. The handler is called when the form is submitted by the user.

:::moniker-end

&dagger;For more information on property binding, see <xref:blazor/components/data-binding#binding-with-component-parameters>.

In the next example, the preceding component is modified to create the form in the `Starship2` component:

* <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> is replaced with <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit>, which processes assigned event handler if the form is valid when submitted by the user.
* A <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component is added to display validation messages when the form is invalid on form submission.
* The data annotations validator (<xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component&dagger;) attaches validation support using data annotations:
  * If the `<input>` form field is left blank when the **`Submit`** button is selected, an error appears in the validation summary (<xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component&Dagger;) ("`The Id field is required.`") and `Submit` is **not** called.
  * If the `<input>` form field contains more than ten characters when the **`Submit`** button is selected, an error appears in the validation summary ("`Id is too long.`"). `Submit` is **not** called.
  * If the `<input>` form field contains a valid value when the **`Submit`** button is selected, `Submit` is called.

&dagger;The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component is covered in the [Validator component](xref:blazor/forms/validation#validator-components) section. &Dagger;The <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component is covered in the [Validation Summary and Validation Message components](xref:blazor/forms/validation#validation-summary-and-validation-message-components) section.

`Starship2.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-2"
@using System.ComponentModel.DataAnnotations
@inject ILogger<Starship2> Logger

<EditForm Model="Model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <InputText @bind-Value="Model!.Id" />
    <button type="submit">Submit</button>
</EditForm>

@code {
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit()
    {
        Logger.LogInformation("Id = {Id}", Model?.Id);
    }

    public class Starship
    {
        [Required]
        [StringLength(10, ErrorMessage = "Id is too long.")]
        public string? Id { get; set; }
    }
}
```

:::moniker-end

## Handle form submission

The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> provides the following callbacks for handling form submission:

* Use <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit> to assign an event handler to run when a form with valid fields is submitted.
* Use <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnInvalidSubmit> to assign an event handler to run when a form with invalid fields is submitted.
* Use <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> to assign an event handler to run regardless of the form fields' validation status. The form is validated by calling <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A?displayProperty=nameWithType> in the event handler method. If <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A> returns `true`, the form is valid.

## Clear a form or field

Reset a form by clearing its model back its default state, which can be performed inside or outside of an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>'s markup:

```razor
<button @onclick="ClearForm">Clear form</button>

...

private void ClearForm() => Model = new();
```

Alternatively, use an explicit Razor expression:

```razor
<button @onclick="@(() => Model = new())">Clear form</button>
```

Reset a field by clearing its model value back to its default state:

```razor
<button @onclick="ResetId">Reset Identifier</button>

...

private void ResetId() => Model!.Id = string.Empty;
```

Alternatively, use an explicit Razor expression:

```razor
<button @onclick="@(() => Model!.Id = string.Empty)">Reset Identifier</button>
```

There's no need to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in the preceding examples because <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is automatically called by the Blazor framework to rerender the component after an event handler is invoked. If an event handler isn't used to invoke the methods that clear a form or field, then developer code should call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> to rerender the component.

:::moniker range=">= aspnetcore-8.0"

## Antiforgery support

Antiforgery services are automatically added to Blazor apps when <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> is called in the `Program` file.

The app uses Antiforgery Middleware by calling <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> in its request processing pipeline in the `Program` file. <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> is called after the call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>. If there are calls to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>, the call to <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> must go between them. A call to <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> must be placed after calls to <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>.

The <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryToken> component renders an antiforgery token as a hidden field, and the `[RequireAntiforgeryToken]` attribute enables antiforgery protection. If an antiforgery check fails, a [`400 - Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status/400) response is thrown and the form isn't processed.

For forms based on <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, the <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryToken> component and `[RequireAntiforgeryToken]` attribute are automatically added to provide antiforgery protection by default.

For forms based on the HTML `<form>` element, manually add the <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryToken> component to the form:

```razor
<form method="post" @onsubmit="Submit" @formname="starshipForm">
    <AntiforgeryToken />
    <input id="send" type="submit" value="Send" />
</form>

@if (submitted)
{
    <p>Form submitted!</p>
}

@code{
    private bool submitted = false;

    private void Submit() => submitted = true;
}
```

> [!WARNING]
> For forms based on either <xref:Microsoft.AspNetCore.Components.Forms.EditForm> or the HTML `<form>` element, antiforgery protection can be disabled by passing `required: false` to the `[RequireAntiforgeryToken]` attribute. The following example disables antiforgery and is ***not recommended*** for public apps:
>
> ```razor
> @using Microsoft.AspNetCore.Antiforgery
> @attribute [RequireAntiforgeryToken(required: false)]
> ```

For more information, see <xref:blazor/security/index#antiforgery-support>.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Mitigate overposting attacks

Statically-rendered server-side forms, such as those typically used in components that create and edit records in a database with a form model, can be vulnerable to an *overposting* attack, also known as a *mass assignment* attack. An overposting attack occurs when a malicious user issues an HTML form POST to the server that processes data for properties that aren't part of the rendered form and that the developer doesn't wish to allow users to modify. The term "overposting" literally means that the malicious user has *over*-POSTed with the form.

Overposting isn't a concern when the model doesn't include restricted properties for create and update operations. However, it's important to keep overposting in mind when working with static SSR-based Blazor forms that you maintain.

To mitigate overposting, we recommend using a separate view model/data transfer object (DTO) for the form and database with create (insert) and update operations. When the form is submitted, only properties of the view model/DTO are used by the component and C# code to modify the database. Any extra data included by a malicious user is discarded, so the malicious user is prevented from conducting an overposting attack.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Enhanced form handling

[Enhance navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) for form POST requests with the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Enhance%2A> parameter for <xref:Microsoft.AspNetCore.Components.Forms.EditForm> forms or the `data-enhance` attribute for HTML forms (`<form>`):

```razor
<EditForm ... Enhance ...>
    ...
</EditForm>
```

```html
<form ... data-enhance ...>
    ...
</form>
```

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> You can't set enhanced navigation on a form's ancestor element to enable enhanced form handling.

```html
<div ... data-enhance ...>
    <form ...>
        <!-- NOT enhanced -->
    </form>
</div>
```

Enhanced form posts only work with Blazor endpoints. Posting an enhanced form to non-Blazor endpoint results in an error.

To disable enhanced form handling:

* For an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, remove the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Enhance%2A> parameter from the form element (or set it to `false`: `Enhance="false"`).
* For an HTML `<form>`, remove the `data-enhance` attribute from form element (or set it to `false`: `data-enhance="false"`).

Blazor's enhanced navigation and form handing may undo dynamic changes to the DOM if the updated content isn't part of the server rendering. To preserve the content of an element, use the `data-permanent` attribute.

In the following example, the content of the `<div>` element is updated dynamically by a script when the page loads:

```html
<div data-permanent>
    ...
</div>
```

To disable enhanced navigation and form handling globally, see <xref:blazor/fundamentals/startup#enhanced-navigation-and-form-handling>.

For guidance on using the `enhancedload` event to listen for enhanced page updates, see <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>.

:::moniker-end

## Examples

:::moniker range=">= aspnetcore-8.0"

Examples don't adopt enhanced form handling for form POST requests, but all of the examples can be updated to adopt the enhanced features by following the guidance in the [Enhanced form handling](#enhanced-form-handling) section.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Examples use the [target-typed `new` operator](/dotnet/csharp/language-reference/operators/new-operator#target-typed-new), which was introduced with C# 9.0 and .NET 5. In the following example, the type isn't explicitly stated for the `new` operator:

```csharp
public ShipDescription ShipDescription { get; set; } = new();
```

If using C# 8.0 or earlier (ASP.NET Core 3.1), modify the example code to state the type to the `new` operator:

```csharp
public ShipDescription ShipDescription { get; set; } = new ShipDescription();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Components use nullable reference types (NRTs), and the .NET compiler performs null-state static analysis, both of which are supported in .NET 6 or later. For more information, see <xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis>.

If using C# 9.0 or earlier (.NET 5 or earlier), remove the NRTs from the examples. Usually, this merely involves removing the question marks (`?`) and exclamation points (`!`) from the types in the example code.

The .NET SDK applies implicit global `using` directives to projects when targeting .NET 6 or later. The examples use a logger to log information about form processing, but it isn't necessary to specify an `@using` directive for the <xref:Microsoft.Extensions.Logging?displayProperty=nameWithType> namespace in the component examples. For more information, see [.NET project SDKs: Implicit using directives](/dotnet/core/project-sdk/overview#implicit-using-directives).

If using C# 9.0 or earlier (.NET 5 or earlier), add `@using` directives to the top of the component after the `@page` directive for any API required by the example. Find API namespaces through Visual Studio (right-click the object and select **Peek Definition**) or the [.NET API browser](/dotnet/api/).

:::moniker-end

To demonstrate how forms work with [data annotations](xref:mvc/models/validation) validation, example components rely on <xref:System.ComponentModel.DataAnnotations?displayProperty=nameWithType> API. If you wish to avoid an extra line of code in components that use data annotations, make the namespace available throughout the app's components with the imports file (`_Imports.razor`):

```razor
@using System.ComponentModel.DataAnnotations
```

Form examples reference aspects of the [Star Trek](http://www.startrek.com/) universe. Star Trek is a copyright &copy;1966-2023 of [CBS Studios](https://www.paramount.com/brand/cbs-studios) and [Paramount](https://www.paramount.com).

:::moniker range=">= aspnetcore-8.0"

## Client-side validation requires a circuit

In Blazor Web Apps, client-side validation requires an active Blazor SignalR circuit. Client-side validation isn't available to forms in components that have adopted static server-side rendering (static SSR). Forms that adopt static SSR are validated on the server after the form is submitted.

:::moniker-end

## Unsupported validation features

All of the [data annotation built-in validators](xref:mvc/models/validation#built-in-attributes) are supported in Blazor except for the [`[Remote]` validation attribute](xref:mvc/models/validation#remote-attribute).

## Additional resources

:::moniker range=">= aspnetcore-8.0"

* <xref:blazor/file-uploads>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))
* [ASP.NET Core GitHub repository (`dotnet/aspnetcore`) forms test assets](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/Components.TestServer/RazorComponents/Pages/Forms)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* <xref:blazor/file-uploads>
* <xref:blazor/security/webassembly/hosted-with-microsoft-entra-id>
* <xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c>
* <xref:blazor/security/webassembly/hosted-with-identity-server>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))
* [ASP.NET Core GitHub repository (`dotnet/aspnetcore`) forms test assets](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/Components.TestServer/RazorComponents/Pages/Forms)

:::moniker-end
