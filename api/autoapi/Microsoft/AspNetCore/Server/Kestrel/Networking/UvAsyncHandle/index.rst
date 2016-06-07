

UvAsyncHandle Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Networking`
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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle`








Syntax
------

.. code-block:: csharp

    public class UvAsyncHandle : UvHandle, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle.UvAsyncHandle(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvAsyncHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle.Init(Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle, System.Action, System.Action<System.Action<System.IntPtr>, System.IntPtr>)
    
        
    
        
        :type loop: Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle
    
        
        :type callback: System.Action
    
        
        :type queueCloseHandle: System.Action<System.Action`2>{System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}, System.IntPtr<System.IntPtr>}
    
        
        .. code-block:: csharp
    
            public void Init(UvLoopHandle loop, Action callback, Action<Action<IntPtr>, IntPtr> queueCloseHandle)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvAsyncHandle.Send()
    
        
    
        
        .. code-block:: csharp
    
            public void Send()
    

