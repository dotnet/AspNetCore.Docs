

UvConnectRequest Class
======================






Summary description for UvWriteRequest


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest`








Syntax
------

.. code-block:: csharp

    public class UvConnectRequest : UvRequest, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest.UvConnectRequest(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvConnectRequest(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest.Connect(Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle, System.String, System.Action<Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest, System.Int32, System.Exception, System.Object>, System.Object)
    
        
    
        
        :type pipe: Microsoft.AspNetCore.Server.Kestrel.Networking.UvPipeHandle
    
        
        :type name: System.String
    
        
        :type callback: System.Action<System.Action`4>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest<Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest>, System.Int32<System.Int32>, System.Exception<System.Exception>, System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Connect(UvPipeHandle pipe, string name, Action<UvConnectRequest, int, Exception, object> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvConnectRequest.Init(Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle)
    
        
    
        
        :type loop: Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
            public void Init(UvLoopHandle loop)
    

