

RouteDataActionConstraint Class
===============================



.. contents:: 
   :local:



Summary
-------

Constraints an action to a route key and value.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint`








Syntax
------

.. code-block:: csharp

   public class RouteDataActionConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Routing/RouteDataActionConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint.RouteDataActionConstraint(System.String, System.String)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint` with a key and value, that are
        required to make the action match.
    
        
        
        
        :param routeKey: The route key.
        
        :type routeKey: System.String
        
        
        :param routeValue: The route value.
        
        :type routeValue: System.String
    
        
        .. code-block:: csharp
    
           public RouteDataActionConstraint(string routeKey, string routeValue)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint.CreateCatchAll(System.String)
    
        
    
        Create a catch all constraint for the given key.
    
        
        
        
        :param routeKey: Route key.
        
        :type routeKey: System.String
        :rtype: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint
        :return: a <see cref="T:Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint" /> that represents a catch all constraint.
    
        
        .. code-block:: csharp
    
           public static RouteDataActionConstraint CreateCatchAll(string routeKey)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint.KeyHandling
    
        
    
        The key handling definition for this constraint.
    
        
        :rtype: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
           public RouteKeyHandling KeyHandling { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint.RouteKey
    
        
    
        The route key this constraint matches against.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteKey { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint.RouteValue
    
        
    
        The route value this constraint matches against.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteValue { get; }
    

