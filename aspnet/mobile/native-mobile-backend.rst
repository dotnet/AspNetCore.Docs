:version: 1.0.0

Creating Backend Services for Native Mobile Applications
========================================================

By `Steve Smith`_

Mobile apps can easily communicate with ASP.NET Core backend services.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/mobile/native-mobile-backend/sample>`__

The Sample App
--------------

This tutorial demonstrates how to create backend services using ASP.NET Core MVC to support native mobile apps. It uses the `Xamarin Forms TodoRest app <https://developer.xamarin.com/guides/xamarin-forms/web-services/consuming/rest/>`_ as its native client, which includes separate native clients for Android, iOS, Windows Universal, and Window Phone devices. The sample application includes an ASP.NET Web API 2 services project, which this article's ASP.NET Core MVC app replaces (with no changes required by the client).

.. image:: native-mobile-backend/_static/todo-android.png

.. note:: Securing web APIs is not covered in this article, but will be covered in follow-up documentation.

Features
^^^^^^^^

The TodoRest app supports listing, adding, deleting, and updating To-Do items. Each item has an ID, a Name, Notes, and a property indicating whether it's been Done yet.

The main view of the items, as shown above, lists each item's name and indicates if it is done with a checkmark.

Tapping the `+` icon opens an add item dialog:

.. image:: native-mobile-backend/_static/todo-android-new-item.png

Tapping an item on the main list screen opens up an edit dialog where the item's Name, Notes, and Done settings can be modified, or the item can be deleted:

.. image:: native-mobile-backend/_static/todo-android-edit-item.png

This sample works with a read-only set of backend services by default. To test it out yourself against the ASP.NET Core app created in the next section running on your computer, you'll need to update the app's ``RestUrl`` constant. Navigate to the ``TodoREST`` project and open the `Constants.cs` file. Replace the ``RestUrl`` with a URL that includes your machine's IP address (not localhost or 127.0.0.1, since this address is used from the device emulator, not from your machine). Include the port number as well (5000). In order to test that your services work with a device, ensure you don't have an active firewall blocking access to this port.

.. code-block:: csharp

    // URL of REST service (Xamarin ReadOnly Service)
    //public static string RestUrl = "http://developer.xamarin.com:8081/api/todoitems{0}";
    
    // use your machine's IP address
    public static string RestUrl = "http://192.168.1.207:5000/api/todoitems/{0}";


Creating the ASP.NET Core MVC Project
-------------------------------------

Create a new ASP.NET Core MVC project in Visual Studio. Choose the Web API template and No Authentication.

.. image:: native-mobile-backend/_static/web-api-template.png

The application should respond to all requests made to port 5000. Update `Program.cs` to include ``.UseUrls("http://*:5000")`` to achieve this:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Program.cs
  :language: c#
  :lines: 10-16
  :dedent: 12
  :emphasize-lines: 3

.. note:: Make sure you run the application using Kestrel, not IIS Express. This can be done from Visual Studio, or by running ``dotnet run`` from the command line.

Add a model class to represent To-Do items. Mark required fields using the ``[Required]`` attribute:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Models/TodoItem.cs
  :language: c#

The API methods require some way to work with data. Use the same ITodoRepository interface the original Xamarin sample uses:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Interfaces/ITodoRepository.cs
  :language: c#

For this sample, the implementation just uses a private collection of items. Configure the implementation in `Startup.cs`:

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Startup.cs
  :language: c#
  :lines: 30-36
  :dedent: 8
  :emphasize-lines: 6
  
At this point, you're ready to create the `TodoItemsController`.

Creating the Controller
-----------------------

Add a new controller to the project, `TodoItemsController`. It should inherit from Microsoft.AspNetCore.Mvc.Controller. Add a ``Route`` attribute to indicate that the controller will handle requests made to paths starting with ``api/todoitems``, which may optionally include an ``id`` argument as part of the URL path. The ``[controller]`` token in the route is replaced by the name of the controller (omitting the ``Controller`` suffix), and is especially helpful for global routes. Learn more about :doc:`routing </fundamentals/routing>`.

The controller requires an ``ITodoRepository`` to function; request an instance of this type through the controller's constructor. At runtime, this instance will be provided using the framework's support for :doc:`dependency injection </fundamentals/dependency-injection>`.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/TodoItemsController.cs
  :language: c#
  :lines: 1-17

This API supports four different HTTP verbs to perform CRUD (Create, Read, Update, Delete) operations on the data source. The simplest of these is the Read operation, which corresponds to an HTTP GET request.

Reading Items
^^^^^^^^^^^^^

Requesting a list of items is done with a GET request to the List() method. The method name doesn't matter as long as it's the only method matching the request for the given HTTP verb (in this case, GET). If there were multiple GET methods, it would be necessary to add ``[Route]`` attributes to each action (or add ``[action]`` to the route, which would use the action's name as part of the route).

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/TodoItemsController.cs
  :language: c#
  :lines: 19-23
  :dedent: 8

You can test your new API method using a variety of tools, such as `Postman <https://www.getpostman.com/docs/>`_, shown here:

.. image:: native-mobile-backend/_static/postman-get.png

Creating Items
^^^^^^^^^^^^^^

By convention, creating new data items is mapped to the HTTP POST verb. The ``Create`` method has an ``[HttpPost]`` attribute applied to it, and accepts an ID parameter and a ``TodoItem`` instance. Since the item will be passed in the body of the POST, this parameter is decorated with the ``[FromBody]`` attribute.

Inside the method, the item is checked for validity and prior existence in the data store, and if no issues occur, it is added using the repository. The error handling  mirrors the behavior of the original service used by the native app.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/TodoItemsController.cs
  :language: c#
  :lines: 25-46
  :dedent: 8

Test adding new items using Postman by choosing the POST verb providing the new object in JSON format in the Body of the request. You should also add a request header specifying a ``Content-Type`` of ``application/json``.
 
.. image:: native-mobile-backend/_static/postman-post.png

The method returns the newly created item in the response.

Updating Items
^^^^^^^^^^^^^^

Modifying records is done using HTTP PUT requests. Other than this change, the ``Edit`` method is almost identical to ``Create``. Note that if the record isn't found, the ``Edit`` action will return a ``NotFound`` (404) response.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/TodoItemsController.cs
  :language: c#
  :lines: 48-69
  :dedent: 8

To test with Poastman, change the verb to PUT and add the ID of the record being updated to the URL. Specify the updated object data in the Body of the request.

.. image:: native-mobile-backend/_static/postman-put.png

This method returns a ``NoContent`` (204) response when successful, for consistency with the pre-existing API.

Deleting Items
^^^^^^^^^^^^^^

Deleting records is accomplished by making DELETE requests to the service, and passing the ID of the item to be deleted. As with updates, requests for items that don't exist will receive ``NotFound`` responses. Otherwise, a successful request will get a ``NoContent`` (204) response.

.. literalinclude:: native-mobile-backend/sample/ToDoApi/src/ToDoApi/Controllers/TodoItemsController.cs
  :language: c#
  :lines: 71-88
  :dedent: 8

Note that when testing the delete functionality, nothing is required in the Body of the request.

.. image:: native-mobile-backend/_static/postman-delete.png

Common Web API Conventions
--------------------------

As you develop the backend services for your app, you will want to come up with a consistent set of conventions or policies for handling cross-cutting concerns. For example, in the service shown above, requests for specific records that weren't found received a ``NotFound`` response, rather than a ``BadRequest`` response. Similarly, commands made to this service that passed in model bound types always checked ``ModelState.IsValid`` and returned a ``BadRequest`` for invalid model types.

Once you've identified a common policy for your APIs, you can usually encapsulate it in a :doc:`filter </mvc/controllers/filters>`. Learn more about `how to encapsulate common API policies in ASP.NET Core MVC applications <https://msdn.microsoft.com/en-us/magazine/mt767699.aspx>`_.


