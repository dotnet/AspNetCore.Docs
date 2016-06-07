

MaxLengthAttributeAdapter Class
===============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter{System.ComponentModel.DataAnnotations.MaxLengthAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase{System.ComponentModel.DataAnnotations.MaxLengthAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter`








Syntax
------

.. code-block:: csharp

    public class MaxLengthAttributeAdapter : AttributeAdapterBase<MaxLengthAttribute>, IAttributeAdapter, IClientModelValidator








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter.MaxLengthAttributeAdapter(System.ComponentModel.DataAnnotations.MaxLengthAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        :type attribute: System.ComponentModel.DataAnnotations.MaxLengthAttribute
    
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public MaxLengthAttributeAdapter(MaxLengthAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter.AddValidation(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    
        
        .. code-block:: csharp
    
            public override void AddValidation(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter.GetErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase)
    
        
    
        
        :type validationContext: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetErrorMessage(ModelValidationContextBase validationContext)
    

