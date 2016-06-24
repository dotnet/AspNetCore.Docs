

ExcludeBindingMetadataProvider Class
====================================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` which configures :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsBindingAllowed` to
<code>false</code> for matching types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider`








Syntax
------

.. code-block:: csharp

    public class ExcludeBindingMetadataProvider : IBindingMetadataProvider, IMetadataDetailsProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider.ExcludeBindingMetadataProvider(System.Type)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider` for the given <em>type</em>.
    
        
    
        
        :param type: 
            The :any:`System.Type`\. All properties of this :any:`System.Type` will have 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsBindingAllowed` set to <code>false</code>.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public ExcludeBindingMetadataProvider(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider.CreateBindingMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    
        
        .. code-block:: csharp
    
            public void CreateBindingMetadata(BindingMetadataProviderContext context)
    

