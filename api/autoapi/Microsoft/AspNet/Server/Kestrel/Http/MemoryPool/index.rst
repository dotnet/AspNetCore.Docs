

MemoryPool Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.MemoryPool`








Syntax
------

.. code-block:: csharp

   public class MemoryPool : IMemoryPool





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/MemoryPool.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool.AllocByte(System.Int32)
    
        
        
        
        :type minimumSize: System.Int32
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public byte[] AllocByte(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool.AllocChar(System.Int32)
    
        
        
        
        :type minimumSize: System.Int32
        :rtype: System.Char[]
    
        
        .. code-block:: csharp
    
           public char[] AllocChar(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool.AllocSegment(System.Int32)
    
        
        
        
        :type minimumSize: System.Int32
        :rtype: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public ArraySegment<byte> AllocSegment(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool.FreeByte(System.Byte[])
    
        
        
        
        :type memory: System.Byte[]
    
        
        .. code-block:: csharp
    
           public void FreeByte(byte[] memory)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool.FreeChar(System.Char[])
    
        
        
        
        :type memory: System.Char[]
    
        
        .. code-block:: csharp
    
           public void FreeChar(char[] memory)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool.FreeSegment(System.ArraySegment<System.Byte>)
    
        
        
        
        :type segment: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public void FreeSegment(ArraySegment<byte> segment)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPool.Empty
    
        
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public byte[] Empty { get; }
    

