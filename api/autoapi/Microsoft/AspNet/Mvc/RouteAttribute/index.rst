

RouteAttribute Class
====================



.. contents:: 
   :local:



Summary
-------

Specifies an attribute route on a controller.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.RouteAttribute`








Syntax
------

.. code-block:: csharp

   public class RouteAttribute : Attribute, _Attribute, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/RouteAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.RouteAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.RouteAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RouteAttribute.RouteAttribute(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.RouteAttribute` with the given route template.
    
        
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public RouteAttribute(string template)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.RouteAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.RouteAttribute.Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider.Order
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           int ? IRouteTemplateProvider.Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RouteAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RouteAttribute.Order
    
        
    
        Gets the route order. The order determines the order of route execution. Routes with a lower order
        value are tried first. If an action defines a route by providing an :any:`Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider`
        with a non <c>null</c> order, that order is used instead of this value. If neither the action nor the
        controller defines an order, a default value of 0 is used.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RouteAttribute.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Template { get; }
    

