

Microsoft.AspNetCore.Server.Kestrel.Infrastructure Namespace
============================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/IKestrelTrace/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/IThreadPool/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/LoggingThreadPool/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/MemoryPool/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/MemoryPoolBlock/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/MemoryPoolIterator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/MemoryPoolIteratorExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/MemoryPoolSlab/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Infrastructure/TaskUtilities/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure


    .. rubric:: Classes


    class :dn:cls:`LoggingThreadPool`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool

        


    class :dn:cls:`MemoryPool`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool

        
        Used to allocate and distribute re-usable blocks of memory.


    class :dn:cls:`MemoryPoolBlock`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock

        
        Block tracking object used by the byte buffer memory pool. A slab is a large allocation which is divided into smaller blocks. The
        individual blocks are then treated as independant array segments.


    class :dn:cls:`MemoryPoolIteratorExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions

        


    class :dn:cls:`MemoryPoolSlab`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab

        
        Slab tracking object used by the byte buffer memory pool. A slab is a large allocation which is divided into smaller blocks. The
        individual blocks are then treated as independant array segments.


    class :dn:cls:`TaskUtilities`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.TaskUtilities

        


    .. rubric:: Structures


    struct :dn:struct:`MemoryPoolIterator`
        .. object: type=struct name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator

        


    .. rubric:: Interfaces


    interface :dn:iface:`IKestrelTrace`
        .. object: type=interface name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace

        


    interface :dn:iface:`IThreadPool`
        .. object: type=interface name=Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool

        


