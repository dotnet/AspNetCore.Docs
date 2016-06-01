Formatting Response Data
========================

By `Steve Smith`_

ASP.NET Core MVC has built-in support for formatting response data, using fixed formats or in response to client specifications.

.. contents:: Sections
    :local:
    :depth: 1

`View or download sample from GitHub <https://github.com/aspnet/Docs/tree/master/mvc/models/formatting/sample>`_.

Format-Specific Action Results
------------------------------

Some ActionResult options are specific to a particular format, such as JsonResult and ContentResult (note strings are simply returned as text). Actions can return specific results that are always formatted in a particular manner. For example, returning a ``JsonResult`` will return JSON-formatted data, regardless of client preferences. Likewise, returning a ``ContentResult`` will return plain text formatted string data.

To return data using a specific result type, assuming you're inheriting from the base ``Controller`` class, it's recommended that you use the built-in helper methods ``Json`` and ``Content``. These methods check to see if the data being formatted implements ``IDisposable`` and register the object for disposal if required. Your action method should return either the specific result type (for instance, ``JsonResult``) or ``IActionResult``.

Returning JSON-formatted data:

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/Controllers/Api/AuthorsController.cs
  :language: c#
  :lines: 21-26
  :emphasize-lines: 3,5
  :dedent: 8

Sample response from this action:

.. image:: formatting/_static/json-response.png

Note that the content type of the response is ``application/json``, shown both in the list of network requests and in the Response Headers section. Also note the list of options presented by the browser (in this case, Microsoft Edge) in the Accept header, in the Request Headers section. The current technique is ignoring this header; obeying it is discussed below.

To return plain text formatted data, use ``ContentResult`` and the ``Content`` helper:

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/Controllers/Api/AuthorsController.cs
  :language: c#
  :lines: 47-52
  :emphasize-lines: 3,5
  :dedent: 8

A response from this action:

.. image:: formatting/_static/text-response.png

Note in this case the ``Content-Type`` returned is ``text/plain``. You can also achieve this same behavior using just a string response type:

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/Controllers/Api/AuthorsController.cs
  :language: c#
  :lines: 54-59
  :emphasize-lines: 3,5
  :dedent: 8

.. tip:: For non-trivial actions with multiple return types or options (for example, different HTTP status codes based on the result of operations performed), prefer ``IActionResult`` as the return type.

Content Negotiation
-------------------

Content negotiation (*conneg* for short) occurs when the client specifies an Accept header. The default format used by ASP.NET Core MVC is JSON. Negotiation occurs automatically for ``IActionResult`` return types, including results returned using the helper methods ``Ok``, ``BadRequest``, ``Created``, etc. You can also return a model type (a class you've defined as your data transfer type) and the framework will automatically wrap it in an ``ObjectResult`` for you.

The following action method demonstrates the use of the ``Ok`` and ``NotFound`` helper methods:

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/Controllers/Api/AuthorsController.cs
  :language: c#
  :lines: 28-38
  :emphasize-lines: 8,10
  :dedent: 8

Like the previous examples, this one will return JSON-formatted results in response to requests by default. However, you can use a tool like `Fiddler <http://www.telerik.com/fiddler>`_ to create a request that includes an Accept header, and specify another format. In that case, if the server has a *formatter* that matches the requested format, the results will be returned in that format.

.. image:: formatting/_static/fiddler-composer.png

In the above screenshot, the Fiddler Composer has been used to generate a request, specifying ``Accept: application/xml``. By default, ASP.NET Core MVC only supports JSON, so even when another format is specified, the result returned is still JSON-formatted. You'll see how to add additional formatters in the next section.

Your controller actions can return model objects, in which case ASP.NET MVC will automatically create an ``ObjectResult`` for you that wraps the object. The client will get the appropriately formatted serialized object. If the object being returned is ``null``, then the framework will return a ``204 No Content`` response.

Returning an object type:

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/Controllers/Api/AuthorsController.cs
  :language: c#
  :lines: 40-45
  :emphasize-lines: 3
  :dedent: 8

In the sample, a request for a valid author alias will receive a 200 OK response with the author's data. A request for an invalid alias will receive a 204 No Content response.

Content Negotiation Process
^^^^^^^^^^^^^^^^^^^^^^^^^^^

Content *negotiation* only takes place if an ``Accept`` header appears in the request. If it does, then the framework will enumerate through the list of formatters until it finds one that can serialize the response object into that format. If no formatter is found that can support the type to be returned, then the framework will send a 406 Not Acceptable response code. However, if the request specifies XML, but the XML formatter has not been configured, then the JSON formatter will be used. Likewise, if no header is given, then the first formatter that can handle the object to be returned will be used to serialize the response (in this case, there isn't any negotiation taking place - the server is determining what format it will use).

Browsers and Content Negotiation
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Unlike typical API clients, web browsers tend to supply ``Accept`` headers that include a wide array of formats, including wildcards. By default, when the framework detects that the request is coming from a browser, it will ignore the ``Accept`` header and instead return the content in the application's configured default format (JSON unless otherwise configured). This provides a more consistent experience when using different browsers to consume APIs.

If you would prefer your application honor browser accept headers, you can configure this as part of MVC's configuration by setting ``RespectBrowserAcceptHeader`` to ``true`` in the ``ConfigureServices`` method in *Startup.cs*.

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/Startup.cs
  :language: c#
  :lines: 30-34,36,39
  :emphasize-lines: 5
  :dedent: 8

Configuring Formatters
----------------------

If your application needs to support additional formats beyond the default of JSON, you can add these as additional dependencies in *project.json* and configure MVC to support them. There are separate formatters for input and output. Input formatters are used by :doc:`model-binding`; output formatters are used to format API responses. You can also configure :doc:`custom-formatters`.

Configuring the JSON Formatter
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

A common request when formatting responses using JSON is to use JavaScript-style "camel" casing (the first character of each property is lowercase, then uppercase is used to begin each additional word making up the name). Support for camel casing can be added by using the ``AddJsonOptions`` extension method when configuring MVC:

.. code-block:: c#

  services.AddMvc()
    .AddJsonOptions(o =>
      o.SerializerSettings.ContractResolver = 
        new CamelCasePropertyNamesContractResolver());

Replace the default ``SerializerSettings.ContractResolver`` with a new instance of ``CamelCasePropertyNamesContractResolver``.

Adding XML Format Support
^^^^^^^^^^^^^^^^^^^^^^^^^

To add support for XML formatting, add the "Microsoft.AspNetCore.Mvc.Formatters.Xml" package to your *project.json*'s list of dependencies.

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/project.json
  :language: javascript
  :lines: 4-26
  :emphasize-lines: 8
  :dedent: 2

Next, add the ``XmlSerializerOutputFormatter`` to MVC's list of OutputFormatters in *Startup.cs*:

.. literalinclude:: formatting/sample/src/ResponseFormattingSample/Startup.cs
  :language: c#
  :lines: 30-39
  :emphasize-lines: 6
  :dedent: 8

Alternately, you can just call the ``AddXmlSerializerFormatters`` extension method:

.. code-block:: c#
  :emphasize-lines: 2

  services.AddMvc()
    .AddXmlSerializerFormatters();

Once you've added support for XML formatting, your API methods should return the appropriate format based on the request's ``Accept`` header, as this Fiddler example demonstrates:

.. image:: formatting/_static/xml-response.png

You can see at the top of the image that the GET request was made with an ``Accept: application/xml`` header set. The response at the bottom of the image has a ``Content-Type: application/xml`` header, and you can see at the bottom the ``Author`` object has been serialized to XML.

Making the same request, but with ``application/json`` specified in the ``Accept`` header, results in a JSON formatted response:

.. image:: formatting/_static/json-response-fiddler.png

In this screenshot, you can see the request sets a header of ``Accept: application/json`` and the response specifies the same as its ``Content-Type``. The ``Author`` object is shown in the body of the response, in JSON format.

Forcing a Particular Format
^^^^^^^^^^^^^^^^^^^^^^^^^^^

If you would like to require the use of a particular response format, without resorting to using a return type like ``JsonResult``, you can apply the ``[Produces]`` filter. Like most :doc:`/mvc/controllers/filters`, this can be applied at the action, controller, or global scope. When you specify it, you provide the content type that should be produced as a string:

.. code-block:: c#

  [Produces("application/json")]
  public class AuthorsController

The above filter would force all actions within the AuthorsController to return JSON-formatted responses, even if other formatters were configured for the application and the client provided an ``Accept`` header requesting a different, available format.

Special Case Formatters
^^^^^^^^^^^^^^^^^^^^^^^

Some special cases are implemented using built-in formatters, as already described above. By default, ``string`` return types will be formatted as `text/plain`. This behavior can be removed by removing the ``TextPlainFormatter``. Likewise, actions that have a model object return type will return a 204 No Content resposne when returning ``null``. This behavior can be removed by removing the ``HttpNoContentOutputFormatter``. Removing formatters is done in *Startup* when configuring MVC.

Response Format URL Mappings
----------------------------

Clients can request a particular format as part of the URL, such as in the querystring or part of the path, or by using a format-specific file extension (.xml, .json). The mapping from request path should be specified in the route the API is using. For example:

.. code-block:: c#

  [FormatFilter]
  public class ProductsController
  {
  [Route("[controller]/[action]/[id].{format?}")]
  public Product GetById(int id)
  
This route would allow the requested format to be specified as an optional file extension. The ``[FormatFilter]`` attribute checks for the existence of the format value in the ``RouteData`` and will map the output format to the appropriate formatter when the response is created.

.. list-table:: Examples
  :header-rows: 1
  
  * - Route
    - Behavior
  * - ``/products/GetById/5`` 
    - Would use the default output format
  * - ``/products/GetById/5.json``
    - Would use the JSON formatter
  * - ``/products/GetById/5.xml``
    - Would use the XML formatter (if configured)

Recommendations
---------------

There are many options when it comes to returning data from API actions. When creating demos or coding something quickly to see if it will work, simple return types may be appropriate. However, for APIs that will be used in production, you should prefer ``IActionResult`` as your return type for data since it allows you to handle error states and different HTTP status codes explicitly.

.. tip:: Prefer ``IActionResult`` as your action return type, since it can effectively handle error states and different HTTP status codes.

Keep your action methods as small and focused as possible. This helps follow the `Don't Repeat Yourself principle <http://deviq.com/don-t-repeat-yourself/>`, and results in code that has fewer bugs and is easier to maintain. Consider :doc:`/mvc/controllers/filters` as an effective means of pulling cross-cutting concerns and policies out of your APIs.

Built properly with :doc:`/fundamentals/dependency-injection`, you should be able to easily unit test your controllers. However, especially if you're relying on filters to apply certain rules, you will also want to add integration tests to your automated test strategy. Learn more about :doc:`/mvc/controllers/testing`.
