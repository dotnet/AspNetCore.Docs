

ValidationVisitor Class
=======================






A visitor implementation that interprets :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary` to traverse
a model object graph and perform validation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor`








Syntax
------

.. code-block:: csharp

    public class ValidationVisitor








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor.ValidationVisitor(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider, Microsoft.AspNetCore.Mvc.Internal.ValidatorCache, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param validatorProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider`\.
        
        :type validatorProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider
    
        
        :param validatorCache: The :any:`Microsoft.AspNetCore.Mvc.Internal.ValidatorCache` that provides a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator`\s.
        
        :type validatorCache: Microsoft.AspNetCore.Mvc.Internal.ValidatorCache
    
        
        :param metadataProvider: The provider used for reading metadata for the model type.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param validationState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary`\.
        
        :type validationState: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary
    
        
        .. code-block:: csharp
    
            public ValidationVisitor(ActionContext actionContext, IModelValidatorProvider validatorProvider, ValidatorCache validatorCache, IModelMetadataProvider metadataProvider, ValidationStateDictionary validationState)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor.Validate(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        
        Validates a object.
    
        
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param key: The model prefix key.
        
        :type key: System.String
    
        
        :param model: The model object.
        
        :type model: System.Object
        :rtype: System.Boolean
        :return: <code>true</code> if the object is valid, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            public bool Validate(ModelMetadata metadata, string key, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor.ValidateNode()
    
        
    
        
        Validates a single node in a model object graph.
    
        
        :rtype: System.Boolean
        :return: <code>true</code> if the node is valid, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            protected virtual bool ValidateNode()
    

