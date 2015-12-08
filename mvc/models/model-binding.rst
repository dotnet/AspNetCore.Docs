Model Binding
=============

By `Rachel Appel <http://github.com/rachelappel>`_

In this article

- `Introduction to model binding`_
- `Binding formatted data from the request body`_ 
- `Binding data from the request URI`_
- `Configuring input formatters`_
- `Resources`_

Introduction to model binding
-----------------------------
Model binders are the part of the ASP.NET MVC framework that maps data from HTTP requests to properties of objects in your model. The requests usually come from an HTML form as part of an HTTP POST, or from a querystring in an HTTP GET request. By default, ASP.NET MVC does a 1:1 mapping using a technique called Convention over Configuration that pairs the incoming data to the model's properties by matching the names and types. However, ASP.NET MVC is quite extensible, so you can customize the built in model binders to suit your own needs.   

Binding formatted data from the request body
--------------------------------------------
In a typical application, ASP.NET generates an HTML form based off the Book class below that includes the ``Title``, ``Year``, ``Price``, ``Genre``, and ``Author`` fields. When the user submits the form, we want to be able to capture those values from the HTTP POST Request, validate them, and save them back to a data store. The easiest way to do so is to use ASP.NET MVC's built in model binder, as it will do those 1:1 mappings automatically. 

.. literalinclude:: ../../aspnet/tutorials/your-first-aspnet-application/sample/src/contosobooks/models/book.cs
   :language: html
   :lines: 5-23
   
The ``Edit`` action method in the controller below contains a ``Movie`` parameter, and it automatically binds incoming data to its properties. As you can see, there is an ``[HttpPost]`` attribute at the beginning of the code block. That signals to ASP.NET to expect the ``Book`` object to arrive via HTTP POST.

.. literalinclude:: ../../aspnet/tutorials/your-first-aspnet-application/sample/src/contosobooks/controllers/bookscontroller.cs
   :language: html
   :lines: 82-94


You can define which fields to include or exclude from mapping by applying the ``Bind`` attribute as you see here. It's like a filter of fields that you want to accept from the request.

.. code-block:: c#

  public ActionResult Edit([Bind(Include = "ID,Title,Year,Genre,Price,Author")] Book book)
  
You can also exclude specific fields if you wish.

.. code-block:: c#

  public ActionResult Edit([Bind(Exclude = "ID,Price")] Book book)


Binding data from the request URI
---------------------------------


Configuring input formatters
----------------------------


Resources
---------

