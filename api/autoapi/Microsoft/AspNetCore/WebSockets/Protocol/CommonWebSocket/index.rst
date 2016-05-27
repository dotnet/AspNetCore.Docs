

CommonWebSocket Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebSockets.Protocol`
Assemblies
    * Microsoft.AspNetCore.WebSockets.Protocol

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Net.WebSockets.WebSocket`
* :dn:cls:`Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket`








Syntax
------

.. code-block:: csharp

    public class CommonWebSocket : WebSocket, IDisposable








.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.CloseStatus
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Net.WebSockets.WebSocketCloseStatus<System.Net.WebSockets.WebSocketCloseStatus>}
    
        
        .. code-block:: csharp
    
            public override WebSocketCloseStatus? CloseStatus
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.CloseStatusDescription
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string CloseStatusDescription
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.State
    
        
        :rtype: System.Net.WebSockets.WebSocketState
    
        
        .. code-block:: csharp
    
            public override WebSocketState State
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.SubProtocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string SubProtocol
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.CommonWebSocket(System.IO.Stream, System.String, System.TimeSpan, System.Int32, System.Boolean, System.Boolean, System.Boolean)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type subProtocol: System.String
    
        
        :type keepAliveInterval: System.TimeSpan
    
        
        :type receiveBufferSize: System.Int32
    
        
        :type maskOutput: System.Boolean
    
        
        :type useZeroMask: System.Boolean
    
        
        :type unmaskInput: System.Boolean
    
        
        .. code-block:: csharp
    
            public CommonWebSocket(Stream stream, string subProtocol, TimeSpan keepAliveInterval, int receiveBufferSize, bool maskOutput, bool useZeroMask, bool unmaskInput)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public override void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus, System.String, System.Threading.CancellationToken)
    
        
    
        
        :type closeStatus: System.Net.WebSockets.WebSocketCloseStatus
    
        
        :type statusDescription: System.String
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.CloseOutputAsync(System.Net.WebSockets.WebSocketCloseStatus, System.String, System.Threading.CancellationToken)
    
        
    
        
        :type closeStatus: System.Net.WebSockets.WebSocketCloseStatus
    
        
        :type statusDescription: System.String
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.CreateClientWebSocket(System.IO.Stream, System.String, System.TimeSpan, System.Int32, System.Boolean)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type subProtocol: System.String
    
        
        :type keepAliveInterval: System.TimeSpan
    
        
        :type receiveBufferSize: System.Int32
    
        
        :type useZeroMask: System.Boolean
        :rtype: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket
    
        
        .. code-block:: csharp
    
            public static CommonWebSocket CreateClientWebSocket(Stream stream, string subProtocol, TimeSpan keepAliveInterval, int receiveBufferSize, bool useZeroMask)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.CreateServerWebSocket(System.IO.Stream, System.String, System.TimeSpan, System.Int32)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type subProtocol: System.String
    
        
        :type keepAliveInterval: System.TimeSpan
    
        
        :type receiveBufferSize: System.Int32
        :rtype: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket
    
        
        .. code-block:: csharp
    
            public static CommonWebSocket CreateServerWebSocket(Stream stream, string subProtocol, TimeSpan keepAliveInterval, int receiveBufferSize)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public override void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.ReceiveAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocketReceiveResult<System.Net.WebSockets.WebSocketReceiveResult>}
    
        
        .. code-block:: csharp
    
            public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.CommonWebSocket.SendAsync(System.ArraySegment<System.Byte>, System.Net.WebSockets.WebSocketMessageType, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type messageType: System.Net.WebSockets.WebSocketMessageType
    
        
        :type endOfMessage: System.Boolean
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
    

