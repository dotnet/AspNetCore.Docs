

IDisplayMetadataProvider Interface
==================================






Provides :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadata` for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


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

    public interface IDisplayMetadataProvider : IMetadataDetailsProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider.CreateDisplayMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext)
    
        
    
        
        Sets the values for properties of :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.DisplayMetadata`\. 
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    
        
        .. code-block:: csharp
    
            void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    

