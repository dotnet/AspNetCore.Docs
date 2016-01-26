

DataAnnotationsClientModelValidatorProvider Class
=================================================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` which provides client validators
for attributes which derive from :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\. It also provides
a validator for types which implement :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator`\.
The logic to support :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator`
is implemented in :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidatorProvider`








Syntax
------

.. code-block:: csharp

   public class DataAnnotationsClientModelValidatorProvider : IClientModelValidatorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/DataAnnotationsClientModelValidatorProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidatorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidatorProvider.DataAnnotationsClientModelValidatorProvider(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions>, Microsoft.Extensions.Localization.IStringLocalizerFactory)
    
        
    
        Create a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidatorProvider`\.
    
        
        
        
        :param options: The .
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions}
        
        
        :param stringLocalizerFactory: The .
        
        :type stringLocalizerFactory: Microsoft.Extensions.Localization.IStringLocalizerFactory
    
        
        .. code-block:: csharp
    
           public DataAnnotationsClientModelValidatorProvider(IOptions<MvcDataAnnotationsLocalizationOptions> options, IStringLocalizerFactory stringLocalizerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    
        
        .. code-block:: csharp
    
           public void GetValidators(ClientValidatorProviderContext context)
    

