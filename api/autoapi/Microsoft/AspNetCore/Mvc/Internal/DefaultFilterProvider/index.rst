

DefaultFilterProvider Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultFilterProvider : IFilterProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuted(FilterProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuting(FilterProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider.ProvideFilter(Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext, Microsoft.AspNetCore.Mvc.Filters.FilterItem)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    
        
        :type filterItem: Microsoft.AspNetCore.Mvc.Filters.FilterItem
    
        
        .. code-block:: csharp
    
            public virtual void ProvideFilter(FilterProviderContext context, FilterItem filterItem)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.DefaultFilterProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

