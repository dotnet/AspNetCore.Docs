Model Validation 
================
By `Rachel Appel <http://github.com/rachelappel>`_

In this article:

- `Introduction to model validation`_
- `Data annotations`_
- `Model state`_
- `Custom validation`_
- `Client side validation`_ 
- `Remote valiation`_

Introduction to model validation
--------------------------------
Before an app stores data in a database, the app must validate the data. Data must be scrubbed for security, verified that it is appropriately formatted by type and size, and it must conform to your rules. Validation is necessary although it can be redundant and tedious to implement. In MVC, validation happens on both the client and server. 

By using data annotations in MVC apps you can validate data by customizing models so they mimic the underlying structure of the data store. This way you can enforce integrity rules and constraints against models by applying attributes to model properties. These attributes generate validation code, thereby reducing the amount of code you must write. Fortunately, .NET has abstracted validation into the data annotations, often reducing validation to a single line of code.

Data annotations
----------------
Data annotations are a way to configure model validation so it's similar to validation on fields in tables. This includes constraints such as assigning data types, required fields, or a primary or foreign key. Other types of validation include applying patterns to data to enforce integrity, such as a credit card, phone number, or email address (regular expressions). Data annotations do all this for you automatically.

Below is an annotated ``Movie`` model from an app that stores information about movies and TV shows. Most of the fields are required, the ``Id`` field is a primary key, and several string properties have length requirements. Additionally, there is a numeric range in place for the ``Price`` property from 0 to $999.99, along with two custom annotations.

.. literalinclude:: validation/sample/Movie.cs
   :language: html
   :lines: 7-37
   :dedent: 4

Simply reading through the model reveals the rules about data for this app, making it easier to maintain the code. Below are several popular built-in data annotations:

- ``[Bind]``: Determines whether the property is included or excluded from model binding.
- ``[CreditCard]``: Formats the property as a credit card type.
- ``[Compare]``: Compares two properties in a model. It works with various types, such as int, string, or date. 
- ``[DataType]``: Applies extra type information to a property. For example, a string property may be formatted as an email data type.
- ``[DisplayName]``: Determines the text that renders in form field labels and validation error messages.
- ``[Email]``: Formats the property with an email format.
- ``[ForeignKey]``: Provides foreign key functionality.
- ``[Key]``: Provides primary key functionality. 
- ``[Phone]``: Formats the property as a telephone format.
- ``[Range]``: Sets the minimum and maximum values for multiple types of properties.
- ``[RegularExpression]``: Forces the data to match a regular expression.
- ``[Required]``: Makes a property required.
- ``[ScaffoldColumn]``: Determines whether to render the property it is applied to.
- ``[StringLength]``: The maximum length for a string field.
- ``[Url]``: Formats the property as a URL.

A complete list of annotations is at the `System.ComponentModel.DataAnnotations <https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations(v=vs.110).aspx>`_ namespace docs. Note that this namespace is not specific to MVC, but in a shared .NET namespace. 

Many annotations provide actions similar to constraint checking in database tables, or in popular business logic patterns. However, there are intances where business rules don't fit into these common scenarios. For those times, you can create custom validation attributes to apply to model properties.  

Model State
-----------
Model state gives you insight as to which form fields have not passed validation. Controllers contain a ``ModelState`` property that is of type ``ModelStateEntry`` and it contains an ``Errors`` property. The errors are a list of keys and values that contains the error messages and other information. You can use the error information to build a response so that the client will know which fields did not pass validation. In the case of a validation error, APIs should return an HTTP status code ``400 Bad Request``.

If you have some logic that can produce a validation error, add that error to the model state's collection of errors by calling ``AddModelStateError`` as demonstrated below. Doing so will return the error message to the client and the view will display it.

.. literalinclude:: validation/sample/MoviesController.cs
   :language: c#
   :lines: 48-69   
   :emphasize-lines: 52-59
   :dedent: 8
   
After model binding and validation are complete, you may want to repeat parts of it. For example, a user may have entered text in a field expecting an integer. You can invoke model binding to update the values of the model by using the ``UpdateModel`` or ``TryUpdateModel`` methods. When using ``UpdateModel``, you must put your code in `try-catch` block. It will attempt to update the model, but if it fails, it will throw an ``InvalidOperationException`` you must catch. ``TryUpdateModel`` attempts to update the model, but comes with a built-in exception handling in case it fails. Both methods will attempt to update the model state with validation errors, and then your view will display those errors. There is a similar pair of methods for validation called ``ValidateModel`` and ``TryValidateModel``. They work in the same manner but attempt to perform validation instead. 

MVC will continue validating fields until reaches the maximum number of errors (200). You can configure this number by inserting the following code into the ``ConfigureServices`` method in the ``Startup.cs`` file, like so:

.. literalinclude:: validation/sample/Startup.cs
   :language: c#
   :lines: 40-41,53-56,66
   :dedent: 8

Custom validation
-----------------
Data annotations work for most validation needs. However, some validation rules are specific to your business, as they're not just generic data validation such as ensuring a field is required or that it conforms to a range of values. For these scenarios, custom validation attributes are a great solution. Creating your own custom validation attributes in MVC is easy. Just inherit from the ``ValidationAttribute``, and override the ``IsValid`` method. The ``IsValid`` method accepts two parameters, the first is an object named `value` and the second is a ``ValidationContext`` object named `validationContext`. `Value` refers to the actual value from the field that your custom validator is validating. The `validationContext` object contains a property named `ObjectInstance`, which contains the information you need to validate your data.

In the following sample, a business rule that states that movies released before 1960 belong to the classic movie genre. The ``[ClassicMovie]`` attribute checks the genre against the release date. If it is released before 1960, genre the property must be categorized as a classic movie. The attribute accepts an integer parameter representing the year that you can use to validate data. You can capture the value of the parameter in the attribute's constructor, as shown here:
					 
.. literalinclude:: validation/sample/ClassicMovieAttribute.cs
   :language: c#
   :lines: 11-36
   :dedent: 4
   
The ``movie`` variable above represents a ``Movie`` object that contains the data from the form submission to validate. In this case, the validation code checks the date and genre in the ``IsValid`` method of the ``ClassicMovieAttribute`` class as per the rules. Upon successful validation ``isValid`` returns a ``ValidationResult.Success`` code, and when validation fails, a ``ValidationResult`` with an error message. When a user modifies the ``Genre`` field and submits the form, the `IsValid` method of the ``ClassicMovieAttribute`` will verify whether the movie is a classic. Like any built-in attribute, apply the ``ClassicMovieAttribute`` to a property such as ``ReleaseDate`` to ensure validation happens, as shown in the previous code sample. 

Client side validation
----------------------
Client side validation is a great convenience for users. It saves time they would otherwise spend waiting for a round trip to the server. In business terms, even a few seconds is multiplied hundreds of times each day and adds up to be a lot of time, expense, and frustration. Straightforward and immediate validation enables users to work more efficiently and produce better quality input and output. 

MVC uses data annotations in addition to type metadata from model properties to validate data and display any error messages. It does so by rendering `HTML5 ``data-`` attributes  <http://w3c.github.io/html/dom.html#embedding-custom-non-visible-data-with-the-data-attributes>`_ in the form elements that need validation, as shown below. MVC generates the ``data-`` attributes for both built-in and custom attributes. The ``data-val-required`` attribute below contains an error message to display if the user doesn't fill in the release date field, and that message displays in the accompanying ``<span>`` element.

.. code-block:: html
 :emphasize-lines: 3
		
  <input name="ReleaseDate" class="form-control" id="ReleaseDate" 
  type="datetime" value="" 
  data-val-required="The ReleaseDate field is required." 
  data-val="true">
        
  <span class="text-danger field-validation-valid" 
  data-valmsg-replace="true" 
  data-valmsg-for="ReleaseDate">
            
After the form fields pass client side validation, the ``ModelStateDictionary`` is populated with values. When the HTTP request reaches MVC it invokes the appropriate action method for processing.

Remote valiation
----------------
Remote validation is a great feature to use when you need to validate data on the client against data on the server. For example, your app may need to verify whether an email or user name is already in use, and it must query a large amount of data to do so. Downloading large sets of data for validating one field consumes too many resources to be worthwile. An alternative is to make a round-trip request to validate a field; however, doing so diminishes the user's experience, especially when other fields quickly pass client side validation. The solution is to use remote validation that will make the UX better with instant validation and high performance.

You can implement remote validation in a two step process. First, you must annotate your model with the ``[Remote]`` attribute. The ``[Remote]`` attribute accepts multiple overloads you can use to direct client side JavaScript to the appropriate code to call. The example points to the ``VerifyEmail`` action method of the ``Users`` controller. 

.. literalinclude:: validation/sample/User.cs
 :language: c#
 :lines: 9-17
 :dedent: 4
 
The second step is putting the validation code in the corresponding action method. In this case it's the ``VerifyEmail`` method in the ``UsersController``. It returns a ``JsonResult`` that the client side can use to proceed or pause and display a validation error if needed.
 
.. literalinclude:: validation/sample/UsersController.cs
 :language: c#
 :lines: 9-17   
 :dedent: 4

Now when users enter an email, JavaScript in the view makes a remote call to see if that email has been taken, and if so, then displays the error message. Otherwise, the user can submit the form as usual.  