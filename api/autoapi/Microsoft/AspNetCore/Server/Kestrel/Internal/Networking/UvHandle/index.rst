

UvHandle Class
==============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle`








Syntax
------

.. code-block:: csharp

    public abstract class UvHandle : UvMemory, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle.UvHandle(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            protected UvHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle.CreateHandle(Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.Libuv, System.Int32, System.Int32, System.Action<System.Action<System.IntPtr>, System.IntPtr>)
    
        
    
        
        :type uv: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.Libuv
    
        
        :type threadId: System.Int32
    
        
        :type size: System.Int32
    
        
        :type queueCloseHandle: System.Action<System.Action`2>{System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}, System.IntPtr<System.IntPtr>}
    
        
        .. code-block:: csharp
    
            protected void CreateHandle(Libuv uv, int threadId, int size, Action<Action<IntPtr>, IntPtr> queueCloseHandle)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle.Reference()
    
        
    
        
        .. code-block:: csharp
    
            public void Reference()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvHandle.Unreference()
    
        
    
        
        .. code-block:: csharp
    
            public void Unreference()
    

