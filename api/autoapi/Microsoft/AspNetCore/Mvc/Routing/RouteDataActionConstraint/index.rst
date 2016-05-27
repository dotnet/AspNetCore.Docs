

RouteDataActionConstraint Class
===============================






Constraints an action to a route key and value.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint`








Syntax
------

.. code-block:: csharp

    public class RouteDataActionConstraint








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint.KeyHandling
    
        
    
        
        The key handling definition for this constraint.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
            public RouteKeyHandling KeyHandling
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint.RouteKey
    
        
    
        
        The route key this constraint matches against.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteKey
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint.RouteValue
    
        
    
        
        The route value this constraint matches against.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteValue
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint.RouteDataActionConstraint(System.String, System.String)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint` with a key and value, that are
        required to make the action match.
    
        
    
        
        :param routeKey: The route key.
        
        :type routeKey: System.String
    
        
        :param routeValue: The route value.
        
        :type routeValue: System.String
    
        
        .. code-block:: csharp
    
            public RouteDataActionConstraint(string routeKey, string routeValue)
    

