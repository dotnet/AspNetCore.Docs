

TagHelperBlock Class
====================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Parser.SyntaxTree.Block` that reprents a special HTML element.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.Block`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock`








Syntax
------

.. code-block:: csharp

   public class TagHelperBlock : Block, IEquatable<TagHelperBlock>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/TagHelpers/TagHelperBlock.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.TagHelperBlock(Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder)
    
        
    
        Instantiates a new instance of a :any:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock`\.
    
        
        
        
        :param source: A  used to construct a valid
            .
        
        :type source: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    
        
        .. code-block:: csharp
    
           public TagHelperBlock(TagHelperBlockBuilder source)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.Equals(Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock)
    
        
    
        Determines whether two :any:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock`\s are equal by comparing the :dn:prop:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.TagName`\, 
        :dn:prop:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.Attributes`\, :dn:prop:`Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Type`\, :dn:prop:`Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.ChunkGenerator` and 
        :dn:prop:`Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Children`\.
    
        
        
        
        :param other: The  to check equality against.
        
        :type other: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock
        :rtype: System.Boolean
        :return: <c>true</c> if the current <see cref="T:Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock" /> is equivalent to the given
            <paramref name="other" />, <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           public bool Equals(TagHelperBlock other)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.Flatten()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<Span> Flatten()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.Attributes
    
        
    
        The HTML attributes.
    
        
        :rtype: System.Collections.Generic.IList{System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode}}
    
        
        .. code-block:: csharp
    
           public IList<KeyValuePair<string, SyntaxTreeNode>> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.Descriptors
    
        
    
        :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for the HTML element.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperDescriptor> Descriptors { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.SourceEndTag
    
        
    
        Gets the unrewritten source end tag.
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block SourceEndTag { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.SourceStartTag
    
        
    
        Gets the unrewritten source start tag.
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block SourceStartTag { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.Start
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public override SourceLocation Start { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.TagMode
    
        
    
        Gets the HTML syntax of the element in the Razor source.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
           public TagMode TagMode { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlock.TagName
    
        
    
        The HTML tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagName { get; }
    

