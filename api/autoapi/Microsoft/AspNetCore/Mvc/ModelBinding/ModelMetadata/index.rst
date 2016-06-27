

ModelMetadata Class
===================






A metadata representation of a model type, property or parameter.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public abstract class ModelMetadata : IEquatable<ModelMetadata>








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Equals(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(ModelMetadata other)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.GetDisplayName()
    
        
    
        
        Gets a display name for the model.
    
        
        :rtype: System.String
        :return: The display name.
    
        
        .. code-block:: csharp
    
            public string GetDisplayName()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param identity: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`\.
        
        :type identity: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
            protected ModelMetadata(ModelMetadataIdentity identity)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.AdditionalValues
    
        
    
        
        Gets a collection of additional information about the model.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary<System.Collections.Generic.IReadOnlyDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public abstract IReadOnlyDictionary<object, object> AdditionalValues { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.BinderModelName
    
        
    
        
        Gets the name of a model if specified explicitly using :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelNameProvider`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string BinderModelName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.BinderType
    
        
    
        
        Gets the :any:`System.Type` of an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` of a model if specified explicitly using 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IBinderTypeProviderMetadata`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public abstract Type BinderType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.BindingSource
    
        
    
        
        Gets a binder metadata for this model.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public abstract BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ContainerType
    
        
    
        
        Gets the container type of this metadata if it represents a property, otherwise <code>null</code>.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ContainerType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ConvertEmptyStringToNull
    
        
    
        
        Gets a value indicating whether or not to convert an empty string value to <code>null</code> when
        representing a model as text.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool ConvertEmptyStringToNull { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.DataTypeName
    
        
    
        
        Gets the name of the model's datatype.  Overrides :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` in some
        display scenarios.
    
        
        :rtype: System.String
        :return: <code>null</code> unless set manually or through additional metadata e.g. attributes.
    
        
        .. code-block:: csharp
    
            public abstract string DataTypeName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Description
    
        
    
        
        Gets the description of the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string Description { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.DisplayFormatString
    
        
    
        
        Gets the composite format :any:`System.String` (see
        http://msdn.microsoft.com/en-us/library/txafckwd.aspx) used to display the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string DisplayFormatString { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.DisplayName
    
        
    
        
        Gets the display name of the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string DisplayName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.EditFormatString
    
        
    
        
        Gets the composite format :any:`System.String` (see
        http://msdn.microsoft.com/en-us/library/txafckwd.aspx) used to edit the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string EditFormatString { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ElementMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for elements of :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` if that :any:`System.Type`
        implements :any:`System.Collections.IEnumerable`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :return: 
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for <code>T</code> if :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` implements 
            :any:`System.Collections.Generic.IEnumerable\`1`\. :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for <code>object</code> if :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType`
            implements :any:`System.Collections.IEnumerable` but not :any:`System.Collections.Generic.IEnumerable\`1`\. <code>null</code> otherwise i.e. when 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsEnumerableType` is <code>false</code>.
    
        
        .. code-block:: csharp
    
            public abstract ModelMetadata ElementMetadata { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ElementType
    
        
    
        
        Gets the :any:`System.Type` for elements of :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` if that :any:`System.Type`
        implements :any:`System.Collections.IEnumerable`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ElementType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.EnumGroupedDisplayNamesAndValues
    
        
    
        
        Gets the ordered and grouped display names and values of all :any:`System.Enum` values in 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName<Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName>, System.String<System.String>}}
        :return: 
            An :any:`System.Collections.Generic.IEnumerable\`1` of :any:`System.Collections.Generic.KeyValuePair\`2` of mappings between 
            :any:`System.Enum` field groups, names and values. <code>null</code> if :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsEnum` is <code>false</code>.
    
        
        .. code-block:: csharp
    
            public abstract IEnumerable<KeyValuePair<EnumGroupAndName, string>> EnumGroupedDisplayNamesAndValues { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.EnumNamesAndValues
    
        
    
        
        Gets the names and values of all :any:`System.Enum` values in :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary<System.Collections.Generic.IReadOnlyDictionary`2>{System.String<System.String>, System.String<System.String>}
        :return: 
            An :any:`System.Collections.Generic.IReadOnlyDictionary\`2` of mappings between :any:`System.Enum` field names
            and values. <code>null</code> if :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsEnum` is <code>false</code>.
    
        
        .. code-block:: csharp
    
            public abstract IReadOnlyDictionary<string, string> EnumNamesAndValues { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.HasNonDefaultEditFormat
    
        
    
        
        Gets a value indicating whether :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.EditFormatString` has a non-<code>null</code>, non-empty
        value different from the default for the datatype.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool HasNonDefaultEditFormat { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.HideSurroundingHtml
    
        
    
        
        Gets a value indicating whether the "HiddenInput" display template should return
        <code>string.Empty</code> (not the expression value) and whether the "HiddenInput" editor template should not
        also return the expression value (together with the hidden <input> element).
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool HideSurroundingHtml { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.HtmlEncode
    
        
    
        
        Gets a value indicating whether the value should be HTML-encoded.
    
        
        :rtype: System.Boolean
        :return: If <code>true</code>, value should be HTML-encoded. Default is <code>true</code>.
    
        
        .. code-block:: csharp
    
            public abstract bool HtmlEncode { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Identity
    
        
    
        
        Gets the key for the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
            protected ModelMetadataIdentity Identity { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsBindingAllowed
    
        
    
        
        Gets a value indicating whether or not the model value can be bound by model binding. This is only
        applicable when the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsBindingAllowed { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsBindingRequired
    
        
    
        
        Gets a value indicating whether or not the model value is required by model binding. This is only
        applicable when the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsBindingRequired { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsCollectionType
    
        
    
        
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` is a collection type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCollectionType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsComplexType
    
        
    
        
        Gets a value indicating whether :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` is a simple type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsComplexType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsEnum
    
        
    
        
        Gets a value indicating whether :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType` is for an :any:`System.Enum`\.
    
        
        :rtype: System.Boolean
        :return: 
            <code>true</code> if <code>type.IsEnum</code> (<code>type.GetTypeInfo().IsEnum</code> for DNX Core 5.0) is <code>true</code> for 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType`\; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public abstract bool IsEnum { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsEnumerableType
    
        
    
        
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` is an enumerable type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnumerableType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsFlagsEnum
    
        
    
        
        Gets a value indicating whether :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType` is for an :any:`System.Enum` with an
        associated :any:`System.FlagsAttribute`\.
    
        
        :rtype: System.Boolean
        :return: 
            <code>true</code> if :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsEnum` is <code>true</code> and :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType` has an
            associated :any:`System.FlagsAttribute`\; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public abstract bool IsFlagsEnum { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsNullableValueType
    
        
    
        
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` is a :any:`System.Nullable\`1`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsNullableValueType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsReadOnly
    
        
    
        
        Gets a value indicating whether or not the model value is read-only. This is only applicable when
        the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsReferenceOrNullableType
    
        
    
        
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` allows <code>null</code> values.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReferenceOrNullableType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsRequired
    
        
    
        
        Gets a value indicating whether or not the model value is required. This is only applicable when
        the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsRequired { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.MetadataKind
    
        
    
        
        Gets a value indicating the kind of metadata element represented by the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataKind
    
        
        .. code-block:: csharp
    
            public ModelMetadataKind MetadataKind { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelBindingMessageProvider
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider` instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
            public abstract IModelBindingMessageProvider ModelBindingMessageProvider { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType
    
        
    
        
        Gets the model type represented by the current instance.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ModelType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.NullDisplayText
    
        
    
        
        Gets the text to display when the model is <code>null</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string NullDisplayText { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Order
    
        
    
        
        Gets a value indicating where the current metadata should be ordered relative to other properties
        in its containing type.
    
        
        :rtype: System.Int32
        :return: The order value of the current metadata.
    
        
        .. code-block:: csharp
    
            public abstract int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Placeholder
    
        
    
        
        Gets the text to display as a placeholder value for an editor.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string Placeholder { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Properties
    
        
    
        
        Gets the collection of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` instances for the model's properties.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection
    
        
        .. code-block:: csharp
    
            public abstract ModelPropertyCollection Properties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.PropertyFilterProvider
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider`\, which can determine which properties
        should be model bound.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider
    
        
        .. code-block:: csharp
    
            public abstract IPropertyFilterProvider PropertyFilterProvider { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.PropertyGetter
    
        
    
        
        Gets a property getter delegate to get the property value from a model object.
    
        
        :rtype: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public abstract Func<object, object> PropertyGetter { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.PropertyName
    
        
    
        
        Gets the property name represented by the current instance.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PropertyName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.PropertySetter
    
        
    
        
        Gets a property setter delegate to set the property value on a model object.
    
        
        :rtype: System.Action<System.Action`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public abstract Action<object, object> PropertySetter { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ShowForDisplay
    
        
    
        
        Gets a value that indicates whether the property should be displayed in read-only views.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool ShowForDisplay { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ShowForEdit
    
        
    
        
        Gets a value that indicates whether the property should be displayed in editable views.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool ShowForEdit { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.SimpleDisplayProperty
    
        
    
        
        Gets  a value which is the name of the property used to display the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string SimpleDisplayProperty { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.TemplateHint
    
        
    
        
        Gets a string used by the templating system to discover display-templates and editor-templates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string TemplateHint { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType
    
        
    
        
        Gets the underlying type argument if :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType` inherits from :any:`System.Nullable\`1`\.
        Otherwise gets :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelType`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type UnderlyingOrModelType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ValidateChildren
    
        
    
        
        Gets a value that indicates whether properties or elements of the model should be validated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool ValidateChildren { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ValidatorMetadata
    
        
    
        
        Gets a collection of metadata items for validators.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public abstract IReadOnlyList<object> ValidatorMetadata { get; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.DefaultOrder
    
        
    
        
        The default value of :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.Order`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int DefaultOrder
    

