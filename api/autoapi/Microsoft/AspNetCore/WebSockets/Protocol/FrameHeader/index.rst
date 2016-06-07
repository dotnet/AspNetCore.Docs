

FrameHeader Class
=================





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
* :dn:cls:`Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader`








Syntax
------

.. code-block:: csharp

    public class FrameHeader








.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.Buffer
    
        
        :rtype: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public ArraySegment<byte> Buffer
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.DataLength
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long DataLength
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.ExtendedLengthFieldSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ExtendedLengthFieldSize
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.Fin
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Fin
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.IsControlFrame
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsControlFrame
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.MaskKey
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaskKey
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.Masked
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Masked
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.OpCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int OpCode
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.PayloadField
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int PayloadField
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.FrameHeader(System.ArraySegment<System.Byte>)
    
        
    
        
        :type header: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public FrameHeader(ArraySegment<byte> header)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.FrameHeader(System.Boolean, System.Int32, System.Boolean, System.Int32, System.Int64)
    
        
    
        
        :type final: System.Boolean
    
        
        :type opCode: System.Int32
    
        
        :type masked: System.Boolean
    
        
        :type maskKey: System.Int32
    
        
        :type dataLength: System.Int64
    
        
        .. code-block:: csharp
    
            public FrameHeader(bool final, int opCode, bool masked, int maskKey, long dataLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.FrameHeader.CalculateFrameHeaderSize(System.Byte)
    
        
    
        
        :type b2: System.Byte
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static int CalculateFrameHeaderSize(byte b2)
    

