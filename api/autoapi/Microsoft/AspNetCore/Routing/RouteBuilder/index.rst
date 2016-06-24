

RouteBuilder Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteBuilder`








Syntax
------

.. code-block:: csharp

    public class RouteBuilder : IRouteBuilder








.. dn:class:: Microsoft.AspNetCore.Routing.RouteBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteBuilder.RouteBuilder(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type applicationBuilder: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public RouteBuilder(IApplicationBuilder applicationBuilder)
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteBuilder.RouteBuilder(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Routing.IRouter)
    
        
    
        
        :type applicationBuilder: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type defaultHandler: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public RouteBuilder(IApplicationBuilder applicationBuilder, IRouter defaultHandler)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBuilder.ApplicationBuilder
    
        
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public IApplicationBuilder ApplicationBuilder { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBuilder.DefaultHandler
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public IRouter DefaultHandler { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBuilder.Routes
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.IRouter<Microsoft.AspNetCore.Routing.IRouter>}
    
        
        .. code-block:: csharp
    
            public IList<IRouter> Routes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBuilder.ServiceProvider
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider ServiceProvider { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBuilder.Build()
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public IRouter Build()
    

