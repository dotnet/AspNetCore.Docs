Introduction to Identity
========================

By `Pranav Rastogi`_, `Rick Anderson`_, Tom Dykstra, Jon Galloway and `Erik Reitan`_

ASP.NET Core Identity is a membership system which allows you to add login functionality to your application. Users can create an account and login with a user name and password or they can use an external login providers such as Facebook, Google, Microsoft Account, Twitter and more.

You can configure ASP.NET Core Identity to use a SQL Server database to store user names, passwords, and profile data. Alternatively, you can use your own persistent store to store data in another other persistent storage, such as Azure Table Storage.

Overview of Identity
--------------------
 
In this topic, you'll learn how to use ASP.NET Core Identity to add functionality to register, log in, and log out a user. You can follow along step by step or just read the details. For more detailed instructions about creating apps using ASP.NET Core Identity, see the Next Steps section at the end of this article.

1. Create an ASP.NET Core Web Application project in Visual Studio with Individual User Accounts. 

  In Visual Studio, select **File** -> **New** -> **Project**. Then, select the **ASP.NET Web Application** from the **New Project** dialog box. Continue by selecting an ASP.NET Core **Web Application** with **Individual User Accounts** as the authentication method.

  .. image:: identity/_static/01-mvc.png

  The created project contains the ``Microsoft.AspNetCore.Identity.EntityFramework`` package, which will persist the identity data and schema to SQL Server using `Entity Framework Core`_.

  .. note:: In Visual Studio, you can view NuGet packages details by selecting **Tools** -> **NuGet Package Manager** -> **Manage NuGet Packages for Solution**. You also see a list of packages in the dependencies section of the *project.json* file within your project.

  The identity services are added to the application in the ``ConfigureServices`` method in the ``Startup`` class:

  .. literalinclude:: identity/sample/src/ASPNET-IdentityDemo/Startup.cs
    :language: c#
    :lines: 38-56
    :emphasize-lines: 10-12
    :dedent: 8

  These services are then made available to the application through :doc:`dependency injection </fundamentals/dependency-injection>`.

  Identity is enabled for the application by calling  ``UseIdentity`` in the ``Configure`` method of the ``Startup`` class. This adds cookie-based authentication to the request pipeline. 

  .. literalinclude:: identity/sample/src/ASPNET-IdentityDemo/Startup.cs
    :language: c#
    :lines: 58-89
    :emphasize-lines: 22
    :dedent: 8

  For more information about the application start up process, see :doc:`/fundamentals/startup`.

2. Creating a user.

  Launch the application from Visual Studio (**Debug** -> **Start Debugging**) and then click on the **Register** link in the browser to create a user. The following image shows the Register page which collects the user name and password.

  .. image:: identity/_static/02-reg.png

  When the user clicks the **Register** link, the ``UserManager`` and ``SignInManager`` services are injected into the Controller:

  .. literalinclude:: identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
    :language: c#
    :lines: 19-43
    :emphasize-lines: 3,4,12,13,19,20

  Then, the **Register** action creates the user by calling ``CreateAsync`` function of the ``UserManager`` object, as shown below:

  .. literalinclude:: identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
    :language: c#
    :lines: 105-132
    :emphasize-lines: 10
    :dedent: 8

3. Log in.

  If the user was successfully created, the user is logged in by the ``SignInAsync`` method, also contained in the ``Register`` action. By signing in, the ``SignInAsync`` method stores a cookie with the user's claims. 

  .. literalinclude:: identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
    :language: c#
    :lines: 105-132
    :emphasize-lines: 19
    :dedent: 8

  The above ``SignInAsync`` method calls the below ``SignInAsync`` task, which is contained in the ``SignInManager`` class. 

  If needed, you can access the user's identity details inside a controller action. For instance, by setting a breakpoint inside the ``HomeController.Index`` action method, you can view the ``User.claims`` details. By having the user signed-in, you can make authorization decisions. For more information, see :doc:`/security/authorization/index`.

  As a registered user, you can log in to the web app by clicking the **Log in** link.  When a registered user logs in, the ``Login`` action of the ``AccountController`` is called. Then, the **Login** action signs in the user using the ``PasswordSignInAsync`` method contained in the ``Login`` action. 

  .. literalinclude:: identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
    :language: c#
    :lines: 57-92
    :emphasize-lines: 12
    :dedent: 8

4. Log off.

  Clicking the **Log off** link calls the ``LogOff`` action in the account controller. 
 
  .. literalinclude:: identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs
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

  .. image:: identity/_static/04-db.png

Identity Components
-------------------

The primary reference assembly for the identity system is ``Microsoft.AspNetCore.Identity``. This package contains the core set of interfaces for ASP.NET Core Identity.

.. image:: identity/_static/05-dependencies.png

These dependencies are needed to use the identity system in ASP.NET Core applications:
 
- ``EntityFramework.SqlServer`` - Entity Framework is Microsoft's recommended data access technology for relational databases.
- ``Microsoft.AspNetCore.Authentication.Cookies`` - Middleware that enables an application to use cookie based authentication, similar to ASP.NET's Forms Authentication. 
- ``Microsoft.AspNetCore.Cryptography.KeyDerivation`` - Utilities for key derivation.
- ``Microsoft.AspNetCore.Hosting.Abstractions`` - Hosting abstractions. 

Migrating to ASP.NET Core Identity
----------------------------------

For additional information and guidance on migrating your existing identity store see :doc:`/migration/identity`

Next Steps 
----------

- :ref:`migration-identity`
- :ref:`security-authentication-account-confirmation`
- :ref:`security-authentication-2fa`
- :ref:`security-authentication-social-logins`
