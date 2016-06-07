

WebSocketExtensions Class
=========================





Namespace
    :dn:ns:`Microsoft.Net.Http.Server`
Assemblies
    * Microsoft.Net.WebSockets.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.WebSocketExtensions`








Syntax
------

.. code-block:: csharp

    public class WebSocketExtensions








.. dn:class:: Microsoft.Net.Http.Server.WebSocketExtensions
    :hidden:

.. dn:class:: Microsoft.Net.Http.Server.WebSocketExtensions

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.WebSocketExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.WebSocketExtensions.AcceptWebSocketAsync(Microsoft.Net.Http.Server.RequestContext)
    
        
    
        
        :type context: Microsoft.Net.Http.Server.RequestContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public static Task<WebSocket> AcceptWebSocketAsync(RequestContext context)
    
    .. dn:method:: Microsoft.Net.Http.Server.WebSocketExtensions.AcceptWebSocketAsync(Microsoft.Net.Http.Server.RequestContext, System.String)
    
        
    
        
        :type context: Microsoft.Net.Http.Server.RequestContext
    
        
        :type subProtocol: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public static Task<WebSocket> AcceptWebSocketAsync(RequestContext context, string subProtocol)
    
    .. dn:method:: Microsoft.Net.Http.Server.WebSocketExtensions.AcceptWebSocketAsync(Microsoft.Net.Http.Server.RequestContext, System.String, System.Int32, System.TimeSpan)
    
        
    
        
        :type context: Microsoft.Net.Http.Server.RequestContext
    
        
        :type subProtocol: System.String
    
        
        :type receiveBufferSize: System.Int32
    
        
        :type keepAliveInterval: System.TimeSpan
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public static Task<WebSocket> AcceptWebSocketAsync(RequestContext context, string subProtocol, int receiveBufferSize, TimeSpan keepAliveInterval)
    
    .. dn:method:: Microsoft.Net.Http.Server.WebSocketExtensions.AcceptWebSocketAsync(Microsoft.Net.Http.Server.RequestContext, System.String, System.Int32, System.TimeSpan, System.ArraySegment<System.Byte>)
    
        
    
        
        :type context: Microsoft.Net.Http.Server.RequestContext
    
        
        :type subProtocol: System.String
    
        
        :type receiveBufferSize: System.Int32
    
        
        :type keepAliveInterval: System.TimeSpan
    
        
        :type internalBuffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public static Task<WebSocket> AcceptWebSocketAsync(RequestContext context, string subProtocol, int receiveBufferSize, TimeSpan keepAliveInterval, ArraySegment<byte> internalBuffer)
    
    .. dn:method:: Microsoft.Net.Http.Server.WebSocketExtensions.AcceptWebSocketAsync(Microsoft.Net.Http.Server.RequestContext, System.String, System.TimeSpan)
    
        
    
        
        :type context: Microsoft.Net.Http.Server.RequestContext
    
        
        :type subProtocol: System.String
    
        
        :type keepAliveInterval: System.TimeSpan
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public static Task<WebSocket> AcceptWebSocketAsync(RequestContext context, string subProtocol, TimeSpan keepAliveInterval)
    
    .. dn:method:: Microsoft.Net.Http.Server.WebSocketExtensions.IsWebSocketRequest(Microsoft.Net.Http.Server.RequestContext)
    
        
    
        
        :type context: Microsoft.Net.Http.Server.RequestContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsWebSocketRequest(RequestContext context)
    

