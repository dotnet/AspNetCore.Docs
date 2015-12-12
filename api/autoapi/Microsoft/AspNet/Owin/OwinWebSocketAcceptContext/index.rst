

OwinWebSocketAcceptContext Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.WebSocketAcceptContext`
* :dn:cls:`Microsoft.AspNet.Owin.OwinWebSocketAcceptContext`








Syntax
------

.. code-block:: csharp

   public class OwinWebSocketAcceptContext : WebSocketAcceptContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Owin/WebSockets/OwinWebSocketAcceptContext.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAcceptContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAcceptContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinWebSocketAcceptContext.OwinWebSocketAcceptContext()
    
        
    
        
        .. code-block:: csharp
    
           public OwinWebSocketAcceptContext()
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinWebSocketAcceptContext.OwinWebSocketAcceptContext(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type options: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public OwinWebSocketAcceptContext(IDictionary<string, object> options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAcceptContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Owin.OwinWebSocketAcceptContext.Options
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> Options { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinWebSocketAcceptContext.SubProtocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string SubProtocol { get; set; }
    

