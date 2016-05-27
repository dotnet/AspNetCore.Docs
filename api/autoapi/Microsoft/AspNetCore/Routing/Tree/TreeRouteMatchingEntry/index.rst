

TreeRouteMatchingEntry Class
============================






Used to build an :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\. Represents an individual URL-matching route that will be
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
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry`








Syntax
------

.. code-block:: csharp

    public class TreeRouteMatchingEntry








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.Constraints
    
        
    
        
        The route constraints.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, IRouteConstraint> Constraints
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.Order
    
        
    
        
        The order of the template.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.Precedence
    
        
    
        
        The precedence of the template.
    
        
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
            public decimal Precedence
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.RouteName
    
        
    
        
        The name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.RouteTemplate
    
        
    
        
        The :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.RouteTemplate`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
            public RouteTemplate RouteTemplate
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.Target
    
        
    
        
        The :any:`Microsoft.AspNetCore.Routing.IRouter` to invoke when this entry matches.
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public IRouter Target
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.TemplateMatcher
    
        
    
        
        The :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry.TemplateMatcher`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    
        
        .. code-block:: csharp
    
            public TemplateMatcher TemplateMatcher
            {
                get;
                set;
            }
    

