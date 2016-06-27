

ClientModelValidationContext Class
==================================






The context for client-side model validation.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext`








Syntax
------

.. code-block:: csharp

    public class ClientModelValidationContext : ModelValidationContextBase








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext.ClientModelValidationContext(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        Create a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` for validation.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for validation.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` to be used in validation.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param attributes: The attributes dictionary for the HTML tag being rendered.
        
        :type attributes: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ClientModelValidationContext(ActionContext actionContext, ModelMetadata metadata, IModelMetadataProvider metadataProvider, IDictionary<string, string> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext.Attributes
    
        
    
        
        Gets the attributes dictionary for the HTML tag being rendered.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Attributes { get; }
    

