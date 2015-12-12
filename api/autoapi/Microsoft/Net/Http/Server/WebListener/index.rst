

WebListener Class
=================



.. contents:: 
   :local:



Summary
-------

An HTTP server wrapping the Http.Sys APIs that accepts requests.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.WebListener`








Syntax
------

.. code-block:: csharp

   public sealed class WebListener : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/weblistener/blob/master/src/Microsoft.Net.Http.Server/WebListener.cs>`_





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
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.Net.Http.Server.RequestContext}
    
        
        .. code-block:: csharp
    
           public Task<RequestContext> GetContextAsync()
    
    .. dn:method:: Microsoft.Net.Http.Server.WebListener.SetRequestQueueLimit(System.Int64)
    
        
    
        Sets the maximum number of requests that will be queued up in Http.Sys.
    
        
        
        
        :type limit: System.Int64
    
        
        .. code-block:: csharp
    
           public void SetRequestQueueLimit(long limit)
    
    .. dn:method:: Microsoft.Net.Http.Server.WebListener.Start()
    
        
    
        
        .. code-block:: csharp
    
           public void Start()
    

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
    

