

NumericClientModelValidator Class
=================================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator` that provides the rule for validating
numeric types.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.NumericClientModelValidator`








Syntax
------

.. code-block:: csharp

   public class NumericClientModelValidator : IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/NumericClientModelValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.NumericClientModelValidator

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.NumericClientModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.NumericClientModelValidator.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

