

MinLengthAttributeAdapter Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator{System.ComponentModel.DataAnnotations.MinLengthAttribute}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.MinLengthAttributeAdapter`








Syntax
------

.. code-block:: csharp

   public class MinLengthAttributeAdapter : DataAnnotationsClientModelValidator<MinLengthAttribute>, IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/MinLengthAttributeAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MinLengthAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MinLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MinLengthAttributeAdapter.MinLengthAttributeAdapter(System.ComponentModel.DataAnnotations.MinLengthAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
        
        
        :type attribute: System.ComponentModel.DataAnnotations.MinLengthAttribute
        
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public MinLengthAttributeAdapter(MinLengthAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MinLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MinLengthAttributeAdapter.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

