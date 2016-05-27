

RouteBase Class
===============





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








Syntax
------

.. code-block:: csharp

    public abstract class RouteBase : INamedRouter, IRouter








.. dn:class:: Microsoft.AspNetCore.Routing.RouteBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBase

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBase.ConstraintResolver
    
        
        :rtype: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
            protected virtual IInlineConstraintResolver ConstraintResolver
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBase.Constraints
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        .. code-block:: csharp
    
            public virtual IDictionary<string, IRouteConstraint> Constraints
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBase.DataTokens
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public virtual RouteValueDictionary DataTokens
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBase.Defaults
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public virtual RouteValueDictionary Defaults
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBase.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Name
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteBase.ParsedTemplate
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
            public virtual RouteTemplate ParsedTemplate
            {
                get;
                protected set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteBase.RouteBase(System.String, System.String, Microsoft.AspNetCore.Routing.IInlineConstraintResolver, Microsoft.AspNetCore.Routing.RouteValueDictionary, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type template: System.String
    
        
        :type name: System.String
    
        
        :type constraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        :type defaults: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type constraints: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type dataTokens: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteBase(string template, string name, IInlineConstraintResolver constraintResolver, RouteValueDictionary defaults, IDictionary<string, object> constraints, RouteValueDictionary dataTokens)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBase.GetConstraints(Microsoft.AspNetCore.Routing.IInlineConstraintResolver, Microsoft.AspNetCore.Routing.Template.RouteTemplate, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type inlineConstraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        :type parsedTemplate: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        :type constraints: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        .. code-block:: csharp
    
            protected static IDictionary<string, IRouteConstraint> GetConstraints(IInlineConstraintResolver inlineConstraintResolver, RouteTemplate parsedTemplate, IDictionary<string, object> constraints)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBase.GetDefaults(Microsoft.AspNetCore.Routing.Template.RouteTemplate, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type parsedTemplate: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        :type defaults: Microsoft.AspNetCore.Routing.RouteValueDictionary
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            protected static RouteValueDictionary GetDefaults(RouteTemplate parsedTemplate, RouteValueDictionary defaults)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBase.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public virtual VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBase.OnRouteMatched(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected abstract Task OnRouteMatched(RouteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBase.OnVirtualPathGenerated(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            protected abstract VirtualPathData OnVirtualPathGenerated(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBase.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RouteAsync(RouteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteBase.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

