

UvShutdownReq Class
===================






Summary description for UvShutdownRequest


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvRequest`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq`








Syntax
------

.. code-block:: csharp

    public class UvShutdownReq : UvRequest, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq.UvShutdownReq(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvShutdownReq(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq.Init(Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle)
    
        
    
        
        :type loop: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
            public void Init(UvLoopHandle loop)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq.Shutdown(Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle, System.Action<Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq, System.Int32, System.Object>, System.Object)
    
        
    
        
        :type handle: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle
    
        
        :type callback: System.Action<System.Action`3>{Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq<Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvShutdownReq>, System.Int32<System.Int32>, System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Shutdown(UvStreamHandle handle, Action<UvShutdownReq, int, object> callback, object state)
    

