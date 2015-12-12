

IActionDescriptorProvider Interface
===================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IActionDescriptorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Abstractions/IActionDescriptorProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Abstractions.IActionDescriptorProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Abstractions.IActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Abstractions.IActionDescriptorProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuted(ActionDescriptorProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Abstractions.IActionDescriptorProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuting(ActionDescriptorProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Abstractions.IActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.IActionDescriptorProvider.Order
    
        
    
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.IActionDescriptorProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

