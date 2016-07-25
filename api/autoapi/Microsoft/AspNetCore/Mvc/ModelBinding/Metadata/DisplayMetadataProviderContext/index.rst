

DisplayMetadataProviderContext Class
====================================






A context for and :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext`








Syntax
------

.. code-block:: csharp

    public class DisplayMetadataProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.DisplayMetadataProviderContext(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity, Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext`\.
    
        
    
        
        :param key: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type key: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        :param attributes: The attributes for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type attributes: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
            public DisplayMetadataProviderContext(ModelMetadataIdentity key, ModelAttributes attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.Attributes
    
        
    
        
        Gets the attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.DisplayMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadata
    
        
        .. code-block:: csharp
    
            public DisplayMetadata DisplayMetadata { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.Key
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
            public ModelMetadataIdentity Key { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.PropertyAttributes
    
        
    
        
        Gets the property attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> PropertyAttributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.TypeAttributes
    
        
    
        
        Gets the type attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> TypeAttributes { get; }
    

