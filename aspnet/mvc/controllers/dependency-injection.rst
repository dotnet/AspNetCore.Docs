:version: 1.0.0-rc1

.. _dependency-injection-controllers:

Dependency Injection and Controllers
====================================

By `Steve Smith`_

ASP.NET Core MVC controllers should request their dependencies explicitly via their constructors. In some instances, individual controller actions may require a service, and it may not make sense to request at the controller level. In this case, you can also choose to inject a service as a parameter on the action method.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/mvc/controllers/dependency-injection/sample>`__

Dependency Injection
--------------------

Dependency injection is a technique that follows the `Dependency Inversion Principle <http://deviq.com/dependency-inversion-principle>`_, allowing for applications to be composed of loosely coupled modules. ASP.NET Core has built-in support for :doc:`dependency injection </fundamentals/dependency-injection>`, which makes applications easier to test and maintain.

Constructor Injection
---------------------

ASP.NET Core's built-in support for constructor-based dependency injection extends to MVC controllers. By simply adding a service type to your controller as a constructor parameter, ASP.NET will attempt to resolve that type using its built in service container. Services are typically, but not always, defined using interfaces. For example, if your application has business logic that depends on the current time, you can inject a service that retrieves the time (rather than hard-coding it), which would allow your tests to pass in implementations that use a set time.

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

If we run the application now, we will most likely encounter an error::

  An unhandled exception occurred while processing the request.

  InvalidOperationException: Unable to resolve service for type 'ControllerDI.Interfaces.IDateTime' while attempting to activate 'ControllerDI.Controllers.HomeController'.
  Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, Boolean isDefaultParameterRequired)

This error occurs when we have not configured a service in the ``ConfigureServices`` method in our ``Startup`` class. To specify that requests for ``IDateTime`` should be resolved using an instance of ``SystemDateTime``, add the highlighted line in the listing below to your ``ConfigureServices`` method:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Startup.cs
  :linenos:
  :language: c#
  :emphasize-lines: 6
  :lines: 29-30,43-47
  :dedent: 8
  
.. note:: This particular service could be implemented using any of several different lifetime options (``Transient``, ``Scoped``, or ``Singleton``). See :doc:`/fundamentals/dependency-injection` to understand how each of these scope options will affect the behavior of your service.

Once the service has been configured, running the application and navigating to the home page should display the time-based message as expected:

.. image:: dependency-injection/_static/server-greeting.png

.. tip:: See `Unit Testing <https://docs.microsoft.com/en-us/dotnet/articles/core/testing/unit-testing-with-dotnet-test>`_ to learn how to explicitly request dependencies <http://deviq.com/explicit-dependencies-principle>`_ in controllers makes code easier to test.

ASP.NET Core's built-in dependency injection supports having only a single constructor for classes requesting services. If you have more than one constructor, you may get an exception stating::

  An unhandled exception occurred while processing the request.

  InvalidOperationException: Multiple constructors accepting all given argument types have been found in type 'ControllerDI.Controllers.HomeController'. There should only be one applicable constructor.
  Microsoft.Extensions.DependencyInjection.ActivatorUtilities.FindApplicableConstructor(Type instanceType, Type[] argumentTypes, ConstructorInfo& matchingConstructor, Nullable`1[]& parameterMap)

As the error message states, you can correct this problem having just a single constructor. You can also :ref:`replace the default dependency injection support with a third party implementation <replacing-the-default-services-container>`, many of which support multiple constructors.

Action Injection with FromServices
----------------------------------

Sometimes you don't need a service for more than one action within your controller. In this case, it may make sense to inject the service as a parameter to the action method. This is done by marking the parameter with the attribute ``[FromServices]`` as shown here:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Controllers/HomeController.cs
  :linenos:
  :language: c#
  :emphasize-lines: 1
  :lines: 33-38
  :dedent: 8
  
Accessing Settings from a Controller
------------------------------------

Accessing application or configuration settings from within a controller is a common pattern. This access should use the Options pattern described in :doc:`configuration </fundamentals/configuration>`. You generally should not request settings directly from your controller using dependency injection. A better approach is to request an ``IOptions<T>`` instance, where ``T`` is the configuration class you need.

To work with the options pattern, you need to create a class that represents the options, such as this one:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Model/SampleWebSettings.cs
  :linenos:
  :language: c#

Then you need to configure the application to use the options model and add your configuration class to the services collection in ``ConfigureServices``:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Startup.cs
  :linenos:
  :language: c#
  :emphasize-lines: 3-5,8,15,18
  :lines: 18-47
  :dedent: 8
  
.. note:: In the above listing, we are configuring the application to read the settings from a JSON-formatted file. You can also configure the settings entirely in code, as is shown in the commented code above. See :doc:`/fundamentals/configuration` for further configuration options.

Once you've specified a strongly-typed configuration object (in this case, ``SampleWebSettings``) and added it to the services collection, you can request it from any Controller or Action method by requesting an instance of ``IOptions<T>`` (in this case, ``IOptions<SampleWebSettings>``). The following code shows how one would request the settings from a controller:

.. literalinclude:: dependency-injection/sample/src/ControllerDI/Controllers/SettingsController.cs
  :linenos:
  :language: c#
  :emphasize-lines: 3,5,7
  :lines: 7-22

Following the Options pattern allows settings and configuration to be decoupled from one another, and ensures the controller is following `separation of concerns <http://deviq.com/separation-of-concerns/>`_, since it doesn't need to know how or where to find the settings information. It also makes the controller easier to `unit test <https://docs.microsoft.com/en-us/dotnet/articles/core/testing/unit-testing-with-dotnet-test>`_, since there is no `static cling <http://deviq.com/static-cling/>`_ or direct instantiation of settings classes within the controller class.
