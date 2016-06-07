

DefaultModelMetadata Class
==========================






A default :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` implementation.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`








Syntax
------

.. code-block:: csharp

    public class DefaultModelMetadata : ModelMetadata, IEquatable<ModelMetadata>








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.AdditionalValues
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary<System.Collections.Generic.IReadOnlyDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public override IReadOnlyDictionary<object, object> AdditionalValues
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Attributes
    
        
    
        
        Gets the set of attributes for the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    
        
        .. code-block:: csharp
    
            public ModelAttributes Attributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BinderModelName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string BinderModelName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BinderType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public override Type BinderType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BindingMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata` for the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata
    
        
        .. code-block:: csharp
    
            public BindingMetadata BindingMetadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public override BindingSource BindingSource
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ConvertEmptyStringToNull
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ConvertEmptyStringToNull
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DataTypeName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string DataTypeName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Description
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Description
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DisplayFormatString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string DisplayFormatString
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DisplayMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadata` for the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadata
    
        
        .. code-block:: csharp
    
            public DisplayMetadata DisplayMetadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DisplayName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string DisplayName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.EditFormatString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string EditFormatString
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ElementMetadata
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public override ModelMetadata ElementMetadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.EnumGroupedDisplayNamesAndValues
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName<Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName>, System.String<System.String>}}
    
        
        .. code-block:: csharp
    
            public override IEnumerable<KeyValuePair<EnumGroupAndName, string>> EnumGroupedDisplayNamesAndValues
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.EnumNamesAndValues
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary<System.Collections.Generic.IReadOnlyDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public override IReadOnlyDictionary<string, string> EnumNamesAndValues
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.HasNonDefaultEditFormat
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool HasNonDefaultEditFormat
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.HideSurroundingHtml
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool HideSurroundingHtml
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.HtmlEncode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool HtmlEncode
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsBindingAllowed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsBindingAllowed
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsBindingRequired
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsBindingRequired
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsEnum
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsEnum
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsFlagsEnum
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsFlagsEnum
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsReadOnly
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.IsRequired
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsRequired
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ModelBindingMessageProvider
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
            public override IModelBindingMessageProvider ModelBindingMessageProvider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.NullDisplayText
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string NullDisplayText
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Placeholder
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Placeholder
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.Properties
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelPropertyCollection
    
        
        .. code-block:: csharp
    
            public override ModelPropertyCollection Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.PropertyFilterProvider
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider
    
        
        .. code-block:: csharp
    
            public override IPropertyFilterProvider PropertyFilterProvider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.PropertyGetter
    
        
        :rtype: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public override Func<object, object> PropertyGetter
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.PropertySetter
    
        
        :rtype: System.Action<System.Action`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public override Action<object, object> PropertySetter
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ShowForDisplay
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ShowForDisplay
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ShowForEdit
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ShowForEdit
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.SimpleDisplayProperty
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string SimpleDisplayProperty
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.TemplateHint
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string TemplateHint
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ValidateChildren
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ValidateChildren
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ValidationMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata` for the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata
    
        
        .. code-block:: csharp
    
            public ValidationMetadata ValidationMetadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.ValidatorMetadata
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public override IReadOnlyList<object> ValidatorMetadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata.DefaultModelMetadata(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider, Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.
    
        
    
        
        :param provider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type provider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param detailsProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`\.
        
        :type detailsProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider
    
        
        :param details: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails`\.
        
        :type details: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails
    
        
        .. code-block:: csharp
    
            public DefaultModelMetadata(IModelMetadataProvider provider, ICompositeMetadataDetailsProvider detailsProvider, DefaultMetadataDetails details)
    

