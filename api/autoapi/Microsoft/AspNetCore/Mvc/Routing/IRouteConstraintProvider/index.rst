

IRouteConstraintProvider Interface
==================================






An interface for metadata which provides :any:`Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint` values
for a controller or action.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRouteConstraintProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider.BlockNonAttributedActions
    
        
    
        
        Set to true to negate this constraint on all actions that do not define a behavior for this route key.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool BlockNonAttributedActions
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider.RouteKey
    
        
    
        
        The route value key.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string RouteKey
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider.RouteKeyHandling
    
        
    
        
        The :dn:prop:`Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider.RouteKeyHandling`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
            RouteKeyHandling RouteKeyHandling
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider.RouteValue
    
        
    
        
        The expected route value. Will be null unless :dn:prop:`Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider.RouteKeyHandling` is
        set to :dn:field:`Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling.RequireKey`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string RouteValue
            {
                get;
            }
    

