

IActionConstraintProvider Interface
===================================





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

    public interface IActionConstraintProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuted(ActionConstraintProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuting(ActionConstraintProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider.Order
    
        
    
        
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order { get; }
    

