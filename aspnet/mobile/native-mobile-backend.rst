:version: 1.0.0

Creating Backend Services for Native Mobile Applications
========================================================

By `Steve Smith`_

Mobile apps can easily communicate with ASP.NET Core backend services.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample backend services code <https://github.com/aspnet/Docs/tree/master/aspnet/mobile/native-mobile-backend/sample>`__

The Sample Native Mobile App
----------------------------

This tutorial demonstrates how to create backend services using ASP.NET Core MVC to support native mobile apps. It uses the `Xamarin Forms ToDoRest app <https://developer.xamarin.com/guides/xamarin-forms/web-services/consuming/rest/>`_ as its native client, which includes separate native clients for Android, iOS, Windows Universal, and Window Phone devices. You can follow the linked tutorial to create the native app (and install the necessary free Xamarin tools), as well as download the Xamarin sample solution. The Xamarin sample includes an ASP.NET Web API 2 services project, which this article's ASP.NET Core app replaces (with no changes required by the client).

.. image:: native-mobile-backend/_static/todo-android.png

Features
^^^^^^^^

The ToDoRest app supports listing, adding, deleting, and updating To-Do items. Each item has an ID, a Name, Notes, and a property indicating whether it's been Done yet.

The main view of the items, as shown above, lists each item's name and indicates if it is done with a checkmark.

Tapping the ``+`` icon opens an add item dialog:

.. image:: native-mobile-backend/_static/todo-android-new-item.png

Tapping an item on the main list screen opens up an edit dialog where the item's Name, Notes, and Done settings can be modified, or the item can be deleted:

.. image:: native-mobile-backend/_static/todo-android-edit-item.png

This sample is configured by default to use backend services hosted at developer.xamarin.com, which allow read-only operations. To test it out yourself against the ASP.NET Core app created in the next section running on your computer, you'll need to update the app's ``RestUrl`` constant. Navigate to the ``ToDoREST`` project and open the `Constants.cs` file. Replace the ``RestUrl`` with a URL that includes your machine's IP address (not localhost or 127.0.0.1, since this address is used from the device emulator, not from your machine). Include the port number as well (5000). In order to test that your services work with a device, ensure you don't have an active firewall blocking access to this port.

.. code-block:: csharp

    // URL of REST service (Xamarin ReadOnly Service)
    //public static string RestUrl = "http://developer.xamarin.com:8081/api/todoitems{0}";
    
    // use your machine's IP address
    public static string RestUrl = "http://192.168.1.207:5000/api/todoitems/{0}";


Creating the ASP.NET Core Project
---------------------------------

Create a new ASP.NET Core Web Application in Visual Studio. Choose the Web API template and No Authentication. Name the project `ToDoApi`.

.. image:: native-mobile-backend/_static/web-api-template.png

The application should respond to all requests made to port 5000. Update `Program.cs` to include ``.UseUrls("http://*:5000")`` to achieve this:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Program.cs
  :language: c#
  :lines: 10-16
  :dedent: 12
  :emphasize-lines: 3

.. note:: Make sure you run the application directly, rather than behind IIS Express, which ignores non-local requests by default. Run ``dotnet run`` from the command line, or choose the application name profile from the Debug Target dropdown in the Visual Studio toolbar.

Add a model class to represent To-Do items. Mark required fields using the ``[Required]`` attribute:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Models/ToDoItem.cs
  :language: c#

The API methods require some way to work with data. Use the same ``IToDoRepository`` interface the original Xamarin sample uses:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Interfaces/IToDoRepository.cs
  :language: c#

For this sample, the implementation just uses a private collection of items:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Services/ToDoRepository.cs
  :language: c#

Configure the implementation in `Startup.cs`:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Startup.cs
  :language: c#
  :lines: 29-36
  :dedent: 8
  :emphasize-lines: 6
  
At this point, you're ready to create the `ToDoItemsController`.

.. tip:: Learn more about creating web APIs in :doc:`/tutorials/first-web-api`.

Creating the Controller
-----------------------

Add a new controller to the project, `ToDoItemsController`. It should inherit from Microsoft.AspNetCore.Mvc.Controller. Add a ``Route`` attribute to indicate that the controller will handle requests made to paths starting with ``api/todoitems``. The ``[controller]`` token in the route is replaced by the name of the controller (omitting the ``Controller`` suffix), and is especially helpful for global routes. Learn more about :doc:`routing </fundamentals/routing>`.

The controller requires an ``IToDoRepository`` to function; request an instance of this type through the controller's constructor. At runtime, this instance will be provided using the framework's support for :doc:`dependency injection </fundamentals/dependency-injection>`.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/ToDoItemsController.cs
  :language: c#
  :lines: 1-17
  :emphasize-lines: 9, 14

This API supports four different HTTP verbs to perform CRUD (Create, Read, Update, Delete) operations on the data source. The simplest of these is the Read operation, which corresponds to an HTTP GET request.

Reading Items
^^^^^^^^^^^^^

Requesting a list of items is done with a GET request to the ``List`` method. The ``[HttpGet]`` attribute on the ``List`` method indicates that this action should only handle GET requests. The route for this action is the route specified on the controller. You don't necessarily need to use the action name as part of the route. You just need to ensure each action has a unique and unambiguous route. Routing attributes can be applied at both the controller and method levels to build up specific routes.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/ToDoItemsController.cs
  :language: c#
  :lines: 19-23
  :dedent: 8

The ``List`` method returns a 200 OK response code and all of the ToDo items, serialized as JSON.

You can test your new API method using a variety of tools, such as `Postman <https://www.getpostman.com/docs/>`_, shown here:

.. image:: native-mobile-backend/_static/postman-get.png

Creating Items
^^^^^^^^^^^^^^

By convention, creating new data items is mapped to the HTTP POST verb. The ``Create`` method has an ``[HttpPost]`` attribute applied to it, and accepts an ID parameter and a ``ToDoItem`` instance. The HTTP verb attributes, like ``[HttpPost]``, optionally accept a route template string (``{id}`` in this example). This has the same effect as adding a ``[Route]`` attribute to the action. Since the ``item`` argument will be passed in the body of the POST, this parameter is decorated with the ``[FromBody]`` attribute.

Inside the method, the item is checked for validity and prior existence in the data store, and if no issues occur, it is added using the repository. Checking ``ModelState.IsValid`` performs :doc:`model validation </mvc/models/validation>`, and should be done in every API method that accepts user input.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/ToDoItemsController.cs
  :language: c#
  :lines: 25-46
  :dedent: 8

The sample uses an enum containing error codes that are passed to the mobile client:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/ToDoItemsController.cs
  :language: c#
  :lines: 91-99
  :dedent: 4

Test adding new items using Postman by choosing the POST verb providing the new object in JSON format in the Body of the request. You should also add a request header specifying a ``Content-Type`` of ``application/json``.
 
.. image:: native-mobile-backend/_static/postman-post.png

The method returns the newly created item in the response.

Updating Items
^^^^^^^^^^^^^^

Modifying records is done using HTTP PUT requests. Other than this change, the ``Edit`` method is almost identical to ``Create``. Note that if the record isn't found, the ``Edit`` action will return a ``NotFound`` (404) response.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/ToDoItemsController.cs
  :language: c#
  :lines: 48-69
  :dedent: 8

To test with Postman, change the verb to PUT and add the ID of the record being updated to the URL. Specify the updated object data in the Body of the request.

.. image:: native-mobile-backend/_static/postman-put.png

This method returns a ``NoContent`` (204) response when successful, for consistency with the pre-existing API.

Deleting Items
^^^^^^^^^^^^^^

Deleting records is accomplished by making DELETE requests to the service, and passing the ID of the item to be deleted. As with updates, requests for items that don't exist will receive ``NotFound`` responses. Otherwise, a successful request will get a ``NoContent`` (204) response.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/ToDoItemsController.cs
  :language: c#
  :lines: 71-88
  :dedent: 8

Note that when testing the delete functionality, nothing is required in the Body of the request.

.. image:: native-mobile-backend/_static/postman-delete.png

Common Web API Conventions
--------------------------

As you develop the backend services for your app, you will want to come up with a consistent set of conventions or policies for handling cross-cutting concerns. For example, in the service shown above, requests for specific records that weren't found received a ``NotFound`` response, rather than a ``BadRequest`` response. Similarly, commands made to this service that passed in model bound types always checked ``ModelState.IsValid`` and returned a ``BadRequest`` for invalid model types.

Once you've identified a common policy for your APIs, you can usually encapsulate it in a :doc:`filter </mvc/controllers/filters>`. Learn more about `how to encapsulate common API policies in ASP.NET Core MVC applications <https://msdn.microsoft.com/en-us/magazine/mt767699.aspx>`_.


