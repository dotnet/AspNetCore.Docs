

TemplateRoute Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Template.TemplateRoute`








Syntax
------

.. code-block:: csharp

   public class TemplateRoute : INamedRouter, IRouter





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Template/TemplateRoute.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateRoute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateRoute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Template.TemplateRoute.TemplateRoute(Microsoft.AspNet.Routing.IRouter, System.String, Microsoft.AspNet.Routing.IInlineConstraintResolver)
    
        
        
        
        :type target: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeTemplate: System.String
        
        
        :type inlineConstraintResolver: Microsoft.AspNet.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
           public TemplateRoute(IRouter target, string routeTemplate, IInlineConstraintResolver inlineConstraintResolver)
    
    .. dn:constructor:: Microsoft.AspNet.Routing.Template.TemplateRoute.TemplateRoute(Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.IInlineConstraintResolver)
    
        
        
        
        :type target: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeTemplate: System.String
        
        
        :type defaults: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type constraints: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type dataTokens: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type inlineConstraintResolver: Microsoft.AspNet.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
           public TemplateRoute(IRouter target, string routeTemplate, IDictionary<string, object> defaults, IDictionary<string, object> constraints, IDictionary<string, object> dataTokens, IInlineConstraintResolver inlineConstraintResolver)
    
    .. dn:constructor:: Microsoft.AspNet.Routing.Template.TemplateRoute.TemplateRoute(Microsoft.AspNet.Routing.IRouter, System.String, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.IInlineConstraintResolver)
    
        
        
        
        :type target: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeName: System.String
        
        
        :type routeTemplate: System.String
        
        
        :type defaults: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type constraints: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type dataTokens: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type inlineConstraintResolver: Microsoft.AspNet.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
           public TemplateRoute(IRouter target, string routeName, string routeTemplate, IDictionary<string, object> defaults, IDictionary<string, object> constraints, IDictionary<string, object> dataTokens, IInlineConstraintResolver inlineConstraintResolver)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateRoute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplateRoute.GetVirtualPath(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: Microsoft.AspNet.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
           public virtual VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplateRoute.RouteAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RouteAsync(RouteContext context)
    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplateRoute.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateRoute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateRoute.Constraints
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,Microsoft.AspNet.Routing.IRouteConstraint}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, IRouteConstraint> Constraints { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateRoute.DataTokens
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, object> DataTokens { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateRoute.Defaults
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, object> Defaults { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateRoute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateRoute.ParsedTemplate
    
        
        :rtype: Microsoft.AspNet.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
           public RouteTemplate ParsedTemplate { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateRoute.RouteTemplate
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteTemplate { get; }
    

