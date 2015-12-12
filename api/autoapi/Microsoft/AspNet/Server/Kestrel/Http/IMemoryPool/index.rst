

IMemoryPool Interface
=====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IMemoryPool





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/IMemoryPool.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool

Methods
-------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool.AllocByte(System.Int32)
    
        
        
        
        :type minimumSize: System.Int32
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           byte[] AllocByte(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool.AllocChar(System.Int32)
    
        
        
        
        :type minimumSize: System.Int32
        :rtype: System.Char[]
    
        
        .. code-block:: csharp
    
           char[] AllocChar(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool.AllocSegment(System.Int32)
    
        
    
        Acquires a sub-segment of a larger memory allocation. Used for async sends of write-behind
        buffers to reduce number of array segments pinned
    
        
        
        
        :param minimumSize: The smallest length of the ArraySegment.Count that may be returned
        
        :type minimumSize: System.Int32
        :rtype: System.ArraySegment{System.Byte}
        :return: An array segment which is a sub-block of a larger allocation
    
        
        .. code-block:: csharp
    
           ArraySegment<byte> AllocSegment(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool.FreeByte(System.Byte[])
    
        
        
        
        :type memory: System.Byte[]
    
        
        .. code-block:: csharp
    
           void FreeByte(byte[] memory)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool.FreeChar(System.Char[])
    
        
        
        
        :type memory: System.Char[]
    
        
        .. code-block:: csharp
    
           void FreeChar(char[] memory)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool.FreeSegment(System.ArraySegment<System.Byte>)
    
        
    
        Frees a sub-segment of a larger memory allocation produced by AllocSegment. The original ArraySegment
        must be frees exactly once and must have the same offset and count that was returned by the Alloc.
        If a segment is not freed it won't be re-used and has the same effect as a memory leak, so callers must be
        implemented exactly correctly.
    
        
        
        
        :param segment: The sub-block that was originally returned by a call to AllocSegment.
        
        :type segment: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           void FreeSegment(ArraySegment<byte> segment)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool.Empty
    
        
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           byte[] Empty { get; }
    

