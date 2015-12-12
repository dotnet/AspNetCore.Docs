

HtmlAttributeNameAttribute Class
================================



.. contents:: 
   :local:



Summary
-------

Used to override an :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` property's HTML attribute name.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute`








Syntax
------

.. code-block:: csharp

   public sealed class HtmlAttributeNameAttribute : Attribute, _Attribute





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/HtmlAttributeNameAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.HtmlAttributeNameAttribute()
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute` class with :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.Name`
        equal to <c>null</c>.
    
        
    
        
        .. code-block:: csharp
    
           public HtmlAttributeNameAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.HtmlAttributeNameAttribute(System.String)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute` class.
    
        
        
        
        :param name: HTML attribute name for the associated property. Must be null or empty if associated property does
            not have a public setter and is compatible with
            where TKey is
            . Otherwise must not be null or empty.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           public HtmlAttributeNameAttribute(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefix
    
        
    
        Gets or sets the prefix used to match HTML attribute names. Matching attributes are added to the
        associated property (an :any:`System.Collections.Generic.IDictionary\`2`\).
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DictionaryAttributePrefix { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefixSet
    
        
    
        Gets an indication whether :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefix` has been set. Used to distinguish an
        uninitialized :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefix` value from an explicit <c>null</c> setting.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool DictionaryAttributePrefixSet { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.HtmlAttributeNameAttribute.Name
    
        
    
        HTML attribute name of the associated property.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    

