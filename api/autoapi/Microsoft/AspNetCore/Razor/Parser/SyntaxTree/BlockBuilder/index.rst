

BlockBuilder Class
==================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder`








Syntax
------

.. code-block:: csharp

    public class BlockBuilder








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder.BlockBuilder()
    
        
    
        
        .. code-block:: csharp
    
            public BlockBuilder()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder.BlockBuilder(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type original: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public BlockBuilder(Block original)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder.Build()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public virtual Block Build()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Reset()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder.Children
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode>}
    
        
        .. code-block:: csharp
    
            public List<SyntaxTreeNode> Children { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder.ChunkGenerator
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.IParentChunkGenerator
    
        
        .. code-block:: csharp
    
            public IParentChunkGenerator ChunkGenerator { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder.Type
    
        
        :rtype: System.Nullable<System.Nullable`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>}
    
        
        .. code-block:: csharp
    
            public BlockType? Type { get; set; }
    

