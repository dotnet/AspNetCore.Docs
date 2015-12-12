

AttributeRouteMatchingEntry Class
=================================



.. contents:: 
   :local:



Summary
-------

Used to build an :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\. Represents an individual URL-matching route that will be
aggregated into the :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry`








Syntax
------

.. code-block:: csharp

   public class AttributeRouteMatchingEntry





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Routing/AttributeRouteMatchingEntry.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry.Constraints
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,Microsoft.AspNet.Routing.IRouteConstraint}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, IRouteConstraint> Constraints { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry.Order
    
        
    
        The order of the template.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry.Precedence
    
        
    
        The precedence of the template.
    
        
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
           public decimal Precedence { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry.RouteName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry.RouteTemplate
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteTemplate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry.Target
    
        
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           public IRouter Target { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry.TemplateMatcher
    
        
        :rtype: Microsoft.AspNet.Routing.Template.TemplateMatcher
    
        
        .. code-block:: csharp
    
           public TemplateMatcher TemplateMatcher { get; set; }
    

