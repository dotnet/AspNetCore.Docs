

IApiDescriptionProvider Interface
=================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IApiDescriptionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ApiExplorer/IApiDescriptionProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuted(ApiDescriptionProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuting(ApiDescriptionProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider.Order
    
        
    
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

