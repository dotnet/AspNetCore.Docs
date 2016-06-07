

TreeRouteLinkGenerationEntry Class
==================================






Used to build a :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\. Represents an individual URL-generating route that will be
aggregated into the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Tree`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry`








Syntax
------

.. code-block:: csharp

    public class TreeRouteLinkGenerationEntry








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.Binder
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.Template.TemplateBinder`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplateBinder
    
        
        .. code-block:: csharp
    
            public TemplateBinder Binder
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.Constraints
    
        
    
        
        Gets or sets the route constraints.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, IRouteConstraint> Constraints
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.Defaults
    
        
    
        
        Gets or sets the route defaults.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> Defaults
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.GenerationPrecedence
    
        
    
        
        Gets or sets the precedence of the template for link generation. A greater value of
        :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.GenerationPrecedence` means that an entry is considered first.
    
        
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
            public decimal GenerationPrecedence
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.Name
    
        
    
        
        Gets or sets the name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.Order
    
        
    
        
        Gets or sets the order of the template.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.RequiredLinkValues
    
        
    
        
        Gets or sets the set of values that must be present for link genration.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> RequiredLinkValues
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.RouteGroup
    
        
    
        
        Gets or sets the route group.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteGroup
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.Template
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry.Template`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
            public RouteTemplate Template
            {
                get;
                set;
            }
    

