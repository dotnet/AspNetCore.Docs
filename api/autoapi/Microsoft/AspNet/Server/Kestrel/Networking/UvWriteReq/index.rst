

UvWriteReq Class
================



.. contents:: 
   :local:



Summary
-------

Summary description for UvWriteRequest





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvRequest`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq`








Syntax
------

.. code-block:: csharp

   public class UvWriteReq : UvRequest, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Networking/UvWriteReq.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq.UvWriteReq(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public UvWriteReq(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq.Write(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.ArraySegment<System.ArraySegment<System.Byte>>, System.Action<Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq, System.Int32, System.Exception, System.Object>, System.Object)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type bufs: System.ArraySegment{System.ArraySegment{System.Byte}}
        
        
        :type callback: System.Action{Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq,System.Int32,System.Exception,System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void Write(UvStreamHandle handle, ArraySegment<ArraySegment<byte>> bufs, Action<UvWriteReq, int, Exception, object> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq.Write2(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.ArraySegment<System.ArraySegment<System.Byte>>, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Action<Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq, System.Int32, System.Exception, System.Object>, System.Object)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type bufs: System.ArraySegment{System.ArraySegment{System.Byte}}
        
        
        :type sendHandle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type callback: System.Action{Microsoft.AspNet.Server.Kestrel.Networking.UvWriteReq,System.Int32,System.Exception,System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void Write2(UvStreamHandle handle, ArraySegment<ArraySegment<byte>> bufs, UvStreamHandle sendHandle, Action<UvWriteReq, int, Exception, object> callback, object state)
    

