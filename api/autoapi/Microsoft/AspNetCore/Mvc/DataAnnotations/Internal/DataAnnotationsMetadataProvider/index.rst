

DataAnnotationsMetadataProvider Class
=====================================






An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` and :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider` for
the System.ComponentModel.DataAnnotations attribute classes.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider`








Syntax
------

.. code-block:: csharp

    public class DataAnnotationsMetadataProvider : IBindingMetadataProvider, IDisplayMetadataProvider, IValidationMetadataProvider, IMetadataDetailsProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider.CreateBindingMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateBindingMetadata(BindingMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider.CreateDisplayMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider.CreateValidationMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateValidationMetadata(ValidationMetadataProviderContext context)
    

