

ModelValidationContext Class
============================






A context object for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext`








Syntax
------

.. code-block:: csharp

    public class ModelValidationContext : ModelValidationContextBase








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext.ModelValidationContext(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, System.Object, System.Object)
    
        
    
        
        Create a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` for validation.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param modelMetadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for validation.
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` to be used in validation.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param container: The model container.
        
        :type container: System.Object
    
        
        :param model: The model to be validated.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            public ModelValidationContext(ActionContext actionContext, ModelMetadata modelMetadata, IModelMetadataProvider metadataProvider, object container, object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext.Container
    
        
    
        
        Gets the model container object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Container { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext.Model
    
        
    
        
        Gets the model object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Model { get; }
    

