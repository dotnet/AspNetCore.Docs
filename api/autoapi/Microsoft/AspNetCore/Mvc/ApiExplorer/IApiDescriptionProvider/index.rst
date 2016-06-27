

IApiDescriptionProvider Interface
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.ApiExplorer

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApiDescriptionProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuted(ApiDescriptionProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuting(ApiDescriptionProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider.Order
    
        
    
        
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order { get; }
    

