---
title: Model validation in ASP.NET Core MVC
author: rachelappel
description: Learn about model validation in ASP.NET Core MVC.
keywords: ASP.NET Core,MVC,validation
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 3a8676dd-7ed8-4a05-bca2-44e288ab99ee
ms.technology: aspnet
ms.prod: asp.net-core 
uid: mvc/models/validation
ms.custom: H1Hack27Feb2017
---
# Introduction to model validation in ASP.NET Core MVC

By [Rachel Appel](https://github.com/rachelappel)

## Introduction to model validation

Before an app stores data in a database, the app must validate the data. Data must be checked for potential security threats, verified that it is appropriately formatted by type and size, and it must conform to your rules. Validation is necessary although it can be redundant and tedious to implement. In MVC, validation happens on both the client and server.

Fortunately, .NET has abstracted validation into validation attributes. These attributes contain validation code, thereby reducing the amount of code you must write.

[View or download sample from GitHub](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/models/validation/sample).

## Validation Attributes

Validation attributes are a way to configure model validation so it's similar conceptually to validation on fields in database tables. This includes constraints such as assigning data types or required fields. Other types of validation include applying patterns to data to enforce business rules, such as a credit card, phone number, or email address. Validation attributes make enforcing these requirements much simpler and easier to use.

Below is an annotated `Movie` model from an app that stores information about movies and TV shows. Most of the properties are required and several string properties have length requirements. Additionally, there is a numeric range restriction in place for the `Price` property from 0 to $999.99, along with a custom validation attribute.

[!code-csharp[Main](validation/sample/Movie.cs?range=6-29)]

Simply reading through the model reveals the rules about data for this app, making it easier to maintain the code. Below are several popular built-in validation attributes:

* `[CreditCard]`: Validates the property has a credit card format.

* `[Compare]`: Validates two properties in a model match.

* `[EmailAddress]`: Validates the property has an email format.

* `[Phone]`: Validates the property has a telephone format.

* `[Range]`: Validates the property value falls within the given range.

* `[RegularExpression]`: Validates that the data matches the specified regular expression.

* `[Required]`: Makes a property required.

* `[StringLength]`: Validates that a string property has at most the given maximum length.

* `[Url]`: Validates the property has a URL format.

MVC supports any attribute that derives from `ValidationAttribute` for validation purposes. Many useful validation attributes can be found in the [System.ComponentModel.DataAnnotations](https://docs.microsoft.com/dotnet/api/system.componentmodel.dataannotations) namespace.

There may be instances where you need more features than built-in attributes provide. For those times, you can create custom validation attributes by deriving from `ValidationAttribute` or changing your model to implement `IValidatableObject`.

## Notes on the use of the Required attribute

Non-nullable [value types](/dotnet/csharp/language-reference/keywords/value-types) (such as `decimal`, `int`, `float`, and `DateTime`) are inherently required and don't need the `Required` attribute. The app performs no server-side validation checks for non-nullable types that are marked `Required`.

MVC model binding, which isn't concerned with validation and validation attributes, rejects a form field submission containing a missing value or whitespace for a non-nullable type. In the absence of a `BindRequired` attribute on the target property, model binding ignores missing data for non-nullable types, where the form field is absent from the incoming form data.

The [BindRequired attribute](/aspnet/core/api/microsoft.aspnetcore.mvc.modelbinding.bindrequiredattribute) (also see [Customize model binding behavior with attributes](xref:mvc/models/model-binding#customize-model-binding-behavior-with-attributes)) is useful to ensure form data is complete. When applied to a property, the model binding system requires a value for that property. When applied to a type, the model binding system requires values for all of the properties of that type.

When you use a [Nullable\<T> type](/dotnet/csharp/programming-guide/nullable-types/) (for example, `decimal?` or `System.Nullable<decimal>`) and mark it `Required`, a server-side validation check is performed as if the property were a standard nullable type (for example, a `string`).

Client-side validation requires a value for a form field that corresponds to a model property that you've marked `Required` and for a non-nullable type property that you haven't marked `Required`. `Required` can be used to control the client-side validation error message.

## Model State

Model state represents validation errors in submitted HTML form values.

MVC will continue validating fields until reaches the maximum number of errors (200 by default). You can configure this number by inserting the following code into the `ConfigureServices` method in the *Startup.cs* file:

[!code-csharp[Main](validation/sample/Startup.cs?range=27)]

## Handling Model State Errors

Model validation occurs prior to each controller action being invoked, and it is the action method’s responsibility to inspect `ModelState.IsValid` and react appropriately. In many cases, the appropriate reaction is to return some kind of error response, ideally detailing the reason why model validation failed.

Some apps will choose to follow a standard convention for dealing with model validation errors, in which case a filter may be an appropriate place to implement such a policy. You should test how your actions behave with valid and invalid model states.

## Manual validation

After model binding and validation are complete, you may want to repeat parts of it. For example, a user may have entered text in a field expecting an integer, or you may need to compute a value for a model's property.

You may need to run validation manually. To do so, call the `TryValidateModel` method, as shown here:

[!code-csharp[Main](validation/sample/MoviesController.cs?range=52)]

## Custom validation

Validation attributes work for most validation needs. However, some validation rules are specific to your business, as they're not just generic data validation such as ensuring a field is required or that it conforms to a range of values. For these scenarios, custom validation attributes are a great solution. Creating your own custom validation attributes in MVC is easy. Just inherit from the `ValidationAttribute`, and override the `IsValid` method. The `IsValid` method accepts two parameters, the first is an object named *value* and the second is a `ValidationContext` object named *validationContext*. *Value* refers to the actual value from the field that your custom validator is validating.

In the following sample, a business rule states that users may not set the genre to *Classic* for a movie released after 1960. The `[ClassicMovie]` attribute checks the genre first, and if it is a classic, then it checks the release date to see that it is later than 1960. If it is released after 1960, validation fails. The attribute accepts an integer parameter representing the year that you can use to validate data. You can capture the value of the parameter in the attribute's constructor, as shown here:

[!code-csharp[Main](validation/sample/ClassicMovieAttribute.cs?range=9-28)]

The `movie` variable above represents a `Movie` object that contains the data from the form submission to validate. In this case, the validation code checks the date and genre in the `IsValid` method of the `ClassicMovieAttribute` class as per the rules. Upon successful validation `IsValid` returns a `ValidationResult.Success` code, and when validation fails, a `ValidationResult` with an error message. When a user modifies the `Genre` field and submits the form, the `IsValid` method of the `ClassicMovieAttribute` will verify whether the movie is a classic. Like any built-in attribute, apply the `ClassicMovieAttribute` to a property such as `ReleaseDate` to ensure validation happens, as shown in the previous code sample. Since the example works only with `Movie` types, a better option is to use `IValidatableObject` as shown in the following paragraph.

Alternatively, this same code could be placed in the model by implementing the `Validate` method on the `IValidatableObject` interface. While custom validation attributes work well for validating individual properties, implementing `IValidatableObject` can be used to implement class-level validation as seen here.

[!code-csharp[Main](validation/sample/MovieIValidatable.cs?range=33-41)]

## Client side validation

Client side validation is a great convenience for users. It saves time they would otherwise spend waiting for a round trip to the server. In business terms, even a few fractions of seconds multiplied hundreds of times each day adds up to be a lot of time, expense, and frustration. Straightforward and immediate validation enables users to work more efficiently and produce better quality input and output.

You must have a view with the proper JavaScript script references in place for client side validation to work as you see here.

[!code-cshtml[Main](validation/sample/Views/Shared/_Layout.cshtml?range=37)]

[!code-cshtml[Main](validation/sample/Views/Shared/_ValidationScriptsPartial.cshtml)]

MVC uses validation attributes in addition to type metadata from model properties to validate data and display any error messages using JavaScript. When you use MVC to render form elements from a model using [Tag Helpers](xref:mvc/views/tag-helpers/intro) or [HTML helpers](xref:mvc/views/overview) it will add HTML 5 [data- attributes](http://w3c.github.io/html/dom.html#embedding-custom-non-visible-data-with-the-data-attributes) in the form elements that need validation, as shown below. MVC generates the `data-` attributes for both built-in and custom attributes. You can display validation errors on the client using the relevant tag helpers as shown here:

[!code-cshtml[Main](validation/sample/Views/Movies/Create.cshtml?highlight=4,5&range=19-25)]

The tag helpers above render the HTML below. Notice that the `data-` attributes in the HTML output correspond to the validation attributes for the `ReleaseDate` property. The `data-val-required` attribute below contains an error message to display if the user doesn't fill in the release date field, and that message displays in the accompanying **\<span>** element.

```html
<form action="/Movies/Create" method="post">
    <div class="form-horizontal">
        <h4>Movie</h4>
        <div class="text-danger"></div>
        <div class="form-group">
            <label class="col-md-2 control-label" for="ReleaseDate">ReleaseDate</label>
            <div class="col-md-10">
                <input class="form-control" type="datetime"
                data-val="true" data-val-required="The ReleaseDate field is required."
                id="ReleaseDate" name="ReleaseDate" value="" />
                <span class="text-danger field-validation-valid"
                data-valmsg-for="ReleaseDate" data-valmsg-replace="true"></span>
            </div>
        </div>
    </div>
</form>
```

Client-side validation prevents submission until the form is valid. The Submit button runs JavaScript that either submits the form or displays error messages.

MVC determines type attribute values based on the .NET data type of a property, possibly overridden using `[DataType]` attributes. The base `[DataType]` attribute does no real server-side validation. Browsers choose their own error messages and display those errors however they wish, however the jQuery Validation Unobtrusive package can override the messages and display them consistently with others. This happens most obviously when users apply `[DataType]` subclasses such as `[EmailAddress]`.

### Adding Validation to Dynamic Forms:

Because jQuery Unobtrusive Validation passes validation logic and parameters to jQuery Validate when the page first loads, dynamically generated forms will not automatically exhibit validation. Instead, you must tell jQuery Unobtrusive Validation to parse the dynamic form immediately after creating it. For example, the code below shows how you might set up client side validation on a form added via AJAX.

```js
$.get({
    url: "https://url/that/returns/a/form",
    dataType: "html",
    error: function(jqXHR, textStatus, errorThrown) {
        alert(textStatus + ": Could not add form. " + errorThrown);
    },
    success: function(newFormHTML) {
        var container = document.getElementById("form-container");
        container.insertAdjacentHTML("beforeend", newFormHTML);
        var forms = container.getElementsByTagName("form");
        var newForm = forms[forms.length - 1];
        $.validator.unobtrusive.parse(newForm);
    }
})
```

The `$.validator.unobtrusive.parse()` method accepts a jQuery selector for its one argument. This method tells jQuery Unobtrusive Validation to parse the `data-` attributes of forms within that selector. The values of those attributes are then passed to the jQuery Validate plugin so that the form exhibits the desired client side validation rules.

### Adding Validation to Dynamic Controls:

You can also update the validation rules on a form when individual controls, such as `<input/>`s and `<select/>`s, are dynamically generated. You cannot pass selectors for these elements to the `parse()` method directly because the surrounding form has already been parsed and will not update.  Instead, you first remove the existing validation data, then reparse the entire form, as shown below:

```js
$.get({
    url: "https://url/that/returns/a/control",
    dataType: "html",
    error: function(jqXHR, textStatus, errorThrown) {
        alert(textStatus + ": Could not add form. " + errorThrown);
    },
    success: function(newInputHTML) {
        var form = document.getElementById("my-form");
        form.insertAdjacentHTML("beforeend", newInputHTML);
        form.removeData("validator")    // Added by the raw jQuery Validate
            .removeData("unobtrusiveValidation");   // Added by jQuery Unobtrusive Validation
        $.validator.unobtrusive.parse(form);
    }
})
```

## IClientModelValidator

You may create client side logic for your custom attribute, and [unobtrusive validation](http://jqueryvalidation.org/documentation/) will execute it on the client for you automatically as part of validation. The first step is to control what data- attributes are added by implementing the `IClientModelValidator` interface as shown here:

[!code-csharp[Main](validation/sample/ClassicMovieAttribute.cs?range=30-42)]

Attributes that implement this interface can add HTML attributes to generated fields. Examining the output for the `ReleaseDate` element reveals HTML that is similar to the previous example, except now there is a `data-val-classicmovie` attribute that was defined in the `AddValidation` method of `IClientModelValidator`.

```html
<input class="form-control" type="datetime"
    data-val="true"
    data-val-classicmovie="Classic movies must have a release year earlier than 1960."
    data-val-classicmovie-year="1960"
    data-val-required="The ReleaseDate field is required."
    id="ReleaseDate" name="ReleaseDate" value="" />
```

Unobtrusive validation uses the data in the `data-` attributes to display error messages. However, jQuery doesn't know about rules or messages until you add them to jQuery's `validator` object. This is shown in the example below that adds a method named `classicmovie` containing custom client validation code to the jQuery `validator` object.

[!code-javascript[Main](validation/sample/Views/Movies/Create.cshtml?range=71-93)]

Now jQuery has the information to execute the custom JavaScript validation as well as the error message to display if that validation code returns false.

## Remote validation

Remote validation is a great feature to use when you need to validate data on the client against data on the server. For example, your app may need to verify whether an email or user name is already in use, and it must query a large amount of data to do so. Downloading large sets of data for validating one or a few fields consumes too many resources. It may also expose sensitive information. An alternative is to make a round-trip request to validate a field.

You can implement remote validation in a two step process. First, you must annotate your model with the `[Remote]` attribute. The `[Remote]` attribute accepts multiple overloads you can use to direct client side JavaScript to the appropriate code to call. The example below points to the `VerifyEmail` action method of the `Users` controller.

[!code-csharp[Main](validation/sample/User.cs?range=7-8)]

The second step is putting the validation code in the corresponding action method as defined in the `[Remote]` attribute. It returns a `JsonResult` that the client side can use to proceed or pause and display an error if needed.

[!code-csharp[Main](validation/sample/UsersController.cs?range=19-28)]

Now when users enter an email, JavaScript in the view makes a remote call to see if that email has been taken, and if so, then displays the error message. Otherwise, the user can submit the form as usual.

The `AdditionalFields` property of the `[Remote]` attribute is useful for validating combinations of fields against data on the server.  For example, if the `User` model from above had two additional properties called `FirstName` and `LastName`, you might want to verify that no existing users already have that pair of names.  You define the new properties as shown in the following code:

[!code-csharp[Main](validation/sample/User.cs?range=10-13)]

`AdditionalFields` could have been set explicitly to the strings `"FirstName"` and `"LastName"`, but using the [`nameof`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/nameof) operator like this simplifies later refactoring.  The action method to perform the validation must then accept two arguments, one for the value of `FirstName` and one for the value of `LastName`.


[!code-csharp[Main](validation/sample/UsersController.cs?range=30-39)]

Now when users enter a first and last name, JavaScript:

* Makes a remote call to see if that pair of names has been taken.
* If the pair has been taken, an error message is displayed. 
* If not taken, the user can submit the form.

If you need to validate two or more additional fields with the `[Remote]` attribute, you provide them as a comma-delimited list.  For example, to add a  `MiddleName` property to the model, set the `[Remote]` attribute as shown in the following code:

```cs
[Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName) + "," + nameof(LastName))]
public string MiddleName { get; set; }
```

`AdditionalFields`, like all attribute arguments, must be a constant expression.  Therefore, you must not use an [interpolated string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings) or call [`string.Join()`](https://msdn.microsoft.com/en-us/library/system.string.join(v=vs.110).aspx) to initialize `AdditionalFields`. For every additional field that you add to the `[Remote]` attribute, you must add another argument to the corresponding controller action method.
