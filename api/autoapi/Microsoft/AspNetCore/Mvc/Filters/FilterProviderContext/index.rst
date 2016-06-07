

FilterProviderContext Class
===========================






A context for filter providers i.e. :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider` implementations.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext`








Syntax
------

.. code-block:: csharp

    public class FilterProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.ActionContext
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.ActionContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.Results
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.Filters.FilterItem`\s, initially created from :any:`Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor`\s or a
        cache entry. :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider`\s should set :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterItem.Filter` on existing items or
        add new :any:`Microsoft.AspNetCore.Mvc.Filters.FilterItem`\s to make executable filters available.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.FilterItem<Microsoft.AspNetCore.Mvc.Filters.FilterItem>}
    
        
        .. code-block:: csharp
    
            public IList<FilterItem> Results
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.FilterProviderContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.FilterItem>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext` instance.
    
        
    
        
        :param actionContext: The :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param items: 
            The :any:`Microsoft.AspNetCore.Mvc.Filters.FilterItem`\s, initially created from :any:`Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor`\s or a cache entry.
        
        :type items: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.FilterItem<Microsoft.AspNetCore.Mvc.Filters.FilterItem>}
    
        
        .. code-block:: csharp
    
            public FilterProviderContext(ActionContext actionContext, IList<FilterItem> items)
    

