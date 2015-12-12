

RouteKeyHandling Enum
=====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public enum RouteKeyHandling





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Routing/RouteKeyHandling.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling.CatchAll
    
        
    
        Requires that the key will be in the route values, but ignore the content.
        Constraints with this value are considered less important than ones with 
        :dn:field:`Microsoft.AspNet.Mvc.Routing.RouteKeyHandling.RequireKey`
    
        
    
        
        .. code-block:: csharp
    
           CatchAll = 2
    
    .. dn:field:: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling.DenyKey
    
        
    
        Requires that the key will not be in the route values.
    
        
    
        
        .. code-block:: csharp
    
           DenyKey = 1
    
    .. dn:field:: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling.RequireKey
    
        
    
        Requires that the key will be in the route values, and that the content matches.
    
        
    
        
        .. code-block:: csharp
    
           RequireKey = 0
    

