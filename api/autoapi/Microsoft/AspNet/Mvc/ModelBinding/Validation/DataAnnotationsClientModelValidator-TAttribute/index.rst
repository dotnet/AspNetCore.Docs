

DataAnnotationsClientModelValidator<TAttribute> Class
=====================================================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator` which understands data annotation attributes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator\<TAttribute>`








Syntax
------

.. code-block:: csharp

   public abstract class DataAnnotationsClientModelValidator<TAttribute> : IClientModelValidator where TAttribute : ValidationAttribute





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.DataAnnotations/DataAnnotationsClientModelValidatorOfTAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>.DataAnnotationsClientModelValidator(TAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        Create a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator\`1`\.
    
        
        
        
        :param attribute: The  instance to validate.
        
        :type attribute: {TAttribute}
        
        
        :param stringLocalizer: The .
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public DataAnnotationsClientModelValidator(TAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public abstract IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>.GetErrorMessage(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Gets the error message formatted using the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator\`1.Attribute`\.
    
        
        
        
        :param modelMetadata: The  associated with the model annotated with
            .
        
        :type modelMetadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        :rtype: System.String
        :return: Formatted error string.
    
        
        .. code-block:: csharp
    
           protected virtual string GetErrorMessage(ModelMetadata modelMetadata)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DataAnnotationsClientModelValidator<TAttribute>.Attribute
    
        
    
        Gets the ``TAttribute`` instance.
    
        
        :rtype: {TAttribute}
    
        
        .. code-block:: csharp
    
           public TAttribute Attribute { get; }
    

