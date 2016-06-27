

MemoryPoolBlock Class
=====================






Block tracking object used by the byte buffer memory pool. A slab is a large allocation which is divided into smaller blocks. The
individual blocks are then treated as independant array segments.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolBlock








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Finalize()
    
        
    
        
        .. code-block:: csharp
    
            protected void Finalize()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.GetIterator()
    
        
    
        
        acquires a cursor pointing into this block at the Start of "active" byte information
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator GetIterator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Reset()
    
        
    
        
        called when the block is returned to the pool. mutable values are re-assigned to their guaranteed initialized state.
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.ToString()
    
        
    
        
        ToString overridden for debugger convenience. This displays the "active" byte information in this block as ASCII characters.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.MemoryPoolBlock(System.IntPtr)
    
        
    
        
        This object cannot be instantiated outside of the static Create method
    
        
    
        
        :type dataArrayPtr: System.IntPtr
    
        
        .. code-block:: csharp
    
            protected MemoryPoolBlock(IntPtr dataArrayPtr)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Array
    
        
    
        
        Convenience accessor
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Array { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Pool
    
        
    
        
        Back-reference to the memory pool which this block was allocated from. It may only be returned to this pool.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool
    
        
        .. code-block:: csharp
    
            public MemoryPool Pool { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Slab
    
        
    
        
        Back-reference to the slab from which this block was taken, or null if it is one-time-use memory.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolSlab
    
        
        .. code-block:: csharp
    
            public MemoryPoolSlab Slab { get; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Data
    
        
    
        
        The array segment describing the range of memory this block is tracking. The caller which has leased this block may only read and
        modify the memory in this range.
    
        
        :rtype: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public ArraySegment<byte> Data
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.DataArrayPtr
    
        
    
        
        Native address of the first byte of this block's Data memory. It is null for one-time-use memory, or copied from 
        the Slab's ArrayPtr for a slab-block segment. The byte it points to corresponds to Data.Array[0], and in practice you will always
        use the DataArrayPtr + Start or DataArrayPtr + End, which point to the start of "active" bytes, or point to just after the "active" bytes.
    
        
        :rtype: System.IntPtr
    
        
        .. code-block:: csharp
    
            public readonly IntPtr DataArrayPtr
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.End
    
        
    
        
        The End represents the offset into Array where the range of "active" bytes ends. At the point when the block is leased
        the End is guaranteed to be equal to Array.Offset. The value of Start may be assigned anywhere between Data.Offset and
        Data.Offset + Data.Count, and must be equal to or less than End.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public volatile int End
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Next
    
        
    
        
        Reference to the next block of data when the overall "active" bytes spans multiple blocks. At the point when the block is
        leased Next is guaranteed to be null. Start, End, and Next are used together in order to create a linked-list of discontiguous 
        working memory. The "active" memory is grown when bytes are copied in, End is increased, and Next is assigned. The "active" 
        memory is shrunk when bytes are consumed, Start is increased, and blocks are returned to the pool.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public MemoryPoolBlock Next
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock.Start
    
        
    
        
        The Start represents the offset into Array where the range of "active" bytes begins. At the point when the block is leased
        the Start is guaranteed to be equal to Array.Offset. The value of Start may be assigned anywhere between Data.Offset and
        Data.Offset + Data.Count, and must be equal to or less than End.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Start
    

