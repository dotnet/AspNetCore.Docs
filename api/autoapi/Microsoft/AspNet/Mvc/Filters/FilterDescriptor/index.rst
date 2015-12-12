

FilterDescriptor Class
======================



.. contents:: 
   :local:



Summary
-------

Descriptor for an :any:`Microsoft.AspNet.Mvc.Filters.IFilterMetadata`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterDescriptor`








Syntax
------

.. code-block:: csharp

   public class FilterDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/FilterDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.FilterDescriptor.FilterDescriptor(Microsoft.AspNet.Mvc.Filters.IFilterMetadata, System.Int32)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Filters.FilterDescriptor`\.
    
        
        
        
        :param filter: The .
        
        :type filter: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
        
        
        :param filterScope: The filter scope.
        
        :type filterScope: System.Int32
    
        
        .. code-block:: csharp
    
           public FilterDescriptor(IFilterMetadata filter, int filterScope)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterDescriptor.Filter
    
        
    
        The :any:`Microsoft.AspNet.Mvc.Filters.IFilterMetadata` instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public IFilterMetadata Filter { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterDescriptor.Order
    
        
    
        The filter order.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterDescriptor.Scope
    
        
    
        The filter scope.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Scope { get; }
    

