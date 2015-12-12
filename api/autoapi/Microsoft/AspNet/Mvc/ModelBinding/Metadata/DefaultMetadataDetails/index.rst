

DefaultMetadataDetails Class
============================



.. contents:: 
   :local:



Summary
-------

Holds associated metadata objects for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails`








Syntax
------

.. code-block:: csharp

   public class DefaultMetadataDetails





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/DefaultMetadataDetails.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.DefaultMetadataDetails(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity, Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails`\.
    
        
        
        
        :param key: The .
        
        :type key: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        
        
        :param attributes: The set of model attributes.
        
        :type attributes: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
           public DefaultMetadataDetails(ModelMetadataIdentity key, ModelAttributes attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.BindingMetadata
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata
    
        
        .. code-block:: csharp
    
           public BindingMetadata BindingMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.DisplayMetadata
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata
    
        
        .. code-block:: csharp
    
           public DisplayMetadata DisplayMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.Key
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
           public ModelMetadataIdentity Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.ModelAttributes
    
        
    
        Gets or sets the set of model attributes.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
           public ModelAttributes ModelAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.Properties
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` entries for the model properties.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata[]
    
        
        .. code-block:: csharp
    
           public ModelMetadata[] Properties { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.PropertyGetter
    
        
    
        Gets or sets a property getter delegate to get the property value from a model object.
    
        
        :rtype: System.Func{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public Func<object, object> PropertyGetter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.PropertySetter
    
        
    
        Gets or sets a property setter delegate to set the property value on a model object.
    
        
        :rtype: System.Action{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public Action<object, object> PropertySetter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails.ValidationMetadata
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata`
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata
    
        
        .. code-block:: csharp
    
           public ValidationMetadata ValidationMetadata { get; set; }
    

