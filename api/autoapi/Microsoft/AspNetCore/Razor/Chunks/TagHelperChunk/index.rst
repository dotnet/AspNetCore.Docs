

TagHelperChunk Class
====================






A :any:`Microsoft.AspNetCore.Razor.Chunks.ParentChunk` that represents a special HTML tag.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Chunks`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.ParentChunk`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk`








Syntax
------

.. code-block:: csharp

    public class TagHelperChunk : ParentChunk








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk.TagHelperChunk(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagMode, System.Collections.Generic.IList<Microsoft.AspNetCore.Razor.Chunks.TagHelperAttributeTracker>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk`\.
    
        
    
        
        :param tagName: The tag name associated with the tag helpers HTML element.
        
        :type tagName: System.String
    
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        :param attributes: The attributes associated with the tag helpers HTML element.
        
        :type attributes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.Chunks.TagHelperAttributeTracker<Microsoft.AspNetCore.Razor.Chunks.TagHelperAttributeTracker>}
    
        
        :param descriptors: 
            The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s associated with this tag helpers HTML element.
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public TagHelperChunk(string tagName, TagMode tagMode, IList<TagHelperAttributeTracker> attributes, IEnumerable<TagHelperDescriptor> descriptors)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk.Attributes
    
        
    
        
        The HTML attributes.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.Chunks.TagHelperAttributeTracker<Microsoft.AspNetCore.Razor.Chunks.TagHelperAttributeTracker>}
    
        
        .. code-block:: csharp
    
            public IList<TagHelperAttributeTracker> Attributes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk.Descriptors
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that are associated with the tag helpers HTML element.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperDescriptor> Descriptors { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk.TagMode
    
        
    
        
        Gets the HTML syntax of the element in the Razor source.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            public TagMode TagMode { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk.TagName
    
        
    
        
        The HTML tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagName { get; set; }
    

