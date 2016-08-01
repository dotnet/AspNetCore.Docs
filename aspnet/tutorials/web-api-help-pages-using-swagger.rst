.. _web-api-help-pages-using-swagger:

ASP.NET Web API Help Pages using Swagger
========================================

By `Shayne Boyer`_

Understanding the various methods of an API can be a challenge for a developer when building a consuming application. 

Generating good documentation and help pages as a part of your Web API using `Swagger <a href="http://swagger.io/">`_ with the .NET Core implementation `Swashbuckle <a href="https://github.com/domaindrivendev/Ahoy">`_ is as easy as adding a couple of nuget packages and modifying the Startup.cs.

This tutorial builds on the sample in :doc:`first-web-api`. 

.. contents:: Sections:
  :local:
  :depth: 1

Getting Started
---------------
There are 2 core components to Swashbuckle 

* Swashbuckle.SwaggerGen - provides the functionality to scaffold your Web API and generate JSON Swagger documents that describe the objects, methods, return types, etc. 
* Swashbuckle.SwaggerUI - an embedded version of the Swagger UI tool which uses the above documents for a rich customizable experience for describing the Web API functionality. This also includes built in test harness capabilities for the public methods.

Basic Example
-------------

Test
'''''


