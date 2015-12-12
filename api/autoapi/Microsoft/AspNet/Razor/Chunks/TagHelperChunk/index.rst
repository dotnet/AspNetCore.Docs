

TagHelperChunk Class
====================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Chunks.ParentChunk` that represents a special HTML tag.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.ParentChunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.TagHelperChunk`








Syntax
------

.. code-block:: csharp

   public class TagHelperChunk : ParentChunk





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/TagHelperChunk.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk.TagHelperChunk(System.String, Microsoft.AspNet.Razor.TagHelpers.TagMode, System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNet.Razor.Chunks.Chunk>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Chunks.TagHelperChunk`\.
    
        
        
        
        :param tagName: The tag name associated with the tag helpers HTML element.
        
        :type tagName: System.String
        
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNet.Razor.TagHelpers.TagMode
        
        
        :param attributes: The attributes associated with the tag helpers HTML element.
        
        :type attributes: System.Collections.Generic.IList{System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Razor.Chunks.Chunk}}
        
        
        :param descriptors: The s associated with this tag helpers HTML element.
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public TagHelperChunk(string tagName, TagMode tagMode, IList<KeyValuePair<string, Chunk>> attributes, IEnumerable<TagHelperDescriptor> descriptors)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk.Attributes
    
        
    
        The HTML attributes.
    
        
        :rtype: System.Collections.Generic.IList{System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Razor.Chunks.Chunk}}
    
        
        .. code-block:: csharp
    
           public IList<KeyValuePair<string, Chunk>> Attributes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk.Descriptors
    
        
    
        The :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that are associated with the tag helpers HTML element.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperDescriptor> Descriptors { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk.TagMode
    
        
    
        Gets the HTML syntax of the element in the Razor source.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
           public TagMode TagMode { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.TagHelperChunk.TagName
    
        
    
        The HTML tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagName { get; set; }
    

