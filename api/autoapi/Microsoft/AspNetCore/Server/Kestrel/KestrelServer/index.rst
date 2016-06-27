

KestrelServer Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.KestrelServer`








Syntax
------

.. code-block:: csharp

    public class KestrelServer : IServer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer.KestrelServer(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions>, Microsoft.AspNetCore.Hosting.IApplicationLifetime, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions<Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions>}
    
        
        :type applicationLifetime: Microsoft.AspNetCore.Hosting.IApplicationLifetime
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public KestrelServer(IOptions<KestrelServerOptions> options, IApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer.Start<TContext>(Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>)
    
        
    
        
        :type application: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1>{TContext}
    
        
        .. code-block:: csharp
    
            public void Start<TContext>(IHttpApplication<TContext> application)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer.Features
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public IFeatureCollection Features { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServer.Options
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        .. code-block:: csharp
    
            public KestrelServerOptions Options { get; }
    

