

BindingMetadataProviderContext Class
====================================






A context for an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext`








Syntax
------

.. code-block:: csharp

    public class BindingMetadataProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.BindingMetadataProviderContext(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity, Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext`\.
    
        
    
        
        :param key: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type key: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        :param attributes: The attributes for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type attributes: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
            public BindingMetadataProviderContext(ModelMetadataIdentity key, ModelAttributes attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.Attributes
    
        
    
        
        Gets the attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.BindingMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata
    
        
        .. code-block:: csharp
    
            public BindingMetadata BindingMetadata { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.Key
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
            public ModelMetadataIdentity Key { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.PropertyAttributes
    
        
    
        
        Gets the property attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> PropertyAttributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.TypeAttributes
    
        
    
        
        Gets the type attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> TypeAttributes { get; }
    

