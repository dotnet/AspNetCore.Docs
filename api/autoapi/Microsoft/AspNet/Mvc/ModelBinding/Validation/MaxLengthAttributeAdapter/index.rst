

MaxLengthAttributeAdapter Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator{System.ComponentModel.DataAnnotations.MaxLengthAttribute}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.MaxLengthAttributeAdapter`








Syntax
------

.. code-block:: csharp

   public class MaxLengthAttributeAdapter : DataAnnotationsClientModelValidator<MaxLengthAttribute>, IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.DataAnnotations/MaxLengthAttributeAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MaxLengthAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MaxLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MaxLengthAttributeAdapter.MaxLengthAttributeAdapter(System.ComponentModel.DataAnnotations.MaxLengthAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
        
        
        :type attribute: System.ComponentModel.DataAnnotations.MaxLengthAttribute
        
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public MaxLengthAttributeAdapter(MaxLengthAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MaxLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MaxLengthAttributeAdapter.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

