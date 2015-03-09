Your First ASP.NET 5 Application Using Visual Studio
====================================================
By `Steve Smith`_ | Originally Published: 1 June 2015 

.. _`Steve Smith`: Author_

ASP.NET 5 provides a host of improvements over its predecessors, including improved performance, better support for modern web development standards and tools, and improved integration between WebAPI, MVC, and WebForms.  In addition, you can easily develop ASP.NET 5 applications using a variety of tools and editors, but Visual Studio continues to provide a very productive way to build web applications.  In this article, we'll walk through creating your first ASP.NET 5 web application using Visual Studio 2015.

**(TODO)** Move most of the project structure topics to the fundamentalconcepts.rst article

This article covers the following topics:
	- Create a new ASP.NET 5 Project
	- Running the Application
	- Server-Side vs. Client Side Behavior
	- Adding Server-Side Dynamic Content
	- Adding Client-Side Dynamic Content
	
You can download the finished source from the project created in this article HERE **(TODO)**.

Create a New ASP.NET 5 Project
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To get started, open Visual Studio 2015. Next, create a New Project (from the Start Page, or via File - New - Project).  On the left part of the New Project window, make sure the Visual C# templates are open and "Web" is selected, as shown:

.. image:: _static/100-new-project.png

On the right, choose ASP.NET Web Application. Make sure the framework specified at the top of the window is .NET Framework 4.6. Enter a name and confirm where you would like the project to be created, and click OK.

Next you should see another dialog, the New ASP.NET Project window:
 
.. image:: _static/200-select-template.png
	
Select the ASP.NET 5 Starter Web template from the set of ASP.NET 5 templates. These are distinct from the ASP.NET 4.6 templates, which can be used to create ASP.NET projects using the previous version of ASP.NET. Note that you can choose to configure hosting in Microsoft Azure directly from this dialog by checking the box on the right **(ED: confirm this is available at RTM)**. After selecting ASP.NET 5 Starter Web, click OK.

At this point, the project is created. It may take a few moments to load, and you may notice Visual Studio's status bar indicates that Visual Studio id downloading some resources as part of this process.  Visual Studio ensures some required files are pulled into the project when a solution is opened (or a new project is created), and other files may be pulled in at compile time.  Your project, once fully loaded, should look like this:

.. image:: _static/300-visual-studio-on-project-load.png

Looking at the Solution Explorer and comparing the elements with what we're familiar with in previous versions of ASP.NET, a few things stick out as being new and different. There's now a *wwwroot* folder, with its own icon. Similarly, there's a *Dependencies* folder **and** still a *References* folder – we'll discuss the differences between these two in a moment. Finally, there's a Compiler folder that isn't something we've seen in prior versions of ASP.NET. Rounding out the list of folders, we have Controllers, Models, and Views, which make sense for an ASP.NET MVC project, and Migrations, which holds classes used by Entity Framework to track updates to our model's database schema.

Looking at the files in the root of the project, we may notice the absence of a few files. Global.asax is no longer present, nor is web.config, both mainstays from the start of ASP.NET. Instead, we find a Startup.cs file and a config.json file.  Adding to this mix are bower.json, gruntfile.js, package.json, and project.json (the Project_Readme.html file you can see in the browser tab). Clearly the success of Javascript in web development has had an effect on how ASP.NET 5 projects are configured and compiled, and deployed, with JavaScript Object Notation (JSON) files replacing XML for configuration purposes.

While we're at it, you may not notice it from the Solution Explorer, but if you open Windows Explorer you'll see that there is no longer a .csproj file, either. Instead you'll find a .kproj file, an MSBuild file that serves the same purpose from a build process perspective, but which is much simpler than its csproj/vbproj predecessor.

Let's address each of these new parts of the ASP.NET project one by one.

Running the Application
^^^^^^^^^^^^^^^^^^^^^^^^^^^

**(TODO)** 

Server-Side vs. Client-Side Behavior
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

**(TODO)**

Adding Server-Side Behavior
^^^^^^^^^^^^^^^^^^^^^^^^^^^

**(TODO)**

Adding Client-Side Behavior
^^^^^^^^^^^^^^^^^^^^^^^^^^^

**(TODO)**

Summary
^^^^^^^

**(TODO)**
	
Playing Around With Code Formatting Section
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. code-block:: c#
	
	using System;
	using System.Web;
	// just kidding, we aren't going to use System.Web!
	public class Foo
	{
		public void Bar()
		{
			var x = new String();
			
			x = x.ToLower();
		}
	}
	
That's it for that code block. What if we want to now show some HTML markup?

.. code-block:: html
	
	<html>
	<head><title>Title</title></head>
	<body>
		<div class="container"></div>
	</body>
	</html>

The above should be highlighted as HTML.

.. include:: ../_authors/steve-smith.rst
