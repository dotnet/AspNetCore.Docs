Migrating From ASP.NET MVC 5 to MVC 6
======================================================
By `Steve Smith`_ | Originally Published: 1 June 2015 

.. _`Steve Smith`: Author_

Migrating from ASP.NET MVC 5 to ASP.NET 5 and MVC 6 requires a few steps to complete, since ASP.NET 5 introduces a number of new concepts. In this article you will learn how to migrate from the ASP.NET MVC 5 Starter Web Project to ASP.NET MVC 6.

This article covers the following topics:
	- Initial project
	- Create the destination solution
	- 

	
You can download the finished source from the project created in this article HERE **(TODO)**.

Initial Project
^^^^^^^^^^^^^^^

For the purposes of this article, we will be starting from the default ASP.NET MVC 5 starter web project, which you can create in Visual Studio 2015 by adding a new web project, and choosing MVC 5.

.. image:: _static/new-project.png

.. image:: _static/new-project-select-mvc-template.png

If you prefer, you can `download the MVC5Project used in this article </_static/mvc5project.zip>`_. **(TODO)**

This sample web project will demonstrate how to migrate an MVC 5 web project that includes controllers, views, and ASP.NET Identity models, as well as startup and configuration logic common to many MVC 5 projects.

Create the Destination Solution
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

We will begin our migration by creating a new, empty ASP.NET 6 solution.

	
Summary
^^^^^^^

ASP.NET 5 introduces a few concepts that didn't exist in previous versions of ASP.NET. Rather than working with web.config, packages.config, and a variety of project properties stored in the .csproj/.vbproj file, developers can now work with specific files and folders devoted to specific purposes. Although at first there is some learning curve, the end result is more secure, works better with source control, and has better separation of concerns than the approach used in previous versions of ASP.NET.

.. include:: /_authors/steve-smith.rst
