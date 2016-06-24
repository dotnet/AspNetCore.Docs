

IWebHost Interface
==================






Represents a configured web host.


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

    public interface IWebHost : IDisposable








.. dn:interface:: Microsoft.AspNetCore.Hosting.IWebHost
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.IWebHost

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IWebHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IWebHost.ServerFeatures
    
        
    
        
        The :any:`Microsoft.AspNetCore.Http.Features.IFeatureCollection` exposed by the configured server.
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            IFeatureCollection ServerFeatures { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IWebHost.Services
    
        
    
        
        The :any:`System.IServiceProvider` for the host.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            IServiceProvider Services { get; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IWebHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IWebHost.Start()
    
        
    
        
        Starts listening on the configured addresses.
    
        
    
        
        .. code-block:: csharp
    
            void Start()
    

