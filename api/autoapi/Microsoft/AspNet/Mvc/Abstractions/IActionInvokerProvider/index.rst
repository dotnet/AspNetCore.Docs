

IActionInvokerProvider Interface
================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IActionInvokerProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Abstractions/IActionInvokerProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuted(ActionInvokerProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuting(ActionInvokerProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider.Order
    
        
    
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

