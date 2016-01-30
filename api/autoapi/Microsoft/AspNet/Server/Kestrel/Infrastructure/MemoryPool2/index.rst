

MemoryPool2 Class
=================



.. contents:: 
   :local:



Summary
-------

Used to allocate and distribute re-usable blocks of memory.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2`








Syntax
------

.. code-block:: csharp

   public class MemoryPool2 : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/MemoryPool2.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2.Lease(System.Int32)
    
        
    
        Called to take a block from the pool.
    
        
        
        
        :param minimumSize: The block returned must be at least this size. It may be larger than this minimum size, and if so,
            the caller may write to the block's entire size rather than being limited to the minumumSize requested.
        
        :type minimumSize: System.Int32
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
        :return: The block that is reserved for the called. It must be passed to Return when it is no longer being used.
    
        
        .. code-block:: csharp
    
           public MemoryPoolBlock2 Lease(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2.Return(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2)
    
        
    
        Called to return a block to the pool. Once Return has been called the memory no longer belongs to the caller, and
        Very Bad Things will happen if the memory is read of modified subsequently. If a caller fails to call Return and the
        block tracking object is garbage collected, the block tracking object's finalizer will automatically re-create and return
        a new tracking object into the pool. This will only happen if there is a bug in the server, however it is necessary to avoid
        leaving "dead zones" in the slab due to lost block tracking objects.
    
        
        
        
        :param block: The block to return. It must have been acquired by calling Lease on the same memory pool instance.
        
        :type block: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    
        
        .. code-block:: csharp
    
           public void Return(MemoryPoolBlock2 block)
    

