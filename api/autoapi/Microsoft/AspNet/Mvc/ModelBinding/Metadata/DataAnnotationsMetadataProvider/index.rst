

DataAnnotationsMetadataProvider Class
=====================================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` and :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider` for
the System.ComponentModel.DataAnnotations attribute classes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataAnnotationsMetadataProvider`








Syntax
------

.. code-block:: csharp

   public class DataAnnotationsMetadataProvider : IBindingMetadataProvider, IDisplayMetadataProvider, IValidationMetadataProvider, IMetadataDetailsProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.DataAnnotations/DataAnnotationsMetadataProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataAnnotationsMetadataProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataAnnotationsMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataAnnotationsMetadataProvider.GetBindingMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
           public void GetBindingMetadata(BindingMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataAnnotationsMetadataProvider.GetDisplayMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    
        
        .. code-block:: csharp
    
           public void GetDisplayMetadata(DisplayMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataAnnotationsMetadataProvider.GetValidationMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    
        
        .. code-block:: csharp
    
           public void GetValidationMetadata(ValidationMetadataProviderContext context)
    

