---
title: ASP.NET Core Blazor forms and input components
author: guardrex
description: Learn how to use forms with field validation and built-in input components in Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/forms-and-input-components
---
# ASP.NET Core Blazor forms and input components

[!INCLUDE[](~/includes/not-latest-version.md)]

The Blazor framework supports forms and provides built-in input components:

* <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component bound to a model that uses [data annotations](xref:mvc/models/validation)
* [Built-in input components](#built-in-input-components)

The <xref:Microsoft.AspNetCore.Components.Forms?displayProperty=fullName> namespace provides:

 * Classes for managing form elements, state, and validation.
 * Access to built-in :::no-loc text="Input*"::: components, which can be used in Blazor apps.
 
A project created from the Blazor project template includes the namespace by default in the app's `_Imports.razor` file, which makes the namespace available in all of the Razor component files (`.razor`) of the app without explicit [`@using`](xref:mvc/views/razor#using) directives:

```razor
@using Microsoft.AspNetCore.Components.Forms
```
## Examples in this article

Component example forms use more vertical line spacing than is normally found in production apps. The extra spacing is merely present to make the examples clearer.

:::moniker range=">= aspnetcore-8.0"

Components are configured for server-side rendering (SSR) and server interactivity. For a client-side experience, change the render mode in the `@attribute` directive at the top of the component to either:

* `RenderModeWebAssembly` for client-side rendering (CSR) in Blazor Web App projects or for Blazor WebAssembly projects.
* `RenderModeAuto` for CSR and interactivity. For CSR, keep in mind that all of the component code is compiled and set to the client, where users can decompile and inspect it. Never provide private code, app secrets, or other sensitive information in client-side code.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Examples use [target-typed `new` operator](/dotnet/csharp/language-reference/operators/new-operator#target-typed-new), which was introduced at .NET 5 with C# 9.0. In the following example, the type isn't explicitly stated with the `new` operator:

```csharp
public ShipDescription ShipDescription { get; set; } = new();
```

In .NET 3.1, modify the example code to explicitly name the type:

```csharp
public ShipDescription ShipDescription { get; set; } = new ShipDescription();
```

:::moniker-end

Components use nullable reference types (NRTs), and the .NET compiler performs null-state static analysis, both of which are supported in .NET 6 or later. For more information, see <xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis>.

The .NET SDK applies implicit global `using` directives to Blazor projects when targeting .NET 6 or later. The examples use a logger to log information about form processing, but it isn't necessary to specify an `@using` directive for the <xref:Microsoft.Extensions.Logging?displayProperty=nameWithType> namespace in the component examples. For more information, see [.NET project SDKs: Implicit using directives](/dotnet/core/project-sdk/overview#implicit-using-directives).

To demonstrate how an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component works with [data annotations](xref:mvc/models/validation) validation, example components rely on <xref:System.ComponentModel.DataAnnotations?displayProperty=nameWithType> API. To avoid an extra line of code in each example to add the namespace, make the namespace available throughout the app's components with the imports file.

Add the following line to the project's `_Imports.razor` file:

```razor
@using System.ComponentModel.DataAnnotations
```

Form examples reference aspects of the [Star Trek](http://www.startrek.com/) universe. Star Trek is a copyright &copy;1966-2023 of [CBS Studios](https://www.paramount.com/brand/cbs-studios) and [Paramount](https://www.paramount.com).

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/FormExampleXXXX.razor":::
:::code language="csharp" source="~/../blazor-samples/8.0/BlazorWebAppSample/XXXX.cs" highlight="XXXX":::

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExampleXXXX.razor":::
-->

## Additional form examples

The following additional form examples are available for inspection in the [ASP.NET Core GitHub repository (`dotnet/aspnetcore`) forms test assets](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/Components.TestServer/RazorComponents/Pages/Forms):

* <xref:Microsoft.AspNetCore.Components.Forms.EditForm> examples
  * xxx
  * xxx
* HTML forms (`<form>`) examples
  * xxx
  * xxx

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Introduction

A form is defined using the Blazor framework's <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component. The following Razor component demonstrates typical elements, components, and Razor code to render a webform using an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component.

`Starship1.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-1"
@attribute [RenderModeServer]
@inject ILogger<Starship1> Logger

<EditForm method="post" Model="@Model" OnSubmit="@Submit" FormName="Starship">

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

* The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component is rendered where the `<EditForm>` element appears. The `FormName` parameter sets the form handler name, which is required for posting to a server-side endpoint. The parameter isn't used during interactive rendering.
* The model is created in the component's `@code` block and held in a public property (`Model`). The property is assigned to  <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> is assigned to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> parameter. The `[SupplyParameterFromForm]` attribute indicates that the value of the associated property should be supplied from the form data for the form.
* The <xref:Microsoft.AspNetCore.Components.Forms.InputText> component is an input component for editing string values. The `@bind-Value` directive attribute binds the `Model.Id` model property to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.Value%2A> property.
* The `Submit` method is registered as a handler for the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> callback. The handler is called when the form is submitted by the user.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-1"
@inject ILogger<Starship1> Logger

<EditForm method="post" Model="@Model" OnSubmit="@Submit">

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
  * If the `<input>` form field contains more than ten characters when the **`Submit`** button is selected, an error appears in the validation summary ("`Id is too long.`") and `Submit` is **not** called.
  * If the `<input>` form field contains a valid value when the **`Submit`** button is selected, `Submit` is called.

&dagger;The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component is covered in the [Validator component](#validator-components) section. &Dagger;The <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component is covered in the [Validation Summary and Validation Message components](#validation-summary-and-validation-message-components) section.

`Starship2.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-2"
@attribute [RenderModeServer]
@inject ILogger<Starship2> Logger

<EditForm method="post" Model="@Model" OnValidSubmit="@Submit" FormName="Starship">

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

## Binding a form

An <xref:Microsoft.AspNetCore.Components.Forms.EditForm> creates an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> based on the assigned object as a [cascading value](xref:blazor/components/cascading-values-and-parameters) for other components in the form. The <xref:Microsoft.AspNetCore.Components.Forms.EditContext> tracks metadata about the edit process, including which form fields have been modified and the current validation messages. Assigning to either an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> or an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext?displayProperty=nameWithType> can bind a form to data.

Assignment to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType>:

:::moniker range=">= aspnetcore-8.0"

```razor
<EditForm method="post" Model="@Model" OnSubmit="@Submit" FormName="Starship">
    ...
</EditForm>

@code {
    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
<EditForm Model="@Model" ...>
    ...
</EditForm>

@code {
    public Starship? Model { get; set; } = new();
}
```

> [!NOTE]
> Most of this article's form model examples bind forms to C# *properties*, but C# field binding is also supported.

:::moniker-end

Assignment to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext?displayProperty=nameWithType>:

:::moniker range=">= aspnetcore-8.0"

```razor
<EditForm method="post" EditContext="@editContext" OnSubmit="@Submit"
     FormName="Starship">
     ...
</EditForm>

@code {
    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

    private EditContext? editContext;

    protected override void OnInitialized()
    {
        Model ??= new();
        editContext = new(Model);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
<EditForm EditContext="@editContext" OnSubmit="@Submit">
     ...
</EditForm>

@code {
    private Starship model = new();
    private EditContext? editContext;

    protected override void OnInitialized() => editContext = new(model);
}
```

:::moniker-end

Assign **either** an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext> **or** a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model> to an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>. Assignment of both isn't supported and generates a runtime error:

> Unhandled exception rendering component: EditForm requires a Model parameter, or an EditContext parameter, but not both.

:::moniker range=">= aspnetcore-8.0"

To bind multiple forms, provide each form a unique form name in the `FormName` parameter and pass the form name to the appropriate binding model property in the `[SupplyParameterFromForm]` attribute.

`Starship3.razor`:

```razor
@page "/starship-3"
@attribute [RenderModeServer]
@inject ILogger<Starship3> Logger

<EditForm method="post" Model="@Model1" OnSubmit="@Submit1" FormName="Starship1">

    <InputText @bind-Value="Model1!.Id" />

    <button type="submit">Submit</button>

</EditForm>

<EditForm method="post" Model="@Model2" OnSubmit="@Submit2" FormName="Starship2">

    <InputText @bind-Value="Model2!.Id" />

    <button type="submit">Submit</button>

</EditForm>

@code {
    [SupplyParameterFromForm(Handler = "Starship1")]
    public Customer? Model1 { get; set; }

    [SupplyParameterFromForm(Handler = "Starship2")]
    public Customer? Model2 { get; set; }

    protected override void OnInitialized()
    {
        Model1 ??= new();
        Model2 ??= new();
    }

    private void Submit1()
    {
        Logger.LogInformation("Submit1: Id = {Id}", Model1?.Id);
    }

    private void Submit2()
    {
        Logger.LogInformation("Submit2: Id = {Id}", Model2?.Id);
    }

    public class Starship
    {
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
@attribute [RenderModeServer]

<form method="post" @onsubmit="Submit" @formname="starship">

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

## Built-in input components

The Blazor framework provides built-in input components to receive and validate user input. The built-in input components in the following table are supported in an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> with an <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.

:::moniker range=">= aspnetcore-7.0"

The components in the table are also supported outside of a form in Razor component markup. Inputs are validated when they're changed and when a form is submitted.

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

| Input component | Rendered as&hellip; |
| --------------- | ------------------- |
| <xref:Microsoft.AspNetCore.Components.Forms.InputCheckbox> | `<input type="checkbox">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> | `<input type="date">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputFile> | `<input type="file">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> | `<input type="number">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> | `<input type="radio">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputRadioGroup%601> | Group of child <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> |
| <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> | `<select>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputText> | `<input>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputTextArea> | `<textarea>` |

For more information on the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component, see <xref:blazor/file-uploads>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

| Input component | Rendered as&hellip; |
| --------------- | ------------------- |
| <xref:Microsoft.AspNetCore.Components.Forms.InputCheckbox> | `<input type="checkbox">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> | `<input type="date">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> | `<input type="number">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> | `<select>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputText> | `<input>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputTextArea> | `<textarea>` |

> [!NOTE]
> <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> and <xref:Microsoft.AspNetCore.Components.Forms.InputRadioGroup%601> components are available in ASP.NET Core 5.0 or later. For more information, select a 5.0 or later version of this article.

:::moniker-end

All of the input components, including <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, support arbitrary attributes. Any attribute that doesn't match a component parameter is added to the rendered HTML element.

Input components provide default behavior for validating when a field is changed:

* For input components in a form with an <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, the default validation behavior includes updating the field CSS class to reflect the field's state as valid or invalid with validation styling of the underlying HTML element.
* For controls that don't have an <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, the default validation reflects the valid or invalid state but does ***not*** provide validation styling to the underlying HTML element.

Some components include useful parsing logic. For example, <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> handle unparseable values gracefully by registering unparseable values as validation errors. Types that can accept null values also support nullability of the target field (for example, `int?` for a nullable integer).

:::moniker range=">= aspnetcore-5.0"

For more information on the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component, see <xref:blazor/file-uploads>.

:::moniker-end

## Example form

The following `Starship` type, which is used in several of this article's examples, defines a diverse set of properties with data annotations:

* `Id` is required because it's annotated with the <xref:System.ComponentModel.DataAnnotations.RequiredAttribute>. `Id` requires a value of at least one character but no more than 16 characters using the <xref:System.ComponentModel.DataAnnotations.StringLengthAttribute>.
* `Description` is optional because it isn't annotated with the <xref:System.ComponentModel.DataAnnotations.RequiredAttribute>.
* `Classification` is required.
* The `MaximumAccommodation` property defaults to zero but requires a value from one to 100,000 per its <xref:System.ComponentModel.DataAnnotations.RangeAttribute>.
* `IsValidatedDesign` requires that the property have a `true` value, which matches a selected state when the property is bound to a checkbox in the UI (`<input type="checkbox">`).
* `ProductionDate` is a <xref:System.DateTime> and required.

`Starship.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

public class Starship
{
    [Required]
    [StringLength(16, ErrorMessage = "Id too long (16 character limit).")]
    public string? Id { get; set; }

    public string? Description { get; set; }

    [Required]
    public string? Classification { get; set; }

    [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
    public int MaximumAccommodation { get; set; }

    [Required]
    [Range(typeof(bool), "true", "true", 
        ErrorMessage = "This form disallows unapproved ships.")]
    public bool IsValidatedDesign { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }
}
```

<!--
:::code language="csharp" source="~/../blazor-samples/8.0/BlazorWebAppSample/Starship.cs":::
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Starship.cs":::
-->

The following form accepts and validates user input using:

* The properties and validation defined in the preceding `Starship` model.
* Several of Blazor's [built-in input components](#built-in-input-components).

`Starship4.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-4"
@attribute [RenderModeServer]
@inject ILogger<Starship4> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit" FormName="Starship">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </p>

    <p>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" />
        </label>
    </p>

    <p>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </p>

    <p>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" />
        </label>
    </p>

    <p>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" />
        </label>
    </p>

    <p>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" />
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

@code {
    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized() =>
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private void Submit()
    {
        // ...
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship4.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-4"
@inject ILogger<Starship4> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </p>

    <p>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" />
        </label>
    </p>

    <p>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </p>

    <p>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" />
        </label>
    </p>

    <p>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" />
        </label>
    </p>

    <p>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" />
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

@code {
    private Starship? Model { get; set; }

    protected override void OnInitialized() =>
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private void Submit()
    {
        // ...
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship4.razor":::
-->

:::moniker-end

The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> in the preceding example creates an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> based on the assigned `Starship` instance (`Model="..."`) and handles a valid form. The next example demonstrates how to assign an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> to a form and validate when the form is submitted.

In the following example:

* A shortened version of the preceding `Starfleet Starship Database` form (`Starship4` component) is used that only accepts a value for the starship's Id. The other `Starship` properties receive valid default values when an instance of the `Starship` type is created.
* The `Submit` method executes when the **`Submit`** button is selected.
* The form is validated by calling <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A?displayProperty=nameWithType> in the `Submit` method.
* Logging is executed depending on the validation result.

> [!NOTE]
> `Submit` in the next example is demonstrated as an asynchronous method because storing form values often uses asynchronous calls (`await ...`). If the form is used in a test app as shown, `Submit` merely runs synchronously. For testing purposes, ignore the following build warning:
>
> > This async method lacks 'await' operators and will run synchronously. ...

`Starship5.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-5"
@attribute [RenderModeServer]
@inject ILogger<Starship5> Logger

<EditForm EditContext="@editContext" OnSubmit="@Submit" FormName="Starship">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

@code {
    private EditContext? editContext;

    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??= 
            new()
            {
                Id = "NCC-1701",
                Classification = "Exploration",
                MaximumAccommodation = 150,
                IsValidatedDesign = true,
                ProductionDate = new DateTime(2245, 4, 11)
            };
        editContext = new(Model);
    }

    private async Task Submit()
    {
        if (editContext != null && editContext.Validate())
        {
            Logger.LogInformation("Submit called: Form is valid");

            // await ...

            await Task.CompletedTask;
        }
        else
        {
            Logger.LogInformation("Submit called: Form is INVALID");
        }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship5.razor" highlight="5,38,43":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-5"
@inject ILogger<Starship5> Logger

<EditForm EditContext="@editContext" OnSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

@code {
    private Starship Model { get; set; }
        
    private EditContext? editContext;

    protected override void OnInitialized()
    {
        Model ??= 
            new()
            {
                Id = "NCC-1701",
                Classification = "Exploration",
                MaximumAccommodation = 150,
                IsValidatedDesign = true,
                ProductionDate = new DateTime(2245, 4, 11)
            };
        editContext = new(Model);
    }

    private async Task Submit()
    {
        if (editContext != null && editContext.Validate())
        {
            Logger.LogInformation("Submit called: Form is valid");

            // await ...

            await Task.CompletedTask;
        }
        else
        {
            Logger.LogInformation("Submit called: Form is INVALID");
        }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship5.razor" highlight="4,38,43":::
-->

:::moniker-end

> [!NOTE]
> Changing the <xref:Microsoft.AspNetCore.Components.Forms.EditContext> after it's assigned is **not** supported.

:::moniker range=">= aspnetcore-6.0"

## Multiple option selection with the `InputSelect` component

Binding supports [`multiple`](https://developer.mozilla.org/docs/Web/HTML/Attributes/multiple) option selection with the <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> component. The [`@onchange`](xref:mvc/views/razor#onevent) event provides an array of the selected options via [event arguments (`ChangeEventArgs`)](xref:blazor/components/event-handling#event-arguments). The value must be bound to an array type, and binding to an array type makes the [`multiple`](https://developer.mozilla.org/docs/Web/HTML/Attributes/multiple) attribute optional on the <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> tag.

In the following example, the user must select at least two starship classifications but no more than three classifications.

`Pages/Starship6.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-6"
@attribute [RenderModeServer]
@inject ILogger<Starship6> Logger

<h1>Bind Multiple <code>InputSelect</code> Example</h1>

<EditForm EditContext="@editContext" OnValidSubmit="@Submit" FormName="Starship">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Select classifications (Minimum: 2, Maximum: 3):
            <InputSelect @bind-Value="Model!.SelectedClassification">
                <option value="@Classification.Exploration">Exploration</option>
                <option value="@Classification.Diplomacy">Diplomacy</option>
                <option value="@Classification.Defense">Defense</option>
                <option value="@Classification.Research">Research</option>
            </InputSelect>
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

@if (Model?.SelectedClassification?.Length > 0)
{
    <p>@string.Join(", ", Model.SelectedClassification)</p>
}

@code {
    private EditContext? editContext;

    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model = new();
        editContext = new(Model);
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    private class Starship
    {
        [Required]
        [MinLength(2, ErrorMessage = "Select at least two classifications.")]
        [MaxLength(3, ErrorMessage = "Select no more than three classifications.")]
        public Classification[]? SelectedClassification { get; set; } =
            new[] { Classification.None };
    }

    private enum Classification { None, Exploration, Diplomacy, Defense, Research }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship6.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-6"
@inject ILogger<Starship6> Logger

<h1>Bind Multiple <code>InputSelect</code> Example</h1>

<EditForm EditContext="@editContext" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Select classifications (Minimum: 2, Maximum: 3):
            <InputSelect @bind-Value="Model!.SelectedClassification">
                <option value="@Classification.Exploration">Exploration</option>
                <option value="@Classification.Diplomacy">Diplomacy</option>
                <option value="@Classification.Defense">Defense</option>
                <option value="@Classification.Research">Research</option>
            </InputSelect>
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

@if (Model?.SelectedClassification?.Length > 0)
{
    <p>@string.Join(", ", Model.SelectedClassification)</p>
}

@code {
    private EditContext? editContext;

    private Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new();
        editContext = new(Model);
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    private class Starship
    {
        [Required]
        [MinLength(2, ErrorMessage = "Select at least two classifications.")]
        [MaxLength(3, ErrorMessage = "Select no more than three classifications.")]
        public Classification[]? SelectedClassification { get; set; } =
            new[] { Classification.None };
    }

    private enum Classification { None, Exploration, Diplomacy, Defense, Research }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship6.razor":::
-->

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

For information on how empty strings and `null` values are handled in data binding, see the [Binding `InputSelect` options to C# object `null` values](#binding-inputselect-options-to-c-object-null-values) section.

:::moniker-end

## Binding `InputSelect` options to C# object `null` values

For information on how empty strings and `null` values are handled in data binding, see <xref:blazor/components/data-binding#binding-select-element-options-to-c-object-null-values>.

:::moniker range=">= aspnetcore-5.0"

## Display name support

Several built-in components support display names with the <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.DisplayName%2A?displayProperty=nameWithType> parameter.

In the `Starfleet Starship Database` form (`Starship4` component) of the [Example form](#example-form) section, the production date of a new starship doesn't specify a display name:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="Model!.ProductionDate" />
</label>
```

If the field contains an invalid date when the form is submitted, the error message doesn't display a friendly name. The field name, "`ProductionDate`" doesn't have a space between "`Production`" and "`Date`" when it appears in the validation summary:

> The ProductionDate field must be a date.

Set the <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.DisplayName%2A> property to a friendly name with a space between the words "`Production`" and "`Date`":

```razor
<label>
    Production Date:
    <InputDate @bind-Value="Model!.ProductionDate" 
               DisplayName="Production Date" />
</label>
```

The validation summary displays the friendly name when the field's value is invalid:

> The Production Date field must be a date.

:::moniker-end

## Error message template support

<xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> support error message templates:

* <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601.ParsingErrorMessage%2A?displayProperty=nameWithType>

:::moniker range=">= aspnetcore-5.0"

In the `Starfleet Starship Database` form (`FormExample2` component) of the [Example form](#example-form) section with a [friendly display name](#display-name-support) assigned, the `Production Date` field produces an error message using the following default error message template:

```css
The {0} field must be a date.
```

The position of the `{0}` placeholder is where the value of the <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.DisplayName%2A> property appears when the error is displayed to the user.

```razor
<label>
    Production Date:
    <InputDate @bind-Value="Model!.ProductionDate" 
               DisplayName="Production Date" />
</label>
```

> The Production Date field must be a date.

Assign a custom template to <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A> to provide a custom message:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="Model!.ProductionDate" 
               DisplayName="Production Date" 
               ParsingErrorMessage="The {0} field has an incorrect date value." />
</label>
```

> The Production Date field has an incorrect date value.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

In the `Starfleet Starship Database` form (`Starship4` component) of the [Example form](#example-form) section uses a default error message template:

```css
The {0} field must be a date.
```

The position of the `{0}` placeholder is where the value of the <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.DisplayName%2A> property appears when the error is displayed to the user.

```razor
<label>
    Production Date:
    <InputDate @bind-Value="Model!.ProductionDate" />
</label>
```

> The ProductionDate field must be a date.

Assign a custom template to <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A> to provide a custom message:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="Model!.ProductionDate" 
               ParsingErrorMessage="The {0} field has an incorrect date value." />
</label>
```

> The ProductionDate field has an incorrect date value.

:::moniker-end

## Basic validation

In basic form validation scenarios, an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> instance can use declared <xref:Microsoft.AspNetCore.Components.Forms.EditContext> and <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> instances to validate form fields. A handler for the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> event of the <xref:Microsoft.AspNetCore.Components.Forms.EditContext> executes custom validation logic. The handler's result updates the <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> instance.

Basic form validation is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a [validator component](#validator-components) is recommended where an independent model class is used across several components.

In the following `Starship7` component, the `HandleValidationRequested` handler method clears any existing validation messages by calling <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore.Clear%2A?displayProperty=nameWithType> before validating the form.

`Starship7.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-7"
@attribute [RenderModeServer]
@implements IDisposable
@inject ILogger<Starship7> Logger

<h2>Ship Holodecks</h2>

<EditForm EditContext="editContext" OnValidSubmit="@Submit">

    <label>
        Type 1:
        <InputCheckbox @bind-Value="Model!.Type1" />
    </label>

    <label>
        Type 2:
        <InputCheckbox @bind-Value="Model!.Type2" />
    </label>

    <button type="submit">Update</button>

    <p>
        <ValidationMessage For="() => Model!.Options" />
    </p>

</EditForm>

@code {
    private EditContext? editContext;

    [SupplyParameterFromForm]
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
        public bool Type1 { get; set; }
        public bool Type2 { get; set; }
        public bool Options => Type1 || Type2;
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
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship7.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-7"
@implements IDisposable
@inject ILogger<Starship7> Logger

<h2>Ship Holodecks</h2>

<EditForm EditContext="editContext" OnValidSubmit="@Submit">

    <label>
        Type 1:
        <InputCheckbox @bind-Value="Model!.Type1" />
    </label>

    <label>
        Type 2:
        <InputCheckbox @bind-Value="Model!.Type2" />
    </label>

    <button type="submit">Update</button>

    <p>
        <ValidationMessage For="() => Model!.Options" />
    </p>

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
        public bool Type1 { get; set; }
        public bool Type2 { get; set; }
        public bool Options => Type1 || Type2;
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
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship7.razor":::
-->

:::moniker-end

## Data Annotations Validator component and custom validation

The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component attaches data annotations validation to a cascaded <xref:Microsoft.AspNetCore.Components.Forms.EditContext>. Enabling data annotations validation requires the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. To use a different validation system than data annotations, use a custom implementation instead of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. The framework implementations for <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> are available for inspection in the reference source:

* [`DataAnnotationsValidator`](https://github.com/dotnet/AspNetCore/blob/main/src/Components/Forms/src/DataAnnotationsValidator.cs)
* [`AddDataAnnotationsValidation`](https://github.com/dotnet/AspNetCore/blob/main/src/Components/Forms/src/EditContextDataAnnotationsExtensions.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Blazor performs two types of validation:

* *Field validation* is performed when the user tabs out of a field. During field validation, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component associates all reported validation results with the field.
* *Model validation* is performed when the user submits the form. During model validation, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component attempts to determine the field based on the member name that the validation result reports. Validation results that aren't associated with an individual member are associated with the model rather than a field.

## Validator components

Validator components support form validation by managing a <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> for a form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.

The Blazor framework provides the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to attach validation support to forms based on [validation attributes (data annotations)](xref:mvc/models/validation#validation-attributes). You can create custom validator components to process validation messages for different forms on the same page or the same form at different steps of form processing (for example, client-side validation followed by server-side validation). The validator component example shown in this section, `CustomValidation`, is used in the following sections of this article:

* [Business logic validation with a validator component](#business-logic-validation-with-a-validator-component)
* [Server validation with a validator component](#server-validation-with-a-validator-component)

> [!NOTE]
> Custom data annotation validation attributes can be used instead of custom validator components in many cases. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation, any custom attributes applied to the model must be executable on the server. For more information, see <xref:mvc/models/validation#alternatives-to-built-in-attributes>.

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

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorSample;

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

    public void DisplayErrors(Dictionary<string, List<string>> errors)
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

<!--
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/CustomValidation.cs":::
-->

> [!IMPORTANT]
> Specifying a namespace is **required** when deriving from <xref:Microsoft.AspNetCore.Components.ComponentBase>. Failing to specify a namespace results in a build error:
>
> > Tag helpers cannot target tag name '\<global namespace>.{CLASS NAME}' because it contains a ' ' character.
>
> The `{CLASS NAME}` placeholder is the name of the component class. The custom validator example in this section specifies the example namespace `BlazorSample`.

> [!NOTE]
> Anonymous lambda expressions are registered event handlers for <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> and <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> in the preceding example. It isn't necessary to implement <xref:System.IDisposable> and unsubscribe the event delegates in this scenario. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

## Business logic validation with a validator component

For general business logic validation, use a [validator component](#validator-components) that receives form errors in a dictionary.

[Basic validation](#basic-validation) is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a validator component is recommended where an independent model class is used across several components.

In the following example:

* A shortened version of the `Starfleet Starship Database` form (`Starship4` component) from the [Example form](#example-form) section is used that only accepts the starship's classification and description. Data annotation validation is **not** triggered on form submission because the `DataAnnotationsValidator` component isn't included in the form.
* The `CustomValidation` component from the [Validator components](#validator-components) section of this article is used.
* The validation requires a value for the ship's description (`Description`) if the user selects the "`Defense`" ship classification (`Classification`).

When validation messages are set in the component, they're added to the validator's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> and shown in the <xref:Microsoft.AspNetCore.Components.Forms.EditForm>'s validation summary.

`Starship8.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-8"
@attribute [RenderModeServer]
@inject ILogger<Starship8> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit">

    <CustomValidation @ref="customValidation" />

    <ValidationSummary />

    <p>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </p>

    <p>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" />
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

@code {
    private CustomValidation? customValidation;

    [SupplyParameterFromForm]
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
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship8.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-8"
@inject ILogger<Starship8> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit">

    <CustomValidation @ref="customValidation" />

    <ValidationSummary />

    <p>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </p>

    <p>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" />
        </label>
    </p>

    <button type="submit">Submit</button>

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
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship8.razor":::
-->

:::moniker-end

> [!NOTE]
> As an alternative to using [validation components](#validator-components), data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation, the attributes must be executable on the server. For more information, see <xref:mvc/models/validation#alternatives-to-built-in-attributes>.

## Server validation with a validator component

Server validation is supported in addition to client-side validation:

* Process client-side validation in the form with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.
* When the form passes client-side validation (<xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit> is called), send the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Model?displayProperty=nameWithType> to a backend server API for form processing.
* Process model validation on the server.
* The server API includes both the built-in framework data annotations validation and custom validation logic supplied by the developer. If validation passes on the server, process the form and send back a success status code ([`200 - OK`](https://developer.mozilla.org/docs/Web/HTTP/Status/200)). If validation fails, return a failure status code ([`400 - Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status/400)) and the field validation errors.
* Either disable the form on success or display the errors.

[Basic validation](#basic-validation) is useful in cases where the form's model is defined within the component hosting the form, either as members directly on the component or in a subclass. Use of a validator component is recommended where an independent model class is used across several components.

The following example is based on:

* A hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) created from the [Blazor WebAssembly project template](xref:blazor/project-structure). The approach is supported for any of the secure hosted Blazor solutions described in the [hosted Blazor WebAssembly security documentation](xref:blazor/security/webassembly/index#implementation-guidance).
* The `Starship` model  (`Starship.cs`) from the [Example form](#example-form) section.
* The `CustomValidation` component shown in the [Validator components](#validator-components) section.

Place the `Starship` model (`Starship.cs`) into the solution's **`Shared`** project so that both the client and server apps can use the model. Add or update the namespace to match the namespace of the shared app (for example, `namespace BlazorSample.Shared`). Since the model requires data annotations, add the [`System.ComponentModel.Annotations`](https://www.nuget.org/packages/System.ComponentModel.Annotations) package to the **`Shared`** project.

[!INCLUDE[](~/includes/package-reference.md)]

In the **:::no-loc text="Server":::** project, add a controller to process starship validation requests and return failed validation messages. Update the namespaces in the last `using` statement for the **`Shared`** project and the `namespace` for the controller class. In addition to data annotations validation (client-side and server-side), the controller validates that a value is provided for the ship's description (`Description`) if the user selects the `Defense` ship classification (`Classification`).

The validation for the `Defense` ship classification only occurs server-side in the controller because the upcoming form doesn't perform the same validation client-side when the form is submitted to the server. Server-side validation without client-side validation is common in apps that require private business logic validation of user input on the server. For example, private information from data stored for a user might be required to validate user input. Private data obviously can't be sent to the client for client-side validation.

> [!NOTE]
> The `StarshipValidation` controller in this section uses Microsoft Identity 2.0. The Web API only accepts tokens for users that have the "`API.Access`" scope for this API. Additional customization is required if the API's scope name is different from `API.Access`. For a version of the controller that works with Microsoft Identity 1.0 and ASP.NET Core prior to version 5.0, see an earlier version of this article.
>
> For more information on security, see:
>
> * <xref:blazor/security/index> (and the other articles in the Blazor *Security and Identity* node)
> * [Microsoft identity platform documentation](/azure/active-directory/develop/)

`Controllers/StarshipValidation.cs`:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using BlazorSample.Shared;

namespace BlazorSample.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class StarshipValidationController : ControllerBase
{
    private readonly ILogger<StarshipValidationController> logger;

    public StarshipValidationController(
        ILogger<StarshipValidationController> logger)
    {
        this.logger = logger;
    }

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

If using the preceding controller in a hosted Blazor WebAssembly app, update the namespace (`BlazorSample.Server.Controllers`) to match the app's controllers namespace.

When a model binding validation error occurs on the server, an [`ApiController`](xref:web-api/index) (<xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute>) normally returns a [default bad request response](xref:web-api/index#default-badrequest-response) with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. The response contains more data than just the validation errors, as shown in the following example when all of the fields of the `Starfleet Starship Database` form aren't submitted and the form fails validation:

```json
{
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
> To demonstrate the preceding JSON response, you must either disable the form's client-side validation to permit empty field form submission or use a tool to send a request directly to the server API, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/) or [Postman](https://www.postman.com).

If the server API returns the preceding default JSON response, it's possible for the client to parse the response in developer code to obtain the children of the `errors` node for forms validation error processing. It's inconvenient to write developer code to parse the file. Parsing the JSON manually requires producing a [`Dictionary<string, List<string>>`](xref:System.Collections.Generic.Dictionary%602) of errors after calling <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A>. Ideally, the server API should only return the validation errors:

```json
{
  "Id": ["The Id field is required."],
  "Classification": ["The Classification field is required."],
  "IsValidatedDesign": ["This form disallows unapproved ships."],
  "MaximumAccommodation": ["Accommodation invalid (1-100000)."]
}
```

To modify the server API's response to make it only return the validation errors, change the delegate that's invoked on actions that are annotated with <xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute> in `Program.cs`. For the API endpoint (`/StarshipValidation`), return a <xref:Microsoft.AspNetCore.Mvc.BadRequestObjectResult> with the <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>. For any other API endpoints, preserve the default behavior by returning the object result with a new <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>.

Add the <xref:Microsoft.AspNetCore.Mvc?displayProperty=fullName> namespace to the top of the `Program.cs` file in the **:::no-loc text="Server":::** app:

```csharp
using Microsoft.AspNetCore.Mvc;
```

In `Program.cs`, locate the <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> extension method and add the following call to <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.ConfigureApiBehaviorOptions%2A>:

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

For more information, see <xref:web-api/handle-errors#validation-failure-error-response>.

In the **:::no-loc text="Client":::** project, add the `CustomValidation` component shown in the [Validator components](#validator-components) section. Update the namespace to match the app (for example, `namespace BlazorSample.Client`).

In the **:::no-loc text="Client":::** project, the `Starfleet Starship Database` form is updated to show server validation errors with help of the `CustomValidation` component. When the server API returns validation messages, they're added to the `CustomValidation` component's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore>. The errors are available in the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> for display by the form's validation summary.

In the following `Starship9` component, update the namespace of the **`Shared`** project (`@using BlazorSample.Shared`) to the shared project's namespace. Note that the form requires authorization, so the user must be signed into the app to navigate to the form.

`Starship9.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-9"
@attribute [RenderModeWebAssembly]
@using System.Net
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using BlazorSample.Shared
@attribute [Authorize]
@inject HttpClient Http
@inject ILogger<Starship9> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <CustomValidation @ref="customValidation" />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" 
                disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification" disabled="@disabled">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </p>

    <p>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" 
                disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" 
                disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" disabled="@disabled" />
        </label>
    </p>

    <button type="submit" disabled="@disabled">Submit</button>

    <p style="@messageStyles">
        @message
    </p>

</EditForm>

@code {
    private bool disabled;
    private string? message;
    private string? messageStyles = "visibility:hidden";
    private CustomValidation? customValidation;
    
    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

    protected override void OnInitialized() => 
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private async Task Submit(EditContext editContext)
    {
        customValidation?.ClearErrors();

        try
        {
            var response = await Http.PostAsJsonAsync<Starship>(
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

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship9.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-9"
@using System.Net
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using BlazorSample.Shared
@attribute [Authorize]
@inject HttpClient Http
@inject ILogger<Starship9> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <CustomValidation @ref="customValidation" />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" 
                disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="Model!.Classification" disabled="@disabled">
                <option value="">Select classification ...</option>
                <option value="Exploration">Exploration</option>
                <option value="Diplomacy">Diplomacy</option>
                <option value="Defense">Defense</option>
            </InputSelect>
        </label>
    </p>

    <p>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" 
                disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" 
                disabled="@disabled" />
        </label>
    </p>

    <p>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" disabled="@disabled" />
        </label>
    </p>

    <button type="submit" disabled="@disabled">Submit</button>

    <p style="@messageStyles">
        @message
    </p>

</EditForm>

@code {
    private bool disabled;
    private string? message;
    private string? messageStyles = "visibility:hidden";
    private CustomValidation? customValidation;
    
    public Starship? Model { get; set; }

    protected override void OnInitialized() => 
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private async Task Submit(EditContext editContext)
    {
        customValidation?.ClearErrors();

        try
        {
            var response = await Http.PostAsJsonAsync<Starship>(
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

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship9.razor":::
-->

:::moniker-end

> [!NOTE]
> As an alternative to the use of a [validation component](#validator-components), data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation, the attributes must be executable on the server. For more information, see <xref:mvc/models/validation#alternatives-to-built-in-attributes>.

> [!NOTE]
> The server-side validation approach in this section is suitable for any of the hosted Blazor WebAssembly solution examples in this documentation set:
>
> * [Azure Active Directory (AAD)](xref:blazor/security/webassembly/hosted-with-azure-active-directory)
> * [Azure Active Directory (AAD) B2C](xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c)
> * [Identity Server](xref:blazor/security/webassembly/hosted-with-identity-server)

## `InputText` based on the input event

Use the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component to create a custom component that uses the `oninput` event ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) instead of the `onchange` event ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)). Use of the `input` event triggers field validation on each keystroke.

The following `CustomInputText` component inherits the framework's `InputText` component and sets event binding to the `oninput` event ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)).

`CustomInputText.razor`:

```razor
@inherits InputText

<input @attributes="AdditionalAttributes" 
    class="@CssClass" 
    @bind="CurrentValueAsString" 
    @bind:event="oninput" />
```

The `CustomInputText` component can be used anywhere <xref:Microsoft.AspNetCore.Components.Forms.InputText> is used. The following  component uses the shared `CustomInputText` component.

`Starship10.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-10"
@attribute [RenderModeServer]
@inject ILogger<Starship10> Logger

<EditForm Model="@Model" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <CustomInputText @bind-Value="Model!.Id" />

    <button type="submit">Submit</button>

</EditForm>

<p>
    CurrentValue: @Model?.Id
</p>

@code {
    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public class Starship
    {
        [Required]
        [StringLength(10, ErrorMessage = "Id is too long.")]
        public string? Id { get; set; }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship10.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-10"
@inject ILogger<Starship10> Logger

<EditForm Model="@Model" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <CustomInputText @bind-Value="Model!.Id" />

    <button type="submit">Submit</button>

</EditForm>

<p>
    CurrentValue: @Model?.Id
</p>

@code {
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public class Starship
    {
        [Required]
        [StringLength(10, ErrorMessage = "Id is too long.")]
        public string? Id { get; set; }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship10.razor" highlight="9":::
-->

:::moniker-end

## Radio buttons

:::moniker range=">= aspnetcore-5.0"

The example in this section is based on the `Starfleet Starship Database` form of the [Example form](#example-form) section of this article.

Add the following [`enum` types](/dotnet/csharp/language-reference/language-specification/enums) to the app. Create a new file to hold them or add them to the `Starship.cs` file.

```csharp
public class ComponentEnums
{
    public enum Manufacturer { SpaceX, NASA, ULA, VirginGalactic, Unknown }
    public enum Color { ImperialRed, SpacecruiserGreen, StarshipBlue, VoyagerOrange }
    public enum Engine { Ion, Plasma, Fusion, Warp }
}
```

Make the `enums` accessible to the:

* `Starship` model in `Starship.cs` (for example, `using static ComponentEnums;` if the `enums` class is named `ComponentEnums`).
* `Starfleet Starship Database` form (for example, `@using static ComponentEnums` if the enums class is named `ComponentEnums`).

Use <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> components with the <xref:Microsoft.AspNetCore.Components.Forms.InputRadioGroup%601> component to create a radio button group. In the following example, properties are added to the `Starship` model described in the [Example form](#example-form) section:

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```csharp
[Required]
[Range(typeof(Manufacturer), nameof(Manufacturer.SpaceX), 
    nameof(Manufacturer.VirginGalactic), ErrorMessage = "Pick a manufacturer.")]
public Manufacturer Manufacturer { get; set; } = Manufacturer.Unknown;

[Required, EnumDataType(typeof(Color))]
public Color? Color { get; set; } = null;

[Required, EnumDataType(typeof(Engine))]
public Engine? Engine { get; set; } = null;
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

```csharp
[Required]
[Range(typeof(Manufacturer), nameof(Manufacturer.SpaceX), 
    nameof(Manufacturer.VirginGalactic), ErrorMessage = "Pick a manufacturer.")]
public Manufacturer Manufacturer { get; set; } = Manufacturer.Unknown;

[Required, EnumDataType(typeof(Color))]
public Color Color { get; set; } = null;

[Required, EnumDataType(typeof(Engine))]
public Engine Engine { get; set; } = null;
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

Update the `Starfleet Starship Database` form (`Starship4` component) from the [Example form](#example-form) section. Add the components to produce:

* A radio button group for the ship manufacturer.
* A nested radio button group for engine and ship color.

> [!NOTE]
> Nested radio button groups aren't often used in forms because they can result in a disorganized layout of form controls that may confuse users. However, there are cases when they make sense in UI design, such as in the following example that pairs recommendations for two user inputs, ship engine and ship color. One engine and one color are required by the form's validation. The form's layout uses nested <xref:Microsoft.AspNetCore.Components.Forms.InputRadioGroup%601>s to pair engine and color recommendations. However, the user can combine any engine with any color to submit the form.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```razor
<fieldset>
    <legend>Manufacturer</legend>
    <InputRadioGroup @bind-Value="Model!.Manufacturer">
        @foreach (var manufacturer in (Manufacturer[])Enum
            .GetValues(typeof(Manufacturer)))
        {
            <label>
                <InputRadio Value="@manufacturer" />
                <text>&nbsp;</text>@manufacturer
            </label>
        }
    </InputRadioGroup>
<fieldset>

<p>
    Select one engine and one color. Recommendations are paired but any 
    combination of engine and color is allowed:<br>
    <InputRadioGroup Name="engine" @bind-Value="Model!.Engine">
        <InputRadioGroup Name="color" @bind-Value="Model!.Color">
            <InputRadio Name="engine" Value="@Engine.Ion" />
            Engine: Ion<br>
            <InputRadio Name="color" Value="@Color.ImperialRed" />
            Color: Imperial Red<br><br>
            <InputRadio Name="engine" Value="@Engine.Plasma" />
            Engine: Plasma<br>
            <InputRadio Name="color" Value="@Color.SpacecruiserGreen" />
            Color: Spacecruiser Green<br><br>
            <InputRadio Name="engine" Value="@Engine.Fusion" />
            Engine: Fusion<br>
            <InputRadio Name="color" Value="@Color.StarshipBlue" />
            Color: Starship Blue<br><br>
            <InputRadio Name="engine" Value="@Engine.Warp" />
            Engine: Warp<br>
            <InputRadio Name="color" Value="@Color.VoyagerOrange" />
            Color: Voyager Orange
        </InputRadioGroup>
    </InputRadioGroup>
</p>
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

```razor
<fieldset>
    <legend>Manufacturer</legend>
    <InputRadioGroup @bind-Value="Model.Manufacturer">
        @foreach (var manufacturer in (Manufacturer[])Enum
            .GetValues(typeof(Manufacturer)))
        {
            <label>
                <InputRadio Value="@manufacturer" />
                <text>&nbsp;</text>@manufacturer
            </label>
        }
    </InputRadioGroup>
<fieldset>

<p>
    Select one engine and one color. Recommendations are paired but any 
    combination of engine and color is allowed:<br>
    <InputRadioGroup Name="engine" @bind-Value="Model.Engine">
        <InputRadioGroup Name="color" @bind-Value="Model.Color">
            <InputRadio Name="engine" Value="@Engine.Ion" />
            Engine: Ion<br>
            <InputRadio Name="color" Value="@Color.ImperialRed" />
            Color: Imperial Red<br><br>
            <InputRadio Name="engine" Value="@Engine.Plasma" />
            Engine: Plasma<br>
            <InputRadio Name="color" Value="@Color.SpacecruiserGreen" />
            Color: Spacecruiser Green<br><br>
            <InputRadio Name="engine" Value="@Engine.Fusion" />
            Engine: Fusion<br>
            <InputRadio Name="color" Value="@Color.StarshipBlue" />
            Color: Starship Blue<br><br>
            <InputRadio Name="engine" Value="@Engine.Warp" />
            Engine: Warp<br>
            <InputRadio Name="color" Value="@Color.VoyagerOrange" />
            Color: Voyager Orange
        </InputRadioGroup>
    </InputRadioGroup>
</p>
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

> [!NOTE]
> If `Name` is omitted, <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> components are grouped by their most recent ancestor.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

When working with radio buttons in a form, data binding is handled differently than other elements because radio buttons are evaluated as a group. The value of each radio button is fixed, but the value of the radio button group is the value of the selected radio button. The following example shows how to:

* Handle data binding for a radio button group.
* Support validation using a custom <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> component.

`InputRadio.razor`:

```razor
@using System.Globalization
@inherits InputBase<TValue>
@typeparam TValue

<input @attributes="AdditionalAttributes" type="radio" value="@SelectedValue" 
       checked="@(SelectedValue.Equals(Value))" @onchange="OnChange" />

@code {
    [Parameter]
    public TValue SelectedValue { get; set; }

    private void OnChange(ChangeEventArgs args)
    {
        CurrentValueAsString = args.Value.ToString();
    }

    protected override bool TryParseValueFromString(string value, 
        out TValue result, out string errorMessage)
    {
        var success = BindConverter.TryConvertTo<TValue>(
            value, CultureInfo.CurrentCulture, out var parsedValue);
        if (success)
        {
            result = parsedValue;
            errorMessage = null;

            return true;
        }
        else
        {
            result = default;
            errorMessage = $"{FieldId.FieldName} field isn't valid.";

            return false;
        }
    }
}
```

For more information on generic type parameters (`@typeparam`), see the following articles:

* <xref:mvc/views/razor#typeparam>
* <xref:blazor/components/index#generic-type-parameter-support>
* <xref:blazor/components/templated-components>

The following `RadioButtonExample` component uses the preceding `InputRadio` component to obtain and validate a rating from the user:

`Pages/RadioButtonExample.razor`:

```razor
@page "/radio-button-example"
@using System.ComponentModel.DataAnnotations
@using Microsoft.Extensions.Logging
@inject ILogger<RadioButtonExample> Logger

<h1>Radio Button Example</h1>

<EditForm Model="@Model" OnValidSubmit="@HandleValidSubmit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    @for (int i = 1; i <= 5; i++)
    {
        <label>
            <InputRadio name="rate" SelectedValue="@i" @bind-Value="Model!.Rating" />
            @i
        </label>
    }

    <button type="submit">Submit</button>

</EditForm>

<p>@Model?.Rating</p>

@code {
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void HandleValidSubmit()
    {
        Logger.LogInformation("HandleValidSubmit called");
    }

    public class Model
    {
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
```

:::moniker-end

## Validation Summary and Validation Message components

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component summarizes all validation messages, which is similar to the [Validation Summary Tag Helper](xref:mvc/views/working-with-forms#the-validation-summary-tag-helper):

```razor
<ValidationSummary />
```

Output validation messages for a specific model with the `Model` parameter:
  
```razor
<ValidationSummary Model="@Model" />
```

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> component displays validation messages for a specific field, which is similar to the [Validation Message Tag Helper](xref:mvc/views/working-with-forms#the-validation-message-tag-helper). Specify the field for validation with the <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601.For%2A> attribute and a lambda expression naming the model property:

```razor
<ValidationMessage For="@(() => Model!.MaximumAccommodation)" />
```

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> and <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> components support arbitrary attributes. Any attribute that doesn't match a component parameter is added to the generated `<div>` or `<ul>` element.

Control the style of validation messages in the app's stylesheet (`wwwroot/css/app.css` or `wwwroot/css/site.css`). The default `validation-message` class sets the text color of validation messages to red:

```css
.validation-message {
    color: red;
}
```

## Custom validation attributes

To ensure that a validation result is correctly associated with a field when using a [custom validation attribute](xref:mvc/models/validation#custom-attributes), pass the validation context's <xref:System.ComponentModel.DataAnnotations.ValidationContext.MemberName> when creating the <xref:System.ComponentModel.DataAnnotations.ValidationResult>.

`CustomValidator.cs`:

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class CustomValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, 
        ValidationContext validationContext)
    {
        ...

        return new ValidationResult("Validation message to user.",
            new[] { validationContext.MemberName });
    }
}
```

Inject services into custom validation attributes through the <xref:System.ComponentModel.DataAnnotations.ValidationContext>. The following example demonstrates a salad chef form that validates user input with dependency injection (DI).

The `SaladChef` class indicates the approved starship ingredient list for a Ten Forward salad.

`SaladChef.cs`:

```csharp
public class SaladChef
{
    public string[] ThingsYouCanPutInASalad = { "Horva", "Kanda Root",
        "Krintar", "Plomeek", "Syto Bean" };
}
```

Register `SaladChef` in the app's DI container in `Program.cs`:

```csharp
builder.Services.AddTransient<SaladChef>();
```

The `IsValid` method of the following `SaladChefValidatorAttribute` class obtains the `SaladChef` service from DI to check the user's input.

`SaladChefValidatorAttribute.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

public class SaladChefValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value,
        ValidationContext validationContext)
    {
        var saladChef = validationContext.GetRequiredService<SaladChef>();

        if (saladChef.ThingsYouCanPutInASalad.Contains(value?.ToString()))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("You should not put that in a salad! " +
            "Only use an ingredient from this list: " +
            string.Join(", ", saladChef.ThingsYouCanPutInASalad));
    }
}
```

The following component validates user input by applying the `SaladChefValidatorAttribute` (`[SaladChefValidator]`) to the salad ingredient string (`SaladIngredient`).

`Starship11.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-11"
@attribute [RenderModeServer]

<EditForm Model="@this" autocomplete="off">

    <DataAnnotationsValidator />

    <p>
        Name something you can put in a salad:
        <input @bind="SaladIngredient" />
    </p>

    <button type="submit">Submit</button>

    <ul>
        @foreach (var message in context.GetValidationMessages())
        {
            <li class="validation-message">@message</li>
        }
    </ul>

</EditForm>

@code {
    [SaladChefValidator]
    public string? SaladIngredient { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-11"

<EditForm Model="@this" autocomplete="off">

    <DataAnnotationsValidator />

    <p>
        Name something you can put in a salad:
        <input @bind="SaladIngredient" />
    </p>

    <button type="submit">Submit</button>

    <ul>
        @foreach (var message in context.GetValidationMessages())
        {
            <li class="validation-message">@message</li>
        }
    </ul>

</EditForm>

@code {
    [SaladChefValidator]
    public string? SaladIngredient { get; set; }
}
```

:::moniker-end

## Custom validation CSS class attributes

:::moniker range=">= aspnetcore-7.0"

Custom validation CSS class attributes are useful when integrating with CSS frameworks, such as [Bootstrap](https://getbootstrap.com/).

To specify custom validation CSS class attributes, start by providing CSS styles for custom validation. In the following example, valid (`validField`) and invalid (`invalidField`) styles are specified.

Add the following CSS classes to the app's stylesheet:

```css
.validField {
    border-color: lawngreen;
}

.invalidField {
    background-color: tomato;
}
```

Create a class derived from <xref:Microsoft.AspNetCore.Components.Forms.FieldCssClassProvider> that checks for field validation messages and applies the appropriate valid or invalid style.

`CustomFieldClassProvider.cs`:

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, 
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        return isValid ? "validField" : "invalidField";
    }
}
```

<!--
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/CustomFieldClassProvider.cs":::
-->

Set the `CustomFieldClassProvider` class as the Field CSS Class Provider on the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> instance with <xref:Microsoft.AspNetCore.Components.Forms.EditContextFieldClassExtensions.SetFieldCssClassProvider%2A>.

`Starship12.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-12"
@attribute [RenderModeServer]
@inject ILogger<Starship12> Logger

<EditForm EditContext="@editContext" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <InputText @bind-Value="Model!.Id" />

    <button type="submit">Submit</button>

</EditForm>

@code {
    private EditContext? editContext;

    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new();
        editContext = new(Model);
        editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public class Starship
    {
        [Required]
        [StringLength(10, ErrorMessage = "Id is too long.")]
        public string? Id { get; set; }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship12.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-12"
@inject ILogger<Starship12> Logger

<EditForm EditContext="@editContext" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <InputText @bind-Value="Model!.Id" />

    <button type="submit">Submit</button>

</EditForm>

@code {
    private EditContext? editContext;

    public Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new();
        editContext = new(Model);
        editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public class Starship
    {
        [Required]
        [StringLength(10, ErrorMessage = "Id is too long.")]
        public string? Id { get; set; }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship12.razor" highlight="21":::
-->

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

The preceding example checks the validity of all form fields and applies a style to each field. If the form should only apply custom styles to a subset of the fields, make `CustomFieldClassProvider` apply styles conditionally. The following `CustomFieldClassProvider2` example only applies a style to the `Name` field. For any fields with names not matching `Name`, `string.Empty` is returned, and no style is applied. Using [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the field is matched to the model member's property or field name, not an `id` assigned to the HTML entity.

`CustomFieldClassProvider2.cs`:

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider2 : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        if (fieldIdentifier.FieldName == "Name")
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            return isValid ? "validField" : "invalidField";
        }

        return string.Empty;
    }
}
```

<!--
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/CustomFieldClassProvider2.cs":::
-->

> [!NOTE]
> Matching the field name in the preceding example is case sensitive, so a model property member designated "`Name`" must match a conditional check on "`Name`":
>
> * <span aria-hidden="true">✔️</span><span class="visually-hidden">Correctly matches:</span> `fieldId.FieldName == "Name"`
> * <span aria-hidden="true">❌</span><span class="visually-hidden">Fails to match:</span> `fieldId.FieldName == "name"`
> * <span aria-hidden="true">❌</span><span class="visually-hidden">Fails to match:</span> `fieldId.FieldName == "NAME"`
> * <span aria-hidden="true">❌</span><span class="visually-hidden">Fails to match:</span> `fieldId.FieldName == "nAmE"`

Add an additional property to `Model`, for example:

```csharp
[StringLength(10, ErrorMessage = "Description is too long.")]
public string? Description { get; set; } 
```

Add the `Description` to the `CustomValidationForm` component's form:

```razor
<InputText @bind-Value="Model!.Description" />
```

Update the `EditContext` instance in the component's `OnInitialized` method to use the new Field CSS Class Provider:

```csharp
editContext?.SetFieldCssClassProvider(new CustomFieldClassProvider2());
```

Because a CSS validation class isn't applied to the `Description` field, it isn't styled. However, field validation runs normally. If more than 10 characters are provided, the validation summary indicates the error:

> Description is too long.

In the following example:

* The custom CSS style is applied to the `Name` field.
* Any other fields apply logic similar to Blazor's default logic and using Blazor's default field CSS validation styles, `modified` with `valid` or `invalid`. Note that for the default styles, you don't need to add them to the app's stylesheet if the app is based on a Blazor project template. For apps not based on a Blazor project template, the default styles can be added to the app's stylesheet:

  ```css
  .valid.modified:not([type=checkbox]) {
      outline: 1px solid #26b050;
  }

  .invalid {
      outline: 1px solid red;
  }
  ```

`CustomFieldClassProvider3.cs`:

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider3 : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        if (fieldIdentifier.FieldName == "Name")
        {
            return isValid ? "validField" : "invalidField";
        }
        else
        {
            if (editContext.IsModified(fieldIdentifier))
            {
                return isValid ? "modified valid" : "modified invalid";
            }
            else
            {
                return isValid ? "valid" : "invalid";
            }
        }
    }
}
```

<!--
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/CustomFieldClassProvider3.cs":::
-->

Update the `EditContext` instance in the component's `OnInitialized` method to use the preceding Field CSS Class Provider:

```csharp
editContext.SetFieldCssClassProvider(new CustomFieldClassProvider3());
```

Using `CustomFieldClassProvider3`:

* The `Name` field uses the app's custom validation CSS styles.
* The `Description` field uses logic similar to Blazor's logic and Blazor's default field CSS validation styles.

:::moniker-end

## Blazor data annotations validation package

The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) is a package that fills validation experience gaps using the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. The package is currently *experimental*.

> [!WARNING]
> The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) package has a latest version of *release candidate* at [NuGet.org](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation). Continue to use the *experimental* release candidate package at this time. Experimental features are provided for the purpose of exploring feature viability and may not ship in a stable version. Watch the [Announcements GitHub repository](https://github.com/aspnet/Announcements), the [dotnet/aspnetcore GitHub repository](https://github.com/dotnet/aspnetcore), or this topic section for further updates.

:::moniker range="< aspnetcore-6.0"

## `[CompareProperty]` attribute

The <xref:System.ComponentModel.DataAnnotations.CompareAttribute> doesn't work well with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component because it doesn't associate the validation result with a specific member. This can result in inconsistent behavior between field-level validation and when the entire model is validated on a submit. The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) *experimental* package introduces an additional validation attribute, `ComparePropertyAttribute`, that works around these limitations. In a Blazor app, `[CompareProperty]` is a direct replacement for the [`[Compare]` attribute](xref:System.ComponentModel.DataAnnotations.CompareAttribute).

:::moniker-end

## Nested models, collection types, and complex types

Blazor provides support for validating form input using data annotations with the built-in <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>. However, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> only validates top-level properties of the model bound to the form that aren't collection- or complex-type properties.

To validate the bound model's entire object graph, including collection- and complex-type properties, use the `ObjectGraphDataAnnotationsValidator` provided by the *experimental* [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) package:

```razor
<EditForm Model="@Model" OnValidSubmit="@Submit">
    <ObjectGraphDataAnnotationsValidator />
    ...
</EditForm>
```

Annotate model properties with `[ValidateComplexType]`. In the following model classes, the `ShipDescription` class contains additional data annotations to validate when the model is bound to the form:

`Starship.cs`:

:::moniker range=">= aspnetcore-5.0"

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class Starship
{
    ...

    [ValidateComplexType]
    public ShipDescription ShipDescription { get; set; } = new();

    ...
}
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class Starship
{
    ...

    [ValidateComplexType]
    public ShipDescription ShipDescription { get; set; } = new ShipDescription();

    ...
}
```

:::moniker-end

`ShipDescription.cs`:

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class ShipDescription
{
    [Required]
    [StringLength(40, ErrorMessage = "Description too long (40 char).")]
    public string? ShortDescription { get; set; }

    [Required]
    [StringLength(240, ErrorMessage = "Description too long (240 char).")]
    public string? LongDescription { get; set; }
}
```

## Enable the submit button based on form validation

To enable and disable the submit button based on form validation, the following example:

* Uses a shortened version of the preceding `Starfleet Starship Database` form (`Starship4` component) from the [Example form](#example-form) section that only accepts a value for the ship's Id. The other `Starship` properties receive valid default values when an instance of the `Starship` type is created.
* Uses the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> to assign the model when the component is initialized.
* Validates the form in the context's <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> callback to enable and disable the submit button.
* Implements <xref:System.IDisposable> and unsubscribes the event handler in the `Dispose` method. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

> [!NOTE]
> When assigning to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext?displayProperty=nameWithType>, don't also assign an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm>.

`Starship13.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-13"
@attribute [RenderModeServer]
@implements IDisposable
@inject ILogger<Starship13> Logger

<EditForm EditContext="@editContext" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </p>

    <button type="submit" disabled="@formInvalid">Submit</button>

</EditForm>

@code {
    private bool formInvalid = false;
    private EditContext? editContext;

    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??=
            new()
            {
                Id = "NCC-1701",
                Classification = "Exploration",
                MaximumAccommodation = 150,
                IsValidatedDesign = true,
                ProductionDate = new DateTime(2245, 4, 11)
            };
        editContext = new(Model);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        if (editContext is not null)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public void Dispose()
    {
        if (editContext is not null)
        {
            editContext.OnFieldChanged -= HandleFieldChanged;
        }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship13.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-13"
@implements IDisposable
@inject ILogger<Starship13> Logger

<EditForm EditContext="@editContext" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary />

    <p>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </p>

    <button type="submit" disabled="@formInvalid">Submit</button>

</EditForm>

@code {
    private bool formInvalid = false;
    private EditContext? editContext;

    private Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??=
            new()
            {
                Id = "NCC-1701",
                Classification = "Exploration",
                MaximumAccommodation = 150,
                IsValidatedDesign = true,
                ProductionDate = new DateTime(2245, 4, 11)
            };
        editContext = new(Model);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        if (editContext is not null)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public void Dispose()
    {
        if (editContext is not null)
        {
            editContext.OnFieldChanged -= HandleFieldChanged;
        }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship13.razor":::
-->

:::moniker-end

If a form isn't preloaded with valid values and you wish to disable the **`Submit`** button on form load, set `formInvalid` to `true`.

A side effect of the preceding approach is that a validation summary (<xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component) is populated with invalid fields after the user interacts with any one field. Address this scenario in either of the following ways:

* Don't use a <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component on the form.
* Make the <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component visible when the submit button is selected (for example, in a `Submit` method).

```razor
<EditForm EditContext="@editContext" OnValidSubmit="@Submit">

    <DataAnnotationsValidator />

    <ValidationSummary style="@displaySummary" />

    ...

    <button type="submit" disabled="@formInvalid">Submit</button>

</EditForm>

@code {
    private string displaySummary = "display:none";

    ...

    private void Submit()
    {
        displaySummary = "display:block";
    }
}
```

## Large form payloads and the SignalR message size limit

*This section only applies to Blazor Server apps and hosted Blazor WebAssembly solutions that implement SignalR.*

:::moniker range=">= aspnetcore-6.0"

If form processing fails because the component's form payload has exceeded the maximum incoming SignalR message size permitted for hub methods, the form can adopt [streaming JS interop](xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net) without increasing the message size limit. For more information on the size limit and the error thrown, see <xref:blazor/fundamentals/signalr#maximum-receive-message-size>.

In the following example a text area (`<textarea>`) is used with streaming JS interop to move up to 50,000 bytes of data to the server.

Add a JavaScript (JS) `getText` function to the app:

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 Remove at RC1 or RTM -->

> [!NOTE]
> During the .NET 8 preview, add `suppress-error="BL9992"` to `<script>` tags when the script is placed in the `App` component (`App.razor`). This requirement will be dropped in a future preview release.

:::moniker-end

```javascript
window.getText = (elem) => {
  const textValue = elem.value;
  const utf8Encoder = new TextEncoder();
  const encodedTextValue = utf8Encoder.encode(textValue);
  return encodedTextValue;
};
```

For information on where to place JS in a Blazor app, see <xref:blazor/js-interop/index#javaScript-location>.

Due to security considerations, zero-length streams aren't permitted for streaming JS Interop. Therefore, the following `StreamFormData` component traps a <xref:Microsoft.JSInterop.JSException> and returns an empty string if the text area is blank when the form is submitted.

`Pages/StreamFormData.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/stream-form-data"
@attribute [RenderModeServer]
@inject IJSRuntime JS
@inject ILogger<StreamFormData> Logger

<h1>Stream form data with JS interop</h1>

<EditForm Model="@this" OnSubmit="@Submit">

    <p>
        <label>
            &lt;textarea&gt; value streamed for assignment to
            <code>TextAreaValue (&lt;= 50,000 characters)</code>:
            <textarea @ref="largeTextArea" />
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

<p>
    Length: @TextAreaValue?.Length
</p>

@code {
    private ElementReference largeTextArea;

    public string? TextAreaValue { get; set; }

    protected override void OnInitialized() =>
        TextAreaValue ??= string.Empty;

    private async Task Submit()
    {
        TextAreaValue = await GetTextAsync();

        Logger.LogInformation("TextAreaValue length: {Length}",
            TextAreaValue.Length);
    }

    public async Task<string> GetTextAsync()
    {
        try
        {
            var streamRef =
                await JS.InvokeAsync<IJSStreamReference>("getText", largeTextArea);
            var stream = await streamRef.OpenReadStreamAsync(maxAllowedSize: 50_000);
            var streamReader = new StreamReader(stream);

            return await streamReader.ReadToEndAsync();
        }
        catch (JSException jsException)
        {
            if (jsException.InnerException is
                    ArgumentOutOfRangeException outOfRangeException &&
                outOfRangeException.ActualValue is not null &&
                outOfRangeException.ActualValue is long actualLength &&
                actualLength == 0)
            {
                return string.Empty;
            }

            throw;
        }
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```razor
@page "/stream-form-data"
@inject IJSRuntime JS
@inject ILogger<StreamFormData> Logger

<h1>Stream form data with JS interop</h1>

<EditForm Model="@this" OnSubmit="@Submit">

    <p>
        <label>
            &lt;textarea&gt; value streamed for assignment to
            <code>TextAreaValue (&lt;= 50,000 characters)</code>:
            <textarea @ref="largeTextArea" />
        </label>
    </p>

    <button type="submit">Submit</button>

</EditForm>

<p>
    Length: @TextAreaValue?.Length
</p>

@code {
    private ElementReference largeTextArea;

    public string? TextAreaValue { get; set; }

    protected override void OnInitialized() => 
        TextAreaValue ??= string.Empty;

    private async Task Submit()
    {
        TextAreaValue = await GetTextAsync();

        Logger.LogInformation("TextAreaValue length: {Length}",
            TextAreaValue.Length);
    }

    public async Task<string> GetTextAsync()
    {
        try
        {
            var streamRef =
                await JS.InvokeAsync<IJSStreamReference>("getText", largeTextArea);
            var stream = await streamRef.OpenReadStreamAsync(maxAllowedSize: 50_000);
            var streamReader = new StreamReader(stream);

            return await streamReader.ReadToEndAsync();
        }
        catch (JSException jsException)
        {
            if (jsException.InnerException is
                    ArgumentOutOfRangeException outOfRangeException &&
                outOfRangeException.ActualValue is not null &&
                outOfRangeException.ActualValue is long actualLength &&
                actualLength == 0)
            {
                return string.Empty;
            }

            throw;
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

If form processing fails because the component's form payload has exceeded the maximum incoming SignalR message size permitted for hub methods, the message size limit can be increased. For more information on the size limit and the error thrown, see <xref:blazor/fundamentals/signalr#maximum-receive-message-size>.

:::moniker-end

## Troubleshoot

### EditForm parameter error

> InvalidOperationException: EditForm requires a Model parameter, or an EditContext parameter, but not both.

Confirm that the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> assigns a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model> **or** an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext>. Don't use both for the same form.

When assigning to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model>, confirm that the model type is instantiated.

### Connection disconnected

> Error: Connection disconnected with error 'Error: Server returned an error on close: Connection closed with an error.'.

> System.IO.InvalidDataException: The maximum message size of 32768B was exceeded. The message size can be configured in AddHubOptions.

For more information and guidance, see the following resources:

* [Large form payloads and the SignalR message size limit](#large-form-payloads-and-the-signalr-message-size-limit)
* <xref:blazor/fundamentals/signalr#maximum-receive-message-size>

## Additional resources

* <xref:blazor/file-uploads>
* <xref:blazor/security/webassembly/hosted-with-azure-active-directory>
* <xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c>
* <xref:blazor/security/webassembly/hosted-with-identity-server>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
* [ASP.NET Core GitHub repository (`dotnet/aspnetcore`) forms test assets](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/Components.TestServer/RazorComponents/Pages/Forms)
