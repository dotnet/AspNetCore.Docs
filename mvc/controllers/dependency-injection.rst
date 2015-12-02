Dependency Injection and Controllers
====================================

By `Steve Smith`_

ASP.NET MVC 6 controllers should request their dependencies explicitly via their constructors. In some cases, though, it may be preferable to populate dependencies using property injection, which is also supported (for controllers).

In this article:
	- `Dependency Injection`_
	- `Constructor Injection`_
	- `Action Injection with FromServices`_

`View or download sample from GitHub <https://github.com/aspnet/Docs/tree/1.0.0-rc1/mvc/controllers/dependency-injection/sample>`_.

Dependency Injection
--------------------
Dependency injection is a technique that follows the `Dependency Inversion Principle <http://deviq.com/dependency-inversion-principle>`_, allowing for applications to be composed of loosely coupled modules. ASP.NET 5, which ASP.NET MVC 6 is built on, has built-in support for `dependency injection (learn more) <http://docs.asp.net/en/latest/fundamentals/dependency-injection.html>`_, and expects applications built for ASP.NET 5 to implement this technique (rather than static access or direct instantiation).

.. tip:: It's important that you have a good understanding of how ASP.NET 5 implements Dependency Injection (DI). If you haven't already done so, please read `dependency injection  <http://docs.asp.net/en/latest/fundamentals/dependency-injection.html>`_ in `ASP.NET 5 Fundamentals <http://docs.asp.net/en/latest/fundamentals/index.html>`_.

Constructor Injection
---------------------
ASP.NET 5's built-in support for constructor-based dependency injection extends to ASP.NET MVC 6 controllers. By simply adding a service type to your controller as a constructor parameter, ASP.NET will attempt to resolve that type using its built in service container. Services are typically, but not always, defined using interfaces. For example, if your application has business logic that depends on the current time, you can inject a service that retrieves the time (rather than hard-coding it), which would allow your tests to pass in implementations that use a set time.

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Interfaces/IDateTime.cs
  :linenos:
  :language: c#

Implementing an interface like this one so that it uses the system clock at runtime is trivial:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Services/SystemDateTime.cs
  :linenos:
  :language: c#

With this in place, we can use the service in our controller. In this case, we have added some logic to the ``HomeController`` ``Index`` method to display a greeting to the user based on the time of day.

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Controllers/HomeController.cs
  :linenos:
  :language: c#
  :emphasize-lines: 8,10,12,17-30
  :lines: 1-31,51-52

If we run the application now, we will most likely encounter an error:

	An unhandled exception occurred while processing the request.

	InvalidOperationException: Unable to resolve service for type 'ControllerDI.Interfaces.IDateTime' while attempting to activate 'ControllerDI.Controllers.HomeController'.
	Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, Boolean isDefaultParameterRequired)

This error occurs when we have not configured a service in the ``ConfigureServices`` method in our ``Startup`` class. To specify that requests for ``IDateTime`` should be resolved using an instance of ``SystemDateTime``, add the following line to ``ConfigureServices``:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Startup.cs
  :linenos:
  :language: c#
  :emphasize-lines: 18
  :lines: 40-58
  :dedent: 8
  
.. note:: This particular service could be implemented using any of several different lifetime options (``Transient``, ``Scoped``, ``Singleton``, or a single instance). Be sure you understand how each of these scope options will affect the behavior of your service. `Learn more <http://docs.asp.net/en/latest/fundamentals/dependency-injection.html>`_.

Once the service has been configured, running the application and navigating to the home page should display the time-based message as expected:

.. image:: dependency-injection/_static/server-greeting.png

.. tip:: To see how `explicitly requesting dependencies <http://deviq.com/explicit-dependencies-principle>`_ in controllers makes code easier to test, learn more about `unit testing <https://docs.asp.net/en/latest/testing/unit-testing.html>`_ ASP.NET 5 applications.

ASP.NET 5's built-in dependency injection supports having only a single constructor for classes requesting services. If you have more than one constructor, you may get an exception stating:

	An unhandled exception occurred while processing the request.

	InvalidOperationException: Multiple constructors accepting all given argument types have been found in type 'ControllerDI.Controllers.HomeController'. There should only be one applicable constructor.
	Microsoft.Extensions.DependencyInjection.ActivatorUtilities.FindApplicableConstructor(Type instanceType, Type[] argumentTypes, ConstructorInfo& matchingConstructor, Nullable`1[]& parameterMap)

As the error message states, you can correct this problem having just a single constructor. You can also `replace the default dependency injection support with a third party implementation <https://docs.asp.net/en/latest/fundamentals/dependency-injection.html#replacing-the-default-services-container>`_, many of which support multiple constructors.

Action Injection with FromServices
----------------------------------
Sometimes you don't need a service for more than one action within your controller. In this case, it may make sense to inject the service as a parameter to the action method. This is done by marking the parameter with the attribute ``[FromServices]`` as shown here:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Controllers/HomeController.cs
  :linenos:
  :language: c#
  :emphasize-lines: 1
  :lines: 33-38
  :dedent: 8
  

