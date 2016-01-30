

RouteBuilder Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteBuilder`








Syntax
------

.. code-block:: csharp

   public class RouteBuilder : IRouteBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/RouteBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.RouteBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.RouteBuilder.RouteBuilder()
    
        
    
        
        .. code-block:: csharp
    
           public RouteBuilder()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.RouteBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.RouteBuilder.Build()
    
        
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           public IRouter Build()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.RouteBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.RouteBuilder.DefaultHandler
    
        
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           public IRouter DefaultHandler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteBuilder.Routes
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Routing.IRouter}
    
        
        .. code-block:: csharp
    
           public IList<IRouter> Routes { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteBuilder.ServiceProvider
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider ServiceProvider { get; set; }
    

