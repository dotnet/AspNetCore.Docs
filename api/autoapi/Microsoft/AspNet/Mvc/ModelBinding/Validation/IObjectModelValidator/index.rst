

IObjectModelValidator Interface
===============================



.. contents:: 
   :local:



Summary
-------

Provides methods to validate an object graph.











Syntax
------

.. code-block:: csharp

   public interface IObjectModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/IObjectModelValidator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator.Validate(Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary, System.String, System.Object)
    
        
    
        Validates the provided object.
    
        
        
        
        :param validatorProvider: The .
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        
        
        :param modelState: The .
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param validationState: The . May be null.
        
        :type validationState: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary
        
        
        :param prefix: The model prefix. Used to map the model object to entries in .
        
        :type prefix: System.String
        
        
        :param model: The model object.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
           void Validate(IModelValidatorProvider validatorProvider, ModelStateDictionary modelState, ValidationStateDictionary validationState, string prefix, object model)
    

