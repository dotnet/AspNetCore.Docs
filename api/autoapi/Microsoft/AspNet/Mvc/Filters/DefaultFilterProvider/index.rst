

DefaultFilterProvider Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultFilterProvider : IFilterProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Filters/DefaultFilterProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.Filters.FilterProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuted(FilterProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.Filters.FilterProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuting(FilterProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider.ProvideFilter(Microsoft.AspNet.Mvc.Filters.FilterProviderContext, Microsoft.AspNet.Mvc.Filters.FilterItem)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.FilterProviderContext
        
        
        :type filterItem: Microsoft.AspNet.Mvc.Filters.FilterItem
    
        
        .. code-block:: csharp
    
           public virtual void ProvideFilter(FilterProviderContext context, FilterItem filterItem)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.DefaultFilterProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

