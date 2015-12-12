

IActionConstraint Interface
===========================



.. contents:: 
   :local:



Summary
-------

Supports conditional logic to determine whether or not an associated action is valid to be selected
for the given request.











Syntax
------

.. code-block:: csharp

   public interface IActionConstraint : IActionConstraintMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ActionConstraints/IActionConstraint.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint.Accept(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext)
    
        
    
        Determines whether an action is a valid candidate for selection.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
        :return: True if the action is valid for selection, otherwise false.
    
        
        .. code-block:: csharp
    
           bool Accept(ActionConstraintContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint.Order
    
        
    
        The constraint order.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

