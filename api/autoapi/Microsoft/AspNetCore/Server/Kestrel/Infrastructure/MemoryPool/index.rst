

MemoryPool Class
================






Used to allocate and distribute re-usable blocks of memory.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool`








Syntax
------

.. code-block:: csharp

    public class MemoryPool : IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool.Lease(System.Int32)
    
        
    
        
        Called to take a block from the pool.
    
        
    
        
        :param minimumSize: The block returned must be at least this size. It may be larger than this minimum size, and if so,
            the caller may write to the block's entire size rather than being limited to the minumumSize requested.
        
        :type minimumSize: System.Int32
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
        :return: The block that is reserved for the called. It must be passed to Return when it is no longer being used.
    
        
        .. code-block:: csharp
    
            public MemoryPoolBlock Lease(int minimumSize = 4032)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool.Return(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock)
    
        
    
        
        Called to return a block to the pool. Once Return has been called the memory no longer belongs to the caller, and
        Very Bad Things will happen if the memory is read of modified subsequently. If a caller fails to call Return and the
        block tracking object is garbage collected, the block tracking object's finalizer will automatically re-create and return
        a new tracking object into the pool. This will only happen if there is a bug in the server, however it is necessary to avoid
        leaving "dead zones" in the slab due to lost block tracking objects.
    
        
    
        
        :param block: The block to return. It must have been acquired by calling Lease on the same memory pool instance.
        
        :type block: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public void Return(MemoryPoolBlock block)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool.MaxPooledBlockLength
    
        
    
        
        Max allocation block size for pooled blocks, 
        larger values can be leased but they will be disposed after use rather than returned to the pool.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int MaxPooledBlockLength = 4032
    

