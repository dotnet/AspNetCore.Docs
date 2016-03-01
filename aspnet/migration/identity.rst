.. _migration-identity:

Migrating Authentication and Identity From ASP.NET MVC 5 to MVC 6
=================================================================

By `Steve Smith`_

In the previous article we :doc:`migrated configuration from an ASP.NET MVC 5 project to MVC 6 <configuration>`. In this article, we migrate the registration, login, and user management features.

This article covers the following topics:
	- Configure Identity and Membership
	- Migrate Registration and Login Logic
	- Migrate User Management Features

You can download the finished source from the project created in this article HERE **(TODO)**.

Configure Identity and Membership
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

In ASP.NET MVC 5, authentication and identity features are configured in Startup.Auth.cs and IdentityConfig.cs, located in the App_Start folder. In MVC 6, these features are configured in Startup.cs. Before pulling in the required services and configuring them, we should add the required dependencies to the project. Open project.json and add "Microsoft.AspNet.Identity.EntityFramework" and "Microsoft.AspNet.Identity.Cookies" to the list of dependencies:

.. code-block:: json

	"dependencies": {
		"Microsoft.AspNet.Server.IIS": "1.0.0-beta3",
		"Microsoft.AspNet.Mvc": "6.0.0-beta3",
		"Microsoft.Framework.ConfigurationModel.Json": "1.0.0-beta3",
		"Microsoft.AspNet.Identity.EntityFramework": "3.0.0-beta3",
		"Microsoft.AspNet.Security.Cookies": "1.0.0-beta3"
	},

Now, open Startup.cs and update the ConfigureServices() method to use Entity Framework and Identity services:

.. code-block:: c#

	public void ConfigureServices(IServiceCollection services)
	{
		// Add EF services to the services container.
		services.AddEntityFramework(Configuration)
			.AddSqlServer()
			.AddDbContext<ApplicationDbContext>();

		// Add Identity services to the services container.
		services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
			.AddEntityFrameworkStores<ApplicationDbContext>();

		services.AddMvc();
	}

At this point, there are two types referenced in the above code that we haven't yet migrated from the MVC 5 project: ApplicationDbContext and ApplicationUser. Create a new Models folder in the MVC 6 project, and add two classes to it corresponding to these types. You will find the MVC 5 versions of these classes in /Models/IdentityModels.cs, but we will use one file per class in the migrated project since that's more clear.

ApplicationUser.cs:

.. code-block:: c#

	using Microsoft.AspNet.Identity;

	namespace NewMvc6Project.Models
	{
		public class ApplicationUser : IdentityUser
		{
		}
	}

ApplicationDbContext.cs:

.. code-block:: c#

	using Microsoft.AspNet.Identity.EntityFramework;
	using Microsoft.Data.Entity;

	namespace NewMvc6Project.Models
	{
		public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
		{
			private static bool _created = false;
			public ApplicationDbContext()
			{
				// Create the database and schema if it doesn't exist
				// This is a temporary workaround to create database until Entity Framework database migrations 
				// are supported in ASP.NET 5
				if (!_created)
				{
					Database.AsMigrationsEnabled().ApplyMigrations();
					_created = true;
				}
			}

			protected override void OnConfiguring(DbContextOptions options)
			{
				options.UseSqlServer();
			}
		}
	}

The MVC 5 Starter Web project doesn't include much customization of users, or the ApplicationDbContext. When migrating a real application, you will also need to migrate all of the custom properties and methods of your application's user and DbContext classes, as well as any other Model classes your application utilizes (for example, if your DbContext has a DbSet<Album>, you will of course need to migrate the Album class).

With these files in place, the Startup.cs file can be made to compile by updating its using statements:

.. code-block:: c#

	using Microsoft.Framework.ConfigurationModel;
	using Microsoft.AspNet.Hosting;
	using NewMvc6Project.Models;
	using Microsoft.AspNet.Identity;

Our application is now ready to support authentication and identity services - it just needs to have these features exposed to users. 

Migrate Registration and Login Logic
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

With identity services configured for the application and data access configured using Entity Framework and SQL Server, we are now ready to add support for registration and login to the application. Recall that :ref:`earlier in the migration process <migrate-layout-file>` we commented out a reference to _LoginPartial in _Layout.cshtml. Now it's time to return to that code, uncomment it, and add in the necessary controllers and views to support login functionality.

Update _Layout.cshtml; uncomment the @Html.Partial line:

.. code-block:: c#

				<li>@Html.ActionLink("Contact", "Contact", "Home")</li>
			</ul>
			@*@Html.Partial("_LoginPartial")*@
		</div>
	</div>

Now, add a new MVC View Page called _LoginPartial to the Views/Shared folder:

.. image migratingauthmembership/_static/AddLoginPartial.png

Update _LoginPartial.cshtml with the following code (replace all of its contents):

.. code-block:: c#

	@using System.Security.Principal

	@if (User.Identity.IsAuthenticated)
	{
	    using (Html.BeginForm("LogOff", "Account", FormMethod.Post, new { id = "logoutForm", @class = "navbar-right" }))
	    {
	        @Html.AntiForgeryToken()
	        <ul class="nav navbar-nav navbar-right">
	            <li>
	                @Html.ActionLink("Hello " + User.Identity.GetUserName() + "!", "Manage", "Account", routeValues: null, htmlAttributes: new { title = "Manage" })
	            </li>
	            <li><a href="javascript:document.getElementById('logoutForm').submit()">Log off</a></li>
	        </ul>
	    }
	}
	else
	{
	    <ul class="nav navbar-nav navbar-right">
	        <li>@Html.ActionLink("Register", "Register", "Account", routeValues: null, htmlAttributes: new { id = "registerLink" })</li>
	        <li>@Html.ActionLink("Log in", "Login", "Account", routeValues: null, htmlAttributes: new { id = "loginLink" })</li>
	    </ul>
	}

At this point, you should be able to refresh the site in your browser.


	
Summary
^^^^^^^

ASP.NET 5 and MVC 6 introduce changes to the ASP.NET Identity 2 features that shipped with ASP.NET MVC 5. In this article, you have seen how to migrate the authentication and user management features of an ASP.NET MVC 5 project to MVC 6.

