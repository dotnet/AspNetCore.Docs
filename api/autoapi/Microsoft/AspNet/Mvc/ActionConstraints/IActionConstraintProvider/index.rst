

IActionConstraintProvider Interface
===================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IActionConstraintProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ActionConstraints/IActionConstraintProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuted(ActionConstraintProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuting(ActionConstraintProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider.Order
    
        
    
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

