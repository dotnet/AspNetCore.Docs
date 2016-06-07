

DataTypeAttributeAdapter Class
==============================






A validation adapter that is used to map :any:`System.ComponentModel.DataAnnotations.DataTypeAttribute`\'s to a single client side validation
rule.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter{System.ComponentModel.DataAnnotations.DataTypeAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase{System.ComponentModel.DataAnnotations.DataTypeAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter`








Syntax
------

.. code-block:: csharp

    public class DataTypeAttributeAdapter : AttributeAdapterBase<DataTypeAttribute>, IAttributeAdapter, IClientModelValidator








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter.RuleName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RuleName
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter.DataTypeAttributeAdapter(System.ComponentModel.DataAnnotations.DataTypeAttribute, System.String, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        :type attribute: System.ComponentModel.DataAnnotations.DataTypeAttribute
    
        
        :type ruleName: System.String
    
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public DataTypeAttributeAdapter(DataTypeAttribute attribute, string ruleName, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter.AddValidation(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    
        
        .. code-block:: csharp
    
            public override void AddValidation(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter.GetErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase)
    
        
    
        
        :type validationContext: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetErrorMessage(ModelValidationContextBase validationContext)
    

