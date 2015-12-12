

ModelMetadata Class
===================



.. contents:: 
   :local:



Summary
-------

A metadata representation of a model type, property or parameter.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`








Syntax
------

.. code-block:: csharp

   public abstract class ModelMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelMetadata.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelMetadata(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param identity: The .
        
        :type identity: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
           protected ModelMetadata(ModelMetadataIdentity identity)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.GetDisplayName()
    
        
    
        Gets a display name for the model.
    
        
        :rtype: System.String
        :return: The display name.
    
        
        .. code-block:: csharp
    
           public string GetDisplayName()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.DefaultOrder
    
        
    
        The default value of :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.Order`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly int DefaultOrder
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.AdditionalValues
    
        
    
        Gets a collection of additional information about the model.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public abstract IReadOnlyDictionary<object, object> AdditionalValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.BinderModelName
    
        
    
        Gets the name of a model if specified explicitly using :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelNameProvider`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string BinderModelName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.BinderType
    
        
    
        Gets the :any:`System.Type` of an :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` of a model if specified explicitly using 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.IBinderTypeProviderMetadata`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public abstract Type BinderType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.BindingSource
    
        
    
        Gets a binder metadata for this model.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public abstract BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ContainerType
    
        
    
        Gets the container type of this metadata if it represents a property, otherwise <c>null</c>.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ContainerType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ConvertEmptyStringToNull
    
        
    
        Gets a value indicating whether or not to convert an empty string value to <c>null</c> when
        representing a model as text.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool ConvertEmptyStringToNull { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.DataTypeName
    
        
    
        Gets the name of the model's datatype.  Overrides :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` in some
        display scenarios.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string DataTypeName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.Description
    
        
    
        Gets the description of the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string Description { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.DisplayFormatString
    
        
    
        Gets the composite format :any:`System.String` (see
        http://msdn.microsoft.com/en-us/library/txafckwd.aspx) used to display the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string DisplayFormatString { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.DisplayName
    
        
    
        Gets the display name of the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string DisplayName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EditFormatString
    
        
    
        Gets the composite format :any:`System.String` (see
        http://msdn.microsoft.com/en-us/library/txafckwd.aspx) used to edit the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string EditFormatString { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ElementMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` for elements of :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` if that :any:`System.Type`
        implements :any:`System.Collections.IEnumerable`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public abstract ModelMetadata ElementMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EnumGroupedDisplayNamesAndValues
    
        
    
        Gets the ordered and grouped display names and values of all :any:`System.Enum` values in 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName,System.String}}
    
        
        .. code-block:: csharp
    
           public abstract IEnumerable<KeyValuePair<EnumGroupAndName, string>> EnumGroupedDisplayNamesAndValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EnumNamesAndValues
    
        
    
        Gets the names and values of all :any:`System.Enum` values in :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public abstract IReadOnlyDictionary<string, string> EnumNamesAndValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.HasNonDefaultEditFormat
    
        
    
        Gets a value indicating whether :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EditFormatString` has a non-<c>null</c>, non-empty
        value different from the default for the datatype.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool HasNonDefaultEditFormat { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.HideSurroundingHtml
    
        
    
        Gets a value indicating whether the "HiddenInput" display template should return
        <c>string.Empty</c> (not the expression value) and whether the "HiddenInput" editor template should not
        also return the expression value (together with the hidden &lt;input&gt; element).
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool HideSurroundingHtml { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.HtmlEncode
    
        
    
        Gets a value indicating whether the value should be HTML-encoded.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool HtmlEncode { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.Identity
    
        
    
        Gets the key for the current instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity
    
        
        .. code-block:: csharp
    
           protected ModelMetadataIdentity Identity { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsBindingAllowed
    
        
    
        Gets a value indicating whether or not the model value can be bound by model binding. This is only
        applicable when the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsBindingAllowed { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsBindingRequired
    
        
    
        Gets a value indicating whether or not the model value is required by model binding. This is only
        applicable when the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsBindingRequired { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsCollectionType
    
        
    
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` is a collection type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsCollectionType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsComplexType
    
        
    
        Gets a value indicating whether :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` is a simple type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsComplexType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsEnum
    
        
    
        Gets a value indicating whether :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType` is for an :any:`System.Enum`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsEnum { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsEnumerableType
    
        
    
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` is an enumerable type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnumerableType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsFlagsEnum
    
        
    
        Gets a value indicating whether :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType` is for an :any:`System.Enum` with an
        associated :any:`System.FlagsAttribute`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsFlagsEnum { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsNullableValueType
    
        
    
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` is a :any:`System.Nullable\`1`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsNullableValueType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsReadOnly
    
        
    
        Gets a value indicating whether or not the model value is read-only. This is only applicable when
        the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsReferenceOrNullableType
    
        
    
        Gets a value indicating whether or not :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` allows <c>null</c> values.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReferenceOrNullableType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsRequired
    
        
    
        Gets a value indicating whether or not the model value is required. This is only applicable when
        the current instance represents a property.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsRequired { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.MetadataKind
    
        
    
        Gets a value indicating the kind of metadata element represented by the current instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataKind
    
        
        .. code-block:: csharp
    
           public ModelMetadataKind MetadataKind { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelBindingMessageProvider
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider` instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
           public abstract IModelBindingMessageProvider ModelBindingMessageProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType
    
        
    
        Gets the model type represented by the current instance.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ModelType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.NullDisplayText
    
        
    
        Gets the text to display when the model is <c>null</c>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string NullDisplayText { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.Order
    
        
    
        Gets a value indicating where the current metadata should be ordered relative to other properties
        in its containing type.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public abstract int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.Properties
    
        
    
        Gets the collection of :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` instances for the model's properties.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection
    
        
        .. code-block:: csharp
    
           public abstract ModelPropertyCollection Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.PropertyBindingPredicateProvider
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider`\, which can determine which properties
        should be model bound.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider
    
        
        .. code-block:: csharp
    
           public abstract IPropertyBindingPredicateProvider PropertyBindingPredicateProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.PropertyGetter
    
        
    
        Gets a property getter delegate to get the property value from a model object.
    
        
        :rtype: System.Func{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public abstract Func<object, object> PropertyGetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.PropertyName
    
        
    
        Gets the property name represented by the current instance.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PropertyName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.PropertySetter
    
        
    
        Gets a property setter delegate to set the property value on a model object.
    
        
        :rtype: System.Action{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public abstract Action<object, object> PropertySetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ShowForDisplay
    
        
    
        Gets a value that indicates whether the property should be displayed in read-only views.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool ShowForDisplay { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ShowForEdit
    
        
    
        Gets a value that indicates whether the property should be displayed in editable views.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool ShowForEdit { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.SimpleDisplayProperty
    
        
    
        Gets  a value which is the name of the property used to display the model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string SimpleDisplayProperty { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.TemplateHint
    
        
    
        Gets a string used by the templating system to discover display-templates and editor-templates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string TemplateHint { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType
    
        
    
        Gets the underlying type argument if :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType` inherits from :any:`System.Nullable\`1`\.
        Otherwise gets :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelType`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type UnderlyingOrModelType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ValidatorMetadata
    
        
    
        Gets a collection of metadata items for validators.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public abstract IReadOnlyList<object> ValidatorMetadata { get; }
    

