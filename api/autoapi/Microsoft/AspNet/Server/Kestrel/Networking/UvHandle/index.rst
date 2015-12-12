

UvHandle Class
==============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvHandle`








Syntax
------

.. code-block:: csharp

   public abstract class UvHandle : UvMemory, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Networking/UvHandle.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle.UvHandle(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           protected UvHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle.CreateHandle(Microsoft.AspNet.Server.Kestrel.Networking.Libuv, System.Int32, System.Int32, System.Action<System.Action<System.IntPtr>, System.IntPtr>)
    
        
        
        
        :type uv: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
        
        
        :type threadId: System.Int32
        
        
        :type size: System.Int32
        
        
        :type queueCloseHandle: System.Action{System.Action{System.IntPtr},System.IntPtr}
    
        
        .. code-block:: csharp
    
           protected void CreateHandle(Libuv uv, int threadId, int size, Action<Action<IntPtr>, IntPtr> queueCloseHandle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle.Reference()
    
        
    
        
        .. code-block:: csharp
    
           public void Reference()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle.Unreference()
    
        
    
        
        .. code-block:: csharp
    
           public void Unreference()
    

