

IWebHostBuilder Interface
=========================






A builder for :any:`Microsoft.AspNetCore.Hosting.IWebHost`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IWebHostBuilder








.. dn:interface:: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.IWebHostBuilder

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.Build()
    
        
    
        
        Builds an :any:`Microsoft.AspNetCore.Hosting.IWebHost` which hosts a web application.
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IWebHost
    
        
        .. code-block:: csharp
    
            IWebHost Build()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.Configure(System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Specify the startup method to be used to configure the web application. 
    
        
    
        
        :param configureApplication: The delegate that configures the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type configureApplication: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            IWebHostBuilder Configure(Action<IApplicationBuilder> configureApplication)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.ConfigureLogging(System.Action<Microsoft.Extensions.Logging.ILoggerFactory>)
    
        
    
        
        Adds a delegate for configuring the provided :any:`Microsoft.Extensions.Logging.ILoggerFactory`\. This may be called multiple times.
    
        
    
        
        :param configureLogging: The delegate that configures the :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type configureLogging: System.Action<System.Action`1>{Microsoft.Extensions.Logging.ILoggerFactory<Microsoft.Extensions.Logging.ILoggerFactory>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            IWebHostBuilder ConfigureLogging(Action<ILoggerFactory> configureLogging)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.ConfigureServices(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
    
        
        Specify the delegate that is used to configure the services of the web application.
    
        
    
        
        :param configureServices: The delegate that configures the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type configureServices: System.Action<System.Action`1>{Microsoft.Extensions.DependencyInjection.IServiceCollection<Microsoft.Extensions.DependencyInjection.IServiceCollection>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.GetSetting(System.String)
    
        
    
        
        Get the setting value from the configuration.
    
        
    
        
        :param key: The key of the setting to look up.
        
        :type key: System.String
        :rtype: System.String
        :return: The value the setting currently contains.
    
        
        .. code-block:: csharp
    
            string GetSetting(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.UseLoggerFactory(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Specify the :any:`Microsoft.Extensions.Logging.ILoggerFactory` to be used by the web host.
    
        
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory` to be used.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            IWebHostBuilder UseLoggerFactory(ILoggerFactory loggerFactory)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.UseSetting(System.String, System.String)
    
        
    
        
        Add or replace a setting in the configuration.
    
        
    
        
        :param key: The key of the setting to add or replace.
        
        :type key: System.String
    
        
        :param value: The value of the setting to add or replace.
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            IWebHostBuilder UseSetting(string key, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHostBuilder.UseStartup(System.Type)
    
        
    
        
        Specify the startup type to be used by the web host. 
    
        
    
        
        :param startupType: The :any:`System.Type` to be used.
        
        :type startupType: System.Type
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            IWebHostBuilder UseStartup(Type startupType)
    

