

IPropertyBindingPredicateProvider Interface
===========================================



.. contents:: 
   :local:



Summary
-------

Provides a predicate which can determines which model properties should be bound by model binding.











Syntax
------

.. code-block:: csharp

   public interface IPropertyBindingPredicateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/IPropertyBindingPredicateProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider.PropertyFilter
    
        
    
        Gets a predicate which can determines which model properties should be bound by model binding.
    
        
        :rtype: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
    
        
        .. code-block:: csharp
    
           Func<ModelBindingContext, string, bool> PropertyFilter { get; }
    

