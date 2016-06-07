

DefaultBindingMetadataProvider Class
====================================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultBindingMetadataProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultBindingMetadataProvider : IBindingMetadataProvider, IMetadataDetailsProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultBindingMetadataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultBindingMetadataProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultBindingMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.DefaultBindingMetadataProvider.DefaultBindingMetadataProvider(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider)
    
        
    
        
        :type messageProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
            public DefaultBindingMetadataProvider(ModelBindingMessageProvider messageProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultBindingMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultBindingMetadataProvider.CreateBindingMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateBindingMetadata(BindingMetadataProviderContext context)
    

