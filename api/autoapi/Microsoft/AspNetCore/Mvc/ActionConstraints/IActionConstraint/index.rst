

IActionConstraint Interface
===========================






Supports conditional logic to determine whether or not an associated action is valid to be selected
for the given request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ActionConstraints`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionConstraint : IActionConstraintMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint.Order
    
        
    
        
        The constraint order.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint.Accept(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext)
    
        
    
        
        Determines whether an action is a valid candidate for selection.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
        :return: True if the action is valid for selection, otherwise false.
    
        
        .. code-block:: csharp
    
            bool Accept(ActionConstraintContext context)
    

