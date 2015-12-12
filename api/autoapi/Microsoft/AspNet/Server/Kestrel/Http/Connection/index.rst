

Connection Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Connection`








Syntax
------

.. code-block:: csharp

   public class Connection : ConnectionContext, IConnectionControl





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/Connection.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Connection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Connection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.Connection.Connection(Microsoft.AspNet.Server.Kestrel.Http.ListenerContext, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext
        
        
        :type socket: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           public Connection(ListenerContext context, UvStreamHandle socket)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Connection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Connection.Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl.End(Microsoft.AspNet.Server.Kestrel.Http.ProduceEndType)
    
        
        
        
        :type endType: Microsoft.AspNet.Server.Kestrel.Http.ProduceEndType
    
        
        .. code-block:: csharp
    
           void IConnectionControl.End(ProduceEndType endType)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Connection.Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl.Pause()
    
        
    
        
        .. code-block:: csharp
    
           void IConnectionControl.Pause()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Connection.Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl.Resume()
    
        
    
        
        .. code-block:: csharp
    
           void IConnectionControl.Resume()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Connection.Start()
    
        
    
        
        .. code-block:: csharp
    
           public void Start()
    

