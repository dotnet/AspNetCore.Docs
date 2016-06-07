

IBindingMetadataProvider Interface
==================================






Provides :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata` for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


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

    public interface IBindingMetadataProvider : IMetadataDetailsProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider.CreateBindingMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
    
        
        Sets the values for properties of :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.BindingMetadata`\. 
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
            void CreateBindingMetadata(BindingMetadataProviderContext context)
    

