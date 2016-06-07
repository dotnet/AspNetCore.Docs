

IInlineConstraintResolver Interface
===================================






Defines an abstraction for resolving inline constraints as instances of :any:`Microsoft.AspNetCore.Routing.IRouteConstraint`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IInlineConstraintResolver








.. dn:interface:: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Routing.IInlineConstraintResolver

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.IInlineConstraintResolver.ResolveConstraint(System.String)
    
        
    
        
        Resolves the inline constraint.
    
        
    
        
        :param inlineConstraint: The inline constraint to resolve.
        
        :type inlineConstraint: System.String
        :rtype: Microsoft.AspNetCore.Routing.IRouteConstraint
        :return: The :any:`Microsoft.AspNetCore.Routing.IRouteConstraint` the inline constraint was resolved to.
    
        
        .. code-block:: csharp
    
            IRouteConstraint ResolveConstraint(string inlineConstraint)
    

