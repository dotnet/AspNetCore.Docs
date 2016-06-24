

MemoryPool Class
================






Used to allocate and distribute re-usable blocks of memory.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool`








Syntax
------

.. code-block:: csharp

    public class MemoryPool : IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool.Lease()
    
        
    
        
        Called to take a block from the pool.
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
        :return: The block that is reserved for the called. It must be passed to Return when it is no longer being used.
    
        
        .. code-block:: csharp
    
            public MemoryPoolBlock Lease()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool.Return(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock)
    
        
    
        
        Called to return a block to the pool. Once Return has been called the memory no longer belongs to the caller, and
        Very Bad Things will happen if the memory is read of modified subsequently. If a caller fails to call Return and the
        block tracking object is garbage collected, the block tracking object's finalizer will automatically re-create and return
        a new tracking object into the pool. This will only happen if there is a bug in the server, however it is necessary to avoid
        leaving "dead zones" in the slab due to lost block tracking objects.
    
        
    
        
        :param block: The block to return. It must have been acquired by calling Lease on the same memory pool instance.
        
        :type block: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public void Return(MemoryPoolBlock block)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool.MaxPooledBlockLength
    
        
    
        
        Max allocation block size for pooled blocks, 
        larger values can be leased but they will be disposed after use rather than returned to the pool.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int MaxPooledBlockLength = 4032
    

