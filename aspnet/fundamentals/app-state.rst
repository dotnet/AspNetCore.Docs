Session and application state
==============================

By `Rick Anderson`_ and `Steve Smith`_

HTTP is a stateless protocol; the Web server treats each HTTP request as an independent request. The server retains no knowledge of variable values that were used in previous requests. 
This article discusses various approaches to preserving application and user (session) state between requests. Although preserving state is often derried, judicious use of state can reduce app complexity and increase performance.


Application state, unlike session state, applies to all users and sessions. 

The following sections provide an overview of the most common approaches to saving state in an ASP.NET Core app.

.. note: If you are using RedisCache try to use it as a Singleton service as it uses StackExchange's api which recommends sharing the ConnectionMultiplexer https://github.com/aspnet/Announcements/issues/43

https://msdn.microsoft.com/en-us/library/z1hkazw7.aspx

MVC also exposes a TempData property on a Controller which is an additional w
rapper around Session. This can be used for storing transient data that only needs to be available for a single request after the current one.
 

fact that app restarts will clear the session. 
http://andrewlock.net/an-introduction-to-session-storage-in-asp-net-core/
show session cookie
eilon in SO TempData is not the same thing as Session State, it is merely built on top of it. (And it is also not yet implemented in ASP.NET vNext.)

TempData behaves totally different than Session in that data stored there only persists to the next request, whereas traditional Session data persists for the lifetime of the session which could vary from some timeframe like 15 minutes to potentially forever. 

http://www.binaryintellect.net/articles/b06fd1d7-5f8c-46d3-9f61-9c11a2254cbb.aspx
show storing employee as byte[] and json seriliazition.

http://stackoverflow.com/questions/29420262/sessions-in-asp-net-core-1-0

.. contents:: Sections
  :local:
  :depth: 1


Session state
--------------

Session state is a feature in ASP.NET Core you can enable that allows you to save and store user data while the user browses your web app. This user specific data is called session data and is stored in temporary persistence (server memory or a distributed cache) , or in a database.

ASP.NET Core session state identifies requests from the same browser during a limited time window as a session, and provides a way to persist variable values for the duration of that session. It uses a cookie-based identifier to access user data related to a given browser session (a series of requests from a specific browser and machine). Session is ideal for storing user state that is specific to a particular session but which doesn’t need to be persisted permanently (or which can be reproduced as needed from a persistent store). 

.. Warning:: You can’t guarantee the client closes the browser and clears their session cookie (some browsers keep them alive across windows). Consequently, you can’t assume that a session is restricted to a single user, the next user may continue with the same session.  

The in-memory session provider stores session data on the server, which can impact scale out. If you run your web app on a server farm, you’ll need to enable sticky sessions to tie each session to a specific server.  Windows Azure Web Sites defaults to sticky sessions (Application Request Routing or ARR). Sticky session can impact scalability and complicate updating your web app. For maximum scalability and flexibility in updating your site, disable sticky sessions and use a distributed cache for the session store. 

See `Installing and Configuring Session`_, below for more details.

Query strings
^^^^^^^^^^^^^^^^^^^^

State from one request can be provided to another request by adding values to the new request's query string. Query strings should never be used with sensitive data. It is also best used with small amounts of data. 

Query strings are useful for capturing state in a persistent manner, allowing links with embedded state to be created and shared through email or social networks. However, no assumption can be made about the user making the request, since URLs with query strings can easily be shared. Care must also be taken to avoid `Cross-Site Request Forgery (CSRF) <https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)>`_ attacks. An attacker could trick a user into visiting a malicious site while authenticated. CSRF are a major form of vulnerability that can be used to steal user data from your app, or take malicious actions on the behalf of the user. Any preserved application or session state needs to protect against CSRF attachs. See :doc:`/security/anti-request-forgery`

Hidden fields
^^^^^^^^^^^^^^

Data can be saved in hidden form fields and posted back on the next request. This is common in multi-page forms.  It’s insecure in that the client can tamper with the data so the server must always revalidate it.

Cookies
^^^^^^^

Data can be stored in cookies. Cookies are sent with every request, so the size should be kept to a minimum. Ideally, only an identifier should be used, with the actual data stored somewhere on the server. Cookies are subject to tampering and therefore need to be validated on the server. Cookies are limited by most browsers to 4096 bytes and you have only a limited number of cookies per domain. Although the durability of the cookie on a client is subject to user intervention and expiration, cookies are generally the most durable form of data persistence on the client. 

Cookies are often used for personalization, where content is customized for a known user. In most cases, identification is the issue rather than authentication. Thus, you can typically secure a cookie that is used for identification by storing the user name, account name, or a unique user ID (such as a GUID) in the cookie and then use the cookie to access the user personalization infrastructure of a site.

HttpContext.Items
^^^^^^^^^^^^^^^^^

The ``Items`` collection is the good location to store data that is only needed while processing a given request. Its contents are discarded after each request. It is best used as a means of communicating between components or middleware that operate at different points in time during a request, and have no direct relationship with one another through which to pass parameters or return values. See `Working with HttpContext.Items`_, below.


Cache
^^^^^

Caching provides a means of efficiently storing and retrieving data. It provides rules for expiring cached items based on time and other considerations. Learn more about :doc:`/performance/caching/index`.

.. _session: 

Installing and Configuring Session
----------------------------------

The following code from the ``Startup`` class shows how to set up the in-memory session provider: 

.. literalinclude:: app-state/sample/src/WebAppSession/Startup.cs
  :language: none
  :start-after: snippet_1
  :end-before: #endregion
  :dedent: 8
  :emphasize-lines: 5-14, 20

ASP.NET Core ships a session package that provides middleware for managing session state. You can install it by including a reference to the ``Microsoft.AspNetCore.Session`` package in your project.json file.

Once the package is installed, Session must be configured in your application's ``Startup`` class. Session is built on top of ``IDistributedCache``, so you must configure this as well, otherwise you will receive an error.



ASP.NET ships with several implementations of ``IDistributedCache``, including an in-memory option (to be used during development and testing only). To configure session using this in-memory option add the ``Microsoft.Extensions.Caching.Memory`` package in your project.json file and then add the following to ``ConfigureServices``:

.. code-block:: c#

  services.AddDistributedMemoryCache();
  services.AddSession();

Then, add the following to ``Configure`` **before** ``app.UseMVC()`` and you're ready to use session in your application code:

.. code-block:: c#

  app.UseSession();

You can reference Session from ``HttpContext`` once it is installed and configured.

.. note:: If you attempt to access ``Session`` before ``UseSession`` has been called, you will get an ``InvalidOperationException`` exception stating that "Session has not been configured for this application or request."

.. warning:: If you attempt to create a new ``Session`` (i.e. no session cookie has been created yet) after you have already begun writing to the ``Response`` stream, you will get an ``InvalidOperationException`` as well, stating that "The session cannot be established after the response has started". This exception may not be displayed in the browser; you may need to view the web server log  to discover it, as shown below:

.. TODO get stack image:: app-state/_static/session-after-response-error.png

Implementation Details
^^^^^^^^^^^^^^^^^^^^^^
Session uses a cookie to track and disambiguate between requests from different browsers. By default this cookie is named ".AspNet.Session" and uses a path of "/". Further, by default this cookie does not specify a domain, and is not made available to client-side script on the page (because ``CookieHttpOnly`` defaults to ``true``).

These defaults, as well as the default ``IdleTimeout`` (used on the server independent from the cookie), can be overridden when configuring ``Session`` by using ``SessionOptions`` as shown here:

.. code-block:: c#

  services.AddSession(options =>
  {
    options.CookieName = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
  });

The ``IdleTimeout`` is used by the server to determine how long a session can be idle before its contents are abandoned. Each request made to the site that passes through the Session middleware (regardless of whether Session is read from or written to within that middleware) will reset the timeout. Note that this is independent of the cookie's expiration.

.. note:: ``Session`` is *non-locking*, so if two requests both attempt to modify the contents of session, the last one will win. Further, ``Session`` is implemented as a *coherent session*, which means that all of the contents are stored together. This means that if two requests are modifying different parts of the session (different keys), they may still impact each other.

ISession
^^^^^^^^^

Once session is installed and configured, you refer to it via HttpContext, which exposes a property called ``Session`` of type :dn:iface:`~Microsoft.AspNetCore.Http.ISession`. You can use this interface to get and set values in ``Session``, such as ``byte[]``.

.. code-block:: c#

  public interface ISession
  {
      bool IsAvailable { get; }
      string Id { get; }
      IEnumerable<string> Keys { get; }
      Task LoadAsync();
      Task CommitAsync();
      bool TryGetValue(string key, out byte[] value);
      void Set(string key, byte[] value);
      void Remove(string key);
      void Clear();
  }

Because ``Session`` is built on top of ``IDistributedCache``, you must always serialize the object instances being stored. Thus, the interface works with ``byte[]`` not simply ``object``. However, there are extension methods that make working with simple types such as ``String`` and ``Int32`` easier, as well as making it easier to get a byte[] value from session.

.. code-block:: c#

  // session extension usage examples
  context.Session.SetInt32("key1", 123);
  int? val = context.Session.GetInt32("key1");
  context.Session.SetString("key2", "value");
  string stringVal = context.Session.GetString("key2");
  byte[] result = context.Session.Get("key3");

If you're storing more complex objects, you will need to serialize the object to a ``byte[]`` in order to store them, and then deserialize them from ``byte[]`` when retrieving them.


Working with HttpContext.Items
------------------------------

The ``HttpContext`` abstraction provides support for a simple dictionary collection of type ``IDictionary<object, object>``, called ``Items``. This collection is available from the start of an `HttpRequest`` and is discarded at the end of each request. You can access it by simply assigning a value to a keyed entry, or by requesting the value for a given key.

For example, some simple :doc:`middleware` could add something to the ``Items`` collection:

.. code-block:: c#

  app.Use(async (context, next) =>
  {
      // perform some verification
      context.Items["isVerified"] = true;
      await next.Invoke();
  });

and later in the pipeline, another piece of middleware could access it:

.. code-block:: c#

  app.Run(async (context) =>
  {
      await context.Response.WriteAsync("Verified request? " + context.Items["isVerified"]);
  });

.. note:: Since keys into ``Items`` are simple strings, if you are developing middleware that needs to work across many applications, you may wish to prefix your keys with a unique identifier to avoid key collisions (e.g. "MyComponent.isVerified" instead of just "isVerified").

.. _appstate-errors: 

Common errors when working with session
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

- "Unable to resolve service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' while attempting to activate 'Microsoft.AspNetCore.Session.DistributedSessionStore'."
 
 Commonly caused by not configuring at least one ``IDistributedCache`` implementation.

Additional Resources
^^^^^^^^^^^^^^^^^^^^^

- `Sample code used in this document <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/app-state/sample>`__
