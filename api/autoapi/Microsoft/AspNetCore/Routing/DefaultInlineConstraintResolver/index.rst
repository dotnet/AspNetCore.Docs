

DefaultInlineConstraintResolver Class
=====================================






The default implementation of :any:`Microsoft.AspNetCore.Routing.IInlineConstraintResolver`\. Resolves constraints by parsing
a constraint key and constraint arguments, using a map to resolve the constraint type, and calling an
appropriate constructor for the constraint type.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver`








Syntax
------

.. code-block:: csharp

    public class DefaultInlineConstraintResolver : IInlineConstraintResolver








.. dn:class:: Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver.DefaultInlineConstraintResolver(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Routing.RouteOptions>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver` class.
    
        
    
        
        :param routeOptions: 
            Accessor for :any:`Microsoft.AspNetCore.Routing.RouteOptions` containing the constraints of interest.
        
        :type routeOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Routing.RouteOptions<Microsoft.AspNetCore.Routing.RouteOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultInlineConstraintResolver(IOptions<RouteOptions> routeOptions)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver.ResolveConstraint(System.String)
    
        
    
        
        :type inlineConstraint: System.String
        :rtype: Microsoft.AspNetCore.Routing.IRouteConstraint
    
        
        .. code-block:: csharp
    
            public virtual IRouteConstraint ResolveConstraint(string inlineConstraint)
    

