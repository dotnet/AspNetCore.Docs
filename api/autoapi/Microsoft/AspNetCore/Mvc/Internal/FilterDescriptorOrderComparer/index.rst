

FilterDescriptorOrderComparer Class
===================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer`








Syntax
------

.. code-block:: csharp

    public class FilterDescriptorOrderComparer : IComparer<FilterDescriptor>








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer.Comparer
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer
    
        
        .. code-block:: csharp
    
            public static FilterDescriptorOrderComparer Comparer
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FilterDescriptorOrderComparer.Compare(Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor, Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor)
    
        
    
        
        :type x: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
    
        
        :type y: Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Compare(FilterDescriptor x, FilterDescriptor y)
    

