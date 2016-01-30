

WebSocketBuffer Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.WebSockets.WebSocketBuffer`








Syntax
------

.. code-block:: csharp

   public class WebSocketBuffer : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/weblistener/blob/master/src/Microsoft.Net.WebSockets/WebSocketBuffer.cs>`_





.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer

Methods
-------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketBuffer.CreateInternalBufferArraySegment(System.Int32, System.Int32, System.Boolean)
    
        
        
        
        :type receiveBufferSize: System.Int32
        
        
        :type sendBufferSize: System.Int32
        
        
        :type isServerBuffer: System.Boolean
        :rtype: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public static ArraySegment<byte> CreateInternalBufferArraySegment(int receiveBufferSize, int sendBufferSize, bool isServerBuffer)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketBuffer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketBuffer.Dispose(System.Net.WebSockets.WebSocketState)
    
        
        
        
        :type webSocketState: System.Net.WebSockets.WebSocketState
    
        
        .. code-block:: csharp
    
           public void Dispose(WebSocketState webSocketState)
    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketBuffer.Validate(System.Int32, System.Int32, System.Int32, System.Boolean)
    
        
        
        
        :type count: System.Int32
        
        
        :type receiveBufferSize: System.Int32
        
        
        :type sendBufferSize: System.Int32
        
        
        :type isServerBuffer: System.Boolean
    
        
        .. code-block:: csharp
    
           public static void Validate(int count, int receiveBufferSize, int sendBufferSize, bool isServerBuffer)
    

Fields
------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Net.WebSockets.WebSocketBuffer.MinSendBufferSize
    
        
    
        
        .. code-block:: csharp
    
           public const int MinSendBufferSize
    

Properties
----------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.WebSockets.WebSocketBuffer.ReceiveBufferSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int ReceiveBufferSize { get; }
    
    .. dn:property:: Microsoft.Net.WebSockets.WebSocketBuffer.SendBufferSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int SendBufferSize { get; }
    

