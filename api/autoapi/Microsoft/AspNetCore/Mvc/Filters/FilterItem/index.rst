

FilterItem Class
================






Used to associate executable filters with :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` instances
as part of :any:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext`\. An :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterProvider` should
inspect :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterProviderContext.Results` and set :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterItem.Filter` and 
:dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterItem.IsReusable` as appropriate.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.FilterItem`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("FilterItem: {Filter}")]
    public class FilterItem








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterItem
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterItem

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterItem
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.FilterItem.FilterItem(Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Filters.FilterItem`\.
    
        
    
        
        :param descriptor: The :any:`Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor`\.
        
        :type descriptor: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
    
        
        .. code-block:: csharp
    
            public FilterItem(FilterDescriptor descriptor)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.FilterItem.FilterItem(Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor, Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Filters.FilterItem`\.
    
        
    
        
        :param descriptor: The :any:`Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor`\.
        
        :type descriptor: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
    
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public FilterItem(FilterDescriptor descriptor, IFilterMetadata filter)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterItem.Descriptor
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor` containing the filter metadata.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
    
        
        .. code-block:: csharp
    
            public FilterDescriptor Descriptor { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterItem.Filter
    
        
    
        
        Gets or sets the executable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` associated with :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterItem.Descriptor`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata Filter { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterItem.IsReusable
    
        
    
        
        Gets or sets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.FilterItem.Filter` can be reused across requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable { get; set; }
    

