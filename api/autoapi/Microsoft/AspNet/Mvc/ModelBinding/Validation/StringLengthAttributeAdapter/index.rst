

StringLengthAttributeAdapter Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator{System.ComponentModel.DataAnnotations.StringLengthAttribute}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.StringLengthAttributeAdapter`








Syntax
------

.. code-block:: csharp

   public class StringLengthAttributeAdapter : DataAnnotationsClientModelValidator<StringLengthAttribute>, IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.DataAnnotations/StringLengthAttributeAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.StringLengthAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.StringLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.StringLengthAttributeAdapter.StringLengthAttributeAdapter(System.ComponentModel.DataAnnotations.StringLengthAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
        
        
        :type attribute: System.ComponentModel.DataAnnotations.StringLengthAttribute
        
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public StringLengthAttributeAdapter(StringLengthAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.StringLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.StringLengthAttributeAdapter.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

