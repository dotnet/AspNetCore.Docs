OWIN
====

By `Steve Smith`_

ASP.NET 5 supports OWIN, the Open Web Interface for .NET, which allows web applications to be decoupled from web servers. In addition, OWIN defines a standard way for middleware to be used in a pipeline to handle individual requests and associated responses. ASP.NET 5 applications and middleware can interoperate with OWIN-based applications and middleware.

In this article:
	- `Running OWIN middleware in the ASP.NET pipeline`_
	- `Using ASP.NET Hosting on an OWIN-based server`_
	- `Using ASP.NET middleware in an OWIN pipeline`_
	- `OWIN keys and ASP.NET OWIN adapters`_

`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/owin/sample>`_.

Running OWIN middleware in the ASP.NET pipeline
-----------------------------------------------

ASP.NET 5's OWIN support is deployed as part of the HttpAbstractions package, in the Microsoft.AspNet.Owin project. You can import OWIN support into your project by adding this package as a dependency in your ``project.json`` file, as shown here:

.. literalinclude:: owin/sample/src/OwinSample/project.json
	:language: javascript
	:lines: 5-10
	:emphasize-lines: 3

OWIN middleware conform to the OWIN specification, which requires certain headers be set. 



Using ASP.NET Hosting on an OWIN-based server
---------------------------------------------

Using ASP.NET middleware in an OWIN pipeline
--------------------------------------------

OWIN keys and ASP.NET OWIN adapters
-----------------------------------

Summary
-------

