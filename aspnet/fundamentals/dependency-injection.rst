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

Some stuff here
What is the difference between DI and IOC?
What is a container?
Mention Dependency Inversion Principle, Strategy Design Pattern, Explicit Dependencies Principle

Using Framework-Provided Services
---------------------------------

When is the framework making things available via DI?
How do you interact with these services?
Template projects will have DI in it already, such as ILoggerFactory
What can I get?
IHostingEnvironment
ILoggerFactory
IApplicationEnvironment
What about things like DbContext?

Registering Your Own Services
-----------------------------

Show an example of registering your own services using a Repository pattern

Inside ConfigureServices, there is a list of service descriptors. At the end of your code in that method, that is the list that will be available to your application via DI.

Service Lifetimes and Registration Options
------------------------------------------

* Transient
* Scoped
* Singleton
* Instance which is also singleton

Talk about registration
* by Type
* by Factory
* by Instance (Singleton)

Request Services and Application Services
-----------------------------------------

Request Services are what you use by default; everything is available here.
Application Services are just the things that are available on startup. Think services that are outside the scope of one request, e.g. IHostingEnvironment, ILoggerFactory.
Anything scoped is not available in AS, only RS.
Developers can look for things in RS, but it's better to use DI for testability. You may need to use the Service Locator pattern sometimes, but it should be the exception not the rule.
AS and RS are both properties of HttpContext. You shouldn't generally reference them directly, but be aware that RS is what is used to satisfy your DI requests.

Designing Your Services For Dependency Injection
------------------------------------------------

Request Ser

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
