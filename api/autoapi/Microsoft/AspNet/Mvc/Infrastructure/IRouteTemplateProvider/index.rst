

IRouteTemplateProvider Interface
================================



.. contents:: 
   :local:



Summary
-------

Interface for attributes which can supply a route template for attribute routing.











Syntax
------

.. code-block:: csharp

   public interface IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/IRouteTemplateProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider.Name
    
        
    
        Gets the route name. The route name can be used to generate a link using a specific route, instead
        of relying on selection of a route based on the given set of route values.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider.Order
    
        
    
        Gets the route order. The order determines the order of route execution. Routes with a lower
        order value are tried first. When a route doesn't specify a value, it gets a default value of 0.
        A null value for the Order property means that the user didn't specify an explicit order for the
        route.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           int ? Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider.Template
    
        
    
        The route template. May be null.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Template { get; }
    

