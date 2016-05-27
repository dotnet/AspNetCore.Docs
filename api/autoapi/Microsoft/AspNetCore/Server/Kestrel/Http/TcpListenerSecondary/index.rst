

TcpListenerSecondary Class
==========================






An implementation of :any:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary` using TCP sockets.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.TcpListenerSecondary`








Syntax
------

.. code-block:: csharp

    public class TcpListenerSecondary : ListenerSecondary, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListenerSecondary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListenerSecondary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListenerSecondary.TcpListenerSecondary(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            public TcpListenerSecondary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListenerSecondary.CreateAcceptSocket()
    
        
    
        
        Creates a socket which can be used to accept an incoming connection
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected override UvStreamHandle CreateAcceptSocket()
    

