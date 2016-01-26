

UvAsyncHandle Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle`








Syntax
------

.. code-block:: csharp

   public class UvAsyncHandle : UvHandle, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Networking/UvAsyncHandle.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle.UvAsyncHandle(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public UvAsyncHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle.DangerousClose()
    
        
    
        
        .. code-block:: csharp
    
           public void DangerousClose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, System.Action)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type callback: System.Action
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop, Action callback)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle.Send()
    
        
    
        
        .. code-block:: csharp
    
           public void Send()
    

