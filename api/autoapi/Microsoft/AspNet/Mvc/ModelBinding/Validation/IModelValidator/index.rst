

IModelValidator Interface
=========================



.. contents:: 
   :local:



Summary
-------

Validates a model value.











Syntax
------

.. code-block:: csharp

   public interface IModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/IModelValidator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator.Validate(Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext)
    
        
    
        Validates the model value.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult}
        :return: A list of <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult" /> indicating the results of validating the model value.
    
        
        .. code-block:: csharp
    
           IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator.IsRequired
    
        
    
        Gets a value indicating whether or not this validator validates that a required value
        has been provided for the model.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsRequired { get; }
    

