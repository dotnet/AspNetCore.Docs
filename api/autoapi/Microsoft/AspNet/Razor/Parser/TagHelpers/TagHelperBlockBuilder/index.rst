

TagHelperBlockBuilder Class
===========================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder` used to create :any:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder`








Syntax
------

.. code-block:: csharp

   public class TagHelperBlockBuilder : BlockBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/TagHelpers/TagHelperBlockBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagHelperBlockBuilder(Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder` instance based on the given
        ``original``.
    
        
        
        
        :param original: The original  to copy data from.
        
        :type original: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock
    
        
        .. code-block:: csharp
    
           public TagHelperBlockBuilder(TagHelperBlock original)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagHelperBlockBuilder(System.String, Microsoft.AspNet.Razor.TagHelpers.TagMode, Microsoft.AspNet.Razor.SourceLocation, System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder` class
        with the provided ``tagName`` and derives its :dn:prop:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Attributes`
        and :dn:prop:`Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.Type` from the ``startTag``.
    
        
        
        
        :param tagName: An HTML tag name.
        
        :type tagName: System.String
        
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNet.Razor.TagHelpers.TagMode
        
        
        :param start: Starting location of the .
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :param attributes: Attributes of the .
        
        :type attributes: System.Collections.Generic.IList{System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode}}
        
        
        :param descriptors: The s associated with the current HTML
            tag.
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public TagHelperBlockBuilder(string tagName, TagMode tagMode, SourceLocation start, IList<KeyValuePair<string, SyntaxTreeNode>> attributes, IEnumerable<TagHelperDescriptor> descriptors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Build()
    
        
    
        Constructs a new :any:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock`\.
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        :return: A <see cref="T:Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock" />.
    
        
        .. code-block:: csharp
    
           public override Block Build()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public override void Reset()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Attributes
    
        
    
        The HTML attributes.
    
        
        :rtype: System.Collections.Generic.IList{System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode}}
    
        
        .. code-block:: csharp
    
           public IList<KeyValuePair<string, SyntaxTreeNode>> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Descriptors
    
        
    
        :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for the HTML element.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperDescriptor> Descriptors { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.SourceEndTag
    
        
    
        Gets or sets the unrewritten source end tag.
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block SourceEndTag { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.SourceStartTag
    
        
    
        Gets or sets the unrewritten source start tag.
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block SourceStartTag { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.Start
    
        
    
        The starting :any:`Microsoft.AspNet.Razor.SourceLocation` of the tag helper.
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Start { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagMode
    
        
    
        Gets the HTML syntax of the element in the Razor source.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
           public TagMode TagMode { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder.TagName
    
        
    
        The HTML tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagName { get; set; }
    

