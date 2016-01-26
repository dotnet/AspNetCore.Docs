

PipeListenerSecondary Class
===========================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary` using UNIX sockets.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.PipeListenerSecondary`








Syntax
------

.. code-block:: csharp

   public class PipeListenerSecondary : ListenerSecondary, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/PipeListenerSecondary.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.PipeListenerSecondary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.PipeListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.PipeListenerSecondary.PipeListenerSecondary(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type serviceContext: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           public PipeListenerSecondary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.PipeListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.PipeListenerSecondary.CreateAcceptSocket()
    
        
    
        Creates a socket which can be used to accept an incoming connection
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected override UvStreamHandle CreateAcceptSocket()
    

