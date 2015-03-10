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

Running the Application
^^^^^^^^^^^^^^^^^^^^^^^^^^^

Run the application and after a quick build step, you should see it open in your web browser.

.. image:: _static/400-first-run.png

Click on the About link, and note the text on the page. Now, open the HomeController.cs file in the Controllers folder, and change the ViewBag.Message as follows:

.. code:: c#

	ViewBag.Message = "ASP.NET 5 Rocks!";
	
Save the file and, **without rebuilding the project**, refresh your web browser. You should see the updated text. ASP.NET 5 no longer requires that you manually build your server-side logic before viewing it, making small updates much faster to inspect during development.

.. image:: _static/500-about-page.png


Server-Side vs. Client-Side Behavior
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Modern web applications frequently make use of a combination of server-side and client-side behavior. Over time, ASP.NET has evolved to support more and more client-side behavior, and with ASP.NET 5 it now includes great support for Single Page Applications (SPAs) that shift virtually all of the application logic to the web client, and use the server only to fetch and store data. Your application's approach to where its behavior resides will depend on a variety of factors. The more comfortable your team is with client-side development, the more likely it is that much of your application's behavior will run on the client. If your web site will include a great deal of public content that should be discoverable by search engines, you may wish to ensure the server returns this content directly, rather than having it built up by client-side scripts, since the latter requires `special effort`_ to be indexed by search engines.

.. _`special effort`: http://stackoverflow.com/questions/18530258/how-to-make-a-spa-seo-crawlable

On the server, ASP.NET MVC 6 (part of ASP.NET 5) works similarly to its predecessor, including support for Razor-formatted Views as well as integrated support for Web API.  On the client, there are many options available for managing client application state, binding to UI elements, and communication with APIs. 

Now we can add a bit of behavior to both the server and the client of the default application, to demonstrate how easy it is to get started building your own ASP.NET 5 application.

Adding Server-Side Behavior
^^^^^^^^^^^^^^^^^^^^^^^^^^^

We've already tweaked the behavior of the HomeController's About method to change the Message passed to the View. We can add additional server-side behavior by adding or modifying Controllers and Views and the Models they work with.

Adding Client-Side Behavior
^^^^^^^^^^^^^^^^^^^^^^^^^^^

**(TODO)**

Summary
^^^^^^^

**(TODO)**
	
.. include:: ../_authors/steve-smith.rst
