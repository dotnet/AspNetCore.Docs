

OwinWebSocketAdapter Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Net.WebSockets.WebSocket`
* :dn:cls:`Microsoft.AspNet.Owin.OwinWebSocketAdapter`








Syntax
------

.. code-block:: csharp

   public class OwinWebSocketAdapter : WebSocket, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Owin/WebSockets/OwinWebSocketAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.OwinWebSocketAdapter(System.Collections.Generic.IDictionary<System.String, System.Object>, System.String)
    
        
        
        
        :type websocketContext: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type subProtocol: System.String
    
        
        .. code-block:: csharp
    
           public OwinWebSocketAdapter(IDictionary<string, object> websocketContext, string subProtocol)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.Abort()
    
        
    
        
        .. code-block:: csharp
    
           public override void Abort()
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus, System.String, System.Threading.CancellationToken)
    
        
        
        
        :type closeStatus: System.Net.WebSockets.WebSocketCloseStatus
        
        
        :type statusDescription: System.String
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.CloseOutputAsync(System.Net.WebSockets.WebSocketCloseStatus, System.String, System.Threading.CancellationToken)
    
        
        
        
        :type closeStatus: System.Net.WebSockets.WebSocketCloseStatus
        
        
        :type statusDescription: System.String
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public override void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.ReceiveAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocketReceiveResult}
    
        
        .. code-block:: csharp
    
           public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.SendAsync(System.ArraySegment<System.Byte>, System.Net.WebSockets.WebSocketMessageType, System.Boolean, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type messageType: System.Net.WebSockets.WebSocketMessageType
        
        
        :type endOfMessage: System.Boolean
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.CloseStatus
    
        
        :rtype: System.Nullable{System.Net.WebSockets.WebSocketCloseStatus}
    
        
        .. code-block:: csharp
    
           public override WebSocketCloseStatus? CloseStatus { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.CloseStatusDescription
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string CloseStatusDescription { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.State
    
        
        :rtype: System.Net.WebSockets.WebSocketState
    
        
        .. code-block:: csharp
    
           public override WebSocketState State { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinWebSocketAdapter.SubProtocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string SubProtocol { get; }
    

