

IClientModelValidator Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/IClientModelValidator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

