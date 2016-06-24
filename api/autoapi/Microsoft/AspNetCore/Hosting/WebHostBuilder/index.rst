

WebHostBuilder Class
====================






A builder for :any:`Microsoft.AspNetCore.Hosting.IWebHost`


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WebHostBuilder`








Syntax
------

.. code-block:: csharp

    public class WebHostBuilder : IWebHostBuilder








.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.WebHostBuilder.WebHostBuilder()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Hosting.WebHostBuilder` class.
    
        
    
        
        .. code-block:: csharp
    
            public WebHostBuilder()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilder.Build()
    
        
    
        
        Builds the required services and an :any:`Microsoft.AspNetCore.Hosting.IWebHost` which hosts a web application.
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IWebHost
    
        
        .. code-block:: csharp
    
            public IWebHost Build()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureLogging(System.Action<Microsoft.Extensions.Logging.ILoggerFactory>)
    
        
    
        
        Adds a delegate for configuring the provided :any:`Microsoft.Extensions.Logging.ILoggerFactory`\. This may be called multiple times.
    
        
    
        
        :param configureLogging: The delegate that configures the :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type configureLogging: System.Action<System.Action`1>{Microsoft.Extensions.Logging.ILoggerFactory<Microsoft.Extensions.Logging.ILoggerFactory>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public IWebHostBuilder ConfigureLogging(Action<ILoggerFactory> configureLogging)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureServices(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
    
        
        Adds a delegate for configuring additional services for the host or web application. This may be called
        multiple times.
    
        
    
        
        :param configureServices: A delegate for configuring the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type configureServices: System.Action<System.Action`1>{Microsoft.Extensions.DependencyInjection.IServiceCollection<Microsoft.Extensions.DependencyInjection.IServiceCollection>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilder.GetSetting(System.String)
    
        
    
        
        Get the setting value from the configuration.
    
        
    
        
        :param key: The key of the setting to look up.
        
        :type key: System.String
        :rtype: System.String
        :return: The value the setting currently contains.
    
        
        .. code-block:: csharp
    
            public string GetSetting(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilder.UseLoggerFactory(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Specify the :any:`Microsoft.Extensions.Logging.ILoggerFactory` to be used by the web host.
    
        
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory` to be used.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public IWebHostBuilder UseLoggerFactory(ILoggerFactory loggerFactory)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilder.UseSetting(System.String, System.String)
    
        
    
        
        Add or replace a setting in the configuration.
    
        
    
        
        :param key: The key of the setting to add or replace.
        
        :type key: System.String
    
        
        :param value: The value of the setting to add or replace.
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public IWebHostBuilder UseSetting(string key, string value)
    

