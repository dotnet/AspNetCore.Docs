

FilterDescriptor Class
======================






Descriptor for an :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor`








Syntax
------

.. code-block:: csharp

    public class FilterDescriptor








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor.FilterDescriptor(Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata, System.Int32)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor`\.
    
        
    
        
        :param filter: The :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata`\.
        
        :type filter: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        :param filterScope: The filter scope.
        
        :type filterScope: System.Int32
    
        
        .. code-block:: csharp
    
            public FilterDescriptor(IFilterMetadata filter, int filterScope)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor.Filter
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata Filter { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor.Order
    
        
    
        
        The filter order.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor.Scope
    
        
    
        
        The filter scope.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Scope { get; }
    

