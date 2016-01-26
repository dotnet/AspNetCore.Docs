

HostingEngine Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Internal.HostingEngine`








Syntax
------

.. code-block:: csharp

   public class HostingEngine : IHostingEngine





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Internal/HostingEngine.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Internal.HostingEngine

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.HostingEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Internal.HostingEngine.HostingEngine(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.AspNet.Hosting.Startup.IStartupLoader, Microsoft.Extensions.Configuration.IConfiguration, System.Boolean)
    
        
        
        
        :type appServices: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type startupLoader: Microsoft.AspNet.Hosting.Startup.IStartupLoader
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type captureStartupErrors: System.Boolean
    
        
        .. code-block:: csharp
    
           public HostingEngine(IServiceCollection appServices, IStartupLoader startupLoader, IConfiguration config, bool captureStartupErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.HostingEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Internal.HostingEngine.Start()
    
        
        :rtype: Microsoft.AspNet.Hosting.Internal.IApplication
    
        
        .. code-block:: csharp
    
           public virtual IApplication Start()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.HostingEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.Internal.HostingEngine.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider ApplicationServices { get; }
    

