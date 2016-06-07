

IActionInvokerProvider Interface
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Abstractions`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionInvokerProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider.Order
    
        
    
        
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuted(ActionInvokerProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuting(ActionInvokerProviderContext context)
    

