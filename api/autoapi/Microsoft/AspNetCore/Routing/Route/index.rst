

Route Class
===========





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteBase`
* :dn:cls:`Microsoft.AspNetCore.Routing.Route`








Syntax
------

.. code-block:: csharp

    public class Route : RouteBase, INamedRouter, IRouter








.. dn:class:: Microsoft.AspNetCore.Routing.Route
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Route

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Route
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Route.Route(Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.IInlineConstraintResolver)
    
        
    
        
        :type target: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeTemplate: System.String
    
        
        :type inlineConstraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
            public Route(IRouter target, string routeTemplate, IInlineConstraintResolver inlineConstraintResolver)
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Route.Route(Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.IInlineConstraintResolver)
    
        
    
        
        :type target: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeTemplate: System.String
    
        
        :type defaults: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type constraints: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type dataTokens: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type inlineConstraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
            public Route(IRouter target, string routeTemplate, RouteValueDictionary defaults, IDictionary<string, object> constraints, RouteValueDictionary dataTokens, IInlineConstraintResolver inlineConstraintResolver)
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Route.Route(Microsoft.AspNetCore.Routing.IRouter, System.String, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.IInlineConstraintResolver)
    
        
    
        
        :type target: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeName: System.String
    
        
        :type routeTemplate: System.String
    
        
        :type defaults: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type constraints: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type dataTokens: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type inlineConstraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
            public Route(IRouter target, string routeName, string routeTemplate, RouteValueDictionary defaults, IDictionary<string, object> constraints, RouteValueDictionary dataTokens, IInlineConstraintResolver inlineConstraintResolver)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Route
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Route.OnRouteMatched(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task OnRouteMatched(RouteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Route.OnVirtualPathGenerated(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            protected override VirtualPathData OnVirtualPathGenerated(VirtualPathContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Route
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Route.RouteTemplate
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteTemplate { get; }
    

