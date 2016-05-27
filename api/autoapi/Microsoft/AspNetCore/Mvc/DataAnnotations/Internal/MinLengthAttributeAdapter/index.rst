

MinLengthAttributeAdapter Class
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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter{System.ComponentModel.DataAnnotations.MinLengthAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase{System.ComponentModel.DataAnnotations.MinLengthAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter`








Syntax
------

.. code-block:: csharp

    public class MinLengthAttributeAdapter : AttributeAdapterBase<MinLengthAttribute>, IAttributeAdapter, IClientModelValidator








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter.MinLengthAttributeAdapter(System.ComponentModel.DataAnnotations.MinLengthAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        :type attribute: System.ComponentModel.DataAnnotations.MinLengthAttribute
    
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public MinLengthAttributeAdapter(MinLengthAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter.AddValidation(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    
        
        .. code-block:: csharp
    
            public override void AddValidation(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter.GetErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase)
    
        
    
        
        :type validationContext: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetErrorMessage(ModelValidationContextBase validationContext)
    

