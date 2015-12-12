

DefaultCompositeMetadataDetailsProvider Class
=============================================



.. contents:: 
   :local:



Summary
-------

A default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultCompositeMetadataDetailsProvider : ICompositeMetadataDetailsProvider, IBindingMetadataProvider, IDisplayMetadataProvider, IValidationMetadataProvider, IMetadataDetailsProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/DefaultCompositeMetadataDetailsProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider.DefaultCompositeMetadataDetailsProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider`\.
    
        
        
        
        :param providers: The set of  instances.
        
        :type providers: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider}
    
        
        .. code-block:: csharp
    
           public DefaultCompositeMetadataDetailsProvider(IEnumerable<IMetadataDetailsProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider.GetBindingMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
           public virtual void GetBindingMetadata(BindingMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider.GetDisplayMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    
        
        .. code-block:: csharp
    
           public virtual void GetDisplayMetadata(DisplayMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider.GetValidationMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    
        
        .. code-block:: csharp
    
           public virtual void GetValidationMetadata(ValidationMetadataProviderContext context)
    

