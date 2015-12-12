

DefaultActionConstraintProvider Class
=====================================



.. contents:: 
   :local:



Summary
-------

A default implementation of :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultActionConstraintProvider : IActionConstraintProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ActionConstraints/DefaultActionConstraintProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuted(ActionConstraintProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuting(ActionConstraintProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

