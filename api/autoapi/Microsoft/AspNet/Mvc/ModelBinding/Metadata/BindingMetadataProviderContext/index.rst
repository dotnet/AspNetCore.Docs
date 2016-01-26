

BindingMetadataProviderContext Class
====================================



.. contents:: 
   :local:



Summary
-------

A context for an :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext`








Syntax
------

.. code-block:: csharp

   public class BindingMetadataProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/BindingMetadataProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.BindingMetadataProviderContext(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity, Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext`\.
    
        
        
        
        :param key: The  for the .
        
        :type key: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        
        
        :param attributes: The attributes for the .
        
        :type attributes: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
           public BindingMetadataProviderContext(ModelMetadataIdentity key, ModelAttributes attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.Attributes
    
        
    
        Gets the attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.BindingMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata
    
        
        .. code-block:: csharp
    
           public BindingMetadata BindingMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.Key
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
           public ModelMetadataIdentity Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.PropertyAttributes
    
        
    
        Gets the property attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> PropertyAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext.TypeAttributes
    
        
    
        Gets the type attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> TypeAttributes { get; }
    

