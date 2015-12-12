

IBindingMetadataProvider Interface
==================================



.. contents:: 
   :local:



Summary
-------

Provides :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata` for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.











Syntax
------

.. code-block:: csharp

   public interface IBindingMetadataProvider : IMetadataDetailsProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/IBindingMetadataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider.GetBindingMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
    
        Gets the values for properties of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
           void GetBindingMetadata(BindingMetadataProviderContext context)
    

