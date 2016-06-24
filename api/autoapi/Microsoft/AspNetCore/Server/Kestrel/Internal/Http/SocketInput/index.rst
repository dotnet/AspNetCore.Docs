

SocketInput Class
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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput`








Syntax
------

.. code-block:: csharp

    public class SocketInput : ICriticalNotifyCompletion, INotifyCompletion, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.SocketInput(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool, Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl)
    
        
    
        
        :type memory: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool
    
        
        :type threadPool: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool
    
        
        :type bufferSizeControl: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl
    
        
        .. code-block:: csharp
    
            public SocketInput(MemoryPool memory, IThreadPool threadPool, IBufferSizeControl bufferSizeControl = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.AbortAwaiting()
    
        
    
        
        .. code-block:: csharp
    
            public void AbortAwaiting()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.CompleteAwaiting()
    
        
    
        
        .. code-block:: csharp
    
            public void CompleteAwaiting()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.ConsumingComplete(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type consumed: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        :type examined: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public void ConsumingComplete(MemoryPoolIterator consumed, MemoryPoolIterator examined)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.ConsumingStart()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator ConsumingStart()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.GetAwaiter()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput
    
        
        .. code-block:: csharp
    
            public SocketInput GetAwaiter()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.GetResult()
    
        
    
        
        .. code-block:: csharp
    
            public void GetResult()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.IncomingComplete(System.Int32, System.Exception)
    
        
    
        
        :type count: System.Int32
    
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
            public void IncomingComplete(int count, Exception error)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.IncomingData(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public void IncomingData(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.IncomingDeferred()
    
        
    
        
        .. code-block:: csharp
    
            public void IncomingDeferred()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.IncomingFin()
    
        
    
        
        .. code-block:: csharp
    
            public void IncomingFin()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.IncomingStart()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolBlock
    
        
        .. code-block:: csharp
    
            public MemoryPoolBlock IncomingStart()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.OnCompleted(System.Action)
    
        
    
        
        :type continuation: System.Action
    
        
        .. code-block:: csharp
    
            public void OnCompleted(Action continuation)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.UnsafeOnCompleted(System.Action)
    
        
    
        
        :type continuation: System.Action
    
        
        .. code-block:: csharp
    
            public void UnsafeOnCompleted(Action continuation)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.IsCompleted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCompleted { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput.RemoteIntakeFin
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RemoteIntakeFin { get; set; }
    

