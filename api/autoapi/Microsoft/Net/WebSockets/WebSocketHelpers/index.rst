

WebSocketHelpers Class
======================





Namespace
    :dn:ns:`Microsoft.Net.WebSockets`
Assemblies
    * Microsoft.Net.WebSockets.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.WebSockets.WebSocketHelpers`








Syntax
------

.. code-block:: csharp

    public class WebSocketHelpers








.. dn:class:: Microsoft.Net.WebSockets.WebSocketHelpers
    :hidden:

.. dn:class:: Microsoft.Net.WebSockets.WebSocketHelpers

Properties
----------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketHelpers
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.WebSockets.WebSocketHelpers.AreWebSocketsSupported
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool AreWebSocketsSupported { get; }
    
    .. dn:property:: Microsoft.Net.WebSockets.WebSocketHelpers.DefaultKeepAliveInterval
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public static TimeSpan DefaultKeepAliveInterval { get; }
    

Methods
-------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketHelpers
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.CreateServerWebSocket(System.IO.Stream, System.String, System.Int32, System.TimeSpan, System.ArraySegment<System.Byte>)
    
        
    
        
        :type opaqueStream: System.IO.Stream
    
        
        :type subProtocol: System.String
    
        
        :type receiveBufferSize: System.Int32
    
        
        :type keepAliveInterval: System.TimeSpan
    
        
        :type internalBuffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
        :rtype: System.Net.WebSockets.WebSocket
    
        
        .. code-block:: csharp
    
            public static WebSocket CreateServerWebSocket(Stream opaqueStream, string subProtocol, int receiveBufferSize, TimeSpan keepAliveInterval, ArraySegment<byte> internalBuffer)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.GetSecWebSocketAcceptString(System.String)
    
        
    
        
        :type secWebSocketKey: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [SuppressMessage("Microsoft.Cryptographic.Standard", "CA5354:SHA1CannotBeUsed", Justification = "SHA1 used only for hashing purposes, not for crypto.")]
            public static string GetSecWebSocketAcceptString(string secWebSocketKey)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.IsValidWebSocketKey(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsValidWebSocketKey(string key)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.ProcessWebSocketProtocolHeader(System.Collections.Generic.IEnumerable<System.String>, System.String)
    
        
    
        
        :type clientSecWebSocketProtocols: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        :type subProtocol: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool ProcessWebSocketProtocolHeader(IEnumerable<string> clientSecWebSocketProtocols, string subProtocol)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.ValidateArraySegment<T>(System.ArraySegment<T>, System.String)
    
        
    
        
        :type arraySegment: System.ArraySegment<System.ArraySegment`1>{T}
    
        
        :type parameterName: System.String
    
        
        .. code-block:: csharp
    
            public static void ValidateArraySegment<T>(ArraySegment<T> arraySegment, string parameterName)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.ValidateOptions(System.String, System.Int32, System.Int32, System.TimeSpan)
    
        
    
        
        :type subProtocol: System.String
    
        
        :type receiveBufferSize: System.Int32
    
        
        :type sendBufferSize: System.Int32
    
        
        :type keepAliveInterval: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public static void ValidateOptions(string subProtocol, int receiveBufferSize, int sendBufferSize, TimeSpan keepAliveInterval)
    

Fields
------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketHelpers
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Net.WebSockets.WebSocketHelpers.DefaultReceiveBufferSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultReceiveBufferSize = 16384
    
    .. dn:field:: Microsoft.Net.WebSockets.WebSocketHelpers.WebSocketUpgradeToken
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string WebSocketUpgradeToken = "websocket"
    

