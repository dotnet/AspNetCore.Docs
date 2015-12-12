

WebHostBuilder Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.WebHostBuilder`








Syntax
------

.. code-block:: csharp

   public class WebHostBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/WebHostBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.WebHostBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.WebHostBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.WebHostBuilder.WebHostBuilder()
    
        
    
        
        .. code-block:: csharp
    
           public WebHostBuilder()
    
    .. dn:constructor:: Microsoft.AspNet.Hosting.WebHostBuilder.WebHostBuilder(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
           public WebHostBuilder(IConfiguration config)
    
    .. dn:constructor:: Microsoft.AspNet.Hosting.WebHostBuilder.WebHostBuilder(Microsoft.Extensions.Configuration.IConfiguration, System.Boolean)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type captureStartupErrors: System.Boolean
    
        
        .. code-block:: csharp
    
           public WebHostBuilder(IConfiguration config, bool captureStartupErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.WebHostBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.Build()
    
        
        :rtype: Microsoft.AspNet.Hosting.Internal.IHostingEngine
    
        
        .. code-block:: csharp
    
           public IHostingEngine Build()
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseEnvironment(System.String)
    
        
        
        
        :type environment: System.String
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseEnvironment(string environment)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseServer(Microsoft.AspNet.Hosting.Server.IServerFactory)
    
        
        
        
        :type factory: Microsoft.AspNet.Hosting.Server.IServerFactory
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseServer(IServerFactory factory)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseServer(System.String)
    
        
        
        
        :type assemblyName: System.String
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseServer(string assemblyName)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseServices(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
        
        
        :type configureServices: System.Action{Microsoft.Extensions.DependencyInjection.IServiceCollection}
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseServices(Action<IServiceCollection> configureServices)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseStartup(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseStartup(Action<IApplicationBuilder> configureApp)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseStartup(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Action{Microsoft.Extensions.DependencyInjection.IServiceCollection}
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseStartup(Action<IApplicationBuilder> configureApp, Action<IServiceCollection> configureServices)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseStartup(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Func<Microsoft.Extensions.DependencyInjection.IServiceCollection, System.IServiceProvider>)
    
        
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseStartup(Action<IApplicationBuilder> configureApp, Func<IServiceCollection, IServiceProvider> configureServices)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseStartup(System.String)
    
        
        
        
        :type startupAssemblyName: System.String
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseStartup(string startupAssemblyName)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseStartup(System.Type)
    
        
        
        
        :type startupType: System.Type
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseStartup(Type startupType)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebHostBuilder.UseStartup<TStartup>()
    
        
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public WebHostBuilder UseStartup<TStartup>()where TStartup : class
    

Fields
------

.. dn:class:: Microsoft.AspNet.Hosting.WebHostBuilder
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Hosting.WebHostBuilder.ApplicationKey
    
        
    
        
        .. code-block:: csharp
    
           public const string ApplicationKey
    
    .. dn:field:: Microsoft.AspNet.Hosting.WebHostBuilder.OldApplicationKey
    
        
    
        
        .. code-block:: csharp
    
           public const string OldApplicationKey
    
    .. dn:field:: Microsoft.AspNet.Hosting.WebHostBuilder.OldServerKey
    
        
    
        
        .. code-block:: csharp
    
           public const string OldServerKey
    
    .. dn:field:: Microsoft.AspNet.Hosting.WebHostBuilder.ServerKey
    
        
    
        
        .. code-block:: csharp
    
           public const string ServerKey
    

