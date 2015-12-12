

DefaultInlineConstraintResolver Class
=====================================



.. contents:: 
   :local:



Summary
-------

The default implementation of :any:`Microsoft.AspNet.Routing.IInlineConstraintResolver`\. Resolves constraints by parsing
a constraint key and constraint arguments, using a map to resolve the constraint type, and calling an
appropriate constructor for the constraint type.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.DefaultInlineConstraintResolver`








Syntax
------

.. code-block:: csharp

   public class DefaultInlineConstraintResolver : IInlineConstraintResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/DefaultInlineConstraintResolver.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.DefaultInlineConstraintResolver

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.DefaultInlineConstraintResolver
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.DefaultInlineConstraintResolver.DefaultInlineConstraintResolver(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Routing.RouteOptions>)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.DefaultInlineConstraintResolver` class.
    
        
        
        
        :param routeOptions: Accessor for  containing the constraints of interest.
        
        :type routeOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Routing.RouteOptions}
    
        
        .. code-block:: csharp
    
           public DefaultInlineConstraintResolver(IOptions<RouteOptions> routeOptions)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.DefaultInlineConstraintResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.DefaultInlineConstraintResolver.ResolveConstraint(System.String)
    
        
        
        
        :type inlineConstraint: System.String
        :rtype: Microsoft.AspNet.Routing.IRouteConstraint
    
        
        .. code-block:: csharp
    
           public virtual IRouteConstraint ResolveConstraint(string inlineConstraint)
    

