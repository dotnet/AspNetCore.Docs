Introduction to ASP.NET Identity
================================

By `Pranav Rastogi`_, `Rick Anderson`_, Tom Dykstra, Jon Galloway, and `Erik Reitan`_

ASP.NET Identity is a membership system which allows you to add login functionality to your application. Users can create an account and login with a user name and password or they can use an external login providers such as Facebook, Google, Microsoft Account, Twitter and more.

You can configure ASP.NET Identity to use a SQL Server database to store user names, passwords, and profile data. Alternatively, you can use your own persistent store to store data in another other persistent storage, such as Azure Table Storage.

Overview of ASP.NET Identity in ASP.NET Web App
-----------------------------------------------
 
ASP.NET Identity is used in the Visual Studio project templates for ASP.NET 5. In this topic, you'll learn how the ASP.NET 5 project templates use ASP.NET Identity to add functionality to register, log in, and log out a user.

The purpose of this article is to give you a high level overview of ASP.NET Identity. You can follow it step by step or just read the details. For more detailed instructions about creating apps using ASP.NET Identity, see the Next Steps section at the end of this article.

1.	Create an ASP.NET Web Application with Individual User Accounts. 

	In Visual Studio, select **File** -> **New** -> **Project**. Then, select the **ASP.NET Web Application** from the **New Project** dialog box. Continue by selecting a **Web Application** with **Individual User Accounts**, as the authentication method.

	.. image:: introduction-to-aspnet-identity/_static/01-mvc.png
	
	The created project contains the following ASP.NET Identity package.

	- ``Microsoft.AspNet.Identity.EntityFramework``
		The `Microsoft.AspNet.Identity.EntityFramework <http://www.nuget.org/packages/Microsoft.AspNet.Identity.EntityFramework/>`_ package has the Entity Framework implementation of ASP.NET Identity which will persist the ASP.NET Identity data and schema to SQL Server. 
	
	.. note:: In Visual Studio, you can view NuGet packages details by selecting **Tools** -> **NuGet Package Manager** -> **Manage NuGet Packages for Solution**. You also see a list of packages in the dependencies section of the *project.json* file within your project.

	When the application is started, the ``Startup`` class is instantiated. Within this class, the runtime calls the ``ConfigureServices`` method which adds a number of services to a services container. Included in this services container is the Identity services:
	
	.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Startup.cs
		:language: c#
		:lines: 38-56
		:emphasize-lines: 10-12
		:dedent: 8

	After the ``ConfigureServices`` method is called, the ``Configure`` method is called. In this method, ASP.NET Identity is enabled for the application when the ``UseIdentity`` method is called. This adds cookie-based authentication to the request pipeline. 
	
	.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Startup.cs
		:language: c#
		:lines: 58-89
		:emphasize-lines: 22
		:dedent: 8	
	
	For more information about the request pipeline, see `Understanding ASP.NET 5 Web Apps - Application Startup <http://docs.asp.net/en/latest/conceptual-overview/understanding-aspnet5-apps.html?highlight=request%20pipeline#application-startup>`_. For more information about the application start up process, see `Application Startup <http://docs.asp.net/en/latest/fundamentals/startup.html>`_. 

2.	Creating a user.

	Launch the application from Visual Studio (**Debug** -> **Start Debugging**) and then click on the **Register** link in the browser to create a user. The following image shows the Register page which collects the user name and password.

	.. image:: introduction-to-aspnet-identity/_static/02-reg.png
	
	
	When the user clicks the **Register** link, the ``UserManager`` and ``SignInManager`` services are injected into the Controller:

	.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
		:language: c#
		:lines: 19-43
		:emphasize-lines: 3,4,12,13,19,20

	Then, the **Register** action creates the user by calling ``CreateAsync`` function of the ``UserManager`` object, as shown below:

	.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
		:language: c#
		:lines: 105-132
		:emphasize-lines: 10
		:dedent: 8	
	
3. Log in.

	If the user was successfully created, the user is logged in by the ``SignInAsync`` method, also contained in the ``Register`` action. By signing in, the ``SignInAsync`` method stores a cookie with the user's claims. 

	.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
		:language: c#
		:lines: 105-132
		:emphasize-lines: 19
		:dedent: 8	

	The above ``SignInAsync`` method calls the below ``SignInAsync`` task, which is contained in the ``SignInManager`` class. 
	
	If needed, you can access the user's identity details inside a controller action. For instance, by setting a breakpoint inside the ``HomeController.Index`` action method, you can view the ``User.claims`` details. By having the user signed-in, you can make authorization decisions. For more information, see `Authorization <http://docs.asp.net/en/latest/security/authorization/index.html>`_.
	
	As a registered user, you can log in to the web app by clicking the **Log in** link.  When a registered user logs in, the ``Login`` action of the ``AccountController`` is called. Then, the **Login** action signs in the user using the ``PasswordSignInAsync`` method contained in the ``Login`` action. 

	.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
		:language: c#
		:lines: 57-92
		:emphasize-lines: 12
		:dedent: 8	
	
4. Log off.

	Clicking the **Log off** link calls the ``LogOff`` action in the account controller. 
	 
	.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
		:language: c#
		:lines: 138-143
		:emphasize-lines: 3
		:dedent: 8 
	 
	The code above shows the ``SignInManager.SignOutAsync`` method. The ``SignOutAsync`` method clears the users claims stored in a cookie. 

5. View the database.

	After stopping the application, view the user database from Visual Studio by selecting **View** -> **SQL Server Object Explorer**. Then, expand the following within the **SQL Server Object Explorer**:
	 
	 - (localdb)\MSSQLLocalDB
	 - Databases
	 - aspnet5-<*the name of your application*>
	 - Tables

	Next, right-click the **dbo.AspNetUsers** table and select **View Data** to see the properties of the user you created.

		.. image:: introduction-to-aspnet-identity/_static/04-db.png

Components of ASP.NET Identity
------------------------------

The primary reference assembly for the ASP.NET Identity system is ``Microsoft.AspNet.Identity``. This assembly contains the core set of interfaces for ASP.NET Identity.

 	.. image:: introduction-to-aspnet-identity/_static/05-dependencies.png

These dependencies are needed to use the ASP.NET Identity system in ASP.NET applications:
 
- ``EntityFramework.SqlServer`` - Entity Framework is Microsoft's recommended data access technology for relational databases.
- ``Microsoft.AspNet.Authentication.Cookies`` - Middleware that enables an application to use cookie based authentication, similar to ASP.NET's Forms Authentication. 
- ``Microsoft.AspNet.Cryptography.KeyDerivation`` - ASP.NET 5 utilities for key derivation.
- ``Microsoft.AspNet.Hosting.Abstractions`` - ASP.NET 5 Hosting abstractions. 

Migrating to ASP.NET Identity 3.x
---------------------------------

For additional information and guidance on migrating your existing apps to the ASP.NET Identity 3.x system, see `Migrating from ASP.NET Identity 2.x to 3.x <http://docs.asp.net/en/latest/migration/identity.html>`_. 

Next Steps 
----------

- `Migrating Authentication and Identity From ASP.NET MVC 5 to MVC 6 <http://docs.asp.net/projects/mvc/en/latest/migration/migratingauthmembership.html?highlight=identity>`_
- `Migrating from ASP.NET Identity 2.x to 3.x <http://docs.asp.net/en/latest/migration/identity.html>`_
- `Account Confirmation and Password Recovery with ASP.NET Identity <http://docs.asp.net/en/latest/security/accconfirm.html>`_
- `Two-factor Authentication with SMS Using ASP.NET Identity <http://docs.asp.net/en/latest/security/2fa.html>`_
- `Enabling authentication using external providers <http://docs.asp.net/en/latest/security/sociallogins.html>`_
