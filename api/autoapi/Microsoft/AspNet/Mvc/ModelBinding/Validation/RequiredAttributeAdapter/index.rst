

RequiredAttributeAdapter Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator{System.ComponentModel.DataAnnotations.RequiredAttribute}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.RequiredAttributeAdapter`








Syntax
------

.. code-block:: csharp

   public class RequiredAttributeAdapter : DataAnnotationsClientModelValidator<RequiredAttribute>, IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/RequiredAttributeAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RequiredAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RequiredAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RequiredAttributeAdapter.RequiredAttributeAdapter(System.ComponentModel.DataAnnotations.RequiredAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
        
        
        :type attribute: System.ComponentModel.DataAnnotations.RequiredAttribute
        
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public RequiredAttributeAdapter(RequiredAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RequiredAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.RequiredAttributeAdapter.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

