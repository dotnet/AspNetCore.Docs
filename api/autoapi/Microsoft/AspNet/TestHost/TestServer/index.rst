

TestServer Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.TestHost.TestServer`








Syntax
------

.. code-block:: csharp

   public class TestServer : IServerFactory, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.TestHost/TestServer.cs>`_





.. dn:class:: Microsoft.AspNet.TestHost.TestServer

Constructors
------------

.. dn:class:: Microsoft.AspNet.TestHost.TestServer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.TestHost.TestServer.TestServer(Microsoft.AspNet.Hosting.WebHostBuilder)
    
        
        
        
        :type builder: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public TestServer(WebHostBuilder builder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.TestHost.TestServer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Create()
    
        
        :rtype: Microsoft.AspNet.TestHost.TestServer
    
        
        .. code-block:: csharp
    
           public static TestServer Create()
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Create(Microsoft.Extensions.Configuration.IConfiguration, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Action{Microsoft.Extensions.DependencyInjection.IServiceCollection}
        :rtype: Microsoft.AspNet.TestHost.TestServer
    
        
        .. code-block:: csharp
    
           public static TestServer Create(IConfiguration config, Action<IApplicationBuilder> configureApp, Action<IServiceCollection> configureServices)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Create(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        :rtype: Microsoft.AspNet.TestHost.TestServer
    
        
        .. code-block:: csharp
    
           public static TestServer Create(Action<IApplicationBuilder> configureApp)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Create(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Action{Microsoft.Extensions.DependencyInjection.IServiceCollection}
        :rtype: Microsoft.AspNet.TestHost.TestServer
    
        
        .. code-block:: csharp
    
           public static TestServer Create(Action<IApplicationBuilder> configureApp, Action<IServiceCollection> configureServices)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Create(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Func<Microsoft.Extensions.DependencyInjection.IServiceCollection, System.IServiceProvider>)
    
        
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
        :rtype: Microsoft.AspNet.TestHost.TestServer
    
        
        .. code-block:: csharp
    
           public static TestServer Create(Action<IApplicationBuilder> configureApp, Func<IServiceCollection, IServiceProvider> configureServices)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Create(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Func<Microsoft.Extensions.DependencyInjection.IServiceCollection, System.IServiceProvider>, System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
        
        
        :type configureHostServices: System.Action{Microsoft.Extensions.DependencyInjection.IServiceCollection}
        :rtype: Microsoft.AspNet.TestHost.TestServer
    
        
        .. code-block:: csharp
    
           public static TestServer Create(Action<IApplicationBuilder> configureApp, Func<IServiceCollection, IServiceProvider> configureServices, Action<IServiceCollection> configureHostServices)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateBuilder()
    
        
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public static WebHostBuilder CreateBuilder()
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateBuilder(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public static WebHostBuilder CreateBuilder(IConfiguration config)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateBuilder(Microsoft.Extensions.Configuration.IConfiguration, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Action{Microsoft.Extensions.DependencyInjection.IServiceCollection}
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public static WebHostBuilder CreateBuilder(IConfiguration config, Action<IApplicationBuilder> configureApp, Action<IServiceCollection> configureServices)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateBuilder(Microsoft.Extensions.Configuration.IConfiguration, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Func<Microsoft.Extensions.DependencyInjection.IServiceCollection, System.IServiceProvider>)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public static WebHostBuilder CreateBuilder(IConfiguration config, Action<IApplicationBuilder> configureApp, Func<IServiceCollection, IServiceProvider> configureServices)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateBuilder(Microsoft.Extensions.Configuration.IConfiguration, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Func<Microsoft.Extensions.DependencyInjection.IServiceCollection, System.IServiceProvider>, System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type configureApp: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
        
        
        :type configureHostServices: System.Action{Microsoft.Extensions.DependencyInjection.IServiceCollection}
        :rtype: Microsoft.AspNet.Hosting.WebHostBuilder
    
        
        .. code-block:: csharp
    
           public static WebHostBuilder CreateBuilder(IConfiguration config, Action<IApplicationBuilder> configureApp, Func<IServiceCollection, IServiceProvider> configureServices, Action<IServiceCollection> configureHostServices)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateClient()
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
           public HttpClient CreateClient()
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateHandler()
    
        
        :rtype: System.Net.Http.HttpMessageHandler
    
        
        .. code-block:: csharp
    
           public HttpMessageHandler CreateHandler()
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateRequest(System.String)
    
        
    
        Begins constructing a request message for submission.
    
        
        
        
        :type path: System.String
        :rtype: Microsoft.AspNet.TestHost.RequestBuilder
        :return: <see cref="T:Microsoft.AspNet.TestHost.RequestBuilder" /> to use in constructing additional request details.
    
        
        .. code-block:: csharp
    
           public RequestBuilder CreateRequest(string path)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.CreateWebSocketClient()
    
        
        :rtype: Microsoft.AspNet.TestHost.WebSocketClient
    
        
        .. code-block:: csharp
    
           public WebSocketClient CreateWebSocketClient()
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Initialize(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public IFeatureCollection Initialize(IConfiguration configuration)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Invoke(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type featureCollection: Microsoft.AspNet.Http.Features.IFeatureCollection
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(IFeatureCollection featureCollection)
    
    .. dn:method:: Microsoft.AspNet.TestHost.TestServer.Start(Microsoft.AspNet.Http.Features.IFeatureCollection, System.Func<Microsoft.AspNet.Http.Features.IFeatureCollection, System.Threading.Tasks.Task>)
    
        
        
        
        :type serverInformation: Microsoft.AspNet.Http.Features.IFeatureCollection
        
        
        :type application: System.Func{Microsoft.AspNet.Http.Features.IFeatureCollection,System.Threading.Tasks.Task}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable Start(IFeatureCollection serverInformation, Func<IFeatureCollection, Task> application)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.TestHost.TestServer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.TestHost.TestServer.BaseAddress
    
        
        :rtype: System.Uri
    
        
        .. code-block:: csharp
    
           public Uri BaseAddress { get; set; }
    

