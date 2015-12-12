

MemoryPoolSlab2 Class
=====================



.. contents:: 
   :local:



Summary
-------

Slab tracking object used by the byte buffer memory pool. A slab is a large allocation which is divided into smaller blocks. The
individual blocks are then treated as independant array segments.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2`








Syntax
------

.. code-block:: csharp

   public class MemoryPoolSlab2 : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/MemoryPoolSlab2.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2.Create(System.Int32)
    
        
        
        
        :type length: System.Int32
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2
    
        
        .. code-block:: csharp
    
           public static MemoryPoolSlab2 Create(int length)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2.Finalize()
    
        
    
        
        .. code-block:: csharp
    
           protected void Finalize()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2.Array
    
        
    
        The managed memory allocated in the large object heap.
    
        
    
        
        .. code-block:: csharp
    
           public byte[] Array
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2.ArrayPtr
    
        
    
        The native memory pointer of the pinned Array. All block native addresses are pointers into the memory
        ranging from ArrayPtr to ArrayPtr + Array.Length
    
        
    
        
        .. code-block:: csharp
    
           public IntPtr ArrayPtr
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolSlab2.IsActive
    
        
    
        True as long as the blocks from this slab are to be considered returnable to the pool. In order to shrink the
        memory pool size an entire slab must be removed. That is done by (1) setting IsActive to false and removing the
        slab from the pool's _slabs collection, (2) as each block currently in use is Return()ed to the pool it will
        be allowed to be garbage collected rather than re-pooled, and (3) when all block tracking objects are garbage
        collected and the slab is no longer references the slab will be garbage collected and the memory unpinned will
        be unpinned by the slab's Dispose.
    
        
    
        
        .. code-block:: csharp
    
           public bool IsActive
    

