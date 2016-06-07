

RouteContext Class
==================






A context object for :dn:meth:`Microsoft.AspNetCore.Routing.IRouter.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)`\.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteContext`








Syntax
------

.. code-block:: csharp

    public class RouteContext








.. dn:class:: Microsoft.AspNetCore.Routing.RouteContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteContext.Handler
    
        
    
        
        Gets or sets the handler for the request. An :any:`Microsoft.AspNetCore.Routing.IRouter` should set :dn:prop:`Microsoft.AspNetCore.Routing.RouteContext.Handler`
        when it matches.
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate Handler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteContext.HttpContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteContext.RouteData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.RouteData` associated with the current context.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public RouteData RouteData
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteContext.RouteContext(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.RouteContext` for the provided <em>httpContext</em>.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public RouteContext(HttpContext httpContext)
    

