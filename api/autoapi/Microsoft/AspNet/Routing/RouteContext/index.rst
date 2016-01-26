

RouteContext Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteContext`








Syntax
------

.. code-block:: csharp

   public class RouteContext





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/RouteContext.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.RouteContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.RouteContext.RouteContext(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public RouteContext(HttpContext httpContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.RouteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.RouteContext.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteContext.IsHandled
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsHandled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteContext.RouteData
    
        
        :rtype: Microsoft.AspNet.Routing.RouteData
    
        
        .. code-block:: csharp
    
           public RouteData RouteData { get; set; }
    

