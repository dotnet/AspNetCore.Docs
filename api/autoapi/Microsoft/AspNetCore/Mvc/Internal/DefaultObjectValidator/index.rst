

DefaultObjectValidator Class
============================






The default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator`








Syntax
------

.. code-block:: csharp

    public class DefaultObjectValidator : IObjectModelValidator








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator.DefaultObjectValidator(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.Internal.ValidatorCache)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator`\.
    
        
    
        
        :param modelMetadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type modelMetadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param validatorCache: The :any:`Microsoft.AspNetCore.Mvc.Internal.ValidatorCache`\.
        
        :type validatorCache: Microsoft.AspNetCore.Mvc.Internal.ValidatorCache
    
        
        .. code-block:: csharp
    
            public DefaultObjectValidator(IModelMetadataProvider modelMetadataProvider, ValidatorCache validatorCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultObjectValidator.Validate(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary, System.String, System.Object)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type validatorProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider
    
        
        :type validationState: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary
    
        
        :type prefix: System.String
    
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            public void Validate(ActionContext actionContext, IModelValidatorProvider validatorProvider, ValidationStateDictionary validationState, string prefix, object model)
    

