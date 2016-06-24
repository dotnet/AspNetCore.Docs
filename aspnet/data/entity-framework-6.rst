Getting Started with ASP.NET Core and Entity Framework 6
===========================================================

By `Paweł Grudzień`_ and `Damien Pontifex`_

This article will show you how to use Entity Framework 6 inside an ASP.NET Core application.

.. contents:: Sections:
  :local:
  :depth: 1
    
Prerequisites
-------------
    
Before you start, make sure that you compile against full .NET Framework in your project.json as Entity Framework 6 does not support .NET Core. If you need cross platform features you will need to upgrade to `Entity Framework Core`_.

In your project.json file specify a single target for the full .NET Framework:

.. code-block:: none
    
    "frameworks": {
        "net46": {}
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
        services.AddScoped(() => new ApplicationDbContext(Configuration["Data:DefaultConnection:ConnectionString"]));
        
        // Configure remaining services
    }

Migrate configuration from config to code
-----------------------------------------

Entity Framework 6 allows configuration to be specified in xml (in web.config or app.config) or through code. As of ASP.NET Core, all configuration is code-based.

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

Summary
-------
Entity Framework 6 is an object relational mapping (ORM) library, that is capable of mapping your classes to database entities with little effort. These features made it very popular so migrating large portions of code may be undesirable for many projects. This article shows how to avoid migration to focus on other new features of ASP.NET.

Additional Resources
--------------------

- `Entity Framework - Code-Based Configuration <https://msdn.microsoft.com/en-us/data/jj680699.aspx>`_

