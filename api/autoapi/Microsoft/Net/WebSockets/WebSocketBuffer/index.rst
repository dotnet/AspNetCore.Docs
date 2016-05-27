

WebSocketBuffer Class
=====================





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
* :dn:cls:`Microsoft.Net.WebSockets.WebSocketBuffer`








Syntax
------

.. code-block:: csharp

    public class WebSocketBuffer : IDisposable








.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer
    :hidden:

.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer

Properties
----------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.WebSockets.WebSocketBuffer.ReceiveBufferSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ReceiveBufferSize
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.WebSockets.WebSocketBuffer.SendBufferSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int SendBufferSize
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Net.WebSockets.WebSocketBuffer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.WebSockets.WebSocketBuffer.CreateInternalBufferArraySegment(System.Int32, System.Int32, System.Boolean)
    
        
    
        
        :type receiveBufferSize: System.Int32
    
        
        :type sendBufferSize: System.Int32
    
        
        :type isServerBuffer: System.Boolean
        :rtype: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
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
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int MinSendBufferSize = 16
    

