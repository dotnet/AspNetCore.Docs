

FilterItem Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterItem`








Syntax
------

.. code-block:: csharp

   public class FilterItem





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/FilterItem.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterItem

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterItem
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.FilterItem.FilterItem(Microsoft.AspNet.Mvc.Filters.FilterDescriptor)
    
        
        
        
        :type descriptor: Microsoft.AspNet.Mvc.Filters.FilterDescriptor
    
        
        .. code-block:: csharp
    
           public FilterItem(FilterDescriptor descriptor)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.FilterItem.FilterItem(Microsoft.AspNet.Mvc.Filters.FilterDescriptor, Microsoft.AspNet.Mvc.Filters.IFilterMetadata)
    
        
        
        
        :type descriptor: Microsoft.AspNet.Mvc.Filters.FilterDescriptor
        
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public FilterItem(FilterDescriptor descriptor, IFilterMetadata filter)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterItem.Descriptor
    
        
        :rtype: Microsoft.AspNet.Mvc.Filters.FilterDescriptor
    
        
        .. code-block:: csharp
    
           public FilterDescriptor Descriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterItem.Filter
    
        
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public IFilterMetadata Filter { get; set; }
    

