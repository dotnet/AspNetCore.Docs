

ChunkWriter Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ChunkWriter`








Syntax
------

.. code-block:: csharp

    public class ChunkWriter








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ChunkWriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ChunkWriter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ChunkWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ChunkWriter.BeginChunkBytes(System.Int32)
    
        
    
        
        :type dataCount: System.Int32
        :rtype: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public static ArraySegment<byte> BeginChunkBytes(int dataCount)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ChunkWriter.WriteBeginChunkBytes(ref Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator, System.Int32)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        :type dataCount: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static int WriteBeginChunkBytes(ref MemoryPoolIterator start, int dataCount)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ChunkWriter.WriteEndChunkBytes(ref Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public static void WriteEndChunkBytes(ref MemoryPoolIterator start)
    

