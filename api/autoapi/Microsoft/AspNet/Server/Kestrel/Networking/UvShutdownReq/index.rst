

UvShutdownReq Class
===================



.. contents:: 
   :local:



Summary
-------

Summary description for UvShutdownRequest





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvRequest`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq`








Syntax
------

.. code-block:: csharp

   public class UvShutdownReq : UvRequest, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Networking/UvShutdownReq.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq.UvShutdownReq(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public UvShutdownReq(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq.Shutdown(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Action<Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq, System.Int32, System.Object>, System.Object)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type callback: System.Action{Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq,System.Int32,System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void Shutdown(UvStreamHandle handle, Action<UvShutdownReq, int, object> callback, object state)
    

