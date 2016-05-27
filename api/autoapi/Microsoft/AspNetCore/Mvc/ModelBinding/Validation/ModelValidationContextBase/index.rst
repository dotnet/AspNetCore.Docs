

ModelValidationContextBase Class
================================






A common base class for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext` and :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext`\.


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








Syntax
------

.. code-block:: csharp

    public class ModelValidationContextBase








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase.ActionContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase.MetadataProvider
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public IModelMetadataProvider MetadataProvider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase.ModelMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata ModelMetadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase.ModelValidationContextBase(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase`\.
    
        
    
        
        :param actionContext: The :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase.ActionContext` for this context.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param modelMetadata: The :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase.ModelMetadata` for this model.
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` to be used by this context.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public ModelValidationContextBase(ActionContext actionContext, ModelMetadata modelMetadata, IModelMetadataProvider metadataProvider)
    

