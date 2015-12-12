

TcpListenerSecondary Class
==========================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary` using TCP sockets.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.TcpListenerSecondary`








Syntax
------

.. code-block:: csharp

   public class TcpListenerSecondary : ListenerSecondary, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/TcpListenerSecondary.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerSecondary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerSecondary.TcpListenerSecondary(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type serviceContext: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           public TcpListenerSecondary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerSecondary.CreateAcceptSocket()
    
        
    
        Creates a socket which can be used to accept an incoming connection
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected override UvStreamHandle CreateAcceptSocket()
    

