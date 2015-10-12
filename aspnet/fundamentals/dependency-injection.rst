Dependency Injection
====================
By `Steve Smith`_

ASP.NET 5 is designed from the ground up to support and leverage dependency injection. ASP.NET 5 applications can leverage built-in framework services by having them injected into methods in the Startup class, and application services can be configured for injection as well. If desired, developers can replace the built-in services container with a custom or third party implementation.

In this article:
	- `What is Dependency Injection?`_
	- `Using Framework-Provided Services`_
	- `Registering Your Own Services`_
	- `Service Lifetimes and Registration Options`_
	- `Request Services and Application Services`_
	- `Designing Your Services For Dependency Injection`_
	- `Replacing the default services container`_
	- `Recommendations`_

`Download sample from GitHub <https://github.com/aspnet/docs/aspnet/fundamentals/dependency-injection/_static/sample>`_. 

What is Dependency Injection?
-----------------------------

Dependency injection (DI) is a technique for achieving loose coupling between objects and their collaborators, or dependencies. Rather than directly instantiating collaborators, or using static references, the objects a class needs in order to perform its actions are provided to the class in some fashion. Most often, classes will declare their dependencies via their constructor, allowing them to follow the `Explicit Dependencies Principle <http://deviq.com/explicit-dependencies-principle/>`_. This approach is known as "constructor injection". Alternately, dependencies can be provided via properties ("property injection") or even as parameters on methods ("parameter injection"), though this is much less common.

When classes are designed with DI in mind, they are more loosely coupled because they do not have direct, hard-coded dependencies on their collaborators. This follows the `Dependency Inversion Principle <http://deviq.com/dependency-inversion-principle/>`_, which states that *"high level modules should not depend on low level modules; both should depend on abstractions."* Instead of referencing specific implementations, classes request abstractions (typically ``interfaces``) which are provided to them when they are constructed. Extracting dependencies into interfaces and providing implementations of these interfaces as parameters is also an example of the `Strategy design pattern <http://deviq.com/strategy-design-pattern/>`_.

When a system is designed to use DI, with many classes requesting their dependencies via their constructor (or properties), it's helpful to have a class dedicated to creating these classes with their associated dependencies. These classes are referred to as *containers*, or more specifically, `Inversion of Control (IoC) <https://en.wikipedia.org/wiki/Inversion_of_control>`_ containers or Dependency Injection (DI) containers. A container is essentially a factory that is responsible for providing instances of types that are requested from it. If a given type has declared that it has dependencies, and the container has been configured to provide the dependency types, it will create the dependencies as part of creating the requested instance. In this way, complex dependency graphs can be provided to classes without the need for any hard-coded object construction. In addition to creating objects with their dependencies, containers typically manage object lifetimes within the application.

ASP.NET 5 includes a simple built-in container (represented by the IServiceProvider interface) that supports constructor and property injection by default, and ASP.NET makes certain services available through DI. ASP.NET's container refers to the types it manages as *services*. Throughout the rest of this article, *services* will refer to types that are managed by ASP.NET 5's IoC container. You configure the built-in container's services int he ``ConfigureServices`` method in your application's ``Startup`` class.

.. note:: Martin Fowler has written an extensive article on `Inversion of Control Containers and the Dependency Injection Pattern <http://www.martinfowler.com/articles/injection.html>`_. Microsoft Patterns and Practices also has a great description of `Dependency Injection <https://msdn.microsoft.com/en-us/library/dn178469(v=pandp.30).aspx>`_.

Using Framework-Provided Services
---------------------------------

ASP.NET 5 provides certain application services during your application's startup. You can request any of these services by simply including the appropriate interface as a parameter on your ``Startup`` class's constructor or one of its ``Configure`` or ``ConfigureServices`` methods. These services include:

IApplicationBuilder (`source <https://github.com/aspnet/HttpAbstractions/blob/1.0.0-beta7/src/Microsoft.AspNet.Http.Abstractions/IApplicationBuilder.cs>`_)
	Used to build the application request pipeline. Available only to the ``Configure`` method in ``Startup``. Learn more about :doc:`request-features`.
	
IApplicationEnvironment (`source <https://github.com/aspnet/dnx/blob/1.0.0-beta7/src/Microsoft.Dnx.Runtime.Abstractions/IApplicationEnvironment.cs>`_)
	Provides access to the application properties, such as ``ApplicationName``, ``ApplicationVersion``, and ``ApplicationBasePath``. Available to the ``Startup`` constructor and ``Configure`` method.
	
IHostingEnvironment (`source <https://github.com/aspnet/Hosting/blob/1.0.0-beta7/src/Microsoft.AspNet.Hosting.Abstractions/IHostingEnvironment.cs>`_)
	Provides the current ``EnvironmentName``, ``WebRootPath``, and web root file provider. Available to the ``Startup`` constructor and ``Configure`` method. Learn more about :doc:`hosting`.
	
ILoggerFactory (`source <https://github.com/aspnet/Logging/blob/1.0.0-beta7/src/Microsoft.Framework.Logging.Abstractions/ILoggerFactory.cs>`_)
	Provides a mechanism for creating loggers. Available to the ``Startup`` constructor and ``Configure`` method. Learn more about :doc:`logging`.
	
IServiceCollection (`source <https://github.com/aspnet/DependencyInjection/blob/1.0.0-beta7/src/Microsoft.Framework.DependencyInjection.Abstractions/IServiceCollection.cs>`_)
	The current set of services configured in the container. Available only to the ``ConfigureServices`` method, and used by that method to configure the services available to an application.

Looking at each method in the ``Startup`` class in the order in which they are called, the following services may be requested as parameters:

Startup Constructor
	- ``IApplicationEnvironment``
	- ``IHostingEnvironment``
	- ``ILoggerFactory``
	
ConfigureServices
	- ``IServiceCollection``

Configure
	- ``IApplicationBuilder``
	- ``IApplicationEnvironment``
	- ``IHostingEnvironment``
	- ``ILoggerFactory``
	

.. note:: Although ``ILoggerFactory`` is available in the constructor, it is typically configured in the ``Configure`` method. Learn more about the ``Startup`` class constructor and ``Configure`` method in :doc:`startup`.

The ``ConfigureServices`` method is responsible for defining the services the application will use, including platform features like Entity Framework and ASP.NET MVC. Initially, the ``IServiceCollection`` provided to ``ConfigureServices`` has just a handful of services defined. The default web template shows an example of how to add additional services to the container using a number of extensions methods like ``AddEntityFramework``, ``Configure<Options>``, and ``AddMvc``.

.. literalinclude:: ../../common/samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 45-84
	:dedent: 8
	:emphasize-lines: 5,11,18,24

In order to keep the ``ConfigureServices`` method manageable, it is recommended that :doc:`middleware` and :doc:`request-features` authors provide extension methods and fluent configuration APIs that work with ``IServiceCollection``. The built-in features for Entity Framework, Identity, and ASP.NET MVC all follow this approach and can be used as models for providing a very succinct way to add a great deal of functionality to an ASP.NET application.

Of course, in addition to configuring the application to take advantage of various framework features, you can also use ``ConfigureServices`` to configure your own application services.

Registering Your Own Services
-----------------------------

In the default web template example above, two application services are added to the ``IServiceCollection`` (``IEmailSender`` and ``ISmsSender``). The ``AddTransient`` method is used to map abstract types to concrete services that are instantiated separately for every object that requires it. This is known as the service's *lifetime*, and additional lifetime options are described below. It is important to choose an appropriate lifetime for each of the services you register. Should a new instance of the service be provided to each class that requests it? Should once instance be used throughout a given web request? Or should a single instance be used for the lifetime of the application?

In the sample for this article, there is a simple controller that displays character names, called ``CharacterController``. Its ``Index`` method displays the current list of characters that have been stored in the application, and initializes the collection with a handful of characters if none exist. Note that although this application uses Entity Framework and the ``ApplicationDbContext`` class for its persistence, none of that is apparent in the controller. Instead, the specific data access mechanism has been abstracted behind an interface, ``ICharacterRepository``, which follows the `repository pattern <http://deviq.com/repository-pattern/>`_. An instance of ``ICharacterRepository`` is requested via the constructor and assigned to a private field, which is then used to access characters as necessary.

.. literalinclude:: dependency-injection/sample/src/DependencyInjectionSample/Controllers/CharactersController.cs
	:language: c#
	:linenos:
	:lines: 1-32
	:emphasize-lines: 9,11,13,19,22-26

The `ICharacterRepository` simply defines the two methods the controller needs to work with `Character` instances.

.. literalinclude:: dependency-injection/sample/src/DependencyInjectionSample/Models/ICharacterRepository.cs
	:language: c#
	:linenos:

This interface is in turn implemented by a concrete type, ``CharacterRepository``, that is used at runtime.

.. literalinclude:: dependency-injection/sample/src/DependencyInjectionSample/Models/CharacterRepository.cs
	:language: c#
	:linenos:

Note that ``CharacterRepository`` requests an ``ApplicationDbContext`` in its constructor. It is not unusual for dependency injection to be used in a chained fashion like this, with each requested dependency in turn requesting its own dependencies. The container is responsible for resolving all of the dependencies in the tree and returning the fully resolved object graph.

In this case, both ``ICharacterRepository`` and in turn ``ApplicationDbContext`` must be registered with the services container in ``ConfigureServices`` in ``Startup``. ``ApplicationDbContext`` is configured via the call to the extension method ``AddEntityFramework`` which includes an extenstion for adding a ``DbContext`` (``AddDbContext<T>``). Registration of the repository is done at the bottom end of ``ConfigureServices``:

.. literalinclude:: dependency-injection/sample/src/DependencyInjectionSample/Startup.cs
	:language: c#
	:lines: 48-54, 82-86
	:linenos:
	:dedent: 8
	:emphasize-lines: 6, 11

Entity Framework contexts should be added to the services container using the ``Scoped`` lifetime. This is taken care of automatically if you use the helper methods as shown above. Repositories that will make use of Entity Framework should use the same lifetime.

Service Lifetimes and Registration Options
------------------------------------------

ASP.NET services can be configured with the following lifetimes:

Transient
	Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless service.

Scoped
	Scoped lifetime services are created once per request.

Singleton
	Singleton lifetime services are created the first time they are requested, and then every subsequent request will use the same instance. If your application requires singleton behavior, this is recommended in place of implementing the singleton design pattern in your class yourself.

Instance
	You can choose to add an instance directly to the services container. If you do so, this instance will be used for all subsequent requests (this technique will create a Singleton-scoped instance).

Services can be registered with the container in several ways. We have already seen how to register a service implementation with a given type by specifying the concrete type to use. In addition, a factory can be specified, which will then be used to create the instance on demand. The third approach is to directly specify the instance of the type to use, in which case the container will never attempt to create an instance.



Request Services and Application Services
-----------------------------------------

Request Services are what you use by default; everything is available here.
Application Services are just the things that are available on startup. Think services that are outside the scope of one request, e.g. IHostingEnvironment, ILoggerFactory.
Anything scoped is not available in AS, only RS.
Developers can look for things in RS, but it's better to use DI for testability. You may need to use the Service Locator pattern sometimes, but it should be the exception not the rule.
AS and RS are both properties of HttpContext. You shouldn't generally reference them directly, but be aware that RS is what is used to satisfy your DI requests.

Designing Your Services For Dependency Injection
------------------------------------------------


What about things like DbContext?
http://stackoverflow.com/questions/30111920/how-do-i-access-the-iapplicationenvironment-from-a-unit-test


Replacing the default services container
----------------------------------------

Example: https://github.com/aspnet/Mvc/blob/dev/samples/MvcSample.Web/Startup.cs
Autofaq?
Ninject?
StructureMap?

Recommendations
---------------

What should go in DI?
  Things with complex dependencies
  
What shouldn't?
  Data and data holders; configuration
  Example: user's shopping cart
  

For configuration, use the Options system. Options are created from the configuration. You should bind to Options rather than Configuration. Options are nicer to work with than Configuration as far as testability. You can sort of look at the data that comes from Configuration as the defaults, but then programmatically you can change the options (e.g. at startup).  Refer to Configuration article.

- The Data Holder pattern. We put something in DI that is a holder for data. HttpContextAccessor. We only use that where necessary. We do that because we are implementing a framework; most business applications shouldn't need this. If people have code that uses HttpContext.Current, they should elevate the parameter they need from Current, and use DI for everything else.
- Avoid static access to services
- Avoid static access to httpcontext
	- This is usually done in a Static Method
	- This might be code that is being ported
	
Antipatterns:
* Static access to services
* Static access to HttpContext
DI is an alternative to static/global access patterns!

Summary
-------

Middleware provide simple components for adding features to individual web requests. Applications configure their request pipelines in accordance with the features they need to support, and thus have fine-grained control over the functionality each request uses. Developers can easily create their own middleware to provide additional functionality to ASP.NET applications.

Additional Resources
--------------------

- :doc:`startup`
- :doc:`request-features`
