

IFilterProvider Interface
=========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IFilterProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IFilterProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IFilterProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IFilterProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IFilterProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.Filters.FilterProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuted(FilterProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IFilterProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.Filters.FilterProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuting(FilterProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IFilterProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.IFilterProvider.Order
    
        
    
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNet.Mvc.Filters.IFilterProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

