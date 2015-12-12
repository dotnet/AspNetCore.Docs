

IRouteConstraintProvider Interface
==================================



.. contents:: 
   :local:



Summary
-------

An interface for metadata which provides :any:`Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint` values
for a controller or action.











Syntax
------

.. code-block:: csharp

   public interface IRouteConstraintProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/IRouteConstraintProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider.BlockNonAttributedActions
    
        
    
        Set to true to negate this constraint on all actions that do not define a behavior for this route key.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool BlockNonAttributedActions { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider.RouteKey
    
        
    
        The route value key.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string RouteKey { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider.RouteKeyHandling
    
        
    
        The :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider.RouteKeyHandling`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
           RouteKeyHandling RouteKeyHandling { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider.RouteValue
    
        
    
        The expected route value. Will be null unless :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider.RouteKeyHandling` is
        set to :dn:field:`Microsoft.AspNet.Mvc.Routing.RouteKeyHandling.RequireKey`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string RouteValue { get; }
    

