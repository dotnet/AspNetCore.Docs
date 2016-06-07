

Utilities Class
===============





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
* :dn:cls:`Microsoft.AspNetCore.WebSockets.Protocol.Utilities`








Syntax
------

.. code-block:: csharp

    public class Utilities








.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities.GetMessageType(System.Int32)
    
        
    
        
        :type opCode: System.Int32
        :rtype: System.Net.WebSockets.WebSocketMessageType
    
        
        .. code-block:: csharp
    
            public static WebSocketMessageType GetMessageType(int opCode)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities.GetOpCode(System.Net.WebSockets.WebSocketMessageType)
    
        
    
        
        :type messageType: System.Net.WebSockets.WebSocketMessageType
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static int GetOpCode(WebSocketMessageType messageType)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities.MaskInPlace(System.Int32, System.ArraySegment<System.Byte>)
    
        
    
        
        :type mask: System.Int32
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public static void MaskInPlace(int mask, ArraySegment<byte> data)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities.MaskInPlace(System.Int32, ref System.Int32, System.ArraySegment<System.Byte>)
    
        
    
        
        :type mask: System.Int32
    
        
        :type maskOffset: System.Int32
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public static void MaskInPlace(int mask, ref int maskOffset, ArraySegment<byte> data)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities.MergeAndMask(System.Int32, System.ArraySegment<System.Byte>, System.ArraySegment<System.Byte>)
    
        
    
        
        :type mask: System.Int32
    
        
        :type header: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static byte[] MergeAndMask(int mask, ArraySegment<byte> header, ArraySegment<byte> data)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.Utilities.TryValidateUtf8(System.ArraySegment<System.Byte>, System.Boolean, Microsoft.AspNetCore.WebSockets.Protocol.Utilities.Utf8MessageState)
    
        
    
        
        :type arraySegment: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type endOfMessage: System.Boolean
    
        
        :type state: Microsoft.AspNetCore.WebSockets.Protocol.Utilities.Utf8MessageState
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryValidateUtf8(ArraySegment<byte> arraySegment, bool endOfMessage, Utilities.Utf8MessageState state)
    

