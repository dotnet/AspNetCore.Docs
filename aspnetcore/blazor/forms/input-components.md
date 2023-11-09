---
title: ASP.NET Core Blazor input components
author: guardrex
description: Learn about built-in Blazor input components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/forms/input-components
---
# ASP.NET Core Blazor input components

[!INCLUDE[](~/includes/not-latest-version.md)]

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

The following `Starship` type, which is used in several of this article's examples and examples in other *Forms* node articles, defines a diverse set of properties with data annotations:

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
* Several of Blazor's built-in input components.

`Starship3.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-3"
@rendermode RenderMode.InteractiveServer
@inject ILogger<Starship3> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit" FormName="Starship3">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" />
        </label>
    </div>
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
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" />
        </label>
    </div>
    <div>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" />
        </label>
    </div>
    <div>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@code {
    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized() =>
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private void Submit()
    {
        Logger.LogInformation("Id = {Id} Description = {Description} " +
            "Classification = {Classification} MaximumAccommodation = " +
            "{MaximumAccommodation} IsValidatedDesign = " +
            "{IsValidatedDesign} ProductionDate = {ProductionDate}", 
            Model?.Id, Model?.Description, Model?.Classification, 
            Model?.MaximumAccommodation, Model?.IsValidatedDesign, 
            Model?.ProductionDate);
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship3.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-3"
@inject ILogger<Starship3> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@Model" OnValidSubmit="@Submit">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="Model!.Description" />
        </label>
    </div>
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
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" />
        </label>
    </div>
    <div>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="Model!.IsValidatedDesign" />
        </label>
    </div>
    <div>
        <label>
            Production Date:
            <InputDate @bind-Value="Model!.ProductionDate" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@code {
    private Starship? Model { get; set; }

    protected override void OnInitialized() =>
        Model ??= new() { ProductionDate = DateTime.UtcNow };

    private void Submit()
    {
        Logger.LogInformation("Id = {Id} Description = {Description} " +
            "Classification = {Classification} MaximumAccommodation = " +
            "{MaximumAccommodation} IsValidatedDesign = " +
            "{IsValidatedDesign} ProductionDate = {ProductionDate}", 
            Model?.Id, Model?.Description, Model?.Classification, 
            Model?.MaximumAccommodation, Model?.IsValidatedDesign, 
            Model?.ProductionDate);
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship3.razor":::
-->

:::moniker-end

The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> in the preceding example creates an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> based on the assigned `Starship` instance (`Model="..."`) and handles a valid form. The next example demonstrates how to assign an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> to a form and validate when the form is submitted.

In the following example:

* A shortened version of the earlier `Starfleet Starship Database` form (`Starship3` component) is used that only accepts a value for the starship's Id. The other `Starship` properties receive valid default values when an instance of the `Starship` type is created.
* The `Submit` method executes when the **`Submit`** button is selected.
* The form is validated by calling <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A?displayProperty=nameWithType> in the `Submit` method.
* Logging is executed depending on the validation result.

> [!NOTE]
> `Submit` in the next example is demonstrated as an asynchronous method because storing form values often uses asynchronous calls (`await ...`). If the form is used in a test app as shown, `Submit` merely runs synchronously. For testing purposes, ignore the following build warning:
>
> > This async method lacks 'await' operators and will run synchronously. ...

`Starship4.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-4"
@rendermode RenderMode.InteractiveServer
@inject ILogger<Starship4> Logger

<EditForm EditContext="@editContext" OnSubmit="@Submit" FormName="Starship4">
    <DataAnnotationsValidator />
    <div>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
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
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship4.razor":::
-->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-4"
@inject ILogger<Starship4> Logger

<EditForm EditContext="@editContext" OnSubmit="@Submit">
    <DataAnnotationsValidator />
    <div>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@code {
    private EditContext? editContext;

    private Starship Model { get; set; }

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
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship4.razor":::
-->

:::moniker-end

> [!NOTE]
> Changing the <xref:Microsoft.AspNetCore.Components.Forms.EditContext> after it's assigned is **not** supported.

:::moniker range=">= aspnetcore-6.0"

## Multiple option selection with the `InputSelect` component

Binding supports [`multiple`](https://developer.mozilla.org/docs/Web/HTML/Attributes/multiple) option selection with the <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> component. The [`@onchange`](xref:mvc/views/razor#onevent) event provides an array of the selected options via [event arguments (`ChangeEventArgs`)](xref:blazor/components/event-handling#event-arguments). The value must be bound to an array type, and binding to an array type makes the [`multiple`](https://developer.mozilla.org/docs/Web/HTML/Attributes/multiple) attribute optional on the <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> tag.

In the following example, the user must select at least two starship classifications but no more than three classifications.

`Starship5.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/starship-5"
@rendermode RenderMode.InteractiveServer
@inject ILogger<Starship5> Logger

<h1>Bind Multiple <code>InputSelect</code> Example</h1>

<EditForm EditContext="@editContext" OnValidSubmit="@Submit" FormName="Starship5">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div>
        <label>
            Select classifications (Minimum: 2, Maximum: 3):
            <InputSelect @bind-Value="Model!.SelectedClassification">
                <option value="@Classification.Exploration">Exploration</option>
                <option value="@Classification.Diplomacy">Diplomacy</option>
                <option value="@Classification.Defense">Defense</option>
                <option value="@Classification.Research">Research</option>
            </InputSelect>
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@if (Model?.SelectedClassification?.Length > 0)
{
    <div>@string.Join(", ", Model.SelectedClassification)</div>
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
:::code language="razor" source="~/../blazor-samples/8.0/BlazorWebAppSample/Components/Pages/Starship7.razor":::
-->

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```razor
@page "/starship-5"
@inject ILogger<Starship5> Logger

<h1>Bind Multiple <code>InputSelect</code> Example</h1>

<EditForm EditContext="@editContext" OnValidSubmit="@Submit">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div>
        <label>
            Select classifications (Minimum: 2, Maximum: 3):
            <InputSelect @bind-Value="Model!.SelectedClassification">
                <option value="@Classification.Exploration">Exploration</option>
                <option value="@Classification.Diplomacy">Diplomacy</option>
                <option value="@Classification.Defense">Defense</option>
                <option value="@Classification.Research">Research</option>
            </InputSelect>
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@if (Model?.SelectedClassification?.Length > 0)
{
    <div>@string.Join(", ", Model.SelectedClassification)</div>
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
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship5.razor":::
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

In the `Starfleet Starship Database` form (`Starship3` component) of the [Example form](#example-form) section, the production date of a new starship doesn't specify a display name:

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

<!-- UPDATE 9.0 The feature has been backlogged.
     https://github.com/dotnet/aspnetcore/issues/49147

> [!NOTE]
> Alternatively, the [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute) on the model class property is supported:
>
> ```csharp
> [Required, Display(Name = "Production Date")]
> public DateTime ProductionDate { get; set; }
> ```
>
> [`[DisplayName]` attribute](xref:System.ComponentModel.DisplayNameAttribute) is also supported:
>
> ```csharp
> [Required, DisplayName("Production Date")]
> public DateTime ProductionDate { get; set; }
> ```
>
> Between the two approaches, the `[Display]` attribute is recommended, which makes additional properties available. The `[Display]` attribute also enables assigning a resource type for localization.

-->

:::moniker-end

## Error message template support

<xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> support error message templates:

* <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601.ParsingErrorMessage%2A?displayProperty=nameWithType>

:::moniker range=">= aspnetcore-5.0"

In the `Starfleet Starship Database` form (`Starship3` component) of the [Example form](#example-form) section with a [friendly display name](#display-name-support) assigned, the `Production Date` field produces an error message using the following default error message template:

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

In the `Starfleet Starship Database` form (`Starship3` component) of the [Example form](#example-form) section uses a default error message template:

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
