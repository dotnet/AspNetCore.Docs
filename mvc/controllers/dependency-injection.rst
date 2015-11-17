Dependency Injection and Controllers
====================================

By `Steve Smith`_

ASP.NET MVC 6 controllers should request their dependencies explicitly via their constructors. In some cases, though, it may be preferable to populate dependencies using property injection, which is also supported.

In this article:
	- `Dependency Injection`_
	- `Constructor Injection`_
	- `Property Injection`_
	
`View or download sample from GitHub <https://github.com/aspnet/Docs/tree/1.0.0-beta8/mvc/controllers/dependency-injection/sample>`_.

Dependency Injection
--------------------
Dependency injection is a technique that follows the `Dependency Inversion Principle <http://deviq.com/dependency-inversion-principle>`_, allowing for applications to be composed of loosely coupled modules. ASP.NET 5 has built-in support for `dependency injection (learn more) <https://docs.asp.net/en/latest/fundamentals/dependency-injection.html>`_, and expects applications built for ASP.NET 5 to implement this technique (rather than static access or direct instantiation).

Constructor Injection
---------------------
ASP.NET 5's built-in support for constructor-based dependency injection extends to ASP.NET MVC 6 controllers. By simply adding a service type to your controller as a constructor parameter, ASP.NET will attempt to resolve that type using its built in service container.

Property Injection
------------------