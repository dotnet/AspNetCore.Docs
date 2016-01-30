

FilterItemOrderComparer Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterItemOrderComparer`








Syntax
------

.. code-block:: csharp

   public class FilterItemOrderComparer : IComparer<FilterItem>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Filters/FilterItemOrderComparer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterItemOrderComparer

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterItemOrderComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.FilterItemOrderComparer.Compare(Microsoft.AspNet.Mvc.Filters.FilterItem, Microsoft.AspNet.Mvc.Filters.FilterItem)
    
        
        
        
        :type x: Microsoft.AspNet.Mvc.Filters.FilterItem
        
        
        :type y: Microsoft.AspNet.Mvc.Filters.FilterItem
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Compare(FilterItem x, FilterItem y)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterItemOrderComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterItemOrderComparer.Comparer
    
        
        :rtype: Microsoft.AspNet.Mvc.Filters.FilterItemOrderComparer
    
        
        .. code-block:: csharp
    
           public static FilterItemOrderComparer Comparer { get; }
    

