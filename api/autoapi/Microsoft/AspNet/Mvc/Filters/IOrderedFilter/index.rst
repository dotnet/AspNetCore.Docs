

IOrderedFilter Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IOrderedFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IOrderedFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IOrderedFilter

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IOrderedFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.IOrderedFilter.Order
    
        
    
        Gets the order value for determining the order of execution of filters. Filters execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNet.Mvc.Filters.IOrderedFilter.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

