Understand the Fundamental Concepts of Web Programming
======================================================
By `Steve Smith`_ | Originally Published: 1 June 2015 

.. _`Steve Smith`: Author_

ASP.NET 5 introduces several new fundamental concepts of web programming that are important to understand in order to productively create web applications. These concepts are not necessarily new to web programming in general, but are new to ASP.NET and thus are likely new to many developers whose experience with web programming has mainly been using ASP.NET and Visual Studio.

This article covers the following topics:
	- ASP.NET Project Structure
	- Framework Target
	- The project.json File
	- The global.json File
	- The wwwroot folder
	- Resolving Client-Side Dependencies
	- Resolving Server-Side Dependencies
	- Configuring the Application
	- Application Startup
	
You can download the finished source from the project created in this article HERE **(TODO)**.

ASP.NET Project Structure
^^^^^^^^^^^^^^^^^^^^^^^^^

**(TODO)**

Framework Target
^^^^^^^^^^^^^^^^

**(TODO)**

The project.json File
^^^^^^^^^^^^^^^^^^^^^

**(TODO)**

The global.json File
^^^^^^^^^^^^^^^^^^^^

**(TODO)**

The wwwroot Folder
^^^^^^^^^^^^^^^^^^

In previous versions of ASP.NET, the root of the project was also the root of the website, typically. If you placed a Default.aspx file in the project root of an early version of ASP.NET, it would load if a request was made to the web application’s root. In later versions of ASP.NET, support for routing was added (first to MVC, and later to all ASP.NET applications), making it possible to easily decouple the locations of files from their corresponding URLs (thus, HomeController in the Controllers folder is able to serve requests made to the root of the site, using a default route implementation). However, this routing typically was used only for ASP.NET-specific application logic, not static files needed by the client to properly render the resulting page. Resources like images, script files, and stylesheets were generally still loaded based on their location within the file structure of the application, based off of the root of the project.

.. image:: _static/400-wwwroot.png

This approach presented some problems. First, protecting sensitive project files required framework-level protection of certain filenames or extensions, to prevent having things like web.config or global.asax served to a client in response to a request. Having to specifically block access to certain files is much less secure than granting access only to those files which should be accessible. It was also frequently the case that different versions of files would be needed during development than when deployed to the server. Client scripts would typically be referenced individually and in a readable format during development, but would be minified and potentially bundled together when deployed to the server. In some cases it would be desirable not to deploy original sources of such files, but handling these kinds of scenarios was difficult with everything in a single folder.

Enter the *wwwroot* folder in ASP.NET 5. The wwwroot folder represents the actual root of the web application when running on a web server. Static files, like config.json, which are not located in wwwroot will never be accessible, and there is no need to create special rules to block access to sensitive files. Instead of blacklisting access to sensitive files, a more secure whitelist approach is taken whereby only those files that placed in the wwwroot folder are accessible via web requests made to the application.

In addition to the security benefits, the wwwroot folder also simplifies common tasks like bundling and minification, which can now be more easily incorporated into a standard build process and automated using tools like Grunt.

Client Side Dependency Management
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The Dependencies folder contains two subfolders: Bower and NPM. These folders correspond to two package managers by the same names, and they’re used to pull in client-side dependencies and tools (e.g. jQuery, bootstrap, or grunt). Expanding the folders reveals which dependencies are currently managed by each tool, and the current version being used by the project.

.. image:: _static/501-dependencies.png

The bower dependencies are controlled by the bower.json file. You’ll notice that each of the items listed in the figure above correspond to dependencies listed in bower.json:

.. image:: _static/600-bower-json.png

Each dependency is then further configured in its own section within the bower.json file, indicating how it should be deployed to the wwwroot folder when the bower task is executed.

By default, the bower task is executed using grunt, which is configured in gruntfile.js. The current web template’s gruntfile simply configures bower and npm:

.. image:: _static/700-gruntfile.png

(**(TODO)**: Show bower_components and node_modules folders in file system)

Server Side Dependency Management
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The References folder details the server-side references for the project. It should be familiar to ASP.NET developers who have worked with previous versions of ASP.NET, but it has been modified to differentiate between references for different framework targets, such as the full ASP.NET 5.0 vs. ASP.NET Core 5.0.  Within each framework target, you will find individual references, with icons indicating whether the reference is to an assembly, a NuGet package, or a project. Note that these dependencies are typically checked at compile time, with missing dependencies downloaded from the configured NuGet package source (specified under Options – NuGet Package Manager – Package Sources).	

.. image:: _static/801-references.png

Configuring the Application
^^^^^^^^^^^^^^^^^^^^^^^^^^^

**(TODO)** 

Application Startup
^^^^^^^^^^^^^^^^^^^

**(TODO)**

Summary
^^^^^^^

**(TODO)**

.. include:: ../_authors/steve-smith.rst
