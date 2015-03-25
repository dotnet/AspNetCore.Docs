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

We will begin our migration by creating a new, empty ASP.NET 6 solution. Create a new project in Visual Studio 2015, choose an ASP.NET Web Application, and then choose select the ASP.NET 5 Empty template.

.. image:: _static/new-project-mvc6.png

.. image:: _static/new-project-select-empty-aspnet5-template.png

This migration will start from an empty template. If you're already familiar with ASP.NET 6 and its starter templates and there are features in a starter template you would like to take advantage of, you may wish to start from another template. The next step is to configure the site to use MVC. This requires changes to the project.json file and startup.cs file. First, open project.json and add "Microsoft.AspNet.Mvc" to the "dependencies" property:

.. code-block:: c#

	"dependencies": {
		"Microsoft.AspNet.Server.IIS": "1.0.0-beta3",
		"Microsoft.AspNet.Mvc": "6.0.0-beta3"
	},

Now open Startup.cs and modify it as follows:

.. code-block:: c#

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc();
	}

	public void Configure(IApplicationBuilder app)
	{
		app.UseMvc(routes =>
		{
			routes.MapRoute(
				name: "default",
				template: "{controller}/{action}/{id?}",
				defaults: new { controller = "Home", action = "Index" });
		});
	}

At this point we are ready to create a simple Controller and View. Add a Controllers folder and a Views folder to the project. Add an MVC Controller called HomeController.cs class to the Controllers folder and a Home folder in the Views folder. Finally, add an Index.cshtml MVC View Page to the Views/Home folder. The project structure should be as shown:

.. image:: _static/project-structure-controller-view.png

Modify Index.cshtml to show a welcome message:

.. code-block:: html

	<h1>Hello world!</h1>

Run the application - you should see Hello World output in your browser.

.. image:: _static/hello-world.png




Summary
^^^^^^^

ASP.NET 5 introduces a few concepts that didn't exist in previous versions of ASP.NET. Rather than working with web.config, packages.config, and a variety of project properties stored in the .csproj/.vbproj file, developers can now work with specific files and folders devoted to specific purposes. Although at first there is some learning curve, the end result is more secure, works better with source control, and has better separation of concerns than the approach used in previous versions of ASP.NET.

.. include:: /_authors/steve-smith.rst
