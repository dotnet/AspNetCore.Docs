

Block Class
===========





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree`
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








Syntax
------

.. code-block:: csharp

    public class Block : SyntaxTreeNode








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Children
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<SyntaxTreeNode> Children
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.ChunkGenerator
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.IParentChunkGenerator
    
        
        .. code-block:: csharp
    
            public IParentChunkGenerator ChunkGenerator
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.IsBlock
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsBlock
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Start
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public override SourceLocation Start
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Type
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType
    
        
        .. code-block:: csharp
    
            public BlockType Type
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Block(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder
    
        
        .. code-block:: csharp
    
            public Block(BlockBuilder source)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Block(System.Nullable<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode>, Microsoft.AspNetCore.Razor.Chunks.Generators.IParentChunkGenerator)
    
        
    
        
        :type type: System.Nullable<System.Nullable`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>}
    
        
        :type contents: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode>}
    
        
        :type generator: Microsoft.AspNetCore.Razor.Chunks.Generators.IParentChunkGenerator
    
        
        .. code-block:: csharp
    
            protected Block(BlockType? type, IReadOnlyList<SyntaxTreeNode> contents, IParentChunkGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Accept(Microsoft.AspNetCore.Razor.Parser.ParserVisitor)
    
        
    
        
        :type visitor: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
            public override void Accept(ParserVisitor visitor)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.EquivalentTo(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type node: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool EquivalentTo(SyntaxTreeNode node)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.FindFirstDescendentSpan()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public Span FindFirstDescendentSpan()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.FindLastDescendentSpan()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public Span FindLastDescendentSpan()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.Flatten()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<Span> Flatten()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.GetEquivalenceHash()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetEquivalenceHash()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.LocateOwner(Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public Span LocateOwner(TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

