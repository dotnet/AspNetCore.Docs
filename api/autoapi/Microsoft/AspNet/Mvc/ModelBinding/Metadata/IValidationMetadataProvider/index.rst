

IValidationMetadataProvider Interface
=====================================



.. contents:: 
   :local:



Summary
-------

Provides :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata` for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.











Syntax
------

.. code-block:: csharp

   public interface IValidationMetadataProvider : IMetadataDetailsProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/IValidationMetadataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider.GetValidationMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext)
    
        
    
        Gets the values for properties of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    
        
        .. code-block:: csharp
    
           void GetValidationMetadata(ValidationMetadataProviderContext context)
    

