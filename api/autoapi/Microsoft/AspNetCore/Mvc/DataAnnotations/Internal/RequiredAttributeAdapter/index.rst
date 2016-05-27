

RequiredAttributeAdapter Class
==============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter{System.ComponentModel.DataAnnotations.RequiredAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase{System.ComponentModel.DataAnnotations.RequiredAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter`








Syntax
------

.. code-block:: csharp

    public class RequiredAttributeAdapter : AttributeAdapterBase<RequiredAttribute>, IAttributeAdapter, IClientModelValidator








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter.RequiredAttributeAdapter(System.ComponentModel.DataAnnotations.RequiredAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        :type attribute: System.ComponentModel.DataAnnotations.RequiredAttribute
    
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public RequiredAttributeAdapter(RequiredAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter.AddValidation(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    
        
        .. code-block:: csharp
    
            public override void AddValidation(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter.GetErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase)
    
        
    
        
        :type validationContext: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetErrorMessage(ModelValidationContextBase validationContext)
    

