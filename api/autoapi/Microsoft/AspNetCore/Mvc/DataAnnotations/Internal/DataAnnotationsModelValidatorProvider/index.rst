

DataAnnotationsModelValidatorProvider Class
===========================================






An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider` which provides validators
for attributes which derive from :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\. It also provides
a validator for types which implement :any:`System.ComponentModel.DataAnnotations.IValidatableObject`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider`








Syntax
------

.. code-block:: csharp

    public class DataAnnotationsModelValidatorProvider : IModelValidatorProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider.DataAnnotationsModelValidatorProvider(Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>, Microsoft.Extensions.Localization.IStringLocalizerFactory)
    
        
    
        
        Create a new instance of :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider`\.
    
        
    
        
        :param validationAttributeAdapterProvider: The :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider`
            that supplies :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter`\s.
        
        :type validationAttributeAdapterProvider: Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider
    
        
        :param options: The :any:`Microsoft.Extensions.Options.IOptions\`1`\.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>}
    
        
        :param stringLocalizerFactory: The :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory`\.
        
        :type stringLocalizerFactory: Microsoft.Extensions.Localization.IStringLocalizerFactory
    
        
        .. code-block:: csharp
    
            public DataAnnotationsModelValidatorProvider(IValidationAttributeAdapterProvider validationAttributeAdapterProvider, IOptions<MvcDataAnnotationsLocalizationOptions> options, IStringLocalizerFactory stringLocalizerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateValidators(ModelValidatorProviderContext context)
    

