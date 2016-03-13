Getting Started with ASP.NET 5 and Entity Framework 6
===========================================================

By `Paweł Grudzień <https://github.com/pgrudzien12>`_, `Damien Pontifex <https://github.com/DamienPontifex>`_

This article will show you how to use Entity Framework 6 inside an ASP.NET 5 application.

In this article:
    - `Setup connection strings and dependency injection`_
    - `Migrate configuration from config to code`_
    - `Notes on Migrations`_
    
Prerequisites
-------------
    
Before you start, make sure that you compile against full .NET Framework in your project.json as Entity Framework 6 does not support .NET Core. If you need cross platform features you will need to upgrade to Entity Framework 7.

In your project.json file under frameworks remove any reference to ``dnxcore50`` or ``dotnet5.1``. Valid identifiers for the .NET Framework are listed on the `corefx repo documentation <https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/standard-platform.md#specific-platform-mapping>`_, but for targeting DNX 4.5.1 the frameworks section should be:

.. code-block:: javascript
    
    "frameworks": {
        "dnx451": {}
    }
    
And .NET 4.5.1 in a class library the frameworks section should be

.. code-block:: javascript
    
    "frameworks": {
        "net451": {}
    }

Setup connection strings and dependency injection
-------------------------------------------------

The simplest change is to explicitly get your connection string and setup dependency injection of your ``DbContext`` instance. 

In your ``DbContext`` subclass, ensure you have a constructor which takes the connection string as so:

.. code-block:: c#
    :linenos:
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }

In the ``Startup`` class within ``ConfigureServices`` add factory method of your context with it's connection string. Context should be resolved once per scope to ensure performance and ensure reliable operation of Entity Framework. 

.. code-block:: c#
    :linenos:
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped((_) => new ApplicationDbContext(Configuration["Data:DefaultConnection:ConnectionString"]));
        
        // Configure remaining services
    }

Migrate configuration from config to code
-----------------------------------------

Entity Framework 6 allows configuration to be specified in xml (in web.config or app.config) or through code. As of ASP.NET 5, all configuration is code-based.

Code-based configuration is achieved by creating a subclass of ``System.Data.Entity.Config.DbConfiguration`` and applying ``System.Data.Entity.DbConfigurationTypeAttribute`` to your ``DbContext`` subclass.

Our config file typically looked like this:

.. code-block:: xml
    :linenos:
    
    <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
            <parameters>
                <parameter value="mssqllocaldb" />
            </parameters>
        </defaultConnectionFactory>
        <providers>
            <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
    </entityFramework>

The ``defaultConnectionFactory`` element sets the factory for connections. If this attribute is not set then the default value is ``SqlConnectionProvider``. If, on the other hand, value is provided, the given class will be used to create ``DbConnection`` with its ``CreateConnection`` method. If the given factory has no default constructor then you must add parameters that are used to construct the object.

.. code-block:: c#
    :linenos:

    [DbConfigurationType(typeof(CodeConfig))] // point to the class that inherit from DbConfiguration
    public class ApplicationDbContext : DbContext
    {
        [...]
    }
    
    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
    
SQL Server, SQL Server Express and LocalDB
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

This is the default and so no explicit configuration is needed. The above ``CodeConfig`` class can be used to explicitly set the provider services and the appropriate connection string should be passed to the ``DbContext`` constructor as shown `above <#setup-connection-strings-and-dependency-injection>`_.

Notes on Migrations
-------------------

.. note:: Valid with RC1 (early November 2015)

As noted by `Rowan Miller on GitHub <https://github.com/aspnet/Docs/issues/633#issuecomment-158542498>`_ Migration commands won't work because .xproj does not support loading commands into Package Manager Console (this will change for RTM though).

Summary
-------
Entity Framework 6 is an object relational mapping (ORM) library, that is capable of mapping your classes to database entities with little effort. These features made it very popular so migrating large portions of code may be undesirable for many projects. This article shows how to avoid migration to focus on other new features of ASP.NET.

Additional Resources
--------------------

- `Entity Framework - Code-Based Configuration <https://msdn.microsoft.com/en-us/data/jj680699.aspx>`_
- `BleedingNEdge.com - Entity Framework 6 With ASP.NET 5 <http://bleedingnedge.com/2015/11/01/entity-framework-6-with-asp-net-5/>`_
