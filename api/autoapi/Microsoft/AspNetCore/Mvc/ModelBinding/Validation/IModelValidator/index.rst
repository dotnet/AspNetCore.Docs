

IModelValidator Interface
=========================






Validates a model value.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IModelValidator








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator.Validate(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext)
    
        
    
        
        Validates the model value.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationResult<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationResult>}
        :return: 
            A list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationResult` indicating the results of validating the model value.
    
        
        .. code-block:: csharp
    
            IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
    

