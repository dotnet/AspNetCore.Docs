

HtmlTargetElementAttribute Class
================================






Provides an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s target.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class HtmlTargetElementAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.Attributes
    
        
    
        
        A comma-separated :any:`System.String` of attribute selectors the HTML element must match for the
        :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` to run. <code>*</code> at the end of an attribute name acts as a prefix match. A value
        surrounded by square brackets is handled as a CSS attribute value selector. Operators <code>^=</code>, <code>$=</code> and
        <code>=</code> are supported e.g. <code>"name"</code>, <code>"[name]"</code>, <code>"[name=value]"</code>, <code>"[ name ^= 'value' ]"</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Attributes
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.ParentTag
    
        
    
        
        The required HTML element name of the direct parent. A <code>null</code> value indicates any HTML element name is
        allowed.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ParentTag
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.Tag
    
        
    
        
        The HTML tag the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` targets. A <code>*</code> value indicates this :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`
        targets all HTML elements with the required :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.Attributes`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Tag
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.TagStructure
    
        
    
        
        The expected tag structure. Defaults to :dn:field:`Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.Unspecified`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure
    
        
        .. code-block:: csharp
    
            public TagStructure TagStructure
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.HtmlTargetElementAttribute()
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute` class that targets all HTML
        elements with the required :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.Attributes`\.
    
        
    
        
        .. code-block:: csharp
    
            public HtmlTargetElementAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.HtmlTargetElementAttribute(System.String)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute` class with the given
        <em>tag</em> as its :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.Tag` value.
    
        
    
        
        :param tag: 
            The HTML tag the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` targets.
        
        :type tag: System.String
    
        
        .. code-block:: csharp
    
            public HtmlTargetElementAttribute(string tag)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute.ElementCatchAllTarget
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string ElementCatchAllTarget = "*"
    

