

DataAnnotationsClientModelValidatorProvider Class
=================================================






An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` which provides client validators
for attributes which derive from :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\. It also provides
a validator for types which implement :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`\.
The logic to support :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`
is implemented in :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider`








Syntax
------

.. code-block:: csharp

    public class DataAnnotationsClientModelValidatorProvider : IClientModelValidatorProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider.DataAnnotationsClientModelValidatorProvider(Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>, Microsoft.Extensions.Localization.IStringLocalizerFactory)
    
        
    
        
        Create a new instance of :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider`\.
    
        
    
        
        :param validationAttributeAdapterProvider: The :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider`
            that supplies :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter`\s.
        
        :type validationAttributeAdapterProvider: Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider
    
        
        :param options: The :any:`Microsoft.Extensions.Options.IOptions\`1`\.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>}
    
        
        :param stringLocalizerFactory: The :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory`\.
        
        :type stringLocalizerFactory: Microsoft.Extensions.Localization.IStringLocalizerFactory
    
        
        .. code-block:: csharp
    
            public DataAnnotationsClientModelValidatorProvider(IValidationAttributeAdapterProvider validationAttributeAdapterProvider, IOptions<MvcDataAnnotationsLocalizationOptions> options, IStringLocalizerFactory stringLocalizerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateValidators(ClientValidatorProviderContext context)
    

