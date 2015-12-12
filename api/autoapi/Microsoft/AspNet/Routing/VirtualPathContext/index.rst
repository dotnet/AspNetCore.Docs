

VirtualPathContext Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.VirtualPathContext`








Syntax
------

.. code-block:: csharp

   public class VirtualPathContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/VirtualPathContext.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.VirtualPathContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.VirtualPathContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.VirtualPathContext.VirtualPathContext(Microsoft.AspNet.Http.HttpContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type ambientValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public VirtualPathContext(HttpContext httpContext, IDictionary<string, object> ambientValues, IDictionary<string, object> values)
    
    .. dn:constructor:: Microsoft.AspNet.Routing.VirtualPathContext.VirtualPathContext(Microsoft.AspNet.Http.HttpContext, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Collections.Generic.IDictionary<System.String, System.Object>, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type ambientValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type routeName: System.String
    
        
        .. code-block:: csharp
    
           public VirtualPathContext(HttpContext context, IDictionary<string, object> ambientValues, IDictionary<string, object> values, string routeName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.VirtualPathContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathContext.AmbientValues
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> AmbientValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathContext.Context
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathContext.IsBound
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsBound { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathContext.ProvidedValues
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> ProvidedValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathContext.RouteName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteName { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathContext.Values
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> Values { get; }
    

