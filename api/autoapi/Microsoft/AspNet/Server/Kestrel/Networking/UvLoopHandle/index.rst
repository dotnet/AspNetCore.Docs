

UvLoopHandle Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle`








Syntax
------

.. code-block:: csharp

   public class UvLoopHandle : UvHandle, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Networking/UvLoopHandle.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle.UvLoopHandle(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public UvLoopHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle.Init(Microsoft.AspNet.Server.Kestrel.Networking.Libuv)
    
        
        
        
        :type uv: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
    
        
        .. code-block:: csharp
    
           public void Init(Libuv uv)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle.Run(System.Int32)
    
        
        
        
        :type mode: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Run(int mode = 0)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle.Stop()
    
        
    
        
        .. code-block:: csharp
    
           public void Stop()
    

