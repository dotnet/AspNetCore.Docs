

DataAnnotationsModelValidator Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator`








Syntax
------

.. code-block:: csharp

   public class DataAnnotationsModelValidator : IModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/DataAnnotationsModelValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator.DataAnnotationsModelValidator(System.ComponentModel.DataAnnotations.ValidationAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
        
        
        :type attribute: System.ComponentModel.DataAnnotations.ValidationAttribute
        
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public DataAnnotationsModelValidator(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator.Validate(Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext)
    
        
        
        
        :type validationContext: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult}
    
        
        .. code-block:: csharp
    
           public IEnumerable<ModelValidationResult> Validate(ModelValidationContext validationContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator.Attribute
    
        
        :rtype: System.ComponentModel.DataAnnotations.ValidationAttribute
    
        
        .. code-block:: csharp
    
           public ValidationAttribute Attribute { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsModelValidator.IsRequired
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsRequired { get; }
    

