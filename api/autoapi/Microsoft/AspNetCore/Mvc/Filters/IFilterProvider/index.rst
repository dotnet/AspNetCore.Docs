

IFilterProvider Interface
=========================






A :any:`Microsoft.AspNetCore.Mvc.Filters.FilterItem` provider. Implementations should update :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.Results`
to make executable filters available.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFilterProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IFilterProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext)
    
        
    
        
        Called in decreasing :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider.Order`\, after all :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider`\s have executed once.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuted(FilterProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IFilterProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext)
    
        
    
        
        Called in increasing :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider.Order`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuting(FilterProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.IFilterProvider.Order
    
        
    
        
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order { get; }
    

