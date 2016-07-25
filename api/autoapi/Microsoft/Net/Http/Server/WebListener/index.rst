

WebListener Class
=================






An HTTP server wrapping the Http.Sys APIs that accepts requests.


Namespace
    :dn:ns:`Microsoft.Net.Http.Server`
Assemblies
    * Microsoft.Net.Http.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.WebListener`








Syntax
------

.. code-block:: csharp

    public sealed class WebListener : IDisposable








.. dn:class:: Microsoft.Net.Http.Server.WebListener
    :hidden:

.. dn:class:: Microsoft.Net.Http.Server.WebListener

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Server.WebListener
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Server.WebListener.WebListener()
    
        
    
        
        .. code-block:: csharp
    
            public WebListener()
    
    .. dn:constructor:: Microsoft.Net.Http.Server.WebListener.WebListener(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public WebListener(ILoggerFactory factory)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.WebListener
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.WebListener.AuthenticationManager
    
        
        :rtype: Microsoft.Net.Http.Server.AuthenticationManager
    
        
        .. code-block:: csharp
    
            public AuthenticationManager AuthenticationManager { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.WebListener.BufferResponses
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool BufferResponses { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.WebListener.IsListening
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsListening { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.WebListener.TimeoutManager
    
        
    
        
        Exposes the Http.Sys timeout configurations.  These may also be configured in the registry.
    
        
        :rtype: Microsoft.Net.Http.Server.TimeoutManager
    
        
        .. code-block:: csharp
    
            public TimeoutManager TimeoutManager { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.WebListener.UrlPrefixes
    
        
        :rtype: Microsoft.Net.Http.Server.UrlPrefixCollection
    
        
        .. code-block:: csharp
    
            public UrlPrefixCollection UrlPrefixes { get; }
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.WebListener
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.WebListener.Dispose()
    
        
    
        
        Stop the server and clean up.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.Net.Http.Server.WebListener.GetContextAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.Net.Http.Server.RequestContext<Microsoft.Net.Http.Server.RequestContext>}
    
        
        .. code-block:: csharp
    
            [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposed by callback")]
            public Task<RequestContext> GetContextAsync()
    
    .. dn:method:: Microsoft.Net.Http.Server.WebListener.SetRequestQueueLimit(System.Int64)
    
        
    
        
        Sets the maximum number of requests that will be queued up in Http.Sys.
    
        
    
        
        :type limit: System.Int64
    
        
        .. code-block:: csharp
    
            public void SetRequestQueueLimit(long limit)
    
    .. dn:method:: Microsoft.Net.Http.Server.WebListener.Start()
    
        
    
        
        .. code-block:: csharp
    
            public void Start()
    

