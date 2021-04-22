---
title: ASP.NET Core Blazor forms and validation
author: guardrex
description: Learn how to use forms and field validation scenarios in Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/22/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/forms-validation
---
# ASP.NET Core Blazor forms and validation

The Blazor framework supports webforms with validation with the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component and [data annotations](xref:mvc/models/validation).

The following `ExampleModel` type defines validation logic using <xref:System.ComponentModel.DataAnnotations?displayProperty=nameWithType>. The `Name` property is marked required with the <xref:System.ComponentModel.DataAnnotations.RequiredAttribute> with a <xref:System.ComponentModel.DataAnnotations.StringLengthAttribute> maximum limit and error.

`ExampleModel.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/ExampleModel.cs)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/ExampleModel.cs)]

::: moniker-end

A form is defined using the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component. The following form demonstrates typical elements, components, and Razor code to produce a webform with validation.

`Pages/FormExample1.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample1.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample1.razor)]

::: moniker-end

In the preceding example:

* The form validates user input in the `name` field using the validation defined in the `ExampleModel` type. The model is created in the component's `@code` block and held in a private field (`exampleModel`). The field is assigned to the `Model` attribute of the `<EditForm>` element.
* The <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's `@bind-Value` binds:
  * The model property (`exampleModel.Name`) to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's `Value` property. For more information on property binding, see <xref:blazor/components/data-binding#binding-with-component-parameters>.
  * A change event delegate to the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component's `ValueChanged` property.
* An event handler (`HandleValidSubmit`) is assigned to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit>. The handler is called if the form passes validation.
* The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> [validator component](#validator-components) attaches validation support using data annotations:
  * If the `<input>` form field is left blank when the **`Submit`** button is selected, an error appears in the <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> (`The Name field is required.`) and `HandleValidSubmit` is **not** called.
  * If the `<input>` form field contains more than ten characters when the **`Submit`** button is selected, an error appears in the <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> (`Name is too long.`) and `HandleValidSubmit` is **not** called.
  * If the `<input>` form field contains a valid value when the **`Submit`** button is selected, `HandleValidSubmit` is called and a message is logged to the console.

## Built-in forms components

A set of built-in components are available to receive and validate user input. Inputs are validated when they're changed and when a form is submitted. Available input components are shown in the following table.

::: moniker range=">= aspnetcore-5.0"

| Input component | Rendered as&hellip; |
| --------------- | ------------------- |
| <xref:Microsoft.AspNetCore.Components.Forms.InputCheckbox> | `<input type="checkbox">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> | `<input type="date">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputFile> | `<input type="file">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> | `<input type="number">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputRadio%601> | `<input type="radio">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputRadioGroup%601> | `<input type="radio">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> | `<select>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputText> | `<input>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputTextArea> | `<textarea>` |

For more information on the `InputFile` component, see <xref:blazor/file-uploads>.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

| Input component | Rendered as&hellip; |
| --------------- | ------------------- |
| <xref:Microsoft.AspNetCore.Components.Forms.InputCheckbox> | `<input type="checkbox">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> | `<input type="date">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> | `<input type="number">` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601> | `<select>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputText> | `<input>` |
| <xref:Microsoft.AspNetCore.Components.Forms.InputTextArea> | `<textarea>` |

> [!NOTE]
> `InputRadio` and `InputRadioGroup` components are available in ASP.NET Core 5.0 or later. For more information, select a 5.0 or later version of this article.

::: moniker-end

All of the input components, including <xref:Microsoft.AspNetCore.Components.Forms.EditForm>, support arbitrary attributes. Any attribute that doesn't match a component parameter is added to the rendered HTML element.

Input components provide default behavior for validating when a field is changed, including updating the field CSS class to reflect the field state. Some components include useful parsing logic. For example, <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> handle unparseable values gracefully by registering unparseable values as validation errors. Types that can accept null values also support nullability of the target field (for example, `int?`).

## Form example

The following `Starship` type defines validation logic using a larger set of properties and data annotations than the earlier `ExampleModel`. `Description` is optional because it isn't annotated with the <xref:System.ComponentModel.DataAnnotations.RequiredAttribute?displayProperty=nameWithType>.

`Starship.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Starship.cs)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Starship.cs)]

::: moniker-end

The following form validates user input using the validation defined in the `Starship` model.

`Pages/FormExample2.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample2.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample2.razor)]

::: moniker-end

The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> creates an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> as a [cascading value](xref:blazor/components/cascading-values-and-parameters) that tracks metadata about the edit process, including which fields have been modified and the current validation messages.

Assign **either** an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> **or** an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> to an <xref:Microsoft.AspNetCore.Components.Forms.EditForm>. Assignment of both isn't supported and generates a **runtime error**:

* The preceding Starfleet Starship Database form (`FormExample2` component) demonstrated assigning an instance of `Starship` to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> property of the form.
* The next example (`FormExample3`) demonstrates how to assign an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> for an instance of `Starship` to a form.

The <xref:Microsoft.AspNetCore.Components.Forms.EditForm> provides convenient events for valid and invalid form submission:

* <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit>
* <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnInvalidSubmit>

Use <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit> to use custom code to trigger validation and check field values.

In the following example:

* A shortened version of the preceding Starfleet Starship Database form (`FormExample2` component) from the [Form example](#form-example) section is used that only accepts and validates a value for the starship's identifier.
* The `HandleSubmit` method executes when the **`Submit`** button is selected.
* The form is validated by calling <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A?displayProperty=nameWithType>.
* Additional code is executed depending on the validation result in the method assigned to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnSubmit>.

`Pages/FormExample3.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample3.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample3.razor)]

::: moniker-end

> [!NOTE]
> Framework API doesn't exist to clear validation messages directly from an <xref:Microsoft.AspNetCore.Components.Forms.EditContext>. Therefore, we don't generally recommend adding validation messages to a new <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> in a form. To manage validation messages, use a [validator component](#validator-components) with your [business logic validation code](#business-logic-validation), as described in this article.

::: moniker range=">= aspnetcore-5.0"

## Display name support

The following built-in components support display names with the <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.DisplayName%2A?displayProperty=nameWithType> parameter:

* <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>
* <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601>
* <xref:Microsoft.AspNetCore.Components.Forms.InputSelect%601>

In the Starfleet Starship Database form (`FormExample2` component) in the [Form example](#form-example) section, the production date of a new starship doesn't specify a display name:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="starship.ProductionDate" />
</label>
```

If the field contains an invalid date when the form is submitted, the error message doesn't display a friendly name. The field name, "`ProductionDate`" doesn't have a space between "Production" and "Date" when it appears in the validation summary:

> The ProductionDate field must be a date.

If the <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.DisplayName%2A> property is set to a friendly value with a space between the words "Production" and "Date" for display, the validation summary displays it in the validation summary:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="starship.ProductionDate" DisplayName="Production Date" />
</label>
```

> The Production Date field must be a date.

::: moniker-end

## Error message template support

::: moniker range=">= aspnetcore-5.0"

<xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> support error message templates:

* <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601.ParsingErrorMessage%2A?displayProperty=nameWithType>

In the Starfleet Starship Database form (`FormExample2` component) in the [Form example](#form-example) section with a display name produces an error message using the default error message template:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="starship.ProductionDate" 
               DisplayName="Production Date" />
</label>
```

> The Production Date field must be a date.

Assign a custom template to <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A> to provide a custom message. The position of the `{0}` placeholder is where the value of the <xref:Microsoft.AspNetCore.Components.Forms.InputBase%601.DisplayName%2A> property appears when the error is displayed to the user:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="starship.ProductionDate" 
               DisplayName="Production Date" 
               ParsingErrorMessage="The {0} field has an incorrect date value." />
</label>
```

> The Production Date field has an incorrect date value.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

<xref:Microsoft.AspNetCore.Components.Forms.InputDate%601> and <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> support error message templates:

* <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601.ParsingErrorMessage%2A?displayProperty=nameWithType>

In the Starfleet Starship Database form (`FormExample2` component) in the [Form example](#form-example) section using the default error message template:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="starship.ProductionDate" />
</label>
```

> The ProductionDate field must be a date.

Assign a custom template to <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601.ParsingErrorMessage%2A> to provide a custom message. The position of the `{0}` placeholder is where the field name appears when the error is displayed to the user:

```razor
<label>
    Production Date:
    <InputDate @bind-Value="starship.ProductionDate" 
               ParsingErrorMessage="The {0} field has an incorrect date value." />
</label>
```

> The ProductionDate field has an incorrect date value.

::: moniker-end

## Validator components

Validator components support form validation by managing a <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> for a form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.

The Blazor framework provides the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to attach validation support to forms based on [validation attributes (data annotations)](xref:mvc/models/validation#validation-attributes). Create custom validator components to process validation messages for different forms on the same page or the same form at different steps of form processing, for example client-side validation followed by server-side validation. The validator component example shown in this section, `CustomValidation`, is used in the following sections of this article:

* [Business logic validation](#business-logic-validation)
* [Server validation](#server-validation)

> [!NOTE]
> Custom data annotation validation attributes can be used instead of custom validator components in many cases. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation, any custom attributes applied to the model must be executable on the server. For more information, see <xref:mvc/models/validation#alternatives-to-built-in-attributes>.

Create a validator component from <xref:Microsoft.AspNetCore.Components.ComponentBase>:

* The form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> is a [cascading parameter](xref:blazor/components/cascading-values-and-parameters) of the component.
* When the validator component is initialized, a new <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> is created to maintain a current list of form errors.
* The message store receives errors when developer code in the form's component calls the `DisplayErrors` method. The errors are passed to the `DisplayErrors` method in a [`Dictionary<string, List<string>>`](xref:System.Collections.Generic.Dictionary`2). In the dictionary, the key is the name of the form field that has one or more errors. The value is the error list.
* Messages are cleared when any of the following have occurred:
  * Validation is requested on the <xref:Microsoft.AspNetCore.Components.Forms.EditContext> when the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> event is raised. All of the errors are cleared.
  * A field changes in the form when the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> event is raised. Only the errors for the field are cleared.
  * The `ClearErrors` method is called by developer code. All of the errors are cleared.

`CustomValidation.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/CustomValidation.cs)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/CustomValidation.cs)]

::: moniker-end

> [!NOTE]
> Specifying a namespace is **required** when deriving from <xref:Microsoft.AspNetCore.Components.ComponentBase>. Failing to specify a namespace results in a build error:
>
> > Tag helpers cannot target tag name '\<global namespace>.{CLASS NAME}' because it contains a ' ' character.
>
> The `{CLASS NAME}` placeholder is the name of the component class. The custom validator example in this section specifies the example namespace `BlazorSample`.

> [!NOTE]
> Anonymous lambda expressions are registered event handlers for <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested> and <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> in the preceding example. It isn't necessary to implement <xref:System.IDisposable> and unsubscribe the event delegates in this scenario. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable>.

## Business logic validation

Business logic validation can be accomplished with a [validator component](#validator-components) that receives form errors in a dictionary.

In the following example:

* A shortened version of the *Starship Validation Database* form (`FormExample2` component) from the [Form example](#form-example) section is used that only accepts the starship's classification and description. Data annotation validation is **not** triggered on form submission because the `DataAnnotationsValidator` component isn't included in the form.
* The `CustomValidation` component from the [Validator components](#validator-components) section of this article is used.
* The validation requires a value for the ship's description (`Description`) if the user selects the "`Defense`" ship classification (`Classification`).

When validation messages are set in the component, they're added to the validator's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> and shown in the <xref:Microsoft.AspNetCore.Components.Forms.EditForm>.

`Pages/FormExample4.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample4.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample4.razor)]

::: moniker-end

> [!NOTE]
> As an alternative to using [validation components](#validator-components), data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation, the attributes must be executable on the server. For more information, see <xref:mvc/models/validation#alternatives-to-built-in-attributes>.

## Server validation

Server validation can be accomplished in addition to client-side validation:

* Process client-side validation in the form with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.
* When the form passes client-side validation (<xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit> is called), send the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Model?displayProperty=nameWithType> to a backend server API for form processing.
* Process model validation on the server.
* The server API includes both the built-in framework data annotations validation and custom validation logic supplied by the developer. If validation passes on the server, process the form and send back a success status code ([`200 - OK`](https://developer.mozilla.org/docs/Web/HTTP/Status/200)). If validation fails, return a failure status code ([`400 - Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status/400)) and the field validation errors.
* Either disable the form on success or display the errors.

The following example is based on:

* A hosted Blazor WebAssembly solution created from the [Blazor WebAssembly project template](xref:blazor/project-structure). The approach can be used with any of the secure hosted Blazor solutions described in the [hosted Blazor WebAssembly security documentation](xref:blazor/security/webassembly/index#implementation-guidance).
* The `Starship` model  (`Starship.cs`) from the [Forms example](#form-example) section.
* The `CustomValidation` component shown in the [Validator components](#validator-components) section.

Place the `Starship` model (`Starship.cs`) into the solution's **`Shared`** project so that both the client and server apps can use the model. Add or update the namespace to match the namespace of the shared app (for example, `namespace BlazorSample.Shared`). Since the model requires data annotations, add a package reference for [`System.ComponentModel.Annotations`](https://www.nuget.org/packages/System.ComponentModel.Annotations) to the **`Shared`** project's project file:

```xml
<ItemGroup>
  <PackageReference Include="System.ComponentModel.Annotations" Version="{VERSION}" />
</ItemGroup>
```

To determine the latest non-preview version of the package for the `{VERSION}` placeholder, see the package **Version History** at [NuGet.org](https://www.nuget.org/packages/System.ComponentModel.Annotations).

In the **`Server`** project, add a controller to process starship validation requests and return failed validation messages. Update the namespaces in the last `using` statement and for the class to match the app. In addition to data annotations validation (client-side and server-side), the controller validates that a value is provided for the ship's description (`Description`) if the user selects the `Defense` ship classification (`Classification`). The validation for the `Defense` ship classification only occurs server-side in the controller.

> [!NOTE]
> The `StarshipValidation` controller in this section uses Microsoft Identity 2.0. The Web API only accepts tokens for users that have the "`API.Access`" scope for this API. Additional customization is required if the API's scope name is different from `API.Access`. For a version of the controller that works with Microsoft Identity 1.0 and ASP.NET Core prior to version 5.0, see an earlier version of this article.

`Controllers/StarshipValidation.cs`:

::: moniker range=">= aspnetcore-5.0"

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using BlazorSample.Shared;

namespace BlazorSample.Server.Controllers
{
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
        public async Task<IActionResult> Post(Starship starship)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            try
            {
                if (starship.Classification == "Defense" && 
                    string.IsNullOrEmpty(starship.Description))
                {
                    ModelState.AddModelError(nameof(starship.Description),
                        "For a 'Defense' ship " +
                        "classification, 'Description' is required.");
                }
                else
                {
                    logger.LogInformation("Processing the form asynchronously");

                    // Process the valid form
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
}
```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

> [!NOTE]
> The `StarshipValidation` controller in this section is appropriate for use with Microsoft Identity 1.0. Additional configuration is required for use with Microsoft Identity 2.0 and ASP.NET Core 5.0 or later. To see a version of the controller for updated versions, see a later version of this article.

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using BlazorSample.Shared;

namespace BlazorSample.Server.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Post(Starship starship)
        {
            try
            {
                if (starship.Classification == "Defense" && 
                    string.IsNullOrEmpty(starship.Description))
                {
                    ModelState.AddModelError(nameof(starship.Description),
                        "For a 'Defense' ship " +
                        "classification, 'Description' is required.");
                }
                else
                {
                    logger.LogInformation("Processing the form asynchronously");

                    // Process the valid form
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
}
```

::: moniker-end

If using the preceding controller in a hosted Blazor WebAssembly app, update the namespace (`BlazorSample.Server.Controllers`) to match the app's controllers namespace.

When a model binding validation error occurs on the server, an [`ApiController`](xref:web-api/index) (<xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute>) normally returns a [default bad request response](xref:web-api/index#default-badrequest-response) with a <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. The response contains more data than just the validation errors, as shown in the following example when all of the fields of the *Starfleet Starship Database* form aren't submitted and the form fails validation:

```json
{
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Identifier": ["The Identifier field is required."],
    "Classification": ["The Classification field is required."],
    "IsValidatedDesign": ["This form disallows unapproved ships."],
    "MaximumAccommodation": ["Accommodation invalid (1-100000)."]
  }
}
```

If the server API returns the preceding default JSON response, it's possible for the client to parse the response to obtain the children of the `errors` node. However, it's inconvenient to parse the file. Parsing the JSON requires additional code after calling <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> in order to produce a [`Dictionary<string, List<string>>`](xref:System.Collections.Generic.Dictionary`2) of errors for forms validation error processing. Ideally, the server API should only return the validation errors:

```json
{
  "Identifier": ["The Identifier field is required."],
  "Classification": ["The Classification field is required."],
  "IsValidatedDesign": ["This form disallows unapproved ships."],
  "MaximumAccommodation": ["Accommodation invalid (1-100000)."]
}
```

To modify the server API's response to make it only return the validation errors, change the delegate that's invoked on actions that are annotated with <xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute> in `Startup.ConfigureServices`. For the API endpoint (`/StarshipValidation`), return a <xref:Microsoft.AspNetCore.Mvc.BadRequestObjectResult> with the <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>. For any other API endpoints, preserve the default behavior by returning the object result with a new <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>.

Add the <xref:Microsoft.AspNetCore.Mvc?displayProperty=fullName> namespace to the `Startup.cs` file of the **`Server`** app.

At the top of `Startup.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;
```

In `Startup.ConfigureServices` of `Startup.cs` of the **`Server`** app, locate the <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> extension method and add the following call to <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.ConfigureApiBehaviorOptions%2A>:

```csharp
services.AddControllersWithViews()
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

In the **`Client`** project, add the `CustomValidation` component shown in the [Validator components](#validator-components) section. Update the namespace to match the app (for example, `namespace BlazorSample.Client`).

In the **`Client`** project, the *Starfleet Starship Database* form is updated to show server validation errors with help of the `CustomValidation` component. When the server API returns validation messages, they're added to the `CustomValidation` component's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore>. The errors are available in the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> for display by the form's <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary>.

In the following `FormExample5` component, update the namespace of the **`Shared`** project (`@using BlazorSample.Shared`) to the shared project's namespace.

`Pages/FormExample5.razor`:

```razor
@page "/form-example-5"
@attribute [Authorize]
@using System.Net
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using Microsoft.Extensions.Logging
@using BlazorSample.Shared
@inject HttpClient Http
@inject ILogger<FormExample5> Logger

<h1>Starfleet Starship Database</h1>

<h2>New Ship Entry Form</h2>

<EditForm Model="@starship" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <CustomValidation @ref="customValidation" />
    <ValidationSummary />

    <p>
        <label>
            Identifier:
            <InputText @bind-Value="starship.Identifier" disabled="@disabled" />
        </label>
    </p>
    <p>
        <label>
            Description (optional):
            <InputTextArea @bind-Value="starship.Description" 
                disabled="@disabled" />
        </label>
    </p>
    <p>
        <label>
            Primary Classification:
            <InputSelect @bind-Value="starship.Classification" disabled="@disabled">
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
            <InputNumber @bind-Value="starship.MaximumAccommodation" 
                disabled="@disabled" />
        </label>
    </p>
    <p>
        <label>
            Engineering Approval:
            <InputCheckbox @bind-Value="starship.IsValidatedDesign" 
                disabled="@disabled" />
        </label>
    </p>
    <p>
        <label>
            Production Date:
            <InputDate @bind-Value="starship.ProductionDate" disabled="@disabled" />
        </label>
    </p>

    <button type="submit" disabled="@disabled">Submit</button>

    <p style="@messageStyles">
        @message
    </p>

    <p>
        <a href="http://www.startrek.com/">Star Trek</a>,
        &copy;1966-2019 CBS Studios, Inc. and
        <a href="https://www.paramount.com">Paramount Pictures</a>
    </p>
</EditForm>

@code {
    private bool disabled;
    private string message;
    private string messageStyles = "visibility:hidden";
    private CustomValidation customValidation;
    private Starship starship = new() { ProductionDate = DateTime.UtcNow };

    private async Task HandleValidSubmit(EditContext editContext)
    {
        customValidation.ClearErrors();

        try
        {
            var response = await Http.PostAsJsonAsync<Starship>(
                "StarshipValidation", (Starship)editContext.Model);

            var errors = await response.Content
                .ReadFromJsonAsync<Dictionary<string, List<string>>>();

            if (response.StatusCode == HttpStatusCode.BadRequest && 
                errors.Count() > 0)
            {
                customValidation.DisplayErrors(errors);
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
> As an alternative to the use of a [validation component](#validator-components), data annotation validation attributes can be used. Custom attributes applied to the form's model activate with the use of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. When used with server-side validation, the attributes must be executable on the server. For more information, see <xref:mvc/models/validation#alternatives-to-built-in-attributes>.

> [!NOTE]
> The server-side validation approach in this section is suitable for any of the Blazor WebAssembly hosted solution examples in this documentation set:
>
> * [Azure Active Directory (AAD)](xref:blazor/security/webassembly/hosted-with-azure-active-directory)
> * [Azure Active Directory (AAD) B2C](xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c)
> * [Identity Server](xref:blazor/security/webassembly/hosted-with-identity-server)

## InputText based on the input event

Use the <xref:Microsoft.AspNetCore.Components.Forms.InputText> component to create a custom component that uses the `input` event instead of the `change` event. This results in a validation of a field on each keystroke.

The following example uses the same `ExampleModel` class as the first example at the top of this article.

`ExampleModel.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/ExampleModel.cs)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/ExampleModel.cs)]

::: moniker-end

The following `CustomInputText` component inherits the framework's `InputText` component and sets event binding to the `oninput` event.

`Shared/CustomInputText.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/forms-and-validation/CustomInputText.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/forms-and-validation/CustomInputText.razor)]

::: moniker-end

The `CustomInputText` component can be used anywhere <xref:Microsoft.AspNetCore.Components.Forms.InputText> is used. The following `FormExample6` component uses the shared `CustomInputText` component.

`Pages/FormExample6.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample6.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/forms-and-validation/FormExample6.razor)]

::: moniker-end

## Radio buttons

::: moniker range=">= aspnetcore-5.0"

Use `InputRadio` components with the `InputRadioGroup` component to create a radio button group. In the following example, properties are added to the `Starship` model described in the [Form example](#form-example) section:

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

Add the following `enums` to the app. Create a new file to hold the `enums` or add the `enums` to the `Starship.cs` file. Make the `enums` accessible to the `Starship` model and the *Starfleet Starship Database* form:

```csharp
public enum Manufacturer { SpaceX, NASA, ULA, VirginGalactic, Unknown }
public enum Color { ImperialRed, SpacecruiserGreen, StarshipBlue, VoyagerOrange }
public enum Engine { Ion, Plasma, Fusion, Warp }
```

Update the *Starship Validation Database* form (`FormExample2` component) from the [Form example](#form-example) section. Add the components to produce:

* A radio button group for the ship manufacturer.
* A nested radio button group for ship color and engine.

```razor
<p>
    <InputRadioGroup @bind-Value="starship.Manufacturer">
        Manufacturer:
        <br>
        @foreach (var manufacturer in (Manufacturer[])Enum
            .GetValues(typeof(Manufacturer)))
        {
            <InputRadio Value="manufacturer" />
            @manufacturer
            <br>
        }
    </InputRadioGroup>
</p>

<p>
    Pick one color and one engine:
    <InputRadioGroup Name="engine" @bind-Value="starship.Engine">
        <InputRadioGroup Name="color" @bind-Value="starship.Color">
            <InputRadio Name="color" Value="Color.ImperialRed" />Imperial Red<br>
            <InputRadio Name="engine" Value="Engine.Ion" />Ion<br>
            <InputRadio Name="color" Value="Color.SpacecruiserGreen" />
                Spacecruiser Green<br>
            <InputRadio Name="engine" Value="Engine.Plasma" />Plasma<br>
            <InputRadio Name="color" Value="Color.StarshipBlue" />Starship Blue<br>
            <InputRadio Name="engine" Value="Engine.Fusion" />Fusion<br>
            <InputRadio Name="color" Value="Color.VoyagerOrange" />
                Voyager Orange<br>
            <InputRadio Name="engine" Value="Engine.Warp" />Warp<br>
        </InputRadioGroup>
    </InputRadioGroup>
</p>
```

> [!NOTE]
> If `Name` is omitted, `InputRadio` components are grouped by their most recent ancestor.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

When working with radio buttons in a form, data binding is handled differently than other elements because radio buttons are evaluated as a group. The value of each radio button is fixed, but the value of the radio button group is the value of the selected radio button. The following example shows how to:

* Handle data binding for a radio button group.
* Support validation using a custom `InputRadio` component.

`Shared/InputRadio.razor`:

```razor
@using System.Globalization
@typeparam TValue
@inherits InputBase<TValue>

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
            errorMessage = $"{FieldIdentifier.FieldName} field isn't valid.";

            return false;
        }
    }
}
```

The following <xref:Microsoft.AspNetCore.Components.Forms.EditForm> uses the preceding `InputRadio` component to obtain and validate a rating from the user:

`Pages/FormExample7.razor`:

```razor
@page "/form-example-7"
@using System.ComponentModel.DataAnnotations
@using Microsoft.Extensions.Logging
@inject ILogger<FormExample7> Logger

<h1>Radio Button Group Test</h1>

<EditForm Model="@model" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    @for (int i = 1; i <= 5; i++)
    {
        <label>
            <InputRadio name="rate" SelectedValue="@i" @bind-Value="model.Rating" />
            @i
        </label>
    }

    <button type="submit">Submit</button>
</EditForm>

<p>You chose: @model.Rating</p>

@code {
    private Model model = new();

    private void HandleValidSubmit()
    {
        Logger.LogInformation("HandleValidSubmit called");

        // Process the valid form
    }

    public class Model
    {
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
```

::: moniker-end

## Binding `<select>` element options to C# object `null` values

There's no sensible way to represent a `<select>` element option value as a C# object `null` value, because:

* HTML attributes can't have `null` values. The closest equivalent to `null` in HTML is absence of the HTML `value` attribute from the `<option>` element.
* When selecting an `<option>` with no `value` attribute, the browser treats the value as the *text content* of that `<option>`'s element.

The Blazor framework doesn't attempt to suppress the default behavior because it would involve:

* Creating a chain of special-case workarounds in the framework.
* Breaking changes to current framework behavior.

::: moniker range=">= aspnetcore-5.0"

The most plausible `null` equivalent in HTML is an *empty string* `value`. The Blazor framework handles `null` to empty string conversions for two-way binding to a `<select>`'s value.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

The Blazor framework doesn't automatically handle `null` to empty string conversions when attempting two-way binding to a `<select>`'s value. For more information, see [Fix binding `<select>` to a null value (dotnet/aspnetcore #23221)](https://github.com/dotnet/aspnetcore/pull/23221).

::: moniker-end

## Validation support

The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component attaches validation support using data annotations to the cascaded <xref:Microsoft.AspNetCore.Components.Forms.EditContext>. Enabling support for validation using data annotations requires this explicit gesture. To use a different validation system than data annotations, replace the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> with a custom implementation. The ASP.NET Core implementations are available for inspection in the reference source: [`DataAnnotationsValidator`](https://github.com/dotnet/AspNetCore/blob/main/src/Components/Forms/src/DataAnnotationsValidator.cs)/[`AddDataAnnotationsValidation`](https://github.com/dotnet/AspNetCore/blob/main/src/Components/Forms/src/EditContextDataAnnotationsExtensions.cs).

[!INCLUDE[](~/blazor/includes/aspnetcore-repo-ref-source-links.md)]

Blazor performs two types of validation:

* *Field validation* is performed when the user tabs out of a field. During field validation, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component associates all reported validation results with the field.
* *Model validation* is performed when the user submits the form. During model validation, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component attempts to determine the field based on the member name that the validation result reports. Validation results that aren't associated with an individual member are associated with the model rather than a field.

### Validation Summary and Validation Message components

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component summarizes all validation messages, which is similar to the [Validation Summary Tag Helper](xref:mvc/views/working-with-forms#the-validation-summary-tag-helper):

```razor
<ValidationSummary />
```

Output validation messages for a specific model with the `Model` parameter:
  
```razor
<ValidationSummary Model="@starship" />
```

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> component displays validation messages for a specific field, which is similar to the [Validation Message Tag Helper](xref:mvc/views/working-with-forms#the-validation-message-tag-helper). Specify the field for validation with the `For` attribute and a lambda expression naming the model property:

```razor
<ValidationMessage For="@(() => starship.MaximumAccommodation)" />
```

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> and <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> components support arbitrary attributes. Any attribute that doesn't match a component parameter is added to the generated `<div>` or `<ul>` element.

Control the style of validation messages in the app's stylesheet (`wwwroot/css/app.css` or `wwwroot/css/site.css`). The default `validation-message` class sets the text color of validation messages to red:

```css
.validation-message {
    color: red;
}
```

### Custom validation attributes

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

> [!NOTE]
> <xref:System.ComponentModel.DataAnnotations.ValidationContext.GetService%2A?displayProperty=nameWithType> is `null`. Injecting services for validation in the `IsValid` method isn't supported.

::: moniker range=">= aspnetcore-5.0"

## Custom validation class attributes

Custom validation class names are useful when integrating with CSS frameworks, such as [Bootstrap](https://getbootstrap.com/).

The following example uses the same `ExampleModel` class as the first example at the top of this article.

`ExampleModel.cs`:

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/ExampleModel.cs)]

To specify custom validation class names, start by providing CSS styles for custom validation. In the following example, valid (`validField`) and invalid (`invalidField`) styles are specified.

`wwwroot/css/app.css` (Blazor WebAssembly) or `wwwroot/css/site.css` (Blazor Server):

```css
.validField {
    border-color: lawngreen;
}

.invalidField {
    background-color: tomato;
}
```

Create a class derived from `FieldCssClassProvider` that checks for field validation messages and applies the appropriate valid or invalid style.

`CustomFieldClassProvider.cs`:

```csharp
using System.Linq;
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

Set the class on the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> instance.

`Pages/FormExample8.razor`:

```razor
@page "/form-example-8"
@using Microsoft.Extensions.Logging
@inject ILogger<FormExample8> Logger

<EditForm Model="@exampleModel" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <InputText id="name" @bind-Value="exampleModel.Name" />

    <button type="submit">Submit</button>
</EditForm>

@code {
    private EditContext editContext;
    private ExampleModel exampleModel = new();

    protected override void OnInitialized()
    {
        editContext = new(model);
        editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
    }


    private void HandleValidSubmit()
    {
        Logger.LogInformation("HandleValidSubmit called");

        // Process the valid form
    }
}
```

The preceding example checks the validity of all form fields and applies a style to each field. If the form should only apply custom styles to a subset of the fields, make `CustomFieldClassProvider` apply styles conditionally. The following example only applies a style to the `Identifier` field.

`CustomFieldClassProvider.cs`:

```csharp
public class CustomFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        if (fieldIdentifier.FieldName == "Identifier")
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            return isValid ? "validField" : "invalidField";
        }

        return string.Empty;
    }
}
```

::: moniker-end

### Blazor data annotations validation package

The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) is a package that fills validation experience gaps using the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. The package is currently *experimental*.

> [!NOTE]
> The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) package has a latest version of *release candidate* at [Nuget.org](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation). Continue to use the *experimental* release candidate package at this time. The package's assembly might be moved to either the framework or the runtime in a future release. Watch the [Announcements GitHub repository](https://github.com/aspnet/Announcements), the [dotnet/aspnetcore GitHub repository](https://github.com/dotnet/aspnetcore), or this topic section for further updates.

::: moniker range="< aspnetcore-5.0"

### `[CompareProperty]` attribute

The <xref:System.ComponentModel.DataAnnotations.CompareAttribute> doesn't work well with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component because it doesn't associate the validation result with a specific member. This can result in inconsistent behavior between field-level validation and when the entire model is validated on a submit. The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) *experimental* package introduces an additional validation attribute, `ComparePropertyAttribute`, that works around these limitations. In a Blazor app, `[CompareProperty]` is a direct replacement for the [`[Compare]` attribute](xref:System.ComponentModel.DataAnnotations.CompareAttribute).

::: moniker-end

### Nested models, collection types, and complex types

Blazor provides support for validating form input using data annotations with the built-in <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>. However, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> only validates top-level properties of the model bound to the form that aren't collection- or complex-type properties.

To validate the bound model's entire object graph, including collection- and complex-type properties, use the `ObjectGraphDataAnnotationsValidator` provided by the *experimental* [`Microsoft.AspNetCore.Components.DataAnnotations.Validation`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) package:

```razor
<EditForm Model="@model" OnValidSubmit="@HandleValidSubmit">
    <ObjectGraphDataAnnotationsValidator />
    ...
</EditForm>
```

Annotate model properties with `[ValidateComplexType]`. In the following model classes, the `ShipDescription` class contains additional data annotations to validate when the model is bound to the form:

`Starship.cs`:

::: moniker range=">= aspnetcore-5.0"

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

::: moniker-end

::: moniker range="< aspnetcore-5.0"

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class Starship
{
    ...

    [ValidateComplexType]
    public ShipDescription ShipDescription { get; set; } = 
        new ShipDescription();

    ...
}
```

::: moniker-end

`ShipDescription.cs`:

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class ShipDescription
{
    [Required]
    [StringLength(40, ErrorMessage = "Description too long (40 char).")]
    public string ShortDescription { get; set; }

    [Required]
    [StringLength(240, ErrorMessage = "Description too long (240 char).")]
    public string LongDescription { get; set; }
}
```

### Enable the submit button based on form validation

To enable and disable the submit button based on form validation:

* Use the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> to assign the model when the component is initialized.
* Validate the form in the context's <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> callback to enable and disable the submit button.
* Implement <xref:System.IDisposable> and unsubscribe the event handler in the `Dispose` method. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable>.

> [!NOTE]
> When using an <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, don't also assign a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model> to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm>.

::: moniker range=">= aspnetcore-5.0"

```razor
@implements IDisposable

<EditForm EditContext="@editContext">
    <DataAnnotationsValidator />
    <ValidationSummary />

    ...

    <button type="submit" disabled="@formInvalid">Submit</button>
</EditForm>

@code {
    private Starship starship = new() { ProductionDate = DateTime.UtcNow };
    private bool formInvalid = true;
    private EditContext editContext;

    protected override void OnInitialized()
    {
        editContext = new(starship);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {
        formInvalid = !editContext.Validate();
        StateHasChanged();
    }

    public void Dispose()
    {
        editContext.OnFieldChanged -= HandleFieldChanged;
    }
}
```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

```razor
@implements IDisposable

<EditForm EditContext="@editContext">
    <DataAnnotationsValidator />
    <ValidationSummary />

    ...

    <button type="submit" disabled="@formInvalid">Submit</button>
</EditForm>

@code {
    private Starship starship = new Starship() { ProductionDate = DateTime.UtcNow };
    private bool formInvalid = true;
    private EditContext editContext;

    protected override void OnInitialized()
    {
        editContext = new Starship(starship);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {
        formInvalid = !editContext.Validate();
        StateHasChanged();
    }

    public void Dispose()
    {
        editContext.OnFieldChanged -= HandleFieldChanged;
    }
}
```

::: moniker-end

In the preceding example, set `formInvalid` to `false` if:

* The form is preloaded with valid default values.
* You want the submit button enabled when the form loads.

A side effect of the preceding approach is that a <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component is populated with invalid fields after the user interacts with any one field. This scenario can be addressed in either of the following ways:

* Don't use a <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component on the form.
* Make the <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component visible when the submit button is selected (for example, in a `HandleValidSubmit` method).

```razor
<EditForm EditContext="@editContext" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary style="@displaySummary" />

    ...

    <button type="submit" disabled="@formInvalid">Submit</button>
</EditForm>

@code {
    private string displaySummary = "display:none";

    ...

    private void HandleValidSubmit()
    {
        displaySummary = "display:block";
    }
}
```

## Troubleshoot

> InvalidOperationException: EditForm requires a Model parameter, or an EditContext parameter, but not both.

Confirm that the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> has a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model> **or** <xref:Microsoft.AspNetCore.Components.Forms.EditContext>. Don't use both for the same form.

When assigning a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model> to the form, confirm that the model type is instantiated, as the following example shows:

::: moniker range=">= aspnetcore-5.0"

```csharp
private ExampleModel exampleModel = new();
```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

```csharp
private ExampleModel exampleModel = new ExampleModel();
```

::: moniker-end

::: moniker range=">= aspnetcore-5.0"

## Additional resources

* <xref:blazor/file-uploads>

::: moniker-end
