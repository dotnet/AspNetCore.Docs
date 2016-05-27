

TagHelperBlockBuilder Class
===========================






A :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder` used to create :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder`








Syntax
------

.. code-block:: csharp

    public class TagHelperBlockBuilder : BlockBuilder








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Attributes
    
        
    
        
        The HTML attributes.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode>}}
    
        
        .. code-block:: csharp
    
            public IList<KeyValuePair<string, SyntaxTreeNode>> Attributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Descriptors
    
        
    
        
        :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for the HTML element.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperDescriptor> Descriptors
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.SourceEndTag
    
        
    
        
        Gets or sets the unrewritten source end tag.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public Block SourceEndTag
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.SourceStartTag
    
        
    
        
        Gets or sets the unrewritten source start tag.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public Block SourceStartTag
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Start
    
        
    
        
        The starting :any:`Microsoft.AspNetCore.Razor.SourceLocation` of the tag helper.
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Start
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagMode
    
        
    
        
        Gets the HTML syntax of the element in the Razor source.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            public TagMode TagMode
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagName
    
        
    
        
        The HTML tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagHelperBlockBuilder(Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder` instance based on the given
        <em>original</em>.
    
        
    
        
        :param original: The original :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock` to copy data from.
        
        :type original: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock
    
        
        .. code-block:: csharp
    
            public TagHelperBlockBuilder(TagHelperBlock original)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagHelperBlockBuilder(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagMode, Microsoft.AspNetCore.Razor.SourceLocation, System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder` class
        with the provided values.
    
        
    
        
        :param tagName: An HTML tag name.
        
        :type tagName: System.String
    
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        :param start: Starting location of the :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\.
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param attributes: Attributes of the :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\.
        
        :type attributes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode>}}
    
        
        :param descriptors: The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s associated with the current HTML
            tag.
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public TagHelperBlockBuilder(string tagName, TagMode tagMode, SourceLocation start, IList<KeyValuePair<string, SyntaxTreeNode>> attributes, IEnumerable<TagHelperDescriptor> descriptors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Build()
    
        
    
        
        Constructs a new :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
        :return: A :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\.
    
        
        .. code-block:: csharp
    
            public override Block Build()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public override void Reset()
    

