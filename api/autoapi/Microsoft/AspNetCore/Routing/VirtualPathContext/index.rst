

VirtualPathContext Class
========================






A context for virtual path generation operations.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.VirtualPathContext`








Syntax
------

.. code-block:: csharp

    public class VirtualPathContext








.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.VirtualPathContext.AmbientValues
    
        
    
        
        Gets the set of route values associated with the current request.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary AmbientValues
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.VirtualPathContext.HttpContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.VirtualPathContext.RouteName
    
        
    
        
        Gets the name of the route to use for virtual path generation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.VirtualPathContext.Values
    
        
    
        
        Gets or sets the set of new values provided for virtual path generation.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary Values
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.VirtualPathContext.VirtualPathContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.VirtualPathContext`\.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param ambientValues: The set of route values associated with the current request.
        
        :type ambientValues: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :param values: The set of new values provided for virtual path generation.
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public VirtualPathContext(HttpContext httpContext, RouteValueDictionary ambientValues, RouteValueDictionary values)
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.VirtualPathContext.VirtualPathContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteValueDictionary, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.VirtualPathContext`\.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param ambientValues: The set of route values associated with the current request.
        
        :type ambientValues: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :param values: The set of new values provided for virtual path generation.
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :param routeName: The name of the route to use for virtual path generation.
        
        :type routeName: System.String
    
        
        .. code-block:: csharp
    
            public VirtualPathContext(HttpContext httpContext, RouteValueDictionary ambientValues, RouteValueDictionary values, string routeName)
    

