

WebHost Class
=============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.WebHost`








Syntax
------

.. code-block:: csharp

    public class WebHost : IWebHost, IDisposable








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHost
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHost

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHost.ServerFeatures
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public IFeatureCollection ServerFeatures
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.WebHost.Services
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider Services
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHost
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Internal.WebHost.WebHost(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.AspNetCore.Hosting.Startup.IStartupLoader, Microsoft.AspNetCore.Hosting.Internal.WebHostOptions, Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        :type appServices: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type startupLoader: Microsoft.AspNetCore.Hosting.Startup.IStartupLoader
    
        
        :type options: Microsoft.AspNetCore.Hosting.Internal.WebHostOptions
    
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
            public WebHost(IServiceCollection appServices, IStartupLoader startupLoader, WebHostOptions options, IConfiguration config)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.WebHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.WebHost.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.WebHost.Initialize()
    
        
    
        
        .. code-block:: csharp
    
            public void Initialize()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.WebHost.Start()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Start()
    

