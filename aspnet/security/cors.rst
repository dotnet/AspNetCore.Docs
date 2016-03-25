Enabling Cross-Origin Requests (CORS)
=====================================

By `Mike Wasson`_

Browser security prevents a web page from making AJAX requests to another domain. This restriction is called the *same-origin policy*, and prevents a malicious site from reading sensitive data from another site. However, sometimes you might want to let other sites make cross-origin requests to your web app.

`Cross Origin Resource Sharing <http://www.w3.org/TR/cors/>`_ (CORS) is a W3C standard that allows a server to relax the same-origin policy. Using CORS, a server can explicitly allow some cross-origin requests while rejecting others. CORS is safer and more flexible than earlier techniques such as `JSONP <http://en.wikipedia.org/wiki/JSONP>`_. This topic shows how to enable CORS in your ASP.NET Core application.

.. contents:: Sections:
  :local:
  :depth: 1

What is "same origin"?
----------------------

Two URLs have the same origin if they have identical schemes, hosts, and ports. (`RFC 6454 <http://tools.ietf.org/html/rfc6454>`_)

These two URLs have the same origin:

- http://example.com/foo.html
- http://example.com/bar.html

These URLs have different origins than the previous two:

- http://example.net - Different domain
- http://example.com:9000/foo.html - Different port
- https://example.com/foo.html - Different scheme
- http://www.example.com/foo.html - Different subdomain

.. note:: Internet Explorer does not consider the port when comparing origins.

Setting up CORS
---------------

To setup CORS for your application you use the ``Microsoft.AspNet.Cors`` package. In your project.json file, add the following:

.. literalinclude:: cors/sample/src/CorsExample1/project.json
  :language: json
  :lines: 5,6,9
  :emphasize-lines: 2
  
Add the CORS services in Startup.cs:

.. literalinclude:: cors/sample/src/CorsExample1/Startup.cs
  :language: csharp
  :lines: 9-12
  :dedent: 8

Enabling CORS with middleware
-----------------------------

To enable CORS for your entire application add the CORS middleware to your request pipeline using the ``UseCors`` extension method. Note that the CORS middleware must proceed any defined endpoints in your app that you want to support cross-origin requests (ex. before any call to ``UseMvc``).

You can specify a cross-origin policy when adding the CORS middleware using the ``CorsPolicyBuilder`` class. There are two ways to do this. The first is to call UseCors with a lambda:

.. literalinclude:: cors/sample/src/CorsExample1/Startup.cs
  :language: csharp
  :lines: 15-18, 24
  :dedent: 8

The lambda takes a CorsPolicyBuilder object. I’ll describe all of the configuration options later in this topic. In this example, the policy allows cross-origin requests from "http://example.com" and no other origins.

Note that CorsPolicyBuilder has a fluent API, so you can chain method calls:

.. literalinclude:: cors/sample/src/CorsExample3/Startup.cs
  :language: csharp
  :lines: 21-24
  :dedent: 12
  :emphasize-lines: 3

The second approach is to define one or more named CORS policies, and then select the policy by name at run time.

.. literalinclude:: cors/sample/src/CorsExample2/Startup.cs
  :language: csharp
  :lines: 9-17,19-26,27
  :dedent: 8

This example adds a CORS policy named "AllowSpecificOrigin". To select the policy, pass the name to UseCors.

.. _cors-policy-options:

Enabling CORS in MVC
--------------------

You can alternatively use MVC to apply specific CORS per action, per controller, or globally for all controllers. When using MVC to enable CORS the same CORS services are used, but the CORS middleware is not.

Per action
^^^^^^^^^^

To specify a CORS policy for a specific action add the ``[EnableCors]`` attribute to the action. Specify the policy name.

.. literalinclude:: cors/sample/src/CorsMvc/Controllers/HomeController.cs
    :language: csharp
    :lines: 7-13
    :dedent: 4

Per controller
^^^^^^^^^^^^^^

To specify the CORS policy for a specific controller add the ``[EnableCors]`` attribute to the controller class. Specify the policy name.

.. literalinclude:: cors/sample/src/CorsMvc/Controllers/HomeController.cs
    :language: csharp
    :lines: 6-8
    :dedent: 4

Globally
^^^^^^^^

You can enable CORS globally for all controllers by adding the ``CorsAuthorizationFilterFactory`` filter to the global filter collection:

.. literalinclude:: cors/sample/src/CorsMvc/Startup.cs
    :language: csharp
    :lines: 13-15,26-30
    :dedent: 8

The precedence order is: Action, controller, global. Action-level policies take precedence over controller-level policies, and controller-level policies take precedence over global policies.

Disable CORS
^^^^^^^^^^^^

To disable CORS for a controller or action, use the ``[DisableCors]`` attribute.

.. literalinclude:: cors/sample/src/CorsMvc/Controllers/HomeController.cs
    :language: csharp
    :lines: 15-19
    :dedent: 4

CORS policy options
-------------------

This section describes the various options that you can set in a CORS policy.

- `Set the allowed origins`_
- `Set the allowed HTTP methods`_
- `Set the allowed request headers`_
- `Set the exposed response headers`_
- `Credentials in cross-origin requests`_
- `Set the preflight expiration time`_

For some options it may be helpful to read `How CORS works`_ first.

Set the allowed origins
^^^^^^^^^^^^^^^^^^^^^^^

To allow one or more specific origins:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN01
  :end-before: END01
  :dedent: 16

To allow all origins:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN02
  :end-before: END02
  :dedent: 16

Consider carefully before allowing requests from any origin. It means that literally any website can make AJAX calls to your app.

Set the allowed HTTP methods
^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To specify which HTTP methods are allowed to access the resource.

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN03
  :end-before: END03
  :dedent: 16

To allow all HTTP methods:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN04
  :end-before: END04
  :dedent: 16

This affects pre-flight requests and Access-Control-Allow-Methods header.

Set the allowed request headers
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

A CORS preflight request might include an Access-Control-Request-Headers header, listing the HTTP headers set by the application (the so-called "author request headers").

To whitelist specific headers:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN05
  :end-before: END05
  :dedent: 16

To allow all author request headers:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN06
  :end-before: END06
  :dedent: 16

Browsers are not entirely consistent in how they set Access-Control-Request-Headers. If you set headers to anything other than "*", you should include at least "accept", "content-type", and "origin", plus any custom headers that you want to support.

Set the exposed response headers
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

By default, the browser does not expose all of the response headers to the application. (See http://www.w3.org/TR/cors/#simple-response-header.) The response headers that are available by default are:

- Cache-Control
- Content-Language
- Content-Type
- Expires
- Last-Modified
- Pragma

The CORS spec calls these *simple response headers*. To make other headers available to the application:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN07
  :end-before: END07
  :dedent: 16

Credentials in cross-origin requests
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Credentials require special handling in a CORS request. By default, the browser does not send any credentials with a cross-origin request. Credentials include cookies as well as HTTP authentication schemes. To send credentials with a cross-origin request, the client must set XMLHttpRequest.withCredentials to true.

Using XMLHttpRequest directly:

.. code-block:: js

    var xhr = new XMLHttpRequest();
    xhr.open('get', 'http://www.example.com/api/test');
    xhr.withCredentials = true;

In jQuery:

.. code-block:: js

    $.ajax({
        type: 'get',
        url: 'http://www.example.com/home',
        xhrFields: {
            withCredentials: true
        }

In addition, the server must allow the credentials. To allow cross-origin credentials:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN08
  :end-before: END08
  :dedent: 16

Now the HTTP response will include an Access-Control-Allow-Credentials header, which tells the browser that the server allows credentials for a cross-origin request.

If the browser sends credentials, but the response does not include a valid Access-Control-Allow-Credentials header, the browser will not expose the response to the application, and the AJAX request fails.

Be very careful about allowing cross-origin credentials, because it means a website at another domain can send a logged-in user’s credentials to your app on the user’s behalf, without the user being aware. The CORS spec also states that setting origins to "*" (all origins) is invalid if the Access-Control-Allow-Credentials header is present.

Set the preflight expiration time
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The Access-Control-Max-Age header specifies how long the response to the preflight request can be cached. To set this header:

.. literalinclude:: cors/sample/src/CorsExample4/Startup.cs
  :language: csharp
  :start-after: BEGIN09
  :end-before: END09
  :dedent: 16

.. _cors-how-cors-works:

How CORS works
--------------

This section describes what happens in a CORS request, at the level of the HTTP messages. It’s important to understand how CORS works, so that you can configure the your CORS policy correctly, and troubleshoot if things don’t work as you expect.

The CORS specification introduces several new HTTP headers that enable cross-origin requests. If a browser supports CORS, it sets these headers automatically for cross-origin requests; you don’t need to do anything special in your JavaScript code.

Here is an example of a cross-origin request. The "Origin" header gives the domain of the site that is making the request::

    GET http://myservice.azurewebsites.net/api/test HTTP/1.1
    Referer: http://myclient.azurewebsites.net/
    Accept: */*
    Accept-Language: en-US
    Origin: http://myclient.azurewebsites.net
    Accept-Encoding: gzip, deflate
    User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)
    Host: myservice.azurewebsites.net

If the server allows the request, it sets the Access-Control-Allow-Origin header. The value of this header either matches the Origin header, or is the wildcard value "*", meaning that any origin is allowed.::

    HTTP/1.1 200 OK
    Cache-Control: no-cache
    Pragma: no-cache
    Content-Type: text/plain; charset=utf-8
    Access-Control-Allow-Origin: http://myclient.azurewebsites.net
    Date: Wed, 20 May 2015 06:27:30 GMT
    Content-Length: 12

    Test message

If the response does not include the Access-Control-Allow-Origin header, the AJAX request fails. Specifically, the browser disallows the request. Even if the server returns a successful response, the browser does not make the response available to the client application.

Preflight Requests
^^^^^^^^^^^^^^^^^^

For some CORS requests, the browser sends an additional request, called a "preflight request", before it sends the actual request for the resource.
The browser can skip the preflight request if the following conditions are true:

- The request method is GET, HEAD, or POST, and
- The application does not set any request headers other than Accept, Accept-Language, Content-Language, Content-Type, or Last-Event-ID, and
- The Content-Type header (if set) is one of the following:

  - application/x-www-form-urlencoded
  - multipart/form-data
  - text/plain

The rule about request headers applies to headers that the application sets by calling setRequestHeader on the XMLHttpRequest object. (The CORS specification calls these "author request headers".) The rule does not apply to headers the browser can set, such as User-Agent, Host, or Content-Length.

Here is an example of a preflight request::

    OPTIONS http://myservice.azurewebsites.net/api/test HTTP/1.1
    Accept: */*
    Origin: http://myclient.azurewebsites.net
    Access-Control-Request-Method: PUT
    Access-Control-Request-Headers: accept, x-my-custom-header
    Accept-Encoding: gzip, deflate
    User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)
    Host: myservice.azurewebsites.net
    Content-Length: 0

The pre-flight request uses the HTTP OPTIONS method. It includes two special headers:

- Access-Control-Request-Method: The HTTP method that will be used for the actual request.
- Access-Control-Request-Headers: A list of request headers that the application set on the actual request. (Again, this does not include headers that the browser sets.)

Here is an example response, assuming that the server allows the request::

    HTTP/1.1 200 OK
    Cache-Control: no-cache
    Pragma: no-cache
    Content-Length: 0
    Access-Control-Allow-Origin: http://myclient.azurewebsites.net
    Access-Control-Allow-Headers: x-my-custom-header
    Access-Control-Allow-Methods: PUT
    Date: Wed, 20 May 2015 06:33:22 GMT

The response includes an Access-Control-Allow-Methods header that lists the allowed methods, and optionally an Access-Control-Allow-Headers header, which lists the allowed headers. If the preflight request succeeds, the browser sends the actual request, as described earlier.
