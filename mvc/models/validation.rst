Model Validation 
=============
By `Rachel Appel <http://github.com/rachelappel>`_

In this article:

- `Introduction to model validation in ASP.NET MVC`_
- `Configure model validation with Data Annotations`_
- `Client side validation`_ 
- `Resources`_

Introduction to data validation
-------------------------------
Any data that your web app uses or stores needs to be thoroughly inspected for the purposes of both security and data integrity. Validation happens in several places, starting with client side validation, and many developers validate again on the server. Databases also check data against integrity rules before storing data. Using Data Annotations in ASP.NET MVC, you can customize models to look and behave just like the underlying backing store. This way you can enforce integrity rules against classes but using metadata, or attributes, reducing the amount of code you must write to perform validation.

Configure model metadata with Data Annotations
------------------------------------------------
ASP.NET uses the model's metadata to generate unobtrusive JavaScript for client side validation. It also uses the metatdata for server side valiation as well. You can customize your models to include proper data types plus extra information about them.

Below is a list of popular data annotations:

-Bind: This attribute sets the field(s) to include or exclude when binding parameters and/or form values to model properties
-DisplayName: This is what displays in form field labels and validation messages.
-Range: This sets the maximum and minimum values for a numeric or date field
-Required: The required attribute sets property as a required field.
-ScaffoldColumn: The ScaffoldColumn attribute denotes whether a property is rendered in views.
-StringLength: This is the maximum length for a string field.
-Url: Formats the property as a URL.
-Phone: Formats the property as a telephone format.
-DataType: This is extra metadata about the data type of the property. For example, a string property may be formatted as an email data type.
-Email: This attribute denotes a property should be formatted as an email type.
-CreditCard: This attribute denotes a property should be formatted as a credit card type.
-Key: The key attribute behaves just like a primary key on a column in a table in the database. 
-ForeignKey: The foreign key attribute behaves just like a foreign key on a column in a table in the database. 
-RegularExpression: This attribute enables you to further configure validation by matching any custom pattern.

The annotations are members of the `System.ComponentModel.DataAnnotations https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations(v=vs.110).aspx` namespace.
Notice that many annotations provide actions similar to constraint checking in database tables. While annotations are similar to constraints, they are not a substitution or replacement for them. If you are using Entity Framework with DB Migrations, EF will create the database and its objects for you. Data annotations give your code more information about the data structures it needs to use. This should help the data quality and integrity as the annotations should match the database constraints where possible.

Client side validation
----------------------
ASP.NET MVC uses the type data from the properties and metadata from the data annotations to crete the fields in HTML forms. It also renders metadata in form elements, as custom attributes or attribute values. jQuery validation scripts then use the HTML elements and their validation metadata to determine if validation has failed and which error message to display. Client side validation is the final polish on a UI, a nice feature for the users. It's not a replacement for security. 

Server side validation and Model State
--------------------------------------
Once the user fills in and submits the form, the corresponding HTTP request contacts an action method of a controller. 
If it's an HTTP POST, then the form fields go as key value pairs
ASP.NET adds them to the ModelStateDictionary 
you can see this in the debugger


Resources
---------
