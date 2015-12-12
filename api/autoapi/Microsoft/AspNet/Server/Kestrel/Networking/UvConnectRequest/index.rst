

UvConnectRequest Class
======================



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
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest`








Syntax
------

.. code-block:: csharp

   public class UvConnectRequest : UvRequest, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Networking/UvConnectRequest.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest.UvConnectRequest(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public UvConnectRequest(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest.Connect(Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle, System.String, System.Action<Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest, System.Int32, System.Exception, System.Object>, System.Object)
    
        
        
        
        :type pipe: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle
        
        
        :type name: System.String
        
        
        :type callback: System.Action{Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest,System.Int32,System.Exception,System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void Connect(UvPipeHandle pipe, string name, Action<UvConnectRequest, int, Exception, object> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop)
    

