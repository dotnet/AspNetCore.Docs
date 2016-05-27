

OwinWebSocketAcceptContext Class
================================





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
* :dn:cls:`Microsoft.AspNetCore.Http.WebSocketAcceptContext`
* :dn:cls:`Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext`








Syntax
------

.. code-block:: csharp

    public class OwinWebSocketAcceptContext : WebSocketAcceptContext








.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext.Options
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> Options
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext.SubProtocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string SubProtocol
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext.OwinWebSocketAcceptContext()
    
        
    
        
        .. code-block:: csharp
    
            public OwinWebSocketAcceptContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinWebSocketAcceptContext.OwinWebSocketAcceptContext(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type options: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public OwinWebSocketAcceptContext(IDictionary<string, object> options)
    

