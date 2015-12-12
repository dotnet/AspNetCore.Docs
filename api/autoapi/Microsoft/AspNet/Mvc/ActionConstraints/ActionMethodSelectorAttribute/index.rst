

ActionMethodSelectorAttribute Class
===================================



.. contents:: 
   :local:



Summary
-------

Base class for attributes which can implement conditional logic to enable or disable an action
for a given request. See :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute`








Syntax
------

.. code-block:: csharp

   public abstract class ActionMethodSelectorAttribute : Attribute, _Attribute, IActionConstraint, IActionConstraintMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ActionConstraints/ActionMethodSelectorAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute.Accept(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Accept(ActionConstraintContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute.IsValidForRequest(Microsoft.AspNet.Routing.RouteContext, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor)
    
        
    
        Determines whether the action selection is valid for the specified route context.
    
        
        
        
        :param routeContext: The route context.
        
        :type routeContext: Microsoft.AspNet.Routing.RouteContext
        
        
        :param action: Information about the action.
        
        :type action: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        :rtype: System.Boolean
        :return: <see langword="true" /> if the action  selection is valid for the specified context;
            otherwise, <see langword="false" />.
    
        
        .. code-block:: csharp
    
           public abstract bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

