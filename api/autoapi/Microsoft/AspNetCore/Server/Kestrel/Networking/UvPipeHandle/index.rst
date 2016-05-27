

UvPipeHandle Class
==================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle`








Syntax
------

.. code-block:: csharp

    public class UvPipeHandle : UvStreamHandle, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle.UvPipeHandle(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvPipeHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle.Bind(System.String)
    
        
    
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public void Bind(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle.Init(Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle, System.Action<System.Action<System.IntPtr>, System.IntPtr>, System.Boolean)
    
        
    
        
        :type loop: Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle
    
        
        :type queueCloseHandle: System.Action<System.Action`2>{System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}, System.IntPtr<System.IntPtr>}
    
        
        :type ipc: System.Boolean
    
        
        .. code-block:: csharp
    
            public void Init(UvLoopHandle loop, Action<Action<IntPtr>, IntPtr> queueCloseHandle, bool ipc = false)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle.PendingCount()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int PendingCount()
    

