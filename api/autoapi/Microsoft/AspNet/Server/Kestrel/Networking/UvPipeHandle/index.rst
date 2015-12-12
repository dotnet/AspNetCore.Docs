

UvPipeHandle Class
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
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle`








Syntax
------

.. code-block:: csharp

   public class UvPipeHandle : UvStreamHandle, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Networking/UvPipeHandle.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle.UvPipeHandle(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public UvPipeHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle.Bind(System.String)
    
        
        
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           public void Bind(string name)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, System.Action<System.Action<System.IntPtr>, System.IntPtr>)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type queueCloseHandle: System.Action{System.Action{System.IntPtr},System.IntPtr}
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop, Action<Action<IntPtr>, IntPtr> queueCloseHandle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, System.Boolean)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type ipc: System.Boolean
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop, bool ipc)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle.PendingCount()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int PendingCount()
    

