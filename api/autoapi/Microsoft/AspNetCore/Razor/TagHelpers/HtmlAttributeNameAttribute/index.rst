

HtmlAttributeNameAttribute Class
================================






Used to override an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` property's HTML attribute name.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class HtmlAttributeNameAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.HtmlAttributeNameAttribute()
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute` class with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.Name`
        equal to <code>null</code>.
    
        
    
        
        .. code-block:: csharp
    
            public HtmlAttributeNameAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.HtmlAttributeNameAttribute(System.String)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute` class.
    
        
    
        
        :param name: 
            HTML attribute name for the associated property. Must be <code>null</code> or empty if associated property does
            not have a public setter and is compatible with 
            :any:`System.Collections.Generic.IDictionary\`2` where <code>TKey</code> is 
            :any:`System.String`\. Otherwise must not be <code>null</code> or empty.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public HtmlAttributeNameAttribute(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefix
    
        
    
        
        Gets or sets the prefix used to match HTML attribute names. Matching attributes are added to the
        associated property (an :any:`System.Collections.Generic.IDictionary\`2`\).
    
        
        :rtype: System.String
        :return: 
            <p>
            If associated property is compatible with 
            :any:`System.Collections.Generic.IDictionary\`2`\, default value is <code>Name + "-"</code>. 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.Name` must not be <code>null</code> or empty in this case.
            </p>
            <p>
            Otherwise default value is <code>null</code>.
            </p>
    
        
        .. code-block:: csharp
    
            public string DictionaryAttributePrefix { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefixSet
    
        
    
        
        Gets an indication whether :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefix` has been set. Used to distinguish an
        uninitialized :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefix` value from an explicit <code>null</code> setting.
    
        
        :rtype: System.Boolean
        :return: <code>true</code> if :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.DictionaryAttributePrefix` was set. <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public bool DictionaryAttributePrefixSet { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute.Name
    
        
    
        
        HTML attribute name of the associated property.
    
        
        :rtype: System.String
        :return: 
            <code>null</code> or empty if and only if associated property does not have a public setter and is compatible
            with :any:`System.Collections.Generic.IDictionary\`2` where <code>TKey</code> is 
            :any:`System.String`\.
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    

