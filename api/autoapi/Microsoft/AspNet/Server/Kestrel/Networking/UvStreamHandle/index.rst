

UvStreamHandle Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle`








Syntax
------

.. code-block:: csharp

   public abstract class UvStreamHandle : UvHandle, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Networking/UvStreamHandle.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle.UvStreamHandle(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           protected UvStreamHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle.Accept(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           public void Accept(UvStreamHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle.Listen(System.Int32, System.Action<Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Exception, System.Object>, System.Object)
    
        
        
        
        :type backlog: System.Int32
        
        
        :type callback: System.Action{Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle,System.Int32,System.Exception,System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void Listen(int backlog, Action<UvStreamHandle, int, Exception, object> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle.ReadStart(System.Func<Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Object, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t>, System.Action<Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Object>, System.Object)
    
        
        
        
        :type allocCallback: System.Func{Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle,System.Int32,System.Object,Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t}
        
        
        :type readCallback: System.Action{Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle,System.Int32,System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void ReadStart(Func<UvStreamHandle, int, object, Libuv.uv_buf_t> allocCallback, Action<UvStreamHandle, int, object> readCallback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle.ReadStop()
    
        
    
        
        .. code-block:: csharp
    
           public void ReadStop()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle.TryWrite(Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t)
    
        
        
        
        :type buf: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int TryWrite(Libuv.uv_buf_t buf)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle._allocCallback
    
        
    
        
        .. code-block:: csharp
    
           public Func<UvStreamHandle, int, object, Libuv.uv_buf_t> _allocCallback
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle._listenCallback
    
        
    
        
        .. code-block:: csharp
    
           public Action<UvStreamHandle, int, Exception, object> _listenCallback
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle._listenState
    
        
    
        
        .. code-block:: csharp
    
           public object _listenState
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle._readCallback
    
        
    
        
        .. code-block:: csharp
    
           public Action<UvStreamHandle, int, object> _readCallback
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle._readState
    
        
    
        
        .. code-block:: csharp
    
           public object _readState
    

