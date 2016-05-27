

IOrderedFilter Interface
========================






A filter that specifies the relative order it should run.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IOrderedFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter.Order
    
        
    
        
        Gets the order value for determining the order of execution of filters. Filters execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order
            {
                get;
            }
    

