

IPropertyFilterProvider Interface
=================================






Provides a predicate which can determines which model properties should be bound by model binding.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IPropertyFilterProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider.PropertyFilter
    
        
    
        
        Gets a predicate which can determines which model properties should be bound by model binding.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            Func<ModelMetadata, bool> PropertyFilter { get; }
    

