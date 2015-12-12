

AttributeRouteLinkGenerationEntry Class
=======================================



.. contents:: 
   :local:



Summary
-------

Used to build an :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\. Represents an individual URL-generating route that will be
aggregated into the :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry`








Syntax
------

.. code-block:: csharp

   public class AttributeRouteLinkGenerationEntry





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Routing/AttributeRouteLinkGenerationEntry.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Binder
    
        
    
        The :any:`Microsoft.AspNet.Routing.Template.TemplateBinder`\.
    
        
        :rtype: Microsoft.AspNet.Routing.Template.TemplateBinder
    
        
        .. code-block:: csharp
    
           public TemplateBinder Binder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Constraints
    
        
    
        The route constraints.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,Microsoft.AspNet.Routing.IRouteConstraint}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, IRouteConstraint> Constraints { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Defaults
    
        
    
        The route defaults.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, object> Defaults { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Name
    
        
    
        The name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Order
    
        
    
        The order of the template.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Precedence
    
        
    
        The precedence of the template.
    
        
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
           public decimal Precedence { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.RequiredLinkValues
    
        
    
        The set of values that must be present for link genration.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> RequiredLinkValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.RouteGroup
    
        
    
        The route group.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteGroup { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Template
    
        
    
        The :dn:prop:`Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.Template`\.
    
        
        :rtype: Microsoft.AspNet.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
           public RouteTemplate Template { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry.TemplateText
    
        
    
        The original :any:`System.String` representing the route template.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TemplateText { get; set; }
    

