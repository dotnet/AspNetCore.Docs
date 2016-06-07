

IValidationMetadataProvider Interface
=====================================






Provides :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata` for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IValidationMetadataProvider : IMetadataDetailsProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider.CreateValidationMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext)
    
        
    
        
        Gets the values for properties of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata`\. 
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    
        
        .. code-block:: csharp
    
            void CreateValidationMetadata(ValidationMetadataProviderContext context)
    

