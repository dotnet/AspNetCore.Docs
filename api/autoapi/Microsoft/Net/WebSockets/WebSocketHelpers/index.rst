

WebSocketHelpers Class
======================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/weblistener/blob/master/src/Microsoft.Net.WebSockets/WebSocketHelpers.cs>`_





.. dn:class:: Microsoft.Net.WebSockets.WebSocketHelpers

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
        
        
        :type internalBuffer: System.ArraySegment{System.Byte}
        :rtype: System.Net.WebSockets.WebSocket
    
        
        .. code-block:: csharp
    
           public static WebSocket CreateServerWebSocket(Stream opaqueStream, string subProtocol, int receiveBufferSize, TimeSpan keepAliveInterval, ArraySegment<byte> internalBuffer)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.GetSecWebSocketAcceptString(System.String)
    
        
        
        
        :type secWebSocketKey: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetSecWebSocketAcceptString(string secWebSocketKey)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.IsValidWebSocketKey(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsValidWebSocketKey(string key)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.ProcessWebSocketProtocolHeader(System.Collections.Generic.IEnumerable<System.String>, System.String)
    
        
        
        
        :type clientSecWebSocketProtocols: System.Collections.Generic.IEnumerable{System.String}
        
        
        :type subProtocol: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool ProcessWebSocketProtocolHeader(IEnumerable<string> clientSecWebSocketProtocols, string subProtocol)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketHelpers.ValidateArraySegment<T>(System.ArraySegment<T>, System.String)
    
        
        
        
        :type arraySegment: System.ArraySegment{{T}}
        
        
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
    
        
    
        
        .. code-block:: csharp
    
           public const int DefaultReceiveBufferSize
    
    .. dn:field:: Microsoft.Net.WebSockets.WebSocketHelpers.WebSocketUpgradeToken
    
        
    
        
        .. code-block:: csharp
    
           public const string WebSocketUpgradeToken
    

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
    

