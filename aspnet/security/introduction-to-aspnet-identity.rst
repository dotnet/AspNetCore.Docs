Introduction to ASP.NET Identity
================================

By `Pranav Rastogi <http://www.asp.net/identity/overview/getting-started/introduction-to-aspnet-identity#author-37788>`_, `Rick Anderson <http://www.asp.net/identity/overview/getting-started/introduction-to-aspnet-identity#author-20106>`_, `Tom Dykstra <http://www.asp.net/identity/overview/getting-started/introduction-to-aspnet-identity#author-36250>`_ and `Jon Galloway <http://www.asp.net/identity/overview/getting-started/introduction-to-aspnet-identity#author-5506f>`_

The ASP.NET membership system was introduced with ASP.NET 2.0 back in 2005, and since then there have been many changes in the ways web applications typically handle authentication and authorization. ASP.NET Identity is a membership system that is used for building modern applications for the web, phone, or tablet.

Getting started with ASP.NET Identity
-------------------------------------
 
ASP.NET Identity is used in the Visual Studio project templates for ASP.NET `MVC <http://www.asp.net/mvc>`_, `Web Forms <http://www.asp.net/web-forms>`_, `Web API <http://www.asp.net/web-api>`_ and `SPA <http://www.asp.net/single-page-application>`_. In this walkthrough, we'll illustrate how the ASP.NET 5 project templates use ASP.NET Identity to add functionality to register, log in and log out a user. 

The purpose of this article is to give you a high level overview of ASP.NET Identity; you can follow it step by step or just read the details. For more detailed instructions about creating apps using ASP.NET Identity, see the Next Steps section at the end of this article.

1. Create an ASP.NET MVC application with Individual Accounts. You can use ASP.NET Identity in an ASP.NET MVC application, as well as other ASP.NET frameworks, such as Web Forms, Web API, SignalR, etc. In this article, you will start with an ASP.NET MVC application. In Visual Studio, select **File** -> **New** -> **Project**. Then, select the **ASP.NET Web Appication** from the **New Project** dialog box. Continue by selecting a **Web Appication** with **Individual User Accounts** as the authenication method.

	.. image:: introduction-to-aspnet-identity/_static/01-mvc.png
	
2. The created project contains the following ASP.NET Identity package.

- ``Microsoft.AspNet.Identity.EntityFramework``
 The `Microsoft.AspNet.Identity.EntityFramework <http://www.nuget.org/packages/Microsoft.AspNet.Identity.EntityFramework/>`_ package has the Entity Framework implementation of ASP.NET Identity which will persist the ASP.NET Identity data and schema to SQL Server. 

.. note:: In Visual Studio, you can view NuGet packages details by selecting **Tools** -> **NuGet Package Manager** -> **Manage NuGet Packages for Solution**.
 
3. Creating a user.

 Launch the application from Visual Studio (**Debug** -> **Start Debugging**) and then click on the **Register** link in the browser to create a user. The following image shows the *Register* page which collects the user name and password.

	.. image:: introduction-to-aspnet-identity/_static/02-reg.png

When the user clicks the **Register** button, the ``Register`` action of the ``AccountController`` creates the user by calling ``CreateAsync`` function of the ``UserManager`` object, as shown below:

.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
	:language: c#
	:lines: 101-127
	:emphasize-lines: 4,10
	:dedent: 8
	
4. Log in.
 If the user was successfully created, they are logged in by the ``SignInAsync`` method, also contained in the ``Register`` action.
	
.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
	:language: c#
	:lines: 101-127
	:emphasize-lines: 19
	:dedent: 8

The above ``SignInAsync`` method calls the below ``SignInAsync`` task, which is contained in the ``SignInManager`` class. The ``SignInAsync`` method is overloaded. The ``authenticationProperties`` parameter that can be added to the call. This parameter is a dictionary used to store state values about the authentication session. These values are applied to the login and authentication cookie. 

5. Log off.
 Clicking the **Log off** link calls the ``LogOff`` action in the account controller. 
 
.. literalinclude:: introduction-to-aspnet-identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
	:language: c#
	:lines: 131-138
	:emphasize-lines: 5
	:dedent: 8 
 
The code above shows the ``SignInManager.SignOut`` method. This is analogous to `FormsAuthentication.SignOut <http://msdn.microsoft.com/en-us/library/system.web.security.formsauthentication.signout.aspx>`_ method used by the `FormsAuthentication <http://msdn.microsoft.com/en-us/library/system.web.security.formsauthenticationmodule.aspx>`_ module in Web Forms.

6. View the database.
 After stopping the application, view the user database from Visual Studio by selecting **View** -> **SQL Server Object Explorer**. Then, expand the following within the **SQL Server Object Explorer**:
 
 - (localdb)\MSSQLLocalDB
 - Databases
 - aspnet5-<*the name of your application*>
 - Tables

 Next, right-click the **dbo.AspNetUsers** table and select **View Data** to see the properties of the user you created.

	.. image:: introduction-to-aspnet-identity/_static/04-db.png

Components of ASP.NET Identity
------------------------------

The diagram below shows the components of the ASP.NET Identity system (click on `this <http://i1.asp.net/media/4459023/1.png?cdn_id=2015-08-15-002>`_ or on the diagram to enlarge it). The packages in green make up the ASP.NET Identity system. All the other packages are dependencies which are needed to use the ASP.NET Identity system in ASP.NET applications.  
 
	.. image:: introduction-to-aspnet-identity/_static/03-1Small.png
 
The following is a brief description of the NuGet packages not mentioned previously:

- ``Microsoft.AspNet.Authentication.Cookies``
 Middleware that enables an application to use cookie based authentication, similar to ASP.NET's Forms Authentication.
- ``EntityFramework``
 Entity Framework is Microsoft's recommended data access technology for relational databases.

Migrating to ASP.NET Identity 3.x
---------------------------------------------

For additional information and guidance on migrating your existing apps to the ASP.NET Identity 3.x system, see `Migrating from ASP.NET Identity 2.x to 3.x <http://docs.asp.net/en/latest/migration/identity.html>`_. 

Next Steps 
----------

- `Migrating Authentication and Identity From ASP.NET MVC 5 to MVC 6 <http://docs.asp.net/projects/mvc/en/latest/migration/migratingauthmembership.html?highlight=identity>`_
- `Migrating from ASP.NET Identity 2.x to 3.x <http://docs.asp.net/en/latest/migration/identity.html>`_
- `Account Confirmation and Password Recovery with ASP.NET Identity <http://docs.asp.net/en/latest/security/accconfirm.html>`_
- `Two-factor Authentication with SMS Using ASP.NET Identity <http://docs.asp.net/en/latest/security/2fa.html>`_
- `Enabling authentication using external providers <http://docs.asp.net/en/latest/security/sociallogins.html>`_
