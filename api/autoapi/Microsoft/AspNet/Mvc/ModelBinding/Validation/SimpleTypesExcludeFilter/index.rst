

SimpleTypesExcludeFilter Class
==============================



.. contents:: 
   :local:



Summary
-------

Identifies the simple types that the default model binding validation will exclude.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.SimpleTypesExcludeFilter`








Syntax
------

.. code-block:: csharp

   public class SimpleTypesExcludeFilter : IExcludeTypeValidationFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/SimpleTypesExcludeFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.SimpleTypesExcludeFilter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.SimpleTypesExcludeFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.SimpleTypesExcludeFilter.IsSimpleType(System.Type)
    
        
    
        Returns true if the given type is the underlying types that :dn:meth:`Microsoft.AspNet.Mvc.ModelBinding.Validation.SimpleTypesExcludeFilter.IsTypeExcluded(System.Type)` will exclude.
    
        
        
        
        :type type: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual bool IsSimpleType(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.SimpleTypesExcludeFilter.IsTypeExcluded(System.Type)
    
        
    
        Returns true if the given type will be excluded from the default model validation.
    
        
        
        
        :type type: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsTypeExcluded(Type type)
    

