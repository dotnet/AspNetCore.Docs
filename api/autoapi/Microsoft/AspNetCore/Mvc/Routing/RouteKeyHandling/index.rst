

RouteKeyHandling Enum
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum RouteKeyHandling








.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling.DenyKey
    
        
    
        
        Requires that the key will not be in the route values.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
            DenyKey = 1
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling.RequireKey
    
        
    
        
        Requires that the key will be in the route values, and that the content matches.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
            RequireKey = 0
    

