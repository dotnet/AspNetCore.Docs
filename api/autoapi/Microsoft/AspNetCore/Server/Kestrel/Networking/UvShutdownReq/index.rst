

UvShutdownReq Class
===================






Summary description for UvShutdownRequest


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq`








Syntax
------

.. code-block:: csharp

    public class UvShutdownReq : UvRequest, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq.UvShutdownReq(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvShutdownReq(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq.Init(Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle)
    
        
    
        
        :type loop: Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
            public void Init(UvLoopHandle loop)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq.Shutdown(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Action<Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq, System.Int32, System.Object>, System.Object)
    
        
    
        
        :type handle: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :type callback: System.Action<System.Action`3>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq<Microsoft.AspNetCore.Server.Kestrel.Networking.UvShutdownReq>, System.Int32<System.Int32>, System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Shutdown(UvStreamHandle handle, Action<UvShutdownReq, int, object> callback, object state)
    

