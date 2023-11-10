---
title: ASP.NET Core Blazor forms overview
author: guardrex
description: Learn how to use forms in Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/forms/index
---
# ASP.NET Core Blazor forms overview

[!INCLUDE[](~/includes/not-latest-version.md)]

The Blazor framework supports forms and provides built-in input components:

:::moniker range=">= aspnetcore-8.0"

* Bound to an object or model that can use [data annotations](xref:mvc/models/validation)
  * HTML forms with the `<form>` element
  * <xref:Microsoft.AspNetCore.Components.Forms.EditForm> components
* [Built-in input components](xref:blazor/forms/input-components)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* An <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component bound to an object or model that can use [data annotations](xref:mvc/models/validation)
* [Built-in input components](xref:blazor/forms/input-components)

:::moniker-end

The <xref:Microsoft.AspNetCore.Components.Forms?displayProperty=fullName> namespace provides:

* Classes for managing form elements, state, and validation.
* Access to built-in :::no-loc text="Input*"::: components.

A project created from the Blazor project template includes the namespace by default in the app's `_Imports.razor` file, which makes the namespace available to the app's Razor components.

:::moniker range=">= aspnetcore-8.0"

Standard interactive HTML forms with server rendering are supported. Create a form using the normal HTML `<form>` tag and specify an `@onsubmit` handler for handling the submitted form request.

`StarshipPlainForm.razor`:

```razor
@page "/starship-plain-form"
@rendermode RenderMode.InteractiveServer
@inject ILogger<StarshipPlainForm> Logger

<form method="post" @onsubmit="Submit" @formname="starship-plain-form">
    <AntiforgeryToken />
    <InputText @bind-Value="Model!.Id" />
    <button type="submit">Submit</button>
</form>

@code {
    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit()
    {
        Logger.LogInformation("Id = {Id}", Model?.Id);
    }

    public class Starship
    {
        public string? Id { get; set; }
    }
}
```

In the preceding `StarshipPlainForm` component:

* The form is rendered where the `<form>` element appears.
* The model is created in the component's `@code` block and held in a public property (`Model`). The `[SupplyParameterFromForm]` attribute indicates that the value of the associated property should be supplied from the form data. Data in the request that matches the property's name is bound to the property.
* The <xref:Microsoft.AspNetCore.Components.Forms.InputText> component is an input component for editing string values. The `@bind-Value` directive attribute binds the `Model.Id` model property to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.Value%2A> property.
* The `Submit` method is registered as a handler for the <!-- <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> --> `@onsubmit` callback. The handler is called when the form is submitted by the user.

Blazor enhances page navigation and form handling by intercepting the request in order to apply the response to the existing DOM, preserving as much of the rendered form as possible. The enhancement avoids the need to fully load the page and provides a much smoother user experience, similar to a single-page app (SPA), although the component is rendered on the server. For more information, see <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>.

[Streaming rendering](xref:blazor/components/rendering#streaming-rendering) is supported for plain HTML forms.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

The preceding example includes antiforgery support by including an `AntiforgeryToken` component in the form. Antiforgery support is explained further in the [Antiforgery support](#antiforgery-support) section of this article.

To submit a form based on another element's DOM events, for example `oninput` or `onblur`, use JavaScript to submit the form ([`submit` (MDN documentation)](https://developer.mozilla.org/docs/Web/API/HTMLFormElement/submit)).

> [!IMPORTANT]
> For an HTML form, always use the `@formname` attribute directive to assign the form's name.

Instead of using plain forms in Blazor apps, a form is typically defined with Blazor's built-in form support using the framework's <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component. The following Razor component demonstrates typical elements, components, and Razor code to render a webform using an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

A form is defined using the Blazor framework's <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component. The following Razor component demonstrates typical elements, components, and Razor code to render a webform using an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component.

:::moniker-end

`Starship1.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-1"
@rendermode RenderMode.InteractiveServer
@inject ILogger<Starship1> Logger

<EditForm Model="@Model" OnSubmit="@Submit" FormName="Starship1">
    <InputText @bind-Value="Model!.Id" />
    <button type="submit">Submit</button>
</EditForm>

@code {
    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit()
    {
        Logger.LogInformation("Id = {Id}", Model?.Id);
    }

    public class Starship
    {
        public string? Id { get; set; }
    }
}
```

In the preceding `Starship1` component:

* The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component is rendered where the `<EditForm>` element appears.
* The model is created in the component's `@code` block and held in a public property (`Model`). The property is assigned to  <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> is assigned to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> parameter. The `[SupplyParameterFromForm]` attribute indicates that the value of the associated property should be supplied from the form data. Data in the request that matches the property's name is bound to the property.
* The <xref:Microsoft.AspNetCore.Components.Forms.InputText> component is an [input component](xref:blazor/forms/input-components) for editing string values. The `@bind-Value` directive attribute binds the `Model.Id` model property to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.Value%2A> property.
* The `Submit` method is registered as a handler for the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> callback. The handler is called when the form is submitted by the user.

Blazor enhances page navigation and form handling for <xref:Microsoft.AspNetCore.Components.Forms.EditForm> components. For more information, see <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>.

[Streaming rendering](xref:blazor/components/rendering#streaming-rendering) is supported for <xref:Microsoft.AspNetCore.Components.Forms.EditForm>.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-1"
@inject ILogger<Starship1> Logger

<EditForm Model="@Model" OnSubmit="@Submit">
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

```razor
@page "/starship-2"
@rendermode RenderMode.InteractiveServer
@inject ILogger<Starship2> Logger

<EditForm Model="@Model" OnValidSubmit="@Submit" FormName="Starship2">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <InputText @bind-Value="Model!.Id" />
    <button type="submit">Submit</button>
</EditForm>

@code {
    [SupplyParameterFromForm]
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

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-2"
@inject ILogger<Starship2> Logger

<EditForm Model="@Model" OnValidSubmit="@Submit">
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

:::moniker range=">= aspnetcore-8.0"

## Antiforgery support

The `AntiforgeryToken` component renders an antiforgery token as a hidden field, and the `[RequireAntiforgeryToken]` attribute enables antiforgery protection. If an antiforgery check fails, a [`400 - Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status/400) response is thrown and the form isn't processed.

For forms based on <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, the `AntiforgeryToken` component and `[RequireAntiforgeryToken]` attribute are automatically added to provide antiforgery protection by default.

For forms based on the HTML `<form>` element, manually add the `AntiforgeryToken` component to the form:

```razor
@rendermode RenderMode.InteractiveServer

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

## Enhanced form handling

[Enhance navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) for form POST requests with the `Enhance` parameter for `EditForm` forms or the `data-enhance` attribute for HTML forms (`<form>`):

```razor
<EditForm Enhance ...>
    ...
</EditForm>
```

```html
<form data-enhance ...>
    ...
</form>
```

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> You can't set enhanced navigation on a form's ancestor element to enable enhanced form handling.

```html
<div data-enhance>
    <form ...>
        <!-- NOT enhanced -->
    </form>
</div>
```

Enhanced form posts only work with Blazor endpoints. Posting an enhanced form to non-Blazor endpoint results in an error.

To disable enhanced form handling:

* For an `EditForm`, remove the `Enhance` parameter from the form element (or set it to `false`: `Enhance="false"`).
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

Components are configured for interactivity with server rendering and enhanced navigation. For a client-side experience in a Blazor Web App, change the render mode in the `@rendermode` directive at the top of the component to either:

* `RenderMode.InteractiveWebAssembly` for only interactive client rendering after prerendering.
* `RenderMode.InteractiveAuto` for interactive client rendering after Interactive Server rendering, which operates while the Blazor app bundle downloads in the background and the .NET WebAssembly runtime starts on the client.

If working with a standalone Blazor WebAssembly app, render modes aren't used. Blazor WebAssembly apps always run interactively on WebAssembly. The example interactive forms in this article function in a standalone Blazor WebAssembly app as long as the code doesn't make assumptions about running on the server instead of the client. You can remove the `@rendermode` directive from the component when using the example forms in a Blazor WebAssembly app.

When using the WebAssembly or Auto render modes, keep in mind that all of the component code is compiled and sent to the client, where users can decompile and inspect it. Don't place private code, app secrets, or other sensitive information in client-rendered components.

Examples don't adopt enhanced form handling for form POST requests, but all of the examples can be updated to adopt the enhanced features by following the guidance in the [Enhanced form handling](#enhanced-form-handling) section.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Examples use the [target-typed `new` operator](/dotnet/csharp/language-reference/operators/new-operator#target-typed-new), which was introduced with C# 9.0 and .NET 5. In the following example, the type isn't explicitly stated for the `new` operator:

```csharp
public ShipDescription ShipDescription { get; set; } = new();
```

If using C# 8.0 or earlier (.NET 3.1), modify the example code to state the type to the `new` operator:

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

To demonstrate how forms work with [data annotations](xref:mvc/models/validation) validation, example components rely on <xref:System.ComponentModel.DataAnnotations?displayProperty=nameWithType> API. To avoid an extra line of code in each example to use the namespace, make the namespace available throughout the app's components with the imports file. Add the following line to the project's `_Imports.razor` file:

```razor
@using System.ComponentModel.DataAnnotations
```

Form examples reference aspects of the [Star Trek](http://www.startrek.com/) universe. Star Trek is a copyright &copy;1966-2023 of [CBS Studios](https://www.paramount.com/brand/cbs-studios) and [Paramount](https://www.paramount.com).

<!-- UPDATE 8.0 HOLD for post-RC2 or post-RTM
                The intention is to link to a few of the
                framework test assets that include great
                additional examples for inspection.

## Additional form examples

The following additional form examples are available for inspection in the [ASP.NET Core GitHub repository (`dotnet/aspnetcore`) forms test assets](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/Components.TestServer/RazorComponents/Pages/Forms).

* <xref:Microsoft.AspNetCore.Components.Forms.EditForm> examples
  * xxx
  * xxx
* HTML forms (`<form>`) examples
  * xxx
  * xxx

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

-->

## Additional resources

:::moniker range=">= aspnetcore-8.0"

* <xref:blazor/file-uploads>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
* [ASP.NET Core GitHub repository (`dotnet/aspnetcore`) forms test assets](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/Components.TestServer/RazorComponents/Pages/Forms)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* <xref:blazor/file-uploads>
* <xref:blazor/security/webassembly/hosted-with-microsoft-entra-id>
* <xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c>
* <xref:blazor/security/webassembly/hosted-with-identity-server>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
* [ASP.NET Core GitHub repository (`dotnet/aspnetcore`) forms test assets](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/Components.TestServer/RazorComponents/Pages/Forms)

:::moniker-end
