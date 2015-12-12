

MemoryPoolIterator2 Struct
==========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct MemoryPoolIterator2





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/MemoryPoolIterator2.cs>`_





.. dn:structure:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.MemoryPoolIterator2(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2)
    
        
        
        
        :type block: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    
        
        .. code-block:: csharp
    
           public MemoryPoolIterator2(MemoryPoolBlock2 block)
    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.MemoryPoolIterator2(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2, System.Int32)
    
        
        
        
        :type block: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
        
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
           public MemoryPoolIterator2(MemoryPoolBlock2 block, int index)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.CopyTo(System.Byte[], System.Int32, System.Int32, out System.Int32)
    
        
        
        
        :type array: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type actual: System.Int32
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
    
        
        .. code-block:: csharp
    
           public MemoryPoolIterator2 CopyTo(byte[] array, int offset, int count, out int actual)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.GetArraySegment(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2)
    
        
        
        
        :type end: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
        :rtype: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public ArraySegment<byte> GetArraySegment(MemoryPoolIterator2 end)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.GetLength(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2)
    
        
        
        
        :type end: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int GetLength(MemoryPoolIterator2 end)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.GetString(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2)
    
        
        
        
        :type end: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GetString(MemoryPoolIterator2 end)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Peek()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Put(System.Byte)
    
        
    
        Save the data at the current location then move to the next available space.
    
        
        
        
        :param data: The byte to be saved.
        
        :type data: System.Byte
        :rtype: System.Boolean
        :return: true if the operation successes. false if can't find available space.
    
        
        .. code-block:: csharp
    
           public bool Put(byte data)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Seek(System.Int32)
    
        
        
        
        :type char0: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Seek(int char0)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Seek(System.Int32, System.Int32)
    
        
        
        
        :type char0: System.Int32
        
        
        :type char1: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Seek(int char0, int char1)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Seek(System.Int32, System.Int32, System.Int32)
    
        
        
        
        :type char0: System.Int32
        
        
        :type char1: System.Int32
        
        
        :type char2: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Seek(int char0, int char1, int char2)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Take()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Take()
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Block
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolBlock2
    
        
        .. code-block:: csharp
    
           public MemoryPoolBlock2 Block { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.Index
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Index { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.IsDefault
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsDefault { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2.IsEnd
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnd { get; }
    

