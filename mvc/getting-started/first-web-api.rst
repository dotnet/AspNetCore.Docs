Building Your First Web API with MVC 6
======================================

By `Mike Wasson`_ 

HTTP is not just for serving up web pages. It’s also a powerful platform for building APIs that expose services and data. HTTP is simple, flexible, and ubiquitous. Almost any platform that you can think of has an HTTP library, so HTTP services can reach a broad range of clients, including browsers, mobile devices, and traditional desktop apps.

In this tutorial, you’ll build a simple web API for managing a list of "to-do" items. You won’t build any UI in this tutorial. 


Previous versions of ASP.NET included the Web API framework for creating web APIs. In ASP.NET 5, this functionality has been merged into the MVC 6 framework. Unifying the two frameworks makes it simpler to build apps that include both UI (HTML) and APIs, because now they share the same pipeline. 

.. note:: If you are porting an existing Web API app to MVC 6, see :doc:`../../migration/migratingfromwebapi2`

In this article:

    - `Overview`_
    - `Install Fiddler`_
    - `Create the project`_
    - `Add a model class`_
    - `Add a repository class`_
    - `Register the repository`_
    - `Add a controller`_
    - `Getting to-do items`_
    - `Use Fiddler to call the API`_
    - `Implement the other CRUD operations`_
    - `Next steps`_

You can browse the source code for the sample app on `GitHub <https://github.com/aspnet/Docs/tree/master/mvc/getting-started/first-web-api/sample>`__.


Overview
--------
Here is the API that you’ll create:

=====================  ========================  ============  =============
API                    Description               Request body  Response body
=====================  ========================  ============  =============
GET /api/todo          Get all to-do items       None          Array of to-do items
GET /api/todo/{id}     Get an item by ID         None          To-do item
POST /api/todo         Add a new item            To-do item    To-do item
PUT /api/todo/{id}     Update an existing item   To-do item    None
DELETE /api/todo/{id}  Delete an item.           None          None
=====================  ========================  ============  =============

The following diagram show the basic design of the app. 
 
.. image:: first-web-api/_static/architecture.png

- The client is whatever consumes the web API (browser, mobile app, and so forth). We aren’t writing a client in this tutorial.  
- A *model* is an object that represents the data in your application. In this case, the only model is a to-do item. Models are represented as simple C# classes (POCOs).
- A *controller* is an object that handles HTTP requests and creates the HTTP response. This app will have a single controller. 
- To keep the tutorial simple and focused on MVC 6, the app doesn’t use a database. Instead, it just keeps to-do items in memory. But we’ll still include a (trivial) data access layer, to illustrate the separation between the web API and the data layer. For a tutorial that uses a database, see :doc:`../tutorials/mvc-with-entity-framework`.

Install Fiddler
---------------

*This step is optional.*

Because we're not building a client, we need a way to call the API. In this tutorial, I’ll show that by using `Fiddler <http://www.fiddler2.com/fiddler2/>`__. Fiddler which is a web debugging tool that lets you compose HTTP requests and view the raw HTTP responses. That lets use make direct HTTP requests to the API as we develop the app.

Create the project
------------------

Start Visual Studio 2015. From the **File** menu, select **New** > **Project**.

Select the **ASP.NET Web Application** project template. It appears under **Installed** > **Templates** > **Visual C#** > **Web**. Name the project ``TodoApi`` and click **OK**.

.. image:: first-web-api/_static/new-project.png
 
In the **New Project** dialog, select **Web API** under **ASP.NET 5 Preview Templates**. Click **OK**.
 
.. image:: first-web-api/_static/web-api-project.png

Add a model class
-----------------

A model is an object that represents the data in your application. In this case, the only model is a to-do item. 

First, add a folder named "Models". In Solution Explorer, right-click the project. (The project appears under the "src" folder.) Select **Add** > **New Folder**. Name the folder *Models*.
 
.. image:: first-web-api/_static/add-folder.png
 
.. note:: You can put model classes anywhere in your project. The *Models* folder is just a convention.

Next, add a ``TodoItem`` class. Right-click the *Models* folder and select **Add** > **New Item**. 

In the **Add New Item** dialog, select the **Class** template. Name the class ``TodoItem`` and click **OK**.
 
.. image:: first-web-api/_static/add-class.png 

Replace the boilerplate code with:

.. literalinclude:: first-web-api/sample/src/TodoApi/Models/TodoItem.cs
    :language: c#

Add a repository class
----------------------

A *repository* is an object that encapsulates the data layer, and contains logic for retrieving data and mapping it to an entity model. Even though the example app doesn’t use a database, it’s useful to see how you can inject a repository into your controllers. 

Start by defining a repository interface named ``ITodoRepository``. Use the class template (**Add New Item**  > **Class**).

.. literalinclude:: first-web-api/sample/src/TodoApi/Models/ITodoRepository.cs
    :language: c#

This interface defines basic CRUD operations. In practice, you might have domain-specific methods. 

Next, add a ``TodoRepository`` class that implements ``ITodoRepository``:

.. literalinclude:: first-web-api/sample/src/TodoApi/Models/TodoRepository.cs
    :language: c#


Register the repository
-----------------------

By defining a repository interface, we can decouple the repository class from the MVC controller that uses it. Instead of newing up a ``TodoRepository`` inside the controller, we will inject an ``ITodoRepository``, using the ASP.NET 5 dependency injection (DI) container.

This approach makes it easier to unit test your controllers. Unit tests should inject a mock or stub version of ``ITodoRepository``. That way, the test narrowly targets the controller logic and not the data access layer.

In order to inject the repository into the controller, we need to register it with the DI container. Open the *Startup.cs* file. Add the following using directive:

.. literalinclude:: first-web-api/sample/src/TodoApi/Startup.cs
    :language: c#
    :lines: 4

In the ``ConfigureServices`` method, add the highlighted code:

.. literalinclude:: first-web-api/sample/src/TodoApi/Startup.cs
    :language: c#
    :lines: 16-22
    :emphasize-lines: 6
    :dedent: 8

Add a controller
----------------

In Solution Explorer, right-click the *Controllers* folder. Select **Add** > **New Item**. In the **Add New Item** dialog, select the **Web  API Controller Class** template. Name the class ``TodoController``.

Replace the boilerplate code with the following:

.. literalinclude:: first-web-api/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :lines: 1-11,68-70

This defines an empty controller class. In the next sections, we'll add methods to implement the API. The ``[FromServices]`` attribute tells MVC to inject the ``ITodoRepository`` that we registered earlier.    

Also, go ahead and delete the *ValuesController.cs* file from the *Controllers* folder. The project template adds it as an example controller, but we don’t need it.
 
.. image:: first-web-api/_static/delete-values-controller.png 
 
Getting to-do items
-------------------

To get to-do items, add the following methods to the ``TodoController`` class.

.. literalinclude:: first-web-api/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :lines: 13-28
    :dedent: 8

These methods implement the two GET methods:

- ``GET /api/todo``
- ``GET /api/todo/{id}``

Here is an example HTTP response for the ``GetAll`` method::

    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Server: Microsoft-IIS/10.0
    Date: Thu, 18 Jun 2015 20:51:10 GMT
    Content-Length: 82

    [{"Key":"4f67d7c5-a2a9-4aae-b030-16003dd829ae","Name":"Item1","IsComplete":false}]

Routing and URL paths 
^^^^^^^^^^^^^^^^^^^^^

The ``[HttpGet]`` attribute specifies that these are HTTP GET methods. The URL path for each method is constructed as follows:

- Take the template string in the controller’s ``[Route]`` attribute, "api/[controller]"
- Replace "[controller]" with the value "todo". That’s the name of the controller class, minus the ``Controller`` suffix.
- If the ``[HttpGet]`` attribute also has a template string, append that to the path. 

For the ``GetById`` method,  "{id}" is a placeholder variable. In the actual HTTP request, the client will use the ID of the do-do item. At runtime, when MVC invokes ``GetById``, it assigns the value of "{id}" in the URL the method's *id* parameter.

To learn more about request routing in MVC 6, see :doc:`../controllers/routing`.

Return values
^^^^^^^^^^^^^

The ``GetAll`` method returns a CLR object. MVC automatically serializes the object to JSON and writes the JSON into the body of the response message. The response code for this method is always 200, assuming there are no unhandled exceptions. (Unhandled exceptions are translated into 5xx errors.)

In contrast, the ``GetById`` method returns an ``IActionResult`` type, which represents a generic result type. That’s because ``GetById`` has two expected return values:

- If no item matches the requested ID, the method returns a 404 error.  This is done by returning ``HttpNotFound``.
- Otherwise, the method returns 200 with a JSON response body. This is done by returning an ``ObjectResult``.

Use Fiddler to call the API
---------------------------

This step is optional, but it’s useful to see the raw HTTP responses from the web API. 
In Visual Studio, press F5 to start debugging the app. Visual Studio launches a browser and navigates to ``http://localhost:port/api/values``, where *port* is a randomly chosen port number. We deleted ``ValuesController``, so this URL does not correspond to any controller, and MVC returns a 404 response. That’s OK, because we're going to use Fiddler to send HTTP requests to the API.

Launch Fiddler. From the **File** menu, uncheck the **Capture Traffic** option. This turns off capturing HTTP traffic. 

.. image:: first-web-api/_static/fiddler1.png

Select the **Composer** page. In the **Parsed** tab, type ``http://localhost:port/api/todo``, where *port* is the port number. Click **Execute** to send the request.

.. image:: first-web-api/_static/fiddler2.png

The result appears in the sessions list. The response code should be 200. Use the **Inspectors** tab to view the content of the response, including the response body.

.. image:: first-web-api/_static/fiddler3.png

Implement the other CRUD operations
------------------------------------

The last step is to add ``Create``, ``Update``, and ``Delete`` methods to the controller. These methods are variations on a theme, so I'll just show the code and highlight the main differences.

Create
^^^^^^

.. literalinclude:: first-web-api/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :lines: 30-39
    :dedent: 8
        
This is an HTTP POST method, indicated by the ``[HttpPost]`` attribute. The ``[FromBody]`` attribute tells MVC to get the value of the to-do item from the body of the HTTP request. 

The ``CreatedAtRoute`` method returns a 201 response, which is the standard response for an HTTP POST method that creates a new resource on the server. ``CreateAtRoute`` also adds a Location header to the response. The Location header specifies the URL of the newly created to-do item.

We can use Fiddler to send a Create request:

#.  In the **Composer** page, select POST from the dropdown.
#.  In the request headers text box, add a Content-Type header with the value ``application/json``. Fiddler automatically adds the Content-Length header.
#.  In the request body text box, type the following: ``{"Name":"<your to-do item>"}``
#.  Click **Execute**.

.. image:: first-web-api/_static/fiddler4.png


Here is an example HTTP session. Request::

    POST http://localhost:29359/api/todo HTTP/1.1
    User-Agent: Fiddler
    Host: localhost:29359
    Content-Type: application/json
    Content-Length: 33

    {"Name":"Alphabetize paperclips"}

Response::

    HTTP/1.1 201 Created
    Content-Type: application/json; charset=utf-8
    Location: http://localhost:29359/api/Todo/8fa2154d-f862-41f8-a5e5-a9a3faba0233
    Server: Microsoft-IIS/10.0
    Date: Thu, 18 Jun 2015 20:51:55 GMT
    Content-Length: 97

    {"Key":"8fa2154d-f862-41f8-a5e5-a9a3faba0233","Name":"Alphabetize paperclips","IsComplete":false}


Update
^^^^^^

.. literalinclude:: first-web-api/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :lines: 41-61
    :dedent: 8

``Update`` is similar to ``Create``, but uses HTTP PUT. The response is 204 (No Content).
According to the HTTP spec, a PUT request requires the client to send the entire updated entity, not just the deltas. To support partial updates, use HTTP PATCH.

Delete
^^^^^^

.. literalinclude:: first-web-api/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :lines: 63-68
    :dedent: 8

The void return type returns a 204 (No Content) response. That means the client receives a 204 even if the item has already been deleted, or never existed. There are two ways to think about a request to delete a non-existent resource:

- "Delete" means "delete an existing item", and the item doesn’t exist, so return 404.
- "Delete" means "ensure the item is not in the collection." The item is already not in the collection, so return a 204. 

Either approach is reasonable. If you return 404, the client will need to handle that case. 

Next steps
----------

To learn about creating a backend for a native mobile app, see :doc:`../tutorials/native-mobile-backend`.

For information about deploying your API, see :ref:`Publishing and Deployment <aspnet:publishing-and-deployment>`.




