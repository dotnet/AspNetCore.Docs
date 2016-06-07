

MemoryPoolSlab Class
====================






Slab tracking object used by the byte buffer memory pool. A slab is a large allocation which is divided into smaller blocks. The
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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolSlab : IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab.Create(System.Int32)
    
        
    
        
        :type length: System.Int32
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab
    
        
        .. code-block:: csharp
    
            public static MemoryPoolSlab Create(int length)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab.Finalize()
    
        
    
        
        .. code-block:: csharp
    
            protected void Finalize()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab.Array
    
        
    
        
        The managed memory allocated in the large object heap.
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Array
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab.ArrayPtr
    
        
    
        
        The native memory pointer of the pinned Array. All block native addresses are pointers into the memory 
        ranging from ArrayPtr to ArrayPtr + Array.Length
    
        
        :rtype: System.IntPtr
    
        
        .. code-block:: csharp
    
            public IntPtr ArrayPtr
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab.IsActive
    
        
    
        
        True as long as the blocks from this slab are to be considered returnable to the pool. In order to shrink the 
        memory pool size an entire slab must be removed. That is done by (1) setting IsActive to false and removing the
        slab from the pool's _slabs collection, (2) as each block currently in use is Return()ed to the pool it will
        be allowed to be garbage collected rather than re-pooled, and (3) when all block tracking objects are garbage
        collected and the slab is no longer references the slab will be garbage collected and the memory unpinned will
        be unpinned by the slab's Dispose.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsActive
    

