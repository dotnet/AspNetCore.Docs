

Block Class
===========



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.Block`








Syntax
------

.. code-block:: csharp

   public class Block : SyntaxTreeNode





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Parser/SyntaxTree/Block.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Block(Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder
    
        
        .. code-block:: csharp
    
           public Block(BlockBuilder source)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Block(System.Nullable<Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode>, Microsoft.AspNet.Razor.Chunks.Generators.IParentChunkGenerator)
    
        
        
        
        :type type: System.Nullable{Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType}
        
        
        :type contents: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode}
        
        
        :type generator: Microsoft.AspNet.Razor.Chunks.Generators.IParentChunkGenerator
    
        
        .. code-block:: csharp
    
           protected Block(BlockType? type, IEnumerable<SyntaxTreeNode> contents, IParentChunkGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Accept(Microsoft.AspNet.Razor.Parser.ParserVisitor)
    
        
        
        
        :type visitor: Microsoft.AspNet.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
           public override void Accept(ParserVisitor visitor)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.EquivalentTo(Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type node: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool EquivalentTo(SyntaxTreeNode node)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.FindFirstDescendentSpan()
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public Span FindFirstDescendentSpan()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.FindLastDescendentSpan()
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public Span FindLastDescendentSpan()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Flatten()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<Span> Flatten()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.GetEquivalenceHash()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetEquivalenceHash()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.LocateOwner(Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public Span LocateOwner(TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Children
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode}
    
        
        .. code-block:: csharp
    
           public IEnumerable<SyntaxTreeNode> Children { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.ChunkGenerator
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.Generators.IParentChunkGenerator
    
        
        .. code-block:: csharp
    
           public IParentChunkGenerator ChunkGenerator { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.IsBlock
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsBlock { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Start
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public override SourceLocation Start { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block.Type
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType
    
        
        .. code-block:: csharp
    
           public BlockType Type { get; }
    

