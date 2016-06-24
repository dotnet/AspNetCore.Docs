

MemoryPoolIterator Struct
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct MemoryPoolIterator








.. dn:structure:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.MemoryPoolIterator(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock)
    
        
    
        
        :type block: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator(MemoryPoolBlock block)
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.MemoryPoolIterator(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock, System.Int32)
    
        
    
        
        :type block: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator(MemoryPoolBlock block, int index)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Block
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public MemoryPoolBlock Block { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Index
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Index { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.IsDefault
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsDefault { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.IsEnd
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnd { get; }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.CopyFrom(System.ArraySegment<System.Byte>)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public void CopyFrom(ArraySegment<byte> buffer)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.CopyFrom(System.Byte[])
    
        
    
        
        :type data: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public void CopyFrom(byte[] data)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.CopyFrom(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type data: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public void CopyFrom(byte[] data, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.CopyFromAscii(System.String)
    
        
    
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
            public void CopyFromAscii(string data)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.CopyTo(System.Byte[], System.Int32, System.Int32, out System.Int32)
    
        
    
        
        :type array: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type actual: System.Int32
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator CopyTo(byte[] array, int offset, int count, out int actual)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.GetLength(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int GetLength(MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Peek()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.PeekLong()
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long PeekLong()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Put(System.Byte)
    
        
    
        
        Save the data at the current location then move to the next available space.
    
        
    
        
        :param data: The byte to be saved.
        
        :type data: System.Byte
        :rtype: System.Boolean
        :return: true if the operation successes. false if can't find available space.
    
        
        .. code-block:: csharp
    
            public bool Put(byte data)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Seek(ref System.Numerics.Vector<System.Byte>)
    
        
    
        
        :type byte0Vector: System.Numerics.Vector<System.Numerics.Vector`1>{System.Byte<System.Byte>}
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Seek(ref Vector<byte> byte0Vector)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Seek(ref System.Numerics.Vector<System.Byte>, ref System.Numerics.Vector<System.Byte>)
    
        
    
        
        :type byte0Vector: System.Numerics.Vector<System.Numerics.Vector`1>{System.Byte<System.Byte>}
    
        
        :type byte1Vector: System.Numerics.Vector<System.Numerics.Vector`1>{System.Byte<System.Byte>}
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Seek(ref Vector<byte> byte0Vector, ref Vector<byte> byte1Vector)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Seek(ref System.Numerics.Vector<System.Byte>, ref System.Numerics.Vector<System.Byte>, ref System.Numerics.Vector<System.Byte>)
    
        
    
        
        :type byte0Vector: System.Numerics.Vector<System.Numerics.Vector`1>{System.Byte<System.Byte>}
    
        
        :type byte1Vector: System.Numerics.Vector<System.Numerics.Vector`1>{System.Byte<System.Byte>}
    
        
        :type byte2Vector: System.Numerics.Vector<System.Numerics.Vector`1>{System.Byte<System.Byte>}
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Seek(ref Vector<byte> byte0Vector, ref Vector<byte> byte1Vector, ref Vector<byte> byte2Vector)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Skip(System.Int32)
    
        
    
        
        :type bytesToSkip: System.Int32
    
        
        .. code-block:: csharp
    
            public void Skip(int bytesToSkip)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator.Take()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Take()
    

