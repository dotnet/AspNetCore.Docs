

MemoryPoolBlock2 Class
======================



.. contents:: 
   :local:



Summary
-------

Block tracking object used by the byte buffer memory pool. A slab is a large allocation which is divided into smaller blocks. The
individual blocks are then treated as independant array segments.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2`








Syntax
------

.. code-block:: csharp

   public class MemoryPoolBlock2





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/MemoryPoolBlock2.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.MemoryPoolBlock2()
    
        
    
        This object cannot be instantiated outside of the static Create method
    
        
    
        
        .. code-block:: csharp
    
           protected MemoryPoolBlock2()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Create(System.ArraySegment<System.Byte>, System.IntPtr, Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2, Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2)
    
        
        
        
        :type data: System.ArraySegment{System.Byte}
        
        
        :type dataPtr: System.IntPtr
        
        
        :type pool: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2
        
        
        :type slab: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    
        
        .. code-block:: csharp
    
           public static MemoryPoolBlock2 Create(ArraySegment<byte> data, IntPtr dataPtr, MemoryPool2 pool, MemoryPoolSlab2 slab)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Finalize()
    
        
    
        
        .. code-block:: csharp
    
           protected void Finalize()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.GetIterator()
    
        
    
        acquires a cursor pointing into this block at the Start of "active" byte information
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
    
        
        .. code-block:: csharp
    
           public MemoryPoolIterator2 GetIterator()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Pin()
    
        
    
        Called to ensure that a block is pinned, and return the pointer to native memory just after
        the range of "active" bytes. This is where arriving data is read into.
    
        
        :rtype: System.IntPtr
    
        
        .. code-block:: csharp
    
           public IntPtr Pin()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Reset()
    
        
    
        called when the block is returned to the pool. mutable values are re-assigned to their guaranteed initialized state.
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.ToString()
    
        
    
        ToString overridden for debugger convenience. This displays the "active" byte information in this block as ASCII characters.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Unpin()
    
        
    
        
        .. code-block:: csharp
    
           public void Unpin()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Data
    
        
    
        The array segment describing the range of memory this block is tracking. The caller which has leased this block may only read and
        modify the memory in this range.
    
        
    
        
        .. code-block:: csharp
    
           public ArraySegment<byte> Data
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Array
    
        
    
        Convenience accessor
    
        
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public byte[] Array { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.End
    
        
    
        The End represents the offset into Array where the range of "active" bytes ends. At the point when the block is leased
        the End is guaranteed to be equal to Array.Offset. The value of Start may be assigned anywhere between Data.Offset and
        Data.Offset + Data.Count, and must be equal to or less than End.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int End { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Next
    
        
    
        Reference to the next block of data when the overall "active" bytes spans multiple blocks. At the point when the block is
        leased Next is guaranteed to be null. Start, End, and Next are used together in order to create a linked-list of discontiguous
        working memory. The "active" memory is grown when bytes are copied in, End is increased, and Next is assigned. The "active"
        memory is shrunk when bytes are consumed, Start is increased, and blocks are returned to the pool.
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    
        
        .. code-block:: csharp
    
           public MemoryPoolBlock2 Next { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Pool
    
        
    
        Back-reference to the memory pool which this block was allocated from. It may only be returned to this pool.
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2
    
        
        .. code-block:: csharp
    
           public MemoryPool2 Pool { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Slab
    
        
    
        Back-reference to the slab from which this block was taken, or null if it is one-time-use memory.
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2
    
        
        .. code-block:: csharp
    
           public MemoryPoolSlab2 Slab { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2.Start
    
        
    
        The Start represents the offset into Array where the range of "active" bytes begins. At the point when the block is leased
        the Start is guaranteed to be equal to Array.Offset. The value of Start may be assigned anywhere between Data.Offset and
        Data.Offset + Data.Count, and must be equal to or less than End.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Start { get; set; }
    

