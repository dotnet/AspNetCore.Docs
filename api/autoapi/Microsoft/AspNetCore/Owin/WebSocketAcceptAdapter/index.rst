

WebSocketAcceptAdapter Class
============================






This adapts the ASP.NET Core WebSocket Accept flow to match the OWIN WebSocket accept flow.
This enables OWIN based components to use WebSockets on ASP.NET Core servers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Owin`
Assemblies
    * Microsoft.AspNetCore.Owin

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Owin.WebSocketAcceptAdapter`








Syntax
------

.. code-block:: csharp

    public class WebSocketAcceptAdapter








.. dn:class:: Microsoft.AspNetCore.Owin.WebSocketAcceptAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Owin.WebSocketAcceptAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Owin.WebSocketAcceptAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.WebSocketAcceptAdapter.WebSocketAcceptAdapter(System.Collections.Generic.IDictionary<System.String, System.Object>, System.Func<Microsoft.AspNetCore.Http.WebSocketAcceptContext, System.Threading.Tasks.Task<System.Net.WebSockets.WebSocket>>)
    
        
    
        
        :type env: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type accept: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.WebSocketAcceptContext<Microsoft.AspNetCore.Http.WebSocketAcceptContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}}
    
        
        .. code-block:: csharp
    
            public WebSocketAcceptAdapter(IDictionary<string, object> env, Func<WebSocketAcceptContext, Task<WebSocket>> accept)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Owin.WebSocketAcceptAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Owin.WebSocketAcceptAdapter.AdaptWebSockets(System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>)
    
        
    
        
        :type next: System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
        :rtype: System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public static Func<IDictionary<string, object>, Task> AdaptWebSockets(Func<IDictionary<string, object>, Task> next)
    

