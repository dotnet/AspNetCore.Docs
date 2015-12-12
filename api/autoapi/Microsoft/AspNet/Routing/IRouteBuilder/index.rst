

IRouteBuilder Interface
=======================



.. contents:: 
   :local:



Summary
-------

Defines a contract for a route builder in an application. A route builder specifies the routes for an application.











Syntax
------

.. code-block:: csharp

   public interface IRouteBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/IRouteBuilder.cs>`_





.. dn:interface:: Microsoft.AspNet.Routing.IRouteBuilder

Methods
-------

.. dn:interface:: Microsoft.AspNet.Routing.IRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.IRouteBuilder.Build()
    
        
    
        Builds an :any:`Microsoft.AspNet.Routing.IRouter` that routes the routes specified in the :dn:prop:`Microsoft.AspNet.Routing.IRouteBuilder.Routes` property.
    
        
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           IRouter Build()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Routing.IRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.IRouteBuilder.DefaultHandler
    
        
    
        Gets or sets the default :any:`Microsoft.AspNet.Routing.IRouter` that is used if an :any:`Microsoft.AspNet.Routing.IRouter` is added to the list of routes but does not specify its own.
    
        
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           IRouter DefaultHandler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.IRouteBuilder.Routes
    
        
    
        Gets the routes configured in the builder.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Routing.IRouter}
    
        
        .. code-block:: csharp
    
           IList<IRouter> Routes { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.IRouteBuilder.ServiceProvider
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           IServiceProvider ServiceProvider { get; }
    

