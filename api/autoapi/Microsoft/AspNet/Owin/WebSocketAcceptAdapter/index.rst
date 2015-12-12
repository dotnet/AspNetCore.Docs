

WebSocketAcceptAdapter Class
============================



.. contents:: 
   :local:



Summary
-------

This adapts the ASP.NET WebSocket Accept flow to match the OWIN WebSocket accept flow.
This enables OWIN based components to use WebSockets on ASP.NET servers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Owin.WebSocketAcceptAdapter`








Syntax
------

.. code-block:: csharp

   public class WebSocketAcceptAdapter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Owin/WebSockets/WebSocketAcceptAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.WebSocketAcceptAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Owin.WebSocketAcceptAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Owin.WebSocketAcceptAdapter.WebSocketAcceptAdapter(System.Collections.Generic.IDictionary<System.String, System.Object>, System.Func<Microsoft.AspNet.Http.Features.WebSocketAcceptContext, System.Threading.Tasks.Task<System.Net.WebSockets.WebSocket>>)
    
        
        
        
        :type env: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type accept: System.Func{Microsoft.AspNet.Http.Features.WebSocketAcceptContext,System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}}
    
        
        .. code-block:: csharp
    
           public WebSocketAcceptAdapter(IDictionary<string, object> env, Func<WebSocketAcceptContext, Task<WebSocket>> accept)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Owin.WebSocketAcceptAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Owin.WebSocketAcceptAdapter.AdaptWebSockets(System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>)
    
        
        
        
        :type next: System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}
        :rtype: System.Func{System.Collections.Generic.IDictionary{System.String,System.Object},System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public static Func<IDictionary<string, object>, Task> AdaptWebSockets(Func<IDictionary<string, object>, Task> next)
    

