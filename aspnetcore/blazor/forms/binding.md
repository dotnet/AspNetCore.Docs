---
title: ASP.NET Core Blazor forms binding
author: guardrex
description: Learn how to use binding in Blazor forms.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/forms/binding
---
# ASP.NET Core Blazor forms binding

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use binding in Blazor forms.

## `EditForm`/`EditContext` model

An <xref:Microsoft.AspNetCore.Components.Forms.EditForm> creates an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> based on the assigned object as a [cascading value](xref:blazor/components/cascading-values-and-parameters) for other components in the form. The <xref:Microsoft.AspNetCore.Components.Forms.EditContext> tracks metadata about the edit process, including which form fields have been modified and the current validation messages. Assigning to either an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> or an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext?displayProperty=nameWithType> can bind a form to data.

## Model binding

Assignment to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType>:

:::moniker range=">= aspnetcore-8.0"

```razor
<EditForm ... Model="Model" ...>
    ...
</EditForm>

@code {
    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
<EditForm ... Model="Model" ...>
    ...
</EditForm>

@code {
    public Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();
}
```

> [!NOTE]
> Most of this article's form model examples bind forms to C# *properties*, but C# field binding is also supported.

:::moniker-end

## Context binding

Assignment to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext?displayProperty=nameWithType>:

:::moniker range=">= aspnetcore-8.0"

```razor
<EditForm ... EditContext="editContext" ...>
    ...
</EditForm>

@code {
    private EditContext? editContext;

    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

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
<EditForm ... EditContext="editContext" ...>
    ...
</EditForm>

@code {
    private EditContext? editContext;

    public Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new();
        editContext = new(Model);
    }
}
```

:::moniker-end

Assign **either** an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext> **or** a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model> to an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>. If both are assigned, a runtime error is thrown.

:::moniker range=">= aspnetcore-8.0"

## Supported types

Binding supports:

* Primitive types
* Collections
* Complex types
* Recursive types
* Types with constructors
* Enums

You can also use the [`[DataMember]`](xref:System.Runtime.Serialization.DataMemberAttribute) and [`[IgnoreDataMember]`](xref:System.Runtime.Serialization.IgnoreDataMemberAttribute) attributes to customize model binding. Use these attributes to rename properties, ignore properties, and mark properties as required.

## Additional binding options

Additional model binding options are available from <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions> when calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>:

* <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions.MaxFormMappingCollectionSize%2A>: Maximum number of elements allowed in a form collection.
* <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions.MaxFormMappingRecursionDepth%2A>: Maximum depth allowed when recursively mapping form data.
* <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions.MaxFormMappingErrorCount%2A>: Maximum number of errors allowed when mapping form data.
* <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions.MaxFormMappingKeySize%2A>: Maximum size of the buffer used to read form data keys.

The following demonstrates the default values assigned by the framework:

```csharp
builder.Services.AddRazorComponents(options =>
{
    options.FormMappingUseCurrentCulture = true;
    options.MaxFormMappingCollectionSize = 1024;
    options.MaxFormMappingErrorCount = 200;
    options.MaxFormMappingKeySize = 1024 * 2;
    options.MaxFormMappingRecursionDepth = 64;
}).AddInteractiveServerComponents();
```

## Form names

Use the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.FormName%2A> parameter to assign a form name. Form names must be unique to bind model data. The following form is named `RomulanAle`:

```razor
<EditForm ... FormName="RomulanAle" ...>
    ...
</EditForm>
```

Supplying a form name:

* Is required for all forms that are submitted by statically-rendered server-side components.
* Isn't required for forms that are submitted by interactively-rendered components, which includes forms in Blazor WebAssembly apps and components with an interactive render mode. However, we recommend supplying a unique form name for every form to prevent runtime form posting errors if interactivity is ever dropped for a form.

The form name is only checked when the form is posted to an endpoint as a traditional HTTP POST request from a statically-rendered server-side component. The framework doesn't throw an exception at the point of rendering a form, but only at the point that an HTTP POST arrives and doesn't specify a form name.

There's an unnamed (empty string) form scope above the app's root component, which suffices when there are no form name collisions in the app. If form name collisions are possible, such as when including a form from a library and you have no control of the form name used by the library's developer, provide a form name scope with the <xref:Microsoft.AspNetCore.Components.Forms.FormMappingScope> component in the Blazor Web App's main project.

In the following example, the `HelloFormFromLibrary` component has a form named `Hello` and is in a library.

`HelloFormFromLibrary.razor`:

```razor
<EditForm FormName="Hello" Model="this" OnSubmit="Submit">
    <InputText @bind-Value="Name" />
    <button type="submit">Submit</button>
</EditForm>

@if (submitted)
{
    <p>Hello @Name from the library's form!</p>
}

@code {
    bool submitted = false;

    [SupplyParameterFromForm]
    private string? Name { get; set; }

    private void Submit() => submitted = true;
}
```

The following `NamedFormsWithScope` component uses the library's `HelloFormFromLibrary` component and also has a form named `Hello`. The <xref:Microsoft.AspNetCore.Components.Forms.FormMappingScope> component's scope name is `ParentContext` for any forms supplied by the `HelloFormFromLibrary` component. Although both of the forms in this example have the form name (`Hello`), the form names don't collide and events are routed to the correct form for form POST events.

`NamedFormsWithScope.razor`:

```razor
@page "/named-forms-with-scope"

<div>Hello form from a library</div>

<FormMappingScope Name="ParentContext">
    <HelloFormFromLibrary />
</FormMappingScope>

<div>Hello form using the same form name</div>

<EditForm FormName="Hello" Model="this" OnSubmit="Submit">
    <InputText @bind-Value="Name" />
    <button type="submit">Submit</button>
</EditForm>

@if (submitted)
{
    <p>Hello @Name from the app form!</p>
}

@code {
    bool submitted = false;

    [SupplyParameterFromForm]
    private string? Name { get; set; }

    private void Submit() => submitted = true;
}
```

## Supply a parameter from the form (`[SupplyParameterFromForm]`)

The `[SupplyParameterFromForm]` attribute indicates that the value of the associated property should be supplied from the form data for the form. Data in the request that matches the name of the property is bound to the property. Inputs based on `InputBase<TValue>` generate form value names that match the names Blazor uses for model binding. Unlike component parameter properties (`[Parameter]`), properties annotated with `[SupplyParameterFromForm]` aren't required to be marked `public`.

You can specify the following form binding parameters to the [`[SupplyParameterFromForm]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute):

* <xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute.Name%2A>: Gets or sets the name for the parameter. The name is used to determine the prefix to use to match the form data and decide whether or not the value needs to be bound.
* <xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute.FormName%2A>: Gets or sets the name for the handler. The name is used to match the parameter to the form by form name to decide whether or not the value needs to be bound.

The following example independently binds two forms to their models by form name.

`Starship6.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/Starship6.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship6.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Nest and bind forms

The following guidance demonstrates how to nest and bind child forms.

The following ship details class (`ShipDetails`) holds a description and length for a subform.

`ShipDetails.cs`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

:::code language="csharp" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/ShipDetails.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/ShipDetails.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

The following `Ship` class names an identifier (`Id`) and includes the ship details.

`Ship.cs`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

:::code language="csharp" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Ship.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Ship.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

The following subform is used for editing values of the `ShipDetails` type. This is implemented by inheriting <xref:Microsoft.AspNetCore.Components.Forms.Editor%601> at the top of the component. <xref:Microsoft.AspNetCore.Components.Forms.Editor%601> ensures that the child component generates the correct form field names based on the model (`T`), where `T` in the following example is `ShipDetails`.

`StarshipSubform.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/StarshipSubform.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/StarshipSubform.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

The main form is bound to the `Ship` class. The `StarshipSubform` component is used to edit ship details, bound as `Model!.Details`.

`Starship7.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/Starship7.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship7.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Initialize form data with static SSR

When a component adopts static SSR, the [`OnInitialized{Async}` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) and the [`OnParametersSet{Async}` lifecycle method](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) fire when the component is initially rendered and on every form POST to the server. To initialize form model values, confirm if the model already has data before assigning new model values in `OnParametersSet{Async}`, as the following example demonstrates.

`StarshipInit.razor`:

```razor
@page "/starship-init"
@inject ILogger<StarshipInit> Logger

<EditForm Model="Model" OnValidSubmit="Submit" FormName="StarshipInit">
    <div>
        <label>
            Identifier:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@code {
    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    protected override void OnParametersSet()
    {
        if (Model!.Id == default)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        Model!.Id = "Set by LoadData";
    }

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

## Advanced form mapping error scenarios

The framework instantiates and populates the <xref:Microsoft.AspNetCore.Components.Forms.FormMappingContext> for a form, which is the context associated with a given form's mapping operation. Each mapping scope (defined by a <xref:Microsoft.AspNetCore.Components.Forms.FormMappingScope> component) instantiates <xref:Microsoft.AspNetCore.Components.Forms.FormMappingContext>. Each time a `[SupplyParameterFromForm]` asks the context for a value, the framework populates the <xref:Microsoft.AspNetCore.Components.Forms.FormMappingContext> with the attempted value and any mapping errors.

Developers aren't expected to interact with <xref:Microsoft.AspNetCore.Components.Forms.FormMappingContext> directly, as it's mainly a source of data for <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601>, <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, and other internal implementations to show mapping errors as validation errors. In advanced custom scenarios, developers can access <xref:Microsoft.AspNetCore.Components.Forms.FormMappingContext> directly as a `[CascadingParameter]` to write custom code that consumes the attempted values and mapping errors.

:::moniker-end

## Custom input components

For custom input processing scenarios, the following subsections demonstrate custom input components:

* [Input component based on `InputBase<T>`](#input-component-based-on-inputbaset): The component inherits from <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601>, which provides a base implementation for binding, callbacks, and validation. Components that inherit from <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601> must be used in a Blazor form (<xref:Microsoft.AspNetCore.Components.Forms.EditForm>).

* [Input component with full developer control](#input-component-with-full-developer-control): The component takes full control of input processing. The component's code must manage binding, callbacks, and validation. The component can be used inside or outside of a Blazor form.

We recommend that you derive your custom input components from <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601> unless specific requirements prevent you from doing so. The <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601> class is actively maintained by the ASP.NET Core team, ensuring it stays up-to-date with the latest Blazor features and framework changes.

### Input component based on `InputBase<T>`

The following example component:

* Inherits from <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601>. Components that inherit from <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601> must be used in a Blazor form (<xref:Microsoft.AspNetCore.Components.Forms.EditForm>).
* Takes boolean input from a checkbox.
* Sets the background color of its container `<div>` based on the checkbox's state, which occurs when the `AfterChange` method executes after binding (`@bind:after`).
* Is required to override the base class's `TryParseValueFromString` method but doesn't process string input data because a checkbox doesn't provide string data. Example implementations of `TryParseValueFromString` for other types of input components that process string input are available in the [ASP.NET Core reference source](https://github.com/search?q=repo%3Adotnet%2Faspnetcore%20TryParseValueFromString&type=code).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

`EngineeringApprovalInputDerived.razor`:

```razor
@using System.Diagnostics.CodeAnalysis
@inherits InputBase<bool>

<div class="@divCssClass">
    <label>
        Engineering Approval:
        <input @bind="CurrentValue" @bind:after="AfterChange" class="@CssClass" 
            type="checkbox" />
    </label>
</div>

@code {
    private string? divCssClass;

    private void AfterChange()
    {
        divCssClass = CurrentValue ? "bg-success text-white" : null;
    }

    protected override bool TryParseValueFromString(
        string? value, out bool result, 
        [NotNullWhen(false)] out string? validationErrorMessage)
            => throw new NotSupportedException(
                "This component does not parse string inputs. " +
                $"Bind to the '{nameof(CurrentValue)}' property, " +
                $"not '{nameof(CurrentValueAsString)}'.");
}
```

To use the preceding component in the [starship example form (`Starship3.razor`/`Starship.cs`)](xref:blazor/forms/input-components#example-form), replace the `<div>` block for the engineering approval field with an `EngineeringApprovalInputDerived` component instance bound to the model's `IsValidatedDesign` property:

```diff
- <div>
-     <label>
-         Engineering Approval: 
-         <InputCheckbox @bind-Value="Model!.IsValidatedDesign" />
-     </label>
- </div>
+ <EngineeringApprovalInputDerived @bind-Value="Model!.IsValidatedDesign" />
```

### Input component with full developer control

The following example component:

* Doesn't inherit from <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601>. The component takes full control of input processing, including binding, callbacks, and validation. The component can be used inside or outside of a Blazor form (<xref:Microsoft.AspNetCore.Components.Forms.EditForm>).
* Takes boolean input from a checkbox.
* Changes the background color if the checkbox is checked.

Code in the component includes:

* The `Value` property is used with two-way binding to get or set the value of the input. `ValueChanged` is the callback that updates the bound value.

* When used in a Blazor form:

  * The <xref:Microsoft.AspNetCore.Components.Forms.EditContext> is a [cascading value](xref:blazor/components/cascading-values-and-parameters).
  * `fieldCssClass` styles the field based on the result of <xref:Microsoft.AspNetCore.Components.Forms.EditContext> validation.
  * `ValueExpression` is an expression (`Expression<Func<T>>`) assigned by the framework that identifies the bound value.
  * <xref:Microsoft.AspNetCore.Components.Forms.FieldIdentifier> uniquely identifies a single field that can be edited, usually corresponding to a model property. The field identifier is created with the expression that identifies the bound value (`ValueExpression`).

* In the `OnChange` event handler:

  * The value of the checkbox input is obtained from <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>.
  * The background color and text color of the container `<div>` element are set.
  * <xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType> invokes the delegate associated with the binding and dispatches an event notification to consumers that the value has changed.
  * If the component is used in an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> (the `EditContext` property isn't `null`), <xref:Microsoft.AspNetCore.Components.Forms.EditContext.NotifyFieldChanged%2A?displayProperty=nameWithType> is called to trigger validation.

`EngineeringApprovalInputStandalone.razor`:

```razor
@using System.Globalization
@using System.Linq.Expressions

<div class="@divCssClass">
    <label>
        Engineering Approval:
        <input class="@fieldCssClass" @onchange="OnChange" type="checkbox" 
            value="@Value" />
    </label>
</div>

@code {
    private string? divCssClass;
    private FieldIdentifier fieldIdentifier;
    private string? fieldCssClass => EditContext?.FieldCssClass(fieldIdentifier);

    [CascadingParameter]
    private EditContext? EditContext { get; set; }

    [Parameter]
    public bool? Value { get; set; }

    [Parameter]
    public EventCallback<bool> ValueChanged { get; set; }

    [Parameter]
    public Expression<Func<bool>>? ValueExpression { get; set; }

    protected override void OnInitialized()
    {
        fieldIdentifier = FieldIdentifier.Create(ValueExpression!);
    }

    private async Task OnChange(ChangeEventArgs args)
    {
        BindConverter.TryConvertToBool(args.Value, CultureInfo.CurrentCulture, 
            out var value);

        divCssClass = value ? "bg-success text-white" : null;

        await ValueChanged.InvokeAsync(value);
        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }
}
```

To use the preceding component in the [starship example form (`Starship3.razor`/`Starship.cs`)](xref:blazor/forms/input-components#example-form), replace the `<div>` block for the engineering approval field with a `EngineeringApprovalInputStandalone` component instance bound to the model's `IsValidatedDesign` property:

```diff
- <div>
-     <label>
-         Engineering Approval: 
-         <InputCheckbox @bind-Value="Model!.IsValidatedDesign" />
-     </label>
- </div>
+ <EngineeringApprovalInputStandalone @bind-Value="Model!.IsValidatedDesign" />
```

The `EngineeringApprovalInputStandalone` component is also functional outside of an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>:

```razor
<EngineeringApprovalInputStandalone @bind-Value="ValidDesign" />

<div>
    <b>ValidDesign:</b> @ValidDesign
</div>

@code {
    private bool ValidDesign { get; set; }
}
```

## Radio buttons

:::moniker range=">= aspnetcore-5.0"

The example in this section is based on the `Starfleet Starship Database` form (`Starship3` component) of the [Example form](xref:blazor/forms/input-components#example-form) section of this article.

Add the following [`enum` types](/dotnet/csharp/language-reference/language-specification/enums) to the app. Create a new file to hold them or add them to the `Starship.cs` file.

```csharp
public class ComponentEnums
{
    public enum Manufacturer { SpaceX, NASA, ULA, VirginGalactic, Unknown }
    public enum Color { ImperialRed, SpacecruiserGreen, StarshipBlue, VoyagerOrange }
    public enum Engine { Ion, Plasma, Fusion, Warp }
}
```

Make the `ComponentEnums` class accessible to the:

* `Starship` model in `Starship.cs` (for example, `using static ComponentEnums;`).
* `Starfleet Starship Database` form (`Starship3.razor`) (for example, `@using static ComponentEnums`).

Use <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> components with the <xref:Microsoft.AspNetCore.Components.Forms.InputRadioGroup%601> component to create a radio button group. In the following example, properties are added to the `Starship` model described in the [Example form](xref:blazor/forms/input-components#example-form) section of the *Input components* article:

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

Update the `Starfleet Starship Database` form (`Starship3` component) of the [Example form](xref:blazor/forms/input-components#example-form) section of the *Input components* article. Add the components to produce:

* A radio button group for the ship manufacturer.
* A nested radio button group for engine and ship color.

> [!NOTE]
> Nested radio button groups aren't often used in forms because they can result in a disorganized layout of form controls that may confuse users. However, there are cases when they make sense in UI design, such as in the following example that pairs recommendations for two user inputs, ship engine and ship color. One engine and one color are required by the form's validation. The form's layout uses nested <xref:Microsoft.AspNetCore.Components.Forms.InputRadioGroup%601>s to pair engine and color recommendations. However, the user can combine any engine with any color to submit the form.

> [!NOTE]
> Be sure to make the `ComponentEnums` class available to the component for the following example:
>
> ```razor
> @using static ComponentEnums
> ```

```razor
<fieldset>
    <legend>Manufacturer</legend>
    <InputRadioGroup @bind-Value="Model!.Manufacturer">
        @foreach (var manufacturer in Enum.GetValues<Manufacturer>())
        {
            <div>
                <label>
                    <InputRadio Value="manufacturer" />
                    @manufacturer
                </label>
            </div>
        }
    </InputRadioGroup>
</fieldset>

<fieldset>
    <legend>Engine and Color</legend>
    <p>
        Engine and color pairs are recommended, but any
        combination of engine and color is allowed.
    </p>
    <InputRadioGroup Name="engine" @bind-Value="Model!.Engine">
        <InputRadioGroup Name="color" @bind-Value="Model!.Color">
            <div style="margin-bottom:5px">
                <div>
                    <label>
                        <InputRadio Name="engine" Value="Engine.Ion" />
                        Ion
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="Color.ImperialRed" />
                        Imperial Red
                    </label>
                </div>
            </div>
            <div style="margin-bottom:5px">
                <div>
                    <label>
                        <InputRadio Name="engine" Value="Engine.Plasma" />
                        Plasma
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="Color.SpacecruiserGreen" />
                        Spacecruiser Green
                    </label>
                </div>
            </div>
            <div style="margin-bottom:5px">
                <div>
                    <label>
                        <InputRadio Name="engine" Value="Engine.Fusion" />
                        Fusion
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="Color.StarshipBlue" />
                        Starship Blue
                    </label>
                </div>
            </div>
            <div style="margin-bottom:5px">
                <div>
                    <label>
                        <InputRadio Name="engine" Value="Engine.Warp" />
                        Warp
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="Color.VoyagerOrange" />
                        Voyager Orange
                    </label>
                </div>
            </div>
        </InputRadioGroup>
    </InputRadioGroup>
</fieldset>
```

> [!NOTE]
> If `Name` is omitted, <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> components are grouped by their most recent ancestor.

If you implemented the preceding Razor markup in the `Starship3` component of the [Example form](xref:blazor/forms/input-components#example-form) section of the *Input components* article, update the logging for the `Submit` method:

```csharp
Logger.LogInformation("Id = {Id} Description = {Description} " +
    "Classification = {Classification} MaximumAccommodation = " +
    "{MaximumAccommodation} IsValidatedDesign = " +
    "{IsValidatedDesign} ProductionDate = {ProductionDate} " +
    "Manufacturer = {Manufacturer}, Engine = {Engine}, " +
    "Color = {Color}",
    Model?.Id, Model?.Description, Model?.Classification,
    Model?.MaximumAccommodation, Model?.IsValidatedDesign,
    Model?.ProductionDate, Model?.Manufacturer, Model?.Engine, 
    Model?.Color);
```

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
            errorMessage = "The field isn't valid.";

            return false;
        }
    }
}
```

For more information on generic type parameters (`@typeparam`), see the following articles:

* <xref:mvc/views/razor#typeparam>
* <xref:blazor/components/index#generic-type-parameter-support>
* <xref:blazor/components/templated-components>

Use the following example model.

`StarshipModel.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

namespace BlazorServer80
{
    public class Model
    {
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
```

The following `RadioButtonExample` component uses the preceding `InputRadio` component to obtain and validate a rating from the user:

`RadioButtonExample.razor`:

```razor
@page "/radio-button-example"
@using System.ComponentModel.DataAnnotations
@using Microsoft.Extensions.Logging
@inject ILogger<RadioButtonExample> Logger

<h1>Radio Button Example</h1>

<EditForm Model="Model" OnValidSubmit="HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    @for (int i = 1; i <= 5; i++)
    {
        <div>
            <label>
                <InputRadio name="rate" SelectedValue="i" 
                    @bind-Value="Model.Rating" />
                @i
            </label>
        </div>
    }

    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

<div>@Model.Rating</div>

@code {
    public StarshipModel Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void HandleValidSubmit()
    {
        Logger.LogInformation("HandleValidSubmit called");
    }
}
```

:::moniker-end
