

DataAnnotationsModelValidator Class
===================================






Validates based on the given :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator`








Syntax
------

.. code-block:: csharp

    public class DataAnnotationsModelValidator : IModelValidator








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator.DataAnnotationsModelValidator(Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider, System.ComponentModel.DataAnnotations.ValidationAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
         Create a new instance of :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator`\.
    
        
    
        
        :param validationAttributeAdapterProvider: The :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider`
            which :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1`\'s will be created from.
        
        :type validationAttributeAdapterProvider: Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider
    
        
        :param attribute: The :any:`System.ComponentModel.DataAnnotations.ValidationAttribute` that defines what we're validating.
        
        :type attribute: System.ComponentModel.DataAnnotations.ValidationAttribute
    
        
        :param stringLocalizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer` used to create messages.
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public DataAnnotationsModelValidator(IValidationAttributeAdapterProvider validationAttributeAdapterProvider, ValidationAttribute attribute, IStringLocalizer stringLocalizer)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator.Attribute
    
        
    
        
        The attribute being validated against.
    
        
        :rtype: System.ComponentModel.DataAnnotations.ValidationAttribute
    
        
        .. code-block:: csharp
    
            public ValidationAttribute Attribute { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator.Validate(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext)
    
        
    
        
        Validates the context against the :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\.
    
        
    
        
        :param validationContext: The context being validated.
        
        :type validationContext: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationResult<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationResult>}
        :return: An enumerable of the validation results.
    
        
        .. code-block:: csharp
    
            public IEnumerable<ModelValidationResult> Validate(ModelValidationContext validationContext)
    

