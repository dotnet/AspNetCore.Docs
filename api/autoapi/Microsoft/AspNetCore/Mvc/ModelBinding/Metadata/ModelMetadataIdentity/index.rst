

ModelMetadataIdentity Struct
============================






A key type which identifies a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct ModelMetadataIdentity : IEquatable<ModelMetadataIdentity>








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ContainerType
    
        
    
        
        Gets the :any:`System.Type` defining the model property respresented by the current
        instance, or <code>null</code> if the current instance does not represent a property.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ContainerType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.MetadataKind
    
        
    
        
        Gets a value indicating the kind of metadata represented by the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataKind
    
        
        .. code-block:: csharp
    
            public ModelMetadataKind MetadataKind
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ModelType
    
        
    
        
        Gets the :any:`System.Type` represented by the current instance.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ModelType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.Name
    
        
    
        
        Gets the name of the current instance if it represents a parameter or property, or <code>null</code> if
        the current instance represents a type.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
            }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.Equals(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(ModelMetadataIdentity other)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ForProperty(System.Type, System.String, System.Type)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` for the provided property.
    
        
    
        
        :param modelType: The model type.
        
        :type modelType: System.Type
    
        
        :param name: The name of the property.
        
        :type name: System.String
    
        
        :param containerType: The container type of the model property.
        
        :type containerType: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        .. code-block:: csharp
    
            public static ModelMetadataIdentity ForProperty(Type modelType, string name, Type containerType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.ForType(System.Type)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity` for the provided model :any:`System.Type`\.
    
        
    
        
        :param modelType: The model :any:`System.Type`\.
        
        :type modelType: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
    
        
        .. code-block:: csharp
    
            public static ModelMetadataIdentity ForType(Type modelType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

