

DisplayMetadataProviderContext Class
====================================



.. contents:: 
   :local:



Summary
-------

A context for and :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext`








Syntax
------

.. code-block:: csharp

   public class DisplayMetadataProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/DisplayMetadataProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.DisplayMetadataProviderContext(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity, Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext`\.
    
        
        
        
        :param key: The  for the .
        
        :type key: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        
        
        :param attributes: The attributes for the .
        
        :type attributes: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
           public DisplayMetadataProviderContext(ModelMetadataIdentity key, ModelAttributes attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.Attributes
    
        
    
        Gets the attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.DisplayMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata
    
        
        .. code-block:: csharp
    
           public DisplayMetadata DisplayMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.Key
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
           public ModelMetadataIdentity Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.PropertyAttributes
    
        
    
        Gets the property attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> PropertyAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext.TypeAttributes
    
        
    
        Gets the type attributes.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> TypeAttributes { get; }
    

