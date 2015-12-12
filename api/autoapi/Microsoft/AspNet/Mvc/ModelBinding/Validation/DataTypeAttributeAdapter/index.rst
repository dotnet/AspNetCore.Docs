

DataTypeAttributeAdapter Class
==============================



.. contents:: 
   :local:



Summary
-------

A validation adapter that is used to map :any:`System.ComponentModel.DataAnnotations.DataTypeAttribute`\'s to a single client side validation
rule.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator{System.ComponentModel.DataAnnotations.DataTypeAttribute}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter`








Syntax
------

.. code-block:: csharp

   public class DataTypeAttributeAdapter : DataAnnotationsClientModelValidator<DataTypeAttribute>, IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.DataAnnotations/DataTypeAttributeAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter.DataTypeAttributeAdapter(System.ComponentModel.DataAnnotations.DataTypeAttribute, System.String, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
        
        
        :type attribute: System.ComponentModel.DataAnnotations.DataTypeAttribute
        
        
        :type ruleName: System.String
        
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public DataTypeAttributeAdapter(DataTypeAttribute attribute, string ruleName, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataTypeAttributeAdapter.RuleName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RuleName { get; }
    

