

IActionDescriptorProvider Interface
===================================





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

    public interface IActionDescriptorProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider.Order
    
        
    
        
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuted(ActionDescriptorProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Abstractions.IActionDescriptorProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuting(ActionDescriptorProviderContext context)
    

