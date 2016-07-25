

ActionMethodSelectorAttribute Class
===================================






Base class for attributes which can implement conditional logic to enable or disable an action
for a given request. See :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ActionConstraints`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class ActionMethodSelectorAttribute : Attribute, _Attribute, IActionConstraint, IActionConstraintMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute.Accept(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accept(ActionConstraintContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute.IsValidForRequest(Microsoft.AspNetCore.Routing.RouteContext, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor)
    
        
    
        
        Determines whether the action selection is valid for the specified route context.
    
        
    
        
        :param routeContext: The route context.
        
        :type routeContext: Microsoft.AspNetCore.Routing.RouteContext
    
        
        :param action: Information about the action.
        
        :type action: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
        :rtype: System.Boolean
        :return: 
            <xref uid="langword_csharp_true" name="true" href=""></xref> if the action  selection is valid for the specified context;
            otherwise, <xref uid="langword_csharp_false" name="false" href=""></xref>.
    
        
        .. code-block:: csharp
    
            public abstract bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    

