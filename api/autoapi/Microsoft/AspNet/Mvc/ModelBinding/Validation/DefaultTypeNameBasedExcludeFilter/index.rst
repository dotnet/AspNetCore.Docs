

DefaultTypeNameBasedExcludeFilter Class
=======================================



.. contents:: 
   :local:



Summary
-------

Provides an implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter` which can filter
based on a type full name.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter`








Syntax
------

.. code-block:: csharp

   public class DefaultTypeNameBasedExcludeFilter : IExcludeTypeValidationFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/DefaultTypeNameBasedExcludeFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter.DefaultTypeNameBasedExcludeFilter(System.String)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter`
    
        
        
        
        :param typeFullName: Fully qualified name of the type which needs to be excluded.
        
        :type typeFullName: System.String
    
        
        .. code-block:: csharp
    
           public DefaultTypeNameBasedExcludeFilter(string typeFullName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter.IsTypeExcluded(System.Type)
    
        
        
        
        :type propertyType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsTypeExcluded(Type propertyType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeNameBasedExcludeFilter.ExcludedTypeName
    
        
    
        Gets the type full name which is excluded from validation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExcludedTypeName { get; }
    

