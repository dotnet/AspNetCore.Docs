

DefaultModelMetadata Class
==========================



.. contents:: 
   :local:



Summary
-------

A default :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` implementation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`








Syntax
------

.. code-block:: csharp

   public class DefaultModelMetadata : ModelMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/DefaultModelMetadata.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DefaultModelMetadata(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider, Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.
    
        
        
        
        :param provider: The .
        
        :type provider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param detailsProvider: The .
        
        :type detailsProvider: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider
        
        
        :param details: The .
        
        :type details: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
    
        
        .. code-block:: csharp
    
           public DefaultModelMetadata(IModelMetadataProvider provider, ICompositeMetadataDetailsProvider detailsProvider, DefaultMetadataDetails details)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.AdditionalValues
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public override IReadOnlyDictionary<object, object> AdditionalValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Attributes
    
        
    
        Gets the set of attributes for the current instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
           public ModelAttributes Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BinderModelName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string BinderModelName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BinderType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public override Type BinderType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BindingMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata` for the current instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata
    
        
        .. code-block:: csharp
    
           public BindingMetadata BindingMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BindingSource
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public override BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ConvertEmptyStringToNull
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool ConvertEmptyStringToNull { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DataTypeName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string DataTypeName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Description
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string Description { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DisplayFormatString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string DisplayFormatString { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DisplayMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata` for the current instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata
    
        
        .. code-block:: csharp
    
           public DisplayMetadata DisplayMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DisplayName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string DisplayName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.EditFormatString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string EditFormatString { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ElementMetadata
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public override ModelMetadata ElementMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.EnumGroupedDisplayNamesAndValues
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName,System.String}}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<KeyValuePair<EnumGroupAndName, string>> EnumGroupedDisplayNamesAndValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.EnumNamesAndValues
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public override IReadOnlyDictionary<string, string> EnumNamesAndValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.HasNonDefaultEditFormat
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool HasNonDefaultEditFormat { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.HideSurroundingHtml
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool HideSurroundingHtml { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.HtmlEncode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool HtmlEncode { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsBindingAllowed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsBindingAllowed { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsBindingRequired
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsBindingRequired { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsEnum
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsEnum { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsFlagsEnum
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsFlagsEnum { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsRequired
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsRequired { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ModelBindingMessageProvider
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
           public override IModelBindingMessageProvider ModelBindingMessageProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.NullDisplayText
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string NullDisplayText { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Properties
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelPropertyCollection
    
        
        .. code-block:: csharp
    
           public override ModelPropertyCollection Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.PropertyBindingPredicateProvider
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider
    
        
        .. code-block:: csharp
    
           public override IPropertyBindingPredicateProvider PropertyBindingPredicateProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.PropertyGetter
    
        
        :rtype: System.Func{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public override Func<object, object> PropertyGetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.PropertySetter
    
        
        :rtype: System.Action{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public override Action<object, object> PropertySetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ShowForDisplay
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool ShowForDisplay { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ShowForEdit
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool ShowForEdit { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.SimpleDisplayProperty
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string SimpleDisplayProperty { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.TemplateHint
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string TemplateHint { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ValidationMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata` for the current instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata
    
        
        .. code-block:: csharp
    
           public ValidationMetadata ValidationMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ValidatorMetadata
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public override IReadOnlyList<object> ValidatorMetadata { get; }
    

