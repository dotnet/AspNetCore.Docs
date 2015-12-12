

IDisplayMetadataProvider Interface
==================================



.. contents:: 
   :local:



Summary
-------

Provides :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata` for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.











Syntax
------

.. code-block:: csharp

   public interface IDisplayMetadataProvider : IMetadataDetailsProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/IDisplayMetadataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider.GetDisplayMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext)
    
        
    
        Gets the values for properties of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    
        
        .. code-block:: csharp
    
           void GetDisplayMetadata(DisplayMetadataProviderContext context)
    

