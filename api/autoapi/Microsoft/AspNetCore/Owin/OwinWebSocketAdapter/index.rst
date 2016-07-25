

OwinWebSocketAdapter Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Owin`
Assemblies
    * Microsoft.AspNetCore.Owin

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Net.WebSockets.WebSocket`
* :dn:cls:`Microsoft.AspNetCore.Owin.OwinWebSocketAdapter`








Syntax
------

.. code-block:: csharp

    public class OwinWebSocketAdapter : WebSocket, IDisposable








.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.OwinWebSocketAdapter(System.Collections.Generic.IDictionary<System.String, System.Object>, System.String)
    
        
    
        
        :type websocketContext: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type subProtocol: System.String
    
        
        .. code-block:: csharp
    
            public OwinWebSocketAdapter(IDictionary<string, object> websocketContext, string subProtocol)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public override void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus, System.String, System.Threading.CancellationToken)
    
        
    
        
        :type closeStatus: System.Net.WebSockets.WebSocketCloseStatus
    
        
        :type statusDescription: System.String
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.CloseOutputAsync(System.Net.WebSockets.WebSocketCloseStatus, System.String, System.Threading.CancellationToken)
    
        
    
        
        :type closeStatus: System.Net.WebSockets.WebSocketCloseStatus
    
        
        :type statusDescription: System.String
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public override void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.ReceiveAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocketReceiveResult<System.Net.WebSockets.WebSocketReceiveResult>}
    
        
        .. code-block:: csharp
    
            public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.SendAsync(System.ArraySegment<System.Byte>, System.Net.WebSockets.WebSocketMessageType, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type messageType: System.Net.WebSockets.WebSocketMessageType
    
        
        :type endOfMessage: System.Boolean
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.CloseStatus
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Net.WebSockets.WebSocketCloseStatus<System.Net.WebSockets.WebSocketCloseStatus>}
    
        
        .. code-block:: csharp
    
            public override WebSocketCloseStatus? CloseStatus { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.CloseStatusDescription
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string CloseStatusDescription { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.State
    
        
        :rtype: System.Net.WebSockets.WebSocketState
    
        
        .. code-block:: csharp
    
            public override WebSocketState State { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Owin.OwinWebSocketAdapter.SubProtocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string SubProtocol { get; }
    

