

DefaultCompositeMetadataDetailsProvider Class
=============================================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultCompositeMetadataDetailsProvider : ICompositeMetadataDetailsProvider, IBindingMetadataProvider, IDisplayMetadataProvider, IValidationMetadataProvider, IMetadataDetailsProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider.DefaultCompositeMetadataDetailsProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider`\.
    
        
    
        
        :param providers: The set of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider` instances.
        
        :type providers: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider>}
    
        
        .. code-block:: csharp
    
            public DefaultCompositeMetadataDetailsProvider(IEnumerable<IMetadataDetailsProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider.CreateBindingMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public virtual void CreateBindingMetadata(BindingMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider.CreateDisplayMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public virtual void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultCompositeMetadataDetailsProvider.CreateValidationMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public virtual void CreateValidationMetadata(ValidationMetadataProviderContext context)
    

