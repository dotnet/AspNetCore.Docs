

TagBuilder Class
================






Contains methods and properties that are used to create HTML elements. This class is often used to write HTML
helpers and tag helpers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString()}")]
    public class TagBuilder : IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.Attributes
    
        
    
        
        Gets the set of attributes that will be written to the tag.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary
    
        
        .. code-block:: csharp
    
            public AttributeDictionary Attributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.InnerHtml
    
        
    
        
        Gets the inner HTML content of the element.
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder InnerHtml
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.TagName
    
        
    
        
        Gets the tag name for this tag.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.TagRenderMode
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Rendering.TagRenderMode` with which the tag is written.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagRenderMode
    
        
        .. code-block:: csharp
    
            public TagRenderMode TagRenderMode
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.TagBuilder(System.String)
    
        
    
        
        Creates a new HTML tag that has the specified tag name.
    
        
    
        
        :param tagName: An HTML tag name.
        
        :type tagName: System.String
    
        
        .. code-block:: csharp
    
            public TagBuilder(string tagName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.AddCssClass(System.String)
    
        
    
        
        Adds a CSS class to the list of CSS classes in the tag.
        If there are already CSS classes on the tag then a space character and the new class will be appended to
        the existing list.
    
        
    
        
        :param value: The CSS class name to add.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public void AddCssClass(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.CreateSanitizedId(System.String, System.String)
    
        
    
        
        Return valid HTML 4.01 "id" attribute for an element with the given <em>name</em>.
    
        
    
        
        :param name: The original element name.
        
        :type name: System.String
    
        
        :param invalidCharReplacement: 
            The :any:`System.String` (normally a single :any:`System.Char`\) to substitute for invalid characters in
            <em>name</em>.
        
        :type invalidCharReplacement: System.String
        :rtype: System.String
        :return: 
            Valid HTML 4.01 "id" attribute for an element with the given <em>name</em>.
    
        
        .. code-block:: csharp
    
            public static string CreateSanitizedId(string name, string invalidCharReplacement)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.GenerateId(System.String, System.String)
    
        
    
        
        Generates a sanitized ID attribute for the tag by using the specified name.
    
        
    
        
        :param name: The name to use to generate an ID attribute.
        
        :type name: System.String
    
        
        :param invalidCharReplacement: 
            The :any:`System.String` (normally a single :any:`System.Char`\) to substitute for invalid characters in
            <em>name</em>.
        
        :type invalidCharReplacement: System.String
    
        
        .. code-block:: csharp
    
            public void GenerateId(string name, string invalidCharReplacement)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.MergeAttribute(System.String, System.String)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public void MergeAttribute(string key, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.MergeAttribute(System.String, System.String, System.Boolean)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        :type replaceExisting: System.Boolean
    
        
        .. code-block:: csharp
    
            public void MergeAttribute(string key, string value, bool replaceExisting)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.MergeAttributes<TKey, TValue>(System.Collections.Generic.IDictionary<TKey, TValue>)
    
        
    
        
        :type attributes: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{TKey, TValue}
    
        
        .. code-block:: csharp
    
            public void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.MergeAttributes<TKey, TValue>(System.Collections.Generic.IDictionary<TKey, TValue>, System.Boolean)
    
        
    
        
        :type attributes: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{TKey, TValue}
    
        
        :type replaceExisting: System.Boolean
    
        
        .. code-block:: csharp
    
            public void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

