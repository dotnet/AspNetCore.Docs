

DefaultTypeBasedExcludeFilter Class
===================================



.. contents:: 
   :local:



Summary
-------

Provides an implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter` which can filter
based on a type.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter`








Syntax
------

.. code-block:: csharp

   public class DefaultTypeBasedExcludeFilter : IExcludeTypeValidationFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/DefaultTypeBasedExcludeFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter.DefaultTypeBasedExcludeFilter(System.Type)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter`\.
    
        
        
        
        :param type: The type which needs to be excluded.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
           public DefaultTypeBasedExcludeFilter(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter.IsTypeExcluded(System.Type)
    
        
        
        
        :type propertyType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsTypeExcluded(Type propertyType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultTypeBasedExcludeFilter.ExcludedType
    
        
    
        Gets the type which is excluded from validation.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ExcludedType { get; }
    

