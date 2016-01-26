

RegularExpressionAttributeAdapter Class
=======================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator{System.ComponentModel.DataAnnotations.RegularExpressionAttribute}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.RegularExpressionAttributeAdapter`








Syntax
------

.. code-block:: csharp

   public class RegularExpressionAttributeAdapter : DataAnnotationsClientModelValidator<RegularExpressionAttribute>, IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/RegularExpressionAttributeAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RegularExpressionAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RegularExpressionAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RegularExpressionAttributeAdapter.RegularExpressionAttributeAdapter(System.ComponentModel.DataAnnotations.RegularExpressionAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
        
        
        :type attribute: System.ComponentModel.DataAnnotations.RegularExpressionAttribute
        
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public RegularExpressionAttributeAdapter(RegularExpressionAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RegularExpressionAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RegularExpressionAttributeAdapter.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

