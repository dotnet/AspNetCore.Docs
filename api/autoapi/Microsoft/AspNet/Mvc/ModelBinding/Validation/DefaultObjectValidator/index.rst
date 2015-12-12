

DefaultObjectValidator Class
============================



.. contents:: 
   :local:



Summary
-------

The default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultObjectValidator`








Syntax
------

.. code-block:: csharp

   public class DefaultObjectValidator : IObjectModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/DefaultObjectValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultObjectValidator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultObjectValidator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultObjectValidator.DefaultObjectValidator(System.Collections.Generic.IList<Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter>, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultObjectValidator`\.
    
        
        
        
        :param excludeFilters: s that determine
            types to exclude from validation.
        
        :type excludeFilters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter}
        
        
        :param modelMetadataProvider: The .
        
        :type modelMetadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           public DefaultObjectValidator(IList<IExcludeTypeValidationFilter> excludeFilters, IModelMetadataProvider modelMetadataProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultObjectValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultObjectValidator.Validate(Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary, System.String, System.Object)
    
        
        
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :type validationState: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary
        
        
        :type prefix: System.String
        
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
           public void Validate(IModelValidatorProvider validatorProvider, ModelStateDictionary modelState, ValidationStateDictionary validationState, string prefix, object model)
    

