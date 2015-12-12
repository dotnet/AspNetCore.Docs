

ConnectionContext Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext`








Syntax
------

.. code-block:: csharp

   public class ConnectionContext : ListenerContext





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/ConnectionContext.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext.ConnectionContext()
    
        
    
        
        .. code-block:: csharp
    
           public ConnectionContext()
    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext.ConnectionContext(Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext
    
        
        .. code-block:: csharp
    
           public ConnectionContext(ConnectionContext context)
    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext.ConnectionContext(Microsoft.AspNet.Server.Kestrel.Http.ListenerContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext
    
        
        .. code-block:: csharp
    
           public ConnectionContext(ListenerContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext.ConnectionControl
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl
    
        
        .. code-block:: csharp
    
           public IConnectionControl ConnectionControl { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext.SocketInput
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
           public SocketInput SocketInput { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext.SocketOutput
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput
    
        
        .. code-block:: csharp
    
           public ISocketOutput SocketOutput { get; set; }
    

