

ModelMetadataIdentity Struct
============================



.. contents:: 
   :local:



Summary
-------

A key type which identifies a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.











Syntax
------

.. code-block:: csharp

   public struct ModelMetadataIdentity





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Metadata/ModelMetadataIdentity.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity

Methods
-------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ForProperty(System.Type, System.String, System.Type)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` for the provided property.
    
        
        
        
        :param modelType: The model type.
        
        :type modelType: System.Type
        
        
        :param name: The name of the property.
        
        :type name: System.String
        
        
        :param containerType: The container type of the model property.
        
        :type containerType: System.Type
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity" />.
    
        
        .. code-block:: csharp
    
           public static ModelMetadataIdentity ForProperty(Type modelType, string name, Type containerType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ForType(System.Type)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` for the provided model :any:`System.Type`\.
    
        
        
        
        :param modelType: The model .
        
        :type modelType: System.Type
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity" />.
    
        
        .. code-block:: csharp
    
           public static ModelMetadataIdentity ForType(Type modelType)
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ContainerType
    
        
    
        Gets the :any:`System.Type` defining the model property respresented by the current
        instance, or <c>null</c> if the current instance does not represent a property.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ContainerType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.MetadataKind
    
        
    
        Gets a value indicating the kind of metadata represented by the current instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataKind
    
        
        .. code-block:: csharp
    
           public ModelMetadataKind MetadataKind { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ModelType
    
        
    
        Gets the :any:`System.Type` represented by the current instance.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ModelType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.Name
    
        
    
        Gets the name of the current instance if it represents a parameter or property, or <c>null</c> if
        the current instance represents a type.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    

