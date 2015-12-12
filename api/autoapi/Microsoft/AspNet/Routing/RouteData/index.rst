

RouteData Class
===============



.. contents:: 
   :local:



Summary
-------

Information about the current routing path.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteData`








Syntax
------

.. code-block:: csharp

   public class RouteData





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/RouteData.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteData

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.RouteData
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.RouteData.RouteData()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Routing.RouteData` instance.
    
        
    
        
        .. code-block:: csharp
    
           public RouteData()
    
    .. dn:constructor:: Microsoft.AspNet.Routing.RouteData.RouteData(Microsoft.AspNet.Routing.RouteData)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Routing.RouteData` instance with values copied from ``other``.
    
        
        
        
        :param other: The other  instance to copy.
        
        :type other: Microsoft.AspNet.Routing.RouteData
    
        
        .. code-block:: csharp
    
           public RouteData(RouteData other)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.RouteData
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.RouteData.DataTokens
    
        
    
        Gets the data tokens produced by routes on the current routing path.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> DataTokens { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteData.Routers
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Routing.IRouter` instances on the current routing path.
    
        
        :rtype: System.Collections.Generic.List{Microsoft.AspNet.Routing.IRouter}
    
        
        .. code-block:: csharp
    
           public List<IRouter> Routers { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteData.Values
    
        
    
        Gets the set of values produced by routes on the current routing path.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> Values { get; }
    

