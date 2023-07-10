---
title: Tag Helpers in forms in ASP.NET Core
author: rick-anderson
description: Describes the built-in Tag Helpers used with Forms.
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
uid: mvc/views/working-with-forms
---
# Tag Helpers in forms in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [N. Taylor Mullen](https://github.com/NTaylorMullen), [Dave Paquette](https://twitter.com/Dave_Paquette), and [Jerrie Pelser](https://github.com/jerriep)

This document demonstrates working with Forms and the HTML elements commonly used on a Form. The HTML [Form](https://www.w3.org/TR/html401/interact/forms.html) element provides the primary mechanism web apps use to post back data to the server. Most of this document describes [Tag Helpers](tag-helpers/intro.md) and how they can help you productively create robust HTML forms. We recommend you read [Introduction to Tag Helpers](tag-helpers/intro.md) before you read this document.

In many cases, HTML Helpers provide an alternative approach to a specific Tag Helper, but it's important to recognize that Tag Helpers don't replace HTML Helpers and there's not a Tag Helper for each HTML Helper. When an HTML Helper alternative exists, it's mentioned.

<a name="my-asp-route-param-ref-label"></a>

## The Form Tag Helper

The [Form Tag Helper](xref:Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper):

* Generates the HTML [\<FORM>](https://www.w3.org/TR/html401/interact/forms.html) `action` attribute value for a MVC controller action or named route

* Generates a hidden [Request Verification Token](/aspnet/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages) to prevent cross-site request forgery (when used with the `[ValidateAntiForgeryToken]` attribute in the HTTP Post action method)

* Provides the `asp-route-<Parameter Name>` attribute, where `<Parameter Name>` is added to the route values. The  `routeValues` parameters to `Html.BeginForm` and `Html.BeginRouteForm` provide similar functionality.

* Has an HTML Helper alternative `Html.BeginForm` and `Html.BeginRouteForm`

Sample:

[!code-cshtml[](working-with-forms/sample/final/Views/Demo/RegisterFormOnly.cshtml)]

The Form Tag Helper above generates the following HTML:

```html
<form method="post" action="/Demo/Register">
    <!-- Input and Submit elements -->
    <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
</form>
```

The MVC runtime generates the `action` attribute value from the Form Tag Helper attributes `asp-controller` and `asp-action`. The Form Tag Helper also generates a hidden [Request Verification Token](/aspnet/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages) to prevent cross-site request forgery (when used with the `[ValidateAntiForgeryToken]` attribute in the HTTP Post action method). Protecting a pure HTML Form from cross-site request forgery is difficult, the Form Tag Helper provides this service for you.

### Using a named route

The `asp-route` Tag Helper attribute can also generate markup for the HTML `action` attribute. An app with a [route](../../fundamentals/routing.md)  named `register` could use the following markup for the registration page:

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Demo/RegisterRoute.cshtml)]

Many of the views in the *Views/Account* folder (generated when you create a new web app with *Individual User Accounts*) contain the [asp-route-returnurl](xref:mvc/views/working-with-forms) attribute:

```cshtml
<form asp-controller="Account" asp-action="Login"
     asp-route-returnurl="@ViewData["ReturnUrl"]"
     method="post" class="form-horizontal" role="form">
```

>[!NOTE]
>With the built in templates, `returnUrl` is only populated automatically when you try to access an authorized resource but are not authenticated or authorized. When you attempt an unauthorized access, the security middleware redirects you to the login page with the `returnUrl` set.

## The Form Action Tag Helper

The Form Action Tag Helper generates the `formaction` attribute on the generated `<button ...>` or `<input type="image" ...>` tag. The `formaction` attribute controls where a form submits its data. It binds to [\<input>](https://www.w3.org/wiki/HTML/Elements/input) elements of type `image` and [\<button>](https://www.w3.org/wiki/HTML/Elements/button) elements. The Form Action Tag Helper enables the usage of several [AnchorTagHelper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper) `asp-` attributes to control what `formaction` link is generated for the corresponding element.

Supported [AnchorTagHelper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper) attributes to control the value of `formaction`:

|Attribute|Description|
|---|---|
|[asp-controller](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-controller)|The name of the controller.|
|[asp-action](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-action)|The name of the action method.|
|[asp-area](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-area)|The name of the area.|
|[asp-page](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-page)|The name of the Razor page.|
|[asp-page-handler](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-page-handler)|The name of the Razor page handler.|
|[asp-route](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-route)|The name of the route.|
|[asp-route-{value}](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-route-value)|A single URL route value. For example, `asp-route-id="1234"`.|
|[asp-all-route-data](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-all-route-data)|All route values.|
|[asp-fragment](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper#asp-fragment)|The URL fragment.|

### Submit to controller example

The following markup submits the form to the `Index` action of `HomeController` when the input or button are selected:

```cshtml
<form method="post">
    <button asp-controller="Home" asp-action="Index">Click Me</button>
    <input type="image" src="..." alt="Or Click Me" asp-controller="Home" 
                                asp-action="Index">
</form>
```

The previous markup generates following HTML:

```html
<form method="post">
    <button formaction="/Home">Click Me</button>
    <input type="image" src="..." alt="Or Click Me" formaction="/Home">
</form>
```

### Submit to page example

The following markup submits the form to the `About` Razor Page:

```cshtml
<form method="post">
    <button asp-page="About">Click Me</button>
    <input type="image" src="..." alt="Or Click Me" asp-page="About">
</form>
```

The previous markup generates following HTML:

```html
<form method="post">
    <button formaction="/About">Click Me</button>
    <input type="image" src="..." alt="Or Click Me" formaction="/About">
</form>
```

### Submit to route example

Consider the `/Home/Test` endpoint:

```csharp
public class HomeController : Controller
{
    [Route("/Home/Test", Name = "Custom")]
    public string Test()
    {
        return "This is the test page";
    }
}
```

The following markup submits the form to the `/Home/Test` endpoint.

```cshtml
<form method="post">
    <button asp-route="Custom">Click Me</button>
    <input type="image" src="..." alt="Or Click Me" asp-route="Custom">
</form>
```

The previous markup generates following HTML:

```html
<form method="post">
    <button formaction="/Home/Test">Click Me</button>
    <input type="image" src="..." alt="Or Click Me" formaction="/Home/Test">
</form>
```

## The Input Tag Helper

The Input Tag Helper binds an HTML [\<input>](https://www.w3.org/wiki/HTML/Elements/input) element to a model expression in your razor view.

Syntax:

```cshtml
<input asp-for="<Expression Name>">
```

The Input Tag Helper:

* Generates the `id` and `name` HTML attributes for the expression name specified in the `asp-for` attribute. `asp-for="Property1.Property2"` is equivalent to `m => m.Property1.Property2`. The name of the expression is what is used for the `asp-for` attribute value. See the [Expression names](#expression-names) section for additional information.

* Sets the HTML `type` attribute value based on the model type and  [data annotation](xref:Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter) attributes applied to the model property

* Won't overwrite the HTML `type` attribute value when one is specified

* Generates [HTML5](https://developer.mozilla.org/docs/Web/Guide/HTML/HTML5)  validation attributes from [data annotation](xref:Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter) attributes applied to model properties

* Has an HTML Helper feature overlap with `Html.TextBoxFor` and `Html.EditorFor`. See the [HTML Helper alternatives to Input Tag Helper](#html-helper-alternatives-to-input-tag-helper) section for details.

* Provides strong typing. If the name of the property changes and you don't update the Tag Helper you'll get an error similar to the following:

  ```
  An error occurred during the compilation of a resource required to process
  this request. Please review the following specific error details and modify
  your source code appropriately.

  Type expected
   'RegisterViewModel' does not contain a definition for 'Email' and no
   extension method 'Email' accepting a first argument of type 'RegisterViewModel'
   could be found (are you missing a using directive or an assembly reference?)
  ```

The `Input` Tag Helper sets the HTML `type` attribute based on the .NET type. The following table lists some common .NET types and generated HTML type (not every .NET type is listed).

|.NET type|Input Type|
|---|---|
|Bool|type="checkbox"|
|String|type="text"|
|DateTime|type=["datetime-local"](https://developer.mozilla.org/docs/Web/HTML/Element/input/datetime-local)|
|Byte|type="number"|
|Int|type="number"|
|Single, Double|type="number"|

The following table shows some common [data annotations](xref:Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter) attributes that the input tag helper will map to specific input types (not every validation attribute is listed):

|Attribute|Input Type|
|---|---|
|[EmailAddress]|type="email"|
|[Url]|type="url"|
|[HiddenInput]|type="hidden"|
|[Phone]|type="tel"|
|[DataType(DataType.Password)]|type="password"|
|[DataType(DataType.Date)]|type="date"|
|[DataType(DataType.Time)]|type="time"|

Sample:

[!code-csharp[](working-with-forms/sample/final/ViewModels/RegisterViewModel.cs)]

[!code-cshtml[](working-with-forms/sample/final/Views/Demo/RegisterInput.cshtml)]

The code above generates the following HTML:

```html
  <form method="post" action="/Demo/RegisterInput">
      Email:
      <input type="email" data-val="true"
             data-val-email="The Email Address field is not a valid email address."
             data-val-required="The Email Address field is required."
             id="Email" name="Email" value=""><br>
      Password:
      <input type="password" data-val="true"
             data-val-required="The Password field is required."
             id="Password" name="Password"><br>
      <button type="submit">Register</button>
      <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
   </form>
```

The data annotations applied to the `Email` and `Password` properties generate metadata on the model. The Input Tag Helper consumes the model metadata and produces [HTML5](https://developer.mozilla.org/docs/Web/Guide/HTML/HTML5) `data-val-*` attributes (see [Model Validation](../models/validation.md)). These attributes describe the validators to attach to the input fields. This provides unobtrusive HTML5 and [jQuery](https://jquery.com/) validation. The unobtrusive attributes have the format `data-val-rule="Error Message"`, where rule is the name of the validation rule (such as `data-val-required`, `data-val-email`, `data-val-maxlength`, etc.) If an error message is provided in the attribute, it's displayed as the value for the `data-val-rule` attribute. There are also attributes of the form `data-val-ruleName-argumentName="argumentValue"` that provide additional details about the rule, for example, `data-val-maxlength-max="1024"` .

When binding multiple `input` controls to the same property, the generated controls share the same `id`, which makes the generated mark-up invalid. To prevent duplicates, specify the `id` attribute for each control explicitly. 

### Checkbox hidden input rendering

Checkboxes in HTML5 don't submit a value when they're unchecked. To enable a default value to be sent for an unchecked checkbox, the Input Tag Helper generates an additional hidden input for checkboxes.

For example, consider the following Razor markup that uses the Input Tag Helper for a boolean model property `IsChecked`:

```cshtml
<form method="post">
    <input asp-for="@Model.IsChecked" />
    <button type="submit">Submit</button>
</form>
```

The preceding Razor markup generates HTML markup similar to the following:

```html
<form method="post">
    <input name="IsChecked" type="checkbox" value="true" />
    <button type="submit">Submit</button>

    <input name="IsChecked" type="hidden" value="false" /> 
</form>
```

The preceding HTML markup shows an additional hidden input with a name of `IsChecked` and a value of `false`. By default, this hidden input is rendered at the end of the form. When the form is submitted:

* If the `IsChecked` checkbox input is checked, both `true` and `false` are submitted as values.
* If the `IsChecked` checkbox input is unchecked, only the hidden input value `false` is submitted.

The ASP.NET Core model-binding process reads only the first value when binding to a `bool` value, which results in `true` for checked checkboxes and `false` for unchecked checkboxes.

To configure the behavior of the hidden input rendering, set the <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions.CheckBoxHiddenInputRenderMode> property on <xref:Microsoft.AspNetCore.Mvc.MvcViewOptions.HtmlHelperOptions?displayProperty=nameWithType>. For example:

```csharp
services.Configure<MvcViewOptions>(options =>
    options.HtmlHelperOptions.CheckBoxHiddenInputRenderMode =
        CheckBoxHiddenInputRenderMode.None);
```

The preceding code disables hidden input rendering for checkboxes by setting `CheckBoxHiddenInputRenderMode` to <xref:Microsoft.AspNetCore.Mvc.Rendering.CheckBoxHiddenInputRenderMode.None?displayProperty=nameWithType>. For all available rendering modes, see the <xref:Microsoft.AspNetCore.Mvc.Rendering.CheckBoxHiddenInputRenderMode> enum.

### HTML Helper alternatives to Input Tag Helper

`Html.TextBox`, `Html.TextBoxFor`, `Html.Editor` and `Html.EditorFor` have overlapping features with the Input Tag Helper. The Input Tag Helper will automatically set the `type` attribute; `Html.TextBox` and `Html.TextBoxFor` won't. `Html.Editor` and `Html.EditorFor` handle collections, complex objects and templates; the Input Tag Helper doesn't. The Input Tag Helper, `Html.EditorFor`  and  `Html.TextBoxFor` are strongly typed (they use lambda expressions); `Html.TextBox` and `Html.Editor` are not (they use expression names).

### HtmlAttributes

`@Html.Editor()` and `@Html.EditorFor()` use a special `ViewDataDictionary` entry named `htmlAttributes` when executing their default templates. This behavior is optionally augmented using `additionalViewData` parameters. The key "htmlAttributes" is case-insensitive. The key "htmlAttributes" is handled similarly to the `htmlAttributes` object passed to input helpers like `@Html.TextBox()`.

```cshtml
@Html.EditorFor(model => model.YourProperty, 
  new { htmlAttributes = new { @class="myCssClass", style="Width:100px" } })
```

### Expression names

The `asp-for` attribute value is a `ModelExpression` and the right hand side of a lambda expression. Therefore, `asp-for="Property1"` becomes `m => m.Property1` in the generated code which is why you don't need to prefix with `Model`. You can use the "\@" character to start an inline expression and move before the `m.`:

```cshtml
@{
  var joe = "Joe";
}

<input asp-for="@joe">
```

Generates the following:

```html
<input type="text" id="joe" name="joe" value="Joe">
```

With collection properties, `asp-for="CollectionProperty[23].Member"` generates the same name as `asp-for="CollectionProperty[i].Member"` when `i` has the value `23`.

When ASP.NET Core MVC calculates the value of `ModelExpression`, it inspects several sources, including `ModelState`. Consider `<input type="text" asp-for="Name">`. The calculated `value` attribute is the first non-null value from:

* `ModelState` entry with key "Name".
* Result of the expression `Model.Name`.

### Navigating child properties

You can also navigate to child properties using the property path of the view model. Consider a more complex model class that contains a child `Address` property.

[!code-csharp[](../../mvc/views/working-with-forms/sample/final/ViewModels/AddressViewModel.cs?highlight=1,2,3,4&range=5-8)]

[!code-csharp[](../../mvc/views/working-with-forms/sample/final/ViewModels/RegisterAddressViewModel.cs?highlight=8&range=5-13)]

In the view, we bind to `Address.AddressLine1`:

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Demo/RegisterAddress.cshtml?highlight=6)]

The following HTML is generated for `Address.AddressLine1`:

```html
<input type="text" id="Address_AddressLine1" name="Address.AddressLine1" value="">
```

### Expression names and Collections

Sample, a model containing an array of `Colors`:

[!code-csharp[](../../mvc/views/working-with-forms/sample/final/ViewModels/Person.cs?highlight=3&range=5-10)]

The action method:

```csharp
public IActionResult Edit(int id, int colorIndex)
{
    ViewData["Index"] = colorIndex;
    return View(GetPerson(id));
}
```

The following Razor shows how you access a specific `Color` element:

[!code-cshtml[](working-with-forms/sample/final/Views/Demo/EditColor.cshtml)]

The `Views/Shared/EditorTemplates/String.cshtml` template:

[!code-cshtml[](working-with-forms/sample/final/Views/Shared/EditorTemplates/String.cshtml)]

Sample using `List<T>`:

[!code-csharp[](working-with-forms/sample/final/ViewModels/ToDoItem.cs?range=3-8)]

The following Razor shows how to iterate over a collection:

[!code-cshtml[](working-with-forms/sample/final/Views/Demo/Edit.cshtml)]

The `Views/Shared/EditorTemplates/ToDoItem.cshtml` template:

[!code-cshtml[](working-with-forms/sample/final/Views/Shared/EditorTemplates/ToDoItem.cshtml)]

`foreach` should be used if possible when the value is going to be used in an `asp-for` or `Html.DisplayFor` equivalent context. In general, `for` is better than `foreach` (if the scenario allows it) because it doesn't need to allocate an enumerator; however, evaluating an indexer in a LINQ expression can be expensive and should be minimized.

&nbsp;

>[!NOTE]
>The commented sample code above shows how you would replace the lambda expression with the `@` operator to access each `ToDoItem` in the list.

## The Textarea Tag Helper

The `Textarea Tag Helper` tag helper is  similar to the Input Tag Helper.

* Generates the `id` and `name` attributes, and the data validation attributes from the model for a [\<textarea>](https://www.w3.org/wiki/HTML/Elements/textarea) element.

* Provides strong typing.

* HTML Helper alternative: `Html.TextAreaFor`

Sample:

[!code-csharp[](working-with-forms/sample/final/ViewModels/DescriptionViewModel.cs)]

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Demo/RegisterTextArea.cshtml?highlight=4)]

The following HTML is generated:

```html
<form method="post" action="/Demo/RegisterTextArea">
  <textarea data-val="true"
   data-val-maxlength="The field Description must be a string or array type with a maximum length of &#x27;1024&#x27;."
   data-val-maxlength-max="1024"
   data-val-minlength="The field Description must be a string or array type with a minimum length of &#x27;5&#x27;."
   data-val-minlength-min="5"
   id="Description" name="Description">
  </textarea>
  <button type="submit">Test</button>
  <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
</form>
```

## The Label Tag Helper

* Generates the label caption and `for` attribute on a [\<label>](https://www.w3.org/wiki/HTML/Elements/label) element for an expression name

* HTML Helper alternative: `Html.LabelFor`.

The `Label Tag Helper`  provides the following benefits over a pure HTML label element:

* You automatically get the descriptive label value from the `Display` attribute. The intended display name might change over time, and the combination of `Display` attribute and Label Tag Helper will apply the `Display` everywhere it's used.

* Less markup in source code

* Strong typing with the model property.

Sample:

[!code-csharp[](working-with-forms/sample/final/ViewModels/SimpleViewModel.cs)]

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Demo/RegisterLabel.cshtml?highlight=4)]

The following HTML is generated for the `<label>` element:

```html
<label for="Email">Email Address</label>
```

The Label Tag Helper generated the `for` attribute value of "Email", which is the ID associated with the `<input>` element. The Tag Helpers generate consistent `id` and `for` elements so they can be correctly associated. The caption in this sample comes from the `Display` attribute. If the model didn't contain a `Display` attribute, the caption would be the property name of the expression.  To override the default caption, add a caption inside the label tag.

## The Validation Tag Helpers

There are two Validation Tag Helpers. The `Validation Message Tag Helper` (which displays a validation message for a single property on your model), and the `Validation Summary Tag Helper` (which displays a summary of validation errors). The `Input Tag Helper` adds HTML5 client side validation attributes to input elements based on data annotation attributes on your model classes. Validation is also performed on the server. The Validation Tag Helper displays these error messages when a validation error occurs.

### The Validation Message Tag Helper

* Adds the [HTML5](https://developer.mozilla.org/docs/Web/Guide/HTML/HTML5)  `data-valmsg-for="property"` attribute to the [span](https://developer.mozilla.org/docs/Web/HTML/Element/span) element, which attaches the validation error messages on the input field of the specified model property. When a client side validation error occurs, [jQuery](https://jquery.com/) displays the error message in the `<span>` element.

* Validation also takes place on the server. Clients may have JavaScript disabled and some validation can only be done on the server side.

* HTML Helper alternative: `Html.ValidationMessageFor`

The `Validation Message Tag Helper`  is used with the `asp-validation-for` attribute on an HTML [span](https://developer.mozilla.org/docs/Web/HTML/Element/span) element.

```cshtml
<span asp-validation-for="Email"></span>
```

The Validation Message Tag Helper will generate the following HTML:

```html
<span class="field-validation-valid"
  data-valmsg-for="Email"
  data-valmsg-replace="true"></span>
```

You generally use the `Validation Message Tag Helper`  after an `Input` Tag Helper for the same property. Doing so displays any validation error messages near the input that caused the error.

> [!NOTE]
> You must have a view with the correct JavaScript and [jQuery](https://jquery.com/) script references in place for client side validation. See [Model Validation](../models/validation.md) for more information.

When a server side validation error occurs (for example when you have custom server side validation or client-side validation is disabled), MVC places that error message as the body of the `<span>` element.

```html
<span class="field-validation-error" data-valmsg-for="Email"
            data-valmsg-replace="true">
   The Email Address field is required.
</span>
```

### The Validation Summary Tag Helper

* Targets `<div>` elements with the `asp-validation-summary` attribute

* HTML Helper alternative: `@Html.ValidationSummary`

The `Validation Summary Tag Helper`  is used to display a summary of validation messages. The `asp-validation-summary` attribute value can be any of the following:

| asp-validation-summary | Validation messages displayed |
|------------------------|-------------------------------|
| `All`                  | Property and model level      |
| `ModelOnly`            | Model                         |
| `None`                 | None                          |

### Sample

In the following example, the data model has `DataAnnotation` attributes, which generates validation error messages on the `<input>` element.  When a validation error occurs, the Validation Tag Helper displays the error message:

[!code-csharp[](working-with-forms/sample/final/ViewModels/RegisterViewModel.cs)]

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Demo/RegisterValidation.cshtml?highlight=4,6,8&range=1-10)]

The generated HTML (when the model is valid):

```html
<form action="/DemoReg/Register" method="post">
  Email:  <input name="Email" id="Email" type="email" value=""
   data-val-required="The Email field is required."
   data-val-email="The Email field is not a valid email address."
   data-val="true"><br>
  <span class="field-validation-valid" data-valmsg-replace="true"
   data-valmsg-for="Email"></span><br>
  Password: <input name="Password" id="Password" type="password"
   data-val-required="The Password field is required." data-val="true"><br>
  <span class="field-validation-valid" data-valmsg-replace="true"
   data-valmsg-for="Password"></span><br>
  <button type="submit">Register</button>
  <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
</form>
```

## The Select Tag Helper

* Generates [select](https://www.w3.org/wiki/HTML/Elements/select) and associated [option](https://www.w3.org/wiki/HTML/Elements/option) elements for properties of your model.

* Has an HTML Helper alternative `Html.DropDownListFor` and `Html.ListBoxFor`

The `Select Tag Helper` `asp-for` specifies the model property  name for the [select](https://www.w3.org/wiki/HTML/Elements/select) element  and `asp-items` specifies the [option](https://www.w3.org/wiki/HTML/Elements/option) elements.  For example:

[!code-cshtml[](working-with-forms/sample/final/Views/Home/Index.cshtml?range=4)]

Sample:

[!code-csharp[](working-with-forms/sample/final/ViewModels/CountryViewModel.cs)]

The `Index` method initializes the `CountryViewModel`, sets the selected country and passes it to the `Index` view.

[!code-csharp[](working-with-forms/sample/final/Controllers/HomeController.cs?range=8-13)]

The HTTP POST `Index` method displays the selection:

[!code-csharp[](working-with-forms/sample/final/Controllers/HomeController.cs?range=15-27)]

The `Index` view:

[!code-cshtml[](working-with-forms/sample/final/Views/Home/Index.cshtml?highlight=4)]

Which generates the following HTML (with "CA" selected):

```html
<form method="post" action="/">
     <select id="Country" name="Country">
       <option value="MX">Mexico</option>
       <option selected="selected" value="CA">Canada</option>
       <option value="US">USA</option>
     </select>
       <br /><button type="submit">Register</button>
     <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
   </form>
```

> [!NOTE]
> We don't recommend using `ViewBag` or `ViewData` with the Select Tag Helper. A view model is more robust at providing MVC metadata and generally less problematic.

The `asp-for` attribute value is a special case and doesn't require a `Model` prefix, the other Tag Helper attributes do (such as `asp-items`)

[!code-cshtml[](working-with-forms/sample/final/Views/Home/Index.cshtml?range=4)]

### Enum binding

It's often convenient to use `<select>` with an `enum` property and generate the `SelectListItem` elements from the `enum` values.

Sample:

[!code-csharp[](working-with-forms/sample/final/ViewModels/CountryEnumViewModel.cs?range=3-7)]

[!code-csharp[](working-with-forms/sample/final/ViewModels/CountryEnum.cs)]

The `GetEnumSelectList` method generates a `SelectList` object for an enum.

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Home/IndexEnum.cshtml?highlight=5)]

You can mark your enumerator list with the `Display` attribute to get a richer UI:

[!code-csharp[](working-with-forms/sample/final/ViewModels/CountryEnum.cs?highlight=5,7)]

The following HTML is generated:

```html
  <form method="post" action="/Home/IndexEnum">
         <select data-val="true" data-val-required="The EnumCountry field is required."
                 id="EnumCountry" name="EnumCountry">
             <option value="0">United Mexican States</option>
             <option value="1">United States of America</option>
             <option value="2">Canada</option>
             <option value="3">France</option>
             <option value="4">Germany</option>
             <option selected="selected" value="5">Spain</option>
         </select>
         <br /><button type="submit">Register</button>
         <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
    </form>
```

### Option Group

The HTML  [\<optgroup>](https://www.w3.org/wiki/HTML/Elements/optgroup) element is generated when the view model contains one or more `SelectListGroup` objects.

The `CountryViewModelGroup` groups the `SelectListItem` elements into the "North America" and "Europe" groups:

[!code-csharp[](../../mvc/views/working-with-forms/sample/final/ViewModels/CountryViewModelGroup.cs?highlight=5,6,14,20,26,32,38,44&range=6-56)]

The two groups are shown below:

![option group example](working-with-forms/_static/grp.png)

The generated HTML:

```html
 <form method="post" action="/Home/IndexGroup">
      <select id="Country" name="Country">
          <optgroup label="North America">
              <option value="MEX">Mexico</option>
              <option value="CAN">Canada</option>
              <option value="US">USA</option>
          </optgroup>
          <optgroup label="Europe">
              <option value="FR">France</option>
              <option value="ES">Spain</option>
              <option value="DE">Germany</option>
          </optgroup>
      </select>
      <br /><button type="submit">Register</button>
      <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
 </form>
```

### Multiple select

The Select Tag Helper  will automatically generate the [multiple = "multiple"](https://w3c.github.io/html-reference/select.html)  attribute if the property specified in the `asp-for` attribute is an `IEnumerable`. For example, given the following model:

[!code-csharp[](../../mvc/views/working-with-forms/sample/final/ViewModels/CountryViewModelIEnumerable.cs?highlight=6)]

With the following view:

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Home/IndexMultiSelect.cshtml?highlight=4)]

Generates the following HTML:

```html
<form method="post" action="/Home/IndexMultiSelect">
    <select id="CountryCodes"
    multiple="multiple"
    name="CountryCodes"><option value="MX">Mexico</option>
<option value="CA">Canada</option>
<option value="US">USA</option>
<option value="FR">France</option>
<option value="ES">Spain</option>
<option value="DE">Germany</option>
</select>
    <br /><button type="submit">Register</button>
  <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
</form>
```

### No selection

If you find yourself using the "not specified" option in multiple pages, you can create a template to eliminate repeating the HTML:

[!code-cshtml[](../../mvc/views/working-with-forms/sample/final/Views/Home/IndexEmptyTemplate.cshtml?highlight=5)]

The `Views/Shared/EditorTemplates/CountryViewModel.cshtml` template:

[!code-cshtml[](working-with-forms/sample/final/Views/Shared/EditorTemplates/CountryViewModel.cshtml)]

Adding HTML [\<option>](https://www.w3.org/wiki/HTML/Elements/option) elements isn't limited to the *No selection* case. For example, the following view and action method will generate HTML similar to the code above:

[!code-csharp[](working-with-forms/sample/final/Controllers/HomeController.cs?name=snippetNone)]

[!code-cshtml[](working-with-forms/sample/final/Views/Home/IndexOption.cshtml)]

The correct `<option>` element will be selected ( contain the `selected="selected"` attribute) depending on the current `Country` value.

[!code-csharp[](working-with-forms/sample/final/Controllers/HomeController.cs?range=114-119)]

```html
 <form method="post" action="/Home/IndexEmpty">
      <select id="Country" name="Country">
          <option value="">&lt;none&gt;</option>
          <option value="MX">Mexico</option>
          <option value="CA" selected="selected">Canada</option>
          <option value="US">USA</option>
      </select>
      <br /><button type="submit">Register</button>
   <input name="__RequestVerificationToken" type="hidden" value="<removed for brevity>">
 </form>
 ```

## Additional resources

* <xref:mvc/views/tag-helpers/intro>
* [HTML Form element](https://www.w3.org/TR/html401/interact/forms.html)
* [Request Verification Token](/aspnet/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages)
* <xref:mvc/models/model-binding>
* <xref:mvc/models/validation>
* [IAttributeAdapter Interface](xref:Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter)
* [Code snippets for this document](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/views/working-with-forms/sample/final)
