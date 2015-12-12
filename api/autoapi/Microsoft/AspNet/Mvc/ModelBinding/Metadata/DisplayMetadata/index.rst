

DisplayMetadata Class
=====================



.. contents:: 
   :local:



Summary
-------

Display metadata details for a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata`








Syntax
------

.. code-block:: csharp

   public class DisplayMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/DisplayMetadata.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.AdditionalValues
    
        
    
        Gets a set of additional values. See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.AdditionalValues`
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> AdditionalValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.ConvertEmptyStringToNull
    
        
    
        Gets or sets a value indicating whether or not empty strings should be treated as <c>null</c>.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ConvertEmptyStringToNull`
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ConvertEmptyStringToNull { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.DataTypeName
    
        
    
        Gets or sets the name of the data type.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.DataTypeName`
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DataTypeName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.Description
    
        
    
        Gets or sets a delegate which is used to get a value for the
        model description. See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.Description`\.
    
        
        :rtype: System.Func{System.String}
    
        
        .. code-block:: csharp
    
           public Func<string> Description { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.DisplayFormatString
    
        
    
        Gets or sets a display format string for the model.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.DisplayFormatString`
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayFormatString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.DisplayName
    
        
    
        Gets or sets a delegate delegate which is used to get a value for the
        display name of the model. See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.DisplayName`\.
    
        
        :rtype: System.Func{System.String}
    
        
        .. code-block:: csharp
    
           public Func<string> DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.EditFormatString
    
        
    
        Gets or sets an edit format string for the model.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EditFormatString`
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EditFormatString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.EnumGroupedDisplayNamesAndValues
    
        
    
        Gets the ordered and grouped display names and values of all :any:`System.Enum` values in 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType`\. See 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EnumGroupedDisplayNamesAndValues`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName,System.String}}
    
        
        .. code-block:: csharp
    
           public IEnumerable<KeyValuePair<EnumGroupAndName, string>> EnumGroupedDisplayNamesAndValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.EnumNamesAndValues
    
        
    
        Gets the names and values of all :any:`System.Enum` values in 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType`\. See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EnumNamesAndValues`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, string> EnumNamesAndValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.HasNonDefaultEditFormat
    
        
    
        Gets or sets a value indicating whether or not the model has a non-default edit format.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.HasNonDefaultEditFormat`
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasNonDefaultEditFormat { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.HideSurroundingHtml
    
        
    
        Gets or sets a value indicating if the surrounding HTML should be hidden.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.HideSurroundingHtml`
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HideSurroundingHtml { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.HtmlEncode
    
        
    
        Gets or sets a value indicating if the model value should be HTML encoded.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.HtmlEncode`
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HtmlEncode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.IsEnum
    
        
    
        Gets a value indicating whether :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType` is for an 
        :any:`System.Enum`\. See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsEnum`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnum { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.IsFlagsEnum
    
        
    
        Gets a value indicating whether :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.UnderlyingOrModelType` is for an 
        :any:`System.Enum` with an associated :any:`System.FlagsAttribute`\. See 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsFlagsEnum`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsFlagsEnum { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.NullDisplayText
    
        
    
        Gets or sets the text to display when the model value is null.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.NullDisplayText`
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string NullDisplayText { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.Order
    
        
    
        Gets or sets the order.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.Order`
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.ShowForDisplay
    
        
    
        Gets or sets a value indicating whether or not to include in the model value in display.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ShowForDisplay`
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ShowForDisplay { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.ShowForEdit
    
        
    
        Gets or sets a value indicating whether or not to include in the model value in an editor.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ShowForEdit`
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ShowForEdit { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.SimpleDisplayProperty
    
        
    
        Gets or sets a the property name of a model property to use for display.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.SimpleDisplayProperty`
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SimpleDisplayProperty { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata.TemplateHint
    
        
    
        Gets or sets a hint for location of a display or editor template.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.TemplateHint`
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TemplateHint { get; set; }
    

