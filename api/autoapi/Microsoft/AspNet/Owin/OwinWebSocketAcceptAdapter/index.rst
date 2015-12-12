

OwinWebSocketAcceptAdapter Class
================================



.. contents:: 
   :local:



Summary
-------

This adapts the OWIN WebSocket accept flow to match the ASP.NET WebSocket Accept flow.
This enables ASP.NET components to use WebSockets on OWIN based servers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Owin.OwinWebSocketAcceptAdapter`








Syntax
------

.. code-block:: csharp

   public class OwinWebSocketAcceptAdapter





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Owin/WebSockets/OwinWebSocketAcceptAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAcceptAdapter

Methods
-------

.. dn:class:: Microsoft.AspNet.Owin.OwinWebSocketAcceptAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Owin.OwinWebSocketAcceptAdapter.AdaptWebSockets(System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>)
    
        
        
        
        :type next: System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}
        :rtype: System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public static Func<IDictionary<string, object>, Task> AdaptWebSockets(Func<IDictionary<string, object>, Task> next)
    

