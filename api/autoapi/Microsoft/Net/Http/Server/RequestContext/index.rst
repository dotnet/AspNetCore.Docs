

RequestContext Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.RequestContext`








Syntax
------

.. code-block:: csharp

   public sealed class RequestContext : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/weblistener/src/Microsoft.Net.Http.Server/RequestProcessing/RequestContext.cs>`_





.. dn:class:: Microsoft.Net.Http.Server.RequestContext

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.RequestContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.Abort()
    
        
    
        
        .. code-block:: csharp
    
           public void Abort()
    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.AcceptWebSocketAsync()
    
        
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           public Task<WebSocket> AcceptWebSocketAsync()
    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.AcceptWebSocketAsync(System.String)
    
        
        
        
        :type subProtocol: System.String
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           public Task<WebSocket> AcceptWebSocketAsync(string subProtocol)
    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.AcceptWebSocketAsync(System.String, System.Int32, System.TimeSpan)
    
        
        
        
        :type subProtocol: System.String
        
        
        :type receiveBufferSize: System.Int32
        
        
        :type keepAliveInterval: System.TimeSpan
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           public Task<WebSocket> AcceptWebSocketAsync(string subProtocol, int receiveBufferSize, TimeSpan keepAliveInterval)
    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.AcceptWebSocketAsync(System.String, System.Int32, System.TimeSpan, System.ArraySegment<System.Byte>)
    
        
        
        
        :type subProtocol: System.String
        
        
        :type receiveBufferSize: System.Int32
        
        
        :type keepAliveInterval: System.TimeSpan
        
        
        :type internalBuffer: System.ArraySegment{System.Byte}
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           public Task<WebSocket> AcceptWebSocketAsync(string subProtocol, int receiveBufferSize, TimeSpan keepAliveInterval, ArraySegment<byte> internalBuffer)
    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.AcceptWebSocketAsync(System.String, System.TimeSpan)
    
        
        
        
        :type subProtocol: System.String
        
        
        :type keepAliveInterval: System.TimeSpan
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           public Task<WebSocket> AcceptWebSocketAsync(string subProtocol, TimeSpan keepAliveInterval)
    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.Net.Http.Server.RequestContext.UpgradeAsync()
    
        
        :rtype: System.Threading.Tasks.Task{System.IO.Stream}
    
        
        .. code-block:: csharp
    
           public Task<Stream> UpgradeAsync()
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.RequestContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.AuthenticationChallenges
    
        
    
        The authentication challengest that will be added to the response if the status code is 401.
        This must be a subset of the AuthenticationSchemes enabled on the server.
    
        
        :rtype: Microsoft.Net.Http.Server.AuthenticationSchemes
    
        
        .. code-block:: csharp
    
           public AuthenticationSchemes AuthenticationChallenges { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.DisconnectToken
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public CancellationToken DisconnectToken { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.IsUpgradableRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsUpgradableRequest { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.IsWebSocketRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsWebSocketRequest { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.Request
    
        
        :rtype: Microsoft.Net.Http.Server.Request
    
        
        .. code-block:: csharp
    
           public Request Request { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.Response
    
        
        :rtype: Microsoft.Net.Http.Server.Response
    
        
        .. code-block:: csharp
    
           public Response Response { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.TraceIdentifier
    
        
        :rtype: System.Guid
    
        
        .. code-block:: csharp
    
           public Guid TraceIdentifier { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.RequestContext.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal User { get; }
    

