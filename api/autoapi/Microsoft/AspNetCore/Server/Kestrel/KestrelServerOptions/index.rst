

KestrelServerOptions Class
==========================






Provides programmatic configuration of Kestrel-specific features.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions`








Syntax
------

.. code-block:: csharp

    public class KestrelServerOptions








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.AddServerHeader
    
        
    
        
        Gets or sets whether the <code>Server</code> header should be included in each response.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AddServerHeader { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ApplicationServices
    
        
    
        
        Enables the UseKestrel options callback to resolve and use services registered by the application during startup.
        Typically initialized by :dn:meth:`Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel(Microsoft.AspNetCore.Hosting.IWebHostBuilder,System.Action{Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions})`\.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ConnectionFilter
    
        
    
        
        Gets or sets an :any:`Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter` that allows each connection :any:`System.IO.Stream`
        to be intercepted and transformed.
        Configured by the <code>UseHttps()</code> and :dn:meth:`Microsoft.AspNetCore.Hosting.KestrelServerOptionsConnectionLoggingExtensions.UseConnectionLogging(Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions)`
        extension methods.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
            public IConnectionFilter ConnectionFilter { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.MaxRequestBufferSize
    
        
    
        
        Maximum size of the request buffer.
        If value is null, the size of the request buffer is unlimited.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public long ? MaxRequestBufferSize { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.NoDelay
    
        
    
        
        Set to false to enable Nagle's algorithm for all connections.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NoDelay { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ShutdownTimeout
    
        
    
        
        The amount of time after the server begins shutting down before connections will be forcefully closed.
        Kestrel will wait for the duration of the timeout for any ongoing request processing to complete before
        terminating the connection. No new connections or requests will be accepted during this time.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan ShutdownTimeout { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ThreadCount
    
        
    
        
        The number of libuv I/O threads used to process requests.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ThreadCount { get; set; }
    

