

HtmlTargetElementAttribute Class
================================



.. contents:: 
   :local:



Summary
-------

Provides an :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s target.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute`








Syntax
------

.. code-block:: csharp

   public sealed class HtmlTargetElementAttribute : Attribute, _Attribute





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/HtmlTargetElementAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.HtmlTargetElementAttribute()
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute` class that targets all HTML
        elements with the required :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.Attributes`\.
    
        
    
        
        .. code-block:: csharp
    
           public HtmlTargetElementAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.HtmlTargetElementAttribute(System.String)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute` class with the given
        ``tag`` as its :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.Tag` value.
    
        
        
        
        :param tag: The HTML tag the  targets.
        
        :type tag: System.String
    
        
        .. code-block:: csharp
    
           public HtmlTargetElementAttribute(string tag)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.ElementCatchAllTarget
    
        
    
        
        .. code-block:: csharp
    
           public const string ElementCatchAllTarget
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.Attributes
    
        
    
        A comma-separated :any:`System.String` of attribute names the HTML element must contain for the 
        :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` to run. <c>*</c> at the end of an attribute name acts as a prefix match.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Attributes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.ParentTag
    
        
    
        The required HTML element name of the direct parent. A <c>null</c> value indicates any HTML element name is
        allowed.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ParentTag { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.Tag
    
        
    
        The HTML tag the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` targets. A <c>*</c> value indicates this :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`
        targets all HTML elements with the required :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.Attributes`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Tag { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.HtmlTargetElementAttribute.TagStructure
    
        
    
        The expected tag structure. Defaults to :dn:field:`Microsoft.AspNet.Razor.TagHelpers.TagStructure.Unspecified`\.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagStructure
    
        
        .. code-block:: csharp
    
           public TagStructure TagStructure { get; set; }
    

