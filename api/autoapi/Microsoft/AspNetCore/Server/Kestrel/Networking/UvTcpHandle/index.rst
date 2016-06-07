

UvTcpHandle Class
=================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle`








Syntax
------

.. code-block:: csharp

    public class UvTcpHandle : UvStreamHandle, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.UvTcpHandle(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvTcpHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.Bind(Microsoft.AspNetCore.Server.Kestrel.ServerAddress)
    
        
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        .. code-block:: csharp
    
            public void Bind(ServerAddress address)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.CreateIPEndpoint(Microsoft.AspNetCore.Server.Kestrel.ServerAddress)
    
        
    
        
        Returns an :any:`System.Net.IPEndPoint` for the given host an port.
        If the host parameter isn't "localhost" or an IP address, use IPAddress.Any.
    
        
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
        :rtype: System.Net.IPEndPoint
    
        
        .. code-block:: csharp
    
            public static IPEndPoint CreateIPEndpoint(ServerAddress address)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.GetPeerIPEndPoint()
    
        
        :rtype: System.Net.IPEndPoint
    
        
        .. code-block:: csharp
    
            public IPEndPoint GetPeerIPEndPoint()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.GetSockIPEndPoint()
    
        
        :rtype: System.Net.IPEndPoint
    
        
        .. code-block:: csharp
    
            public IPEndPoint GetSockIPEndPoint()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.Init(Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle, System.Action<System.Action<System.IntPtr>, System.IntPtr>)
    
        
    
        
        :type loop: Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle
    
        
        :type queueCloseHandle: System.Action<System.Action`2>{System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}, System.IntPtr<System.IntPtr>}
    
        
        .. code-block:: csharp
    
            public void Init(UvLoopHandle loop, Action<Action<IntPtr>, IntPtr> queueCloseHandle)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.NoDelay(System.Boolean)
    
        
    
        
        :type enable: System.Boolean
    
        
        .. code-block:: csharp
    
            public void NoDelay(bool enable)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvTcpHandle.Open(System.IntPtr)
    
        
    
        
        :type hSocket: System.IntPtr
    
        
        .. code-block:: csharp
    
            public void Open(IntPtr hSocket)
    

