

OwinWebSocketAcceptAdapter Class
================================






This adapts the OWIN WebSocket accept flow to match the ASP.NET Core WebSocket Accept flow.
This enables ASP.NET Core components to use WebSockets on OWIN based servers.


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
* :dn:cls:`Microsoft.AspNetCore.Owin.OwinWebSocketAcceptAdapter`








Syntax
------

.. code-block:: csharp

    public class OwinWebSocketAcceptAdapter








.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptAdapter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptAdapter.AdaptWebSockets(System.Func<System.Collections.Generic.IDictionary<System.String, System.Object>, System.Threading.Tasks.Task>)
    
        
    
        
        :type next: System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
        :rtype: System.Func<System.Func`2>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public static Func<IDictionary<string, object>, Task> AdaptWebSockets(Func<IDictionary<string, object>, Task> next)
    

