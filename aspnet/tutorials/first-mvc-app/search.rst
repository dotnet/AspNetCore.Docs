Adding Search
==================================================

By `Rick Anderson`_


In this section you'll add search capability to the ``Index`` action method that lets you search movies by *genre* or *name*.

Update the ``Index`` action method to enable search:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 154-166
 :dedent: 8

The first line of the ``Index`` action method creates a `LINQ <http://msdn.microsoft.com/en-us/library/bb397926.aspx>`__ query to select the movies:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 156-157
 :dedent: 12


The query is *only* defined at this point, it **has not** been run against the database.

If the ``searchString`` parameter contains a string, the movies query is modified to filter on the value of the search string, using the following code:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
  :language: c#
  :lines: 159-163
  :dedent: 12
  :emphasize-lines: 3

The ``s => s.Title.Contains()`` code above is a `Lambda Expression <http://msdn.microsoft.com/en-us/library/bb397687.aspx>`__. Lambdas are used in method-based `LINQ <http://msdn.microsoft.com/en-us/library/bb397926.aspx>`__ queries as arguments to standard query operator methods such as the `Where <http://msdn.microsoft.com/en-us/library/system.linq.enumerable.where.aspx>`__ method or ``Contains`` used in the code above. LINQ queries are not executed when they are defined or when they are modified by calling a method such as ``Where``, ``Contains``  or ``OrderBy``. Instead, query execution is deferred, which means that the evaluation of an expression is delayed until its realized value is actually iterated over or the ``ToListAsync`` method is called. For more information about deferred query execution, see `Query Execution <http://msdn.microsoft.com/en-us/library/bb738633.aspx>`__.

.. Note:: The `Contains <http://msdn.microsoft.com/en-us/library/bb155125.aspx>`__ method is run on the database, not the c# code above. On the database, `Contains <http://msdn.microsoft.com/en-us/library/bb155125.aspx>`__ maps to `SQL LIKE <http://msdn.microsoft.com/en-us/library/ms179859.aspx>`__, which is case insensitive.


Navigate to ``/Movies/Index``. Append a query string such as ``?searchString=ghost`` to the URL. The filtered movies are displayed.

.. image:: search/_static/ghost.png

If you change the signature of the ``Index`` method to have a parameter named ``id``, the ``id`` parameter will match the optional ``{id}`` placeholder for the default routes set in *Startup.cs*.

.. literalinclude:: start-mvc/sample/src/MvcMovie/Startup.cs
  :language: c#
  :lines: 80-86
  :dedent: 12
  :emphasize-lines: 5

You can quickly rename the ``searchString`` parameter to ``id`` with the **rename** command. Right click on ``searchString`` **> Rename**.

.. image:: search/_static/rename.png

The rename targets are highlighted.

.. image:: search/_static/rename2.png

Change the parameter to ``id`` and all occurrences of ``searchString`` change to ``id``.

.. image:: search/_static/rename3.png

The previous ``Index`` method:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 154-166
 :emphasize-lines: 1, 6,8
 :dedent: 8

The updated ``Index`` method:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 173-185
 :emphasize-lines: 1, 6,8
 :dedent: 8

You can now pass the search title as route data (a URL segment) instead of as a query string value.

.. image:: search/_static/g2.png

However, you can't expect users to modify the URL every time they want to search for a movie. So now you'll add UI to help them filter movies. If you changed the signature of the ``Index`` method to test how to pass the route-bound ``ID`` parameter, change it back so that it takes a parameter named ``searchString``:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 154-166
 :emphasize-lines: 1, 6,8
 :dedent: 8

.. Index.cshtml is never referenced in the .rst files and is used only to test the code.
  Copy the relevant IndexXXX.cshtml file to Index.cshtml and test.
  Open the *Views/Movies/Index.cshtml* file, and add the ``<form>`` markup highlighted below:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Views/Movies/IndexForm1.cshtml
  :language: HTML
  :lines: 1-21
  :emphasize-lines: 13-18

The HTML ``<form>`` tag uses the :doc:`Form Tag Helper </mvc/views/working-with-forms>`, so when you submit the form, the filter string is posted to the ``Index`` action of the movies controller. Save your changes and then test the filter.

.. image:: search/_static/filter.png

There's no ``[HttpPost]`` overload of the ``Index`` method as you might expect. You don't need it, because the method isn't changing the state of the app, just filtering data.

You could add the following ``[HttpPost] Index`` method.

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
  :language: c#
  :lines: 212-218
  :dedent: 8
  :emphasize-lines: 1

The ``notUsed`` parameter is used to create an overload for the ``Index`` method. We'll talk about that later in the tutorial.

If you add this method, the action invoker would match the ``[HttpPost] Index`` method, and the ``[HttpPost] Index`` method would run as shown in the image below.

.. image:: search/_static/fo.png

However, even if you add this ``[HttpPost]`` version of the ``Index`` method, there's a limitation in how this has all been implemented. Imagine that you want to bookmark a particular search or you want to send a link to friends that they can click in order to see the same filtered list of movies. Notice that the URL for the HTTP POST request is the same as the URL for the GET request (localhost:xxxxx/Movies/Index) -- there's no search information in the URL. The search string information is sent to the server as a `form field value <https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/Forms/Sending_and_retrieving_form_data>`__. You can verify that with the `F12 Developer tools <https://dev.windows.com/en-us/microsoft-edge/platform/documentation/f12-devtools-guide/>`__ or the excellent `Fiddler tool <http://www.telerik.com/fiddler>`__. Start the `F12 tool <https://dev.windows.com/en-us/microsoft-edge/platform/documentation/f12-devtools-guide/>`__:


Tap the **http://localhost:xxx/Movies  HTTP POST 200** line and then tap **Body  > Request Body**.

.. image:: search/_static/f12_rb.png

You can see the search parameter and :doc:`XSRF </security/anti-request-forgery>` token in the request body. Note, as mentioned in the previous tutorial, the :doc:`Form Tag Helper </mvc/views/working-with-forms>` generates an :doc:`XSRF </security/anti-request-forgery>` anti-forgery token. We're not modifying data, so we don't need to validate the token in the controller method.

Because the search parameter is in the request body and not the URL, you can't capture that search information to bookmark or share with others. We'll fix this by specifying the request should be ``HTTP GET``. Notice how intelliSense helps us update the markup.

.. image:: search/_static/int_m.png

.. image:: search/_static/int_get.png

Notice the distinctive font in the ``<form>`` tag. That distinctive font indicates the tag is supported by :doc:`Tag Helpers </mvc/views/tag-helpers/intro>`.

.. image:: search/_static/th_font.png


Now when you submit a search, the URL contains the search query string. Searching will also go to the ``HttpGet Index`` action method, even if you have a ``HttpPost Index`` method.

.. image:: search/_static/search_get.png


Adding Search by Genre
------------------------

Add the following ``MovieGenreViewModel`` class to the *Models* folder:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Models/MovieGenreViewModel.cs
 :language: c#

The move-genre view model will contain:

 - a list of movies
 - a `SelectList <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Mvc/Rendering/SelectList/index.html>`__ containing the list of genres. This will allow the user to select a genre from the list.
 - ``movieGenre``, which contains the selected genre

Replace the ``Index`` method with the following code:

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 223-247
 :dedent: 8


The following code is a ``LINQ`` query that retrieves all the genres from the database.

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 225-228
 :dedent: 12

The ``SelectList`` of genres is created by projecting the distinct genres (we don't want our select list to have duplicate genres).

.. literalinclude:: start-mvc/sample/src/MvcMovie/Controllers/MoviesController.cs
 :language: c#
 :lines: 243
 :dedent: 12


Adding search by genre to the Index view
--------------------------------------------

.. literalinclude:: start-mvc/sample/src/MvcMovie/Views/Movies/IndexFormGenre.cshtml
  :language: HTML
  :lines: 1-64
  :emphasize-lines: 1, 15-17,27,41

Test the app by searching by genre, by movie title, and by both.