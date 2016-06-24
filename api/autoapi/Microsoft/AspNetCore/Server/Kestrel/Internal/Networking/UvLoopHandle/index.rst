

UvLoopHandle Class
==================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle`








Syntax
------

.. code-block:: csharp

    public class UvLoopHandle : UvMemory, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle.UvLoopHandle(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvLoopHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle.Init(Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.Libuv)
    
        
    
        
        :type uv: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.Libuv
    
        
        .. code-block:: csharp
    
            public void Init(Libuv uv)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle.Run(System.Int32)
    
        
    
        
        :type mode: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Run(int mode = 0)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle.Stop()
    
        
    
        
        .. code-block:: csharp
    
            public void Stop()
    

