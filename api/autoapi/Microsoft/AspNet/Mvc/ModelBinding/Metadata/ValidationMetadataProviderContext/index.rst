

ValidationMetadataProviderContext Class
=======================================



.. contents:: 
   :local:



Summary
-------

A context for an :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext`








Syntax
------

.. code-block:: csharp

   public class ValidationMetadataProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/ValidationMetadataProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.ValidationMetadataProviderContext(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity, Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext`\.
    
        
        
        
        :param key: The  for the .
        
        :type key: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        
        
        :param attributes: The attributes for the .
        
        :type attributes: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
           public ValidationMetadataProviderContext(ModelMetadataIdentity key, ModelAttributes attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.Attributes
    
        
    
        Gets the attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.Key
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
           public ModelMetadataIdentity Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.PropertyAttributes
    
        
    
        Gets the property attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> PropertyAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.TypeAttributes
    
        
    
        Gets the type attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> TypeAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext.ValidationMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata
    
        
        .. code-block:: csharp
    
           public ValidationMetadata ValidationMetadata { get; }
    

