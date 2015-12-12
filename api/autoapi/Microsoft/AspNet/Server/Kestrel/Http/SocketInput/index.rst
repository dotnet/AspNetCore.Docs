

SocketInput Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.SocketInput`








Syntax
------

.. code-block:: csharp

   public class SocketInput : ICriticalNotifyCompletion, INotifyCompletion





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/SocketInput.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.SocketInput(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2)
    
        
        
        
        :type memory: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2
    
        
        .. code-block:: csharp
    
           public SocketInput(MemoryPool2 memory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.ConsumingComplete(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2, Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2)
    
        
        
        
        :type consumed: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
        
        
        :type examined: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
    
        
        .. code-block:: csharp
    
           public void ConsumingComplete(MemoryPoolIterator2 consumed, MemoryPoolIterator2 examined)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.ConsumingStart()
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
    
        
        .. code-block:: csharp
    
           public MemoryPoolIterator2 ConsumingStart()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.GetAwaiter()
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
           public SocketInput GetAwaiter()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.GetResult()
    
        
    
        
        .. code-block:: csharp
    
           public void GetResult()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.IncomingComplete(System.Int32, System.Exception)
    
        
        
        
        :type count: System.Int32
        
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public void IncomingComplete(int count, Exception error)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.IncomingStart(System.Int32)
    
        
        
        
        :type minimumSize: System.Int32
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.IncomingBuffer
    
        
        .. code-block:: csharp
    
           public SocketInput.IncomingBuffer IncomingStart(int minimumSize)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.OnCompleted(System.Action)
    
        
        
        
        :type continuation: System.Action
    
        
        .. code-block:: csharp
    
           public void OnCompleted(Action continuation)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.Skip(System.Int32)
    
        
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public void Skip(int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.Take(System.Int32)
    
        
        
        
        :type count: System.Int32
        :rtype: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public ArraySegment<byte> Take(int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.UnsafeOnCompleted(System.Action)
    
        
        
        
        :type continuation: System.Action
    
        
        .. code-block:: csharp
    
           public void UnsafeOnCompleted(Action continuation)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.Buffer
    
        
        :rtype: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public ArraySegment<byte> Buffer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.IsCompleted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsCompleted { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.SocketInput.RemoteIntakeFin
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RemoteIntakeFin { get; set; }
    

