

DataAnnotationsModelValidatorProvider Class
===========================================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider` which provides validators
for attributes which derive from :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\. It also provides
a validator for types which implement :any:`System.ComponentModel.DataAnnotations.IValidatableObject`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidatorProvider`








Syntax
------

.. code-block:: csharp

   public class DataAnnotationsModelValidatorProvider : IModelValidatorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.DataAnnotations/DataAnnotationsModelValidatorProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidatorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidatorProvider.DataAnnotationsModelValidatorProvider(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions>, Microsoft.Extensions.Localization.IStringLocalizerFactory)
    
        
    
        Create a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidatorProvider`\.
    
        
        
        
        :param options: The .
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions}
        
        
        :param stringLocalizerFactory: The .
        
        :type stringLocalizerFactory: Microsoft.Extensions.Localization.IStringLocalizerFactory
    
        
        .. code-block:: csharp
    
           public DataAnnotationsModelValidatorProvider(IOptions<MvcDataAnnotationsLocalizationOptions> options, IStringLocalizerFactory stringLocalizerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    
        
        .. code-block:: csharp
    
           public void GetValidators(ModelValidatorProviderContext context)
    

