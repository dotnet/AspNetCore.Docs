

MemoryPoolBlock Class
=====================






Block tracking object used by the byte buffer memory pool. A slab is a large allocation which is divided into smaller blocks. The
individual blocks are then treated as independant array segments.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolBlock








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Array
    
        
    
        
        Convenience accessor
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Array
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Pool
    
        
    
        
        Back-reference to the memory pool which this block was allocated from. It may only be returned to this pool.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    
        
        .. code-block:: csharp
    
            public MemoryPool Pool
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Slab
    
        
    
        
        Back-reference to the slab from which this block was taken, or null if it is one-time-use memory.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab
    
        
        .. code-block:: csharp
    
            public MemoryPoolSlab Slab
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.MemoryPoolBlock()
    
        
    
        
        This object cannot be instantiated outside of the static Create method
    
        
    
        
        .. code-block:: csharp
    
            protected MemoryPoolBlock()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Data
    
        
    
        
        The array segment describing the range of memory this block is tracking. The caller which has leased this block may only read and
        modify the memory in this range.
    
        
        :rtype: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public ArraySegment<byte> Data
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.End
    
        
    
        
        The End represents the offset into Array where the range of "active" bytes ends. At the point when the block is leased
        the End is guaranteed to be equal to Array.Offset. The value of Start may be assigned anywhere between Data.Offset and
        Data.Offset + Data.Count, and must be equal to or less than End.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public volatile int End
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Next
    
        
    
        
        Reference to the next block of data when the overall "active" bytes spans multiple blocks. At the point when the block is
        leased Next is guaranteed to be null. Start, End, and Next are used together in order to create a linked-list of discontiguous 
        working memory. The "active" memory is grown when bytes are copied in, End is increased, and Next is assigned. The "active" 
        memory is shrunk when bytes are consumed, Start is increased, and blocks are returned to the pool.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public MemoryPoolBlock Next
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Start
    
        
    
        
        The Start represents the offset into Array where the range of "active" bytes begins. At the point when the block is leased
        the Start is guaranteed to be equal to Array.Offset. The value of Start may be assigned anywhere between Data.Offset and
        Data.Offset + Data.Count, and must be equal to or less than End.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Start
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Create(System.ArraySegment<System.Byte>, System.IntPtr, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab)
    
        
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type dataPtr: System.IntPtr
    
        
        :type pool: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    
        
        :type slab: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public static MemoryPoolBlock Create(ArraySegment<byte> data, IntPtr dataPtr, MemoryPool pool, MemoryPoolSlab slab)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Finalize()
    
        
    
        
        .. code-block:: csharp
    
            protected void Finalize()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.GetIterator()
    
        
    
        
        acquires a cursor pointing into this block at the Start of "active" byte information
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator GetIterator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Pin()
    
        
    
        
        Called to ensure that a block is pinned, and return the pointer to the native address
        of the first byte of this block's Data memory. Arriving data is read into Pin() + End.
        Outgoing data is read from Pin() + Start.
    
        
        :rtype: System.IntPtr
    
        
        .. code-block:: csharp
    
            public IntPtr Pin()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Reset()
    
        
    
        
        called when the block is returned to the pool. mutable values are re-assigned to their guaranteed initialized state.
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.ToString()
    
        
    
        
        ToString overridden for debugger convenience. This displays the "active" byte information in this block as ASCII characters.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock.Unpin()
    
        
    
        
        .. code-block:: csharp
    
            public void Unpin()
    

