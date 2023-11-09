---
title: ASP.NET Core Blazor forms binding
author: guardrex
description: Learn how to use binding in Blazor forms.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/forms/binding
---
# ASP.NET Core Blazor forms binding

[!INCLUDE[](~/includes/not-latest-version.md)]

An <xref:Microsoft.AspNetCore.Components.Forms.EditForm> creates an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> based on the assigned object as a [cascading value](xref:blazor/components/cascading-values-and-parameters) for other components in the form. The <xref:Microsoft.AspNetCore.Components.Forms.EditContext> tracks metadata about the edit process, including which form fields have been modified and the current validation messages. Assigning to either an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> or an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext?displayProperty=nameWithType> can bind a form to data.

## Model binding

Assignment to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType>:

:::moniker range=">= aspnetcore-8.0"

```razor
<EditForm ... Model="@Model" ...>
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
<EditForm ... EditContext="@editContext" ...>
    ...
</EditForm>

@code {
    private EditContext? editContext;

    [SupplyParameterFromForm]
    public Starship? Model { get; set; }

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
<EditForm EditContext="@editContext" ...>
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

Additional model binding options are available from `RazorComponentOptions` when calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>:

* `MaxFormMappingCollectionSize`: Maximum number of elements allowed in a form collection.
* `MaxFormMappingRecursionDepth`: Maximum depth allowed when recursively mapping form data.
* `MaxFormMappingErrorCount`: Maximum number of errors allowed when mapping form data.
* `MaxFormMappingKeySize`: Maximum size of the buffer used to read form data keys.

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

Use the `FormName` parameter to assign a form name. Form names must be unique to bind model data. The following form is named `RomulanAle`:

```razor
<EditForm ... FormName="RomulanAle">
    ...
</EditForm>
```

Supplying a form name:

* Is required for all forms that are submitted by statically-rendered server-side components.
* Isn't required for forms that are submitted by interactively-rendered components, which includes forms in Blazor WebAssembly apps and components with an interactive render mode. However, we recommend supplying a unique form name for every form to prevent runtime form posting errors if interactivity is ever dropped for a form.

The form name is only checked when the form is posted to an endpoint as a traditional HTTP POST request from a statically-rendered server-side component. The framework doesn't throw an exception at the point of rendering a form, but only at the point that an HTTP POST arrives and doesn't specify a form name.

By default, there's an unnamed (empty string) form scope above the app's root component, which suffices when there are no form name collisions in the app. If form name collisions are possible, such as when including a form from a library and you have no control of the form name used by the library's developer, provide a form name scope with the `FormMappingScope` component in the Blazor Web App's main project.

In the following example, the `HelloFormFromLibrary` component has a form named `Hello` and is in a library.

`HelloFormFromLibrary.razor`:

```razor
<EditForm Model="@this" OnSubmit="@Submit" FormName="Hello">
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
    public string? Name { get; set; }

    private void Submit() => submitted = true;
}
```

The following `NamedFormsWithScope` component uses the library's `HelloFormFromLibrary` component and also has a form named `Hello`. The `FormMappingScope` component's scope name is `ParentContext` for any forms supplied by the `HelloFormFromLibrary` component. Although both of the forms in this example have the form name (`Hello`), the form names don't collide and events are routed to the correct form for form POST events.

`NamedFormsWithScope.razor`:

```razor
@page "/named-forms-with-scope"

<div>Hello form from a library</div>

<FormMappingScope Name="ParentContext">
    <HelloFormFromLibrary />
</FormMappingScope>

<div>Hello form using the same form name</div>

<EditForm Model="@this" OnSubmit="@Submit" FormName="Hello">
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
    public string? Name { get; set; }

    private void Submit() => submitted = true;
}
```

## Supply a parameter from the form (`[SupplyParameterFromForm]`)

The `[SupplyParameterFromForm]` attribute indicates that the value of the associated property should be supplied from the form data for the form. Data in the request that matches the name of the property is bound to the property. Inputs based on `InputBase<TValue>` generate form value names that match the names Blazor uses for model binding.

You can specify the following form binding parameters to the `[SupplyParameterFromForm]` attribute:

* `Name`: Gets or sets the name for the parameter. The name is used to determine the prefix to use to match the form data and decide whether or not the value needs to be bound.
* `FormName`: Gets or sets the name for the handler. The name is used to match the parameter to the form by form name to decide whether or not the value needs to be bound.

The following example independently binds two forms to their models by form name.

`Starship6.razor`:

```razor
@page "/starship-6"
@rendermode RenderMode.InteractiveServer
@inject ILogger<Starship6> Logger

<EditForm Model="@Model1" OnSubmit="@Submit1" FormName="Holodeck1">
    <InputText @bind-Value="Model1!.Id" />
    <button type="submit">Submit</button>
</EditForm>

<EditForm Model="@Model2" OnSubmit="@Submit2" FormName="Holodeck2">
    <InputText @bind-Value="Model2!.Id" />
    <button type="submit">Submit</button>
</EditForm>

@code {
    [SupplyParameterFromForm(FormName = "Holodeck1")]
    public Holodeck? Model1 { get; set; }

    [SupplyParameterFromForm(FormName = "Holodeck2")]
    public Holodeck? Model2 { get; set; }

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

    public class Holodeck
    {
        public string? Id { get; set; }
    }
}
```

## Nest and bind forms

The following guidance demonstrates how to nest and bind child forms.

<!-- UPDATE 8.0 At RTM or upon API browser updates, cross-link 
     Microsoft.AspNetCore.Components.Forms.Editor<T>. -->

The following ship details class (`ShipDetails`) holds a description and length for a subform.

`ShipDetails.cs`:

```csharp
public class ShipDetails
{
    public string? Description { get; set; }
    public int? Length { get; set; }
}
```

The following `Ship` class names an identifier (`Id`) and includes the ship details.

`Ship.cs`:

```csharp
public class Ship
{
    public string? Id { get; set; }
    public ShipDetails Details { get; set; } = new();
}
```

The following subform is used for editing values of the `ShipDetails` type. This is implemented by inheriting `Editor<T>` at the top of the component. `Editor<T>` ensures that the child component generates the correct form field names based on the model (`T`), where `T` in the following example is `ShipDetails`.

`StarshipSubform.razor`:

```razor
@inherits Editor<ShipDetails>

<div>
    <label>
        Description:
        <InputText @bind-Value="Value!.Description" />
    </label>
</div>
<div>
    <label>
        Length:
        <InputNumber @bind-Value="Value!.Length" />
    </label>
</div>
```

The main form is bound to the `Ship` class. The `StarshipSubform` component is used to edit ship details, bound as `Model!.Details`.

`Starship7.razor`:

```razor
@page "/starship-7"
@rendermode RenderMode.InteractiveServer
@inject ILogger<Starship7> Logger

<EditForm Model="@Model" OnSubmit="@Submit" FormName="Starship7">
    <div>
        <label>
            Id:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <StarshipSubform @bind-Value="Model!.Details" />
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@code {
    [SupplyParameterFromForm]
    public Ship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit()
    {
        Logger.LogInformation("Id = {Id} Desc = {Description} Length = {Length}", 
            Model?.Id, Model?.Details?.Description, Model?.Details?.Length);
    }
}
```

## Advanced form mapping error scenarios

The framework instantiates and populates the `FormMappingContext` for a form, which is the context associated with a given form's mapping operation. Each mapping scope (defined by a `FormMappingScope` component) instantiates `FormMappingContext`. Each time a `[SupplyParameterFromForm]` asks the context for a value, the framework populates the `FormMappingContext` with the attempted value and any mapping errors.

Developers aren't expected to interact with `FormMappingContext` directly, as it's mainly a source of data for `InputBase`, `EditContext`, and other internal implementations to show mapping errors as validation errors. In advanced custom scenarios, developers can access `FormMappingContext` directly as a `[CascadingParameter]` to write custom code that consumes the attempted values and mapping errors.

:::moniker-end

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

Make the `enums` class accessible to the:

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
        @foreach (var manufacturer in (Manufacturer[])Enum
            .GetValues(typeof(Manufacturer)))
        {
            <div>
                <label>
                    <InputRadio Value="@manufacturer" />
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
                        <InputRadio Name="engine" Value="@Engine.Ion" />
                        Ion
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="@Color.ImperialRed" />
                        Imperial Red
                    </label>
                </div>
            </div>
            <div style="margin-bottom:5px">
                <div>
                    <label>
                        <InputRadio Name="engine" Value="@Engine.Plasma" />
                        Plasma
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="@Color.SpacecruiserGreen" />
                        Spacecruiser Green
                    </label>
                </div>
            </div>
            <div style="margin-bottom:5px">
                <div>
                    <label>
                        <InputRadio Name="engine" Value="@Engine.Fusion" />
                        Fusion
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="@Color.StarshipBlue" />
                        Starship Blue
                    </label>
                </div>
            </div>
            <div style="margin-bottom:5px">
                <div>
                    <label>
                        <InputRadio Name="engine" Value="@Engine.Warp" />
                        Warp
                    </label>
                </div>
                <div>
                    <label>
                        <InputRadio Name="color" Value="@Color.VoyagerOrange" />
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

`RadioButtonExample.razor`:

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
        <div>
            <label>
                <InputRadio name="rate" SelectedValue="@i" 
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
    public Starship Model { get; set; }

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
