

FilterDescriptorOrderComparer Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterDescriptorOrderComparer`








Syntax
------

.. code-block:: csharp

   public class FilterDescriptorOrderComparer : IComparer<FilterDescriptor>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Filters/FilterDescriptorOrderComparer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterDescriptorOrderComparer

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterDescriptorOrderComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.FilterDescriptorOrderComparer.Compare(Microsoft.AspNet.Mvc.Filters.FilterDescriptor, Microsoft.AspNet.Mvc.Filters.FilterDescriptor)
    
        
        
        
        :type x: Microsoft.AspNet.Mvc.Filters.FilterDescriptor
        
        
        :type y: Microsoft.AspNet.Mvc.Filters.FilterDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Compare(FilterDescriptor x, FilterDescriptor y)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterDescriptorOrderComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterDescriptorOrderComparer.Comparer
    
        
        :rtype: Microsoft.AspNet.Mvc.Filters.FilterDescriptorOrderComparer
    
        
        .. code-block:: csharp
    
           public static FilterDescriptorOrderComparer Comparer { get; }
    

