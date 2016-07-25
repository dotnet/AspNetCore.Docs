

TagHelperBlock Class
====================






A :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block` that reprents a special HTML element.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`








Syntax
------

.. code-block:: csharp

    public class TagHelperBlock : Block, IEquatable<TagHelperBlock>








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.TagHelperBlock(Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder)
    
        
    
        
        Instantiates a new instance of a :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\.
    
        
    
        
        :param source: A :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder` used to construct a valid 
            :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\.
        
        :type source: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    
        
        .. code-block:: csharp
    
            public TagHelperBlock(TagHelperBlockBuilder source)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.Attributes
    
        
    
        
        The HTML attributes.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode<Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode>}
    
        
        .. code-block:: csharp
    
            public IList<TagHelperAttributeNode> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.Descriptors
    
        
    
        
        :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for the HTML element.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperDescriptor> Descriptors { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Length { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.SourceEndTag
    
        
    
        
        Gets the unrewritten source end tag.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public Block SourceEndTag { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.SourceStartTag
    
        
    
        
        Gets the unrewritten source start tag.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public Block SourceStartTag { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.Start
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public override SourceLocation Start { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.TagMode
    
        
    
        
        Gets the HTML syntax of the element in the Razor source.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            public TagMode TagMode { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.TagName
    
        
    
        
        The HTML tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagName { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.Equals(Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock)
    
        
    
        
        Determines whether two :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock`\s are equal by comparing the :dn:prop:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.TagName`\, 
        :dn:prop:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.Attributes`\, :dn:prop:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Type`\, :dn:prop:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.ChunkGenerator` and 
        :dn:prop:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Children`\.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock` to check equality against.
        
        :type other: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock
        :rtype: System.Boolean
        :return: 
            <code>true</code> if the current :any:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock` is equivalent to the given
            <em>other</em>, <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public bool Equals(TagHelperBlock other)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.Flatten()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        .. code-block:: csharp
    
            public override IEnumerable<Span> Flatten()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlock.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

