

IInlineConstraintResolver Interface
===================================



.. contents:: 
   :local:



Summary
-------

Defines an abstraction for resolving inline constraints as instances of :any:`Microsoft.AspNet.Routing.IRouteConstraint`\.











Syntax
------

.. code-block:: csharp

   public interface IInlineConstraintResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/IInlineConstraintResolver.cs>`_





.. dn:interface:: Microsoft.AspNet.Routing.IInlineConstraintResolver

Methods
-------

.. dn:interface:: Microsoft.AspNet.Routing.IInlineConstraintResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.IInlineConstraintResolver.ResolveConstraint(System.String)
    
        
    
        Resolves the inline constraint.
    
        
        
        
        :param inlineConstraint: The inline constraint to resolve.
        
        :type inlineConstraint: System.String
        :rtype: Microsoft.AspNet.Routing.IRouteConstraint
        :return: The <see cref="T:Microsoft.AspNet.Routing.IRouteConstraint" /> the inline constraint was resolved to.
    
        
        .. code-block:: csharp
    
           IRouteConstraint ResolveConstraint(string inlineConstraint)
    

