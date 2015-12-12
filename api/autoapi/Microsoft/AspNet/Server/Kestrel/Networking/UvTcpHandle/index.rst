

UvTcpHandle Class
=================



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
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle`








Syntax
------

.. code-block:: csharp

   public class UvTcpHandle : UvStreamHandle, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Networking/UvTcpHandle.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle.UvTcpHandle(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public UvTcpHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle.Bind(Microsoft.AspNet.Server.Kestrel.ServerAddress)
    
        
        
        
        :type address: Microsoft.AspNet.Server.Kestrel.ServerAddress
    
        
        .. code-block:: csharp
    
           public void Bind(ServerAddress address)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle.CreateIPEndpoint(Microsoft.AspNet.Server.Kestrel.ServerAddress)
    
        
    
        Returns an :any:`System.Net.IPEndPoint` for the given host an port.
        If the host parameter isn't "localhost" or an IP address, use IPAddress.Any.
    
        
        
        
        :type address: Microsoft.AspNet.Server.Kestrel.ServerAddress
        :rtype: System.Net.IPEndPoint
    
        
        .. code-block:: csharp
    
           public static IPEndPoint CreateIPEndpoint(ServerAddress address)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle.Init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, System.Action<System.Action<System.IntPtr>, System.IntPtr>)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type queueCloseHandle: System.Action{System.Action{System.IntPtr},System.IntPtr}
    
        
        .. code-block:: csharp
    
           public void Init(UvLoopHandle loop, Action<Action<IntPtr>, IntPtr> queueCloseHandle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle.NoDelay(System.Boolean)
    
        
        
        
        :type enable: System.Boolean
    
        
        .. code-block:: csharp
    
           public void NoDelay(bool enable)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle.Open(System.IntPtr)
    
        
        
        
        :type hSocket: System.IntPtr
    
        
        .. code-block:: csharp
    
           public void Open(IntPtr hSocket)
    

