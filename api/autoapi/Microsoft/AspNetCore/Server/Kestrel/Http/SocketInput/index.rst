

SocketInput Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput`








Syntax
------

.. code-block:: csharp

    public class SocketInput : ICriticalNotifyCompletion, INotifyCompletion, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.IsCompleted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCompleted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.RemoteIntakeFin
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RemoteIntakeFin
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.SocketInput(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool)
    
        
    
        
        :type memory: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    
        
        :type threadPool: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool
    
        
        .. code-block:: csharp
    
            public SocketInput(MemoryPool memory, IThreadPool threadPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.AbortAwaiting()
    
        
    
        
        .. code-block:: csharp
    
            public void AbortAwaiting()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.CompleteAwaiting()
    
        
    
        
        .. code-block:: csharp
    
            public void CompleteAwaiting()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.ConsumingComplete(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type consumed: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :type examined: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public void ConsumingComplete(MemoryPoolIterator consumed, MemoryPoolIterator examined)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.ConsumingStart()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator ConsumingStart()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.GetAwaiter()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
            public SocketInput GetAwaiter()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.GetResult()
    
        
    
        
        .. code-block:: csharp
    
            public void GetResult()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.IncomingComplete(System.Int32, System.Exception)
    
        
    
        
        :type count: System.Int32
    
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
            public void IncomingComplete(int count, Exception error)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.IncomingData(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public void IncomingData(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.IncomingDeferred()
    
        
    
        
        .. code-block:: csharp
    
            public void IncomingDeferred()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.IncomingFin()
    
        
    
        
        .. code-block:: csharp
    
            public void IncomingFin()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.IncomingStart()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public MemoryPoolBlock IncomingStart()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.OnCompleted(System.Action)
    
        
    
        
        :type continuation: System.Action
    
        
        .. code-block:: csharp
    
            public void OnCompleted(Action continuation)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput.UnsafeOnCompleted(System.Action)
    
        
    
        
        :type continuation: System.Action
    
        
        .. code-block:: csharp
    
            public void UnsafeOnCompleted(Action continuation)
    

