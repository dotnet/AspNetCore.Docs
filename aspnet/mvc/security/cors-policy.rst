.. _cors-policy:

Specifying a CORS Policy
========================

By `Mike Wasson`_

Browser security prevents a web page from making AJAX requests to another domain. This restriction is called the *same-origin policy*, and prevents a malicious site from reading sensitive data from another site. However, sometimes you might want to let other sites make cross-origin requests to your web app.

`Cross Origin Resource Sharing <http://www.w3.org/TR/cors/>`_ is a W3C standard that allows a server to relax the same-origin policy. Using CORS, a server can explicitly allow some cross-origin requests while rejecting others. This topic shows how to enable CORS in your ASP.NET MVC 6 application. (For background on CORS, see :ref:`aspnet:cors-how-cors-works`.)


Add the CORS package
--------------------

In your project.json file, add the following:

.. literalinclude:: cors-policy/sample/project.json
    :language: json
    :lines: 5,11,12
    :emphasize-lines: 2


Configure CORS
--------------

To configure CORS, call ``AddCors`` in the ``ConfigureServices`` method of your ``Startup`` class, as shown here:

.. literalinclude:: cors-policy/sample/Startup.cs
    :language: csharp
    :lines: 13-24,30
    :dedent: 8

This example defines a CORS policy named "AllowSpecificOrigin" that allows cross-origin requests from "http://example.com" and no other origins. The lambda takes a ``CorsPolicyBuilder`` object. To learn more about the various CORS policy settings, see :ref:`aspnet:cors-policy-options`.

Apply CORS Policies
-------------------

The next step is to apply the policies. You can apply a CORS policy per action, per controller, or globally for all controllers in your application.

Per action
^^^^^^^^^^

Add the ``[EnableCors]`` attribute to the action. Specify the policy name.

.. literalinclude:: cors-policy/sample/Controllers/HomeController.cs
    :language: csharp
    :lines: 7-13
    :dedent: 4

Per controller
^^^^^^^^^^^^^^

Add the ``[EnableCors]`` attribute to the controller class. Specify the policy name.

.. literalinclude:: cors-policy/sample/Controllers/HomeController.cs
    :language: csharp
    :lines: 6-8
    :dedent: 4

Globally
^^^^^^^^

Add the ``CorsAuthorizationFilterFactory`` filter to the global filter collection:

.. literalinclude:: cors-policy/sample/Startup.cs
    :language: csharp
    :lines: 13-15,26-30
    :dedent: 8

The precedence order is: Action, controller, global. Action-level policies take precedence over controller-level policies, and controller-level policies take precedence over global policies.

Disable CORS
^^^^^^^^^^^^

To disable CORS for a controller or action, use the ``[DisableCors]`` attribute.

.. literalinclude:: cors-policy/sample/Controllers/HomeController.cs
    :language: csharp
    :lines: 15-19
    :dedent: 4
