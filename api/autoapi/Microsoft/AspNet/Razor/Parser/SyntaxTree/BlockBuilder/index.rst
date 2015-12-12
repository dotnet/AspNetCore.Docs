

BlockBuilder Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder`








Syntax
------

.. code-block:: csharp

   public class BlockBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/SyntaxTree/BlockBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.BlockBuilder()
    
        
    
        
        .. code-block:: csharp
    
           public BlockBuilder()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.BlockBuilder(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type original: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public BlockBuilder(Block original)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.Build()
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public virtual Block Build()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void Reset()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.Children
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode}
    
        
        .. code-block:: csharp
    
           public IList<SyntaxTreeNode> Children { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.ChunkGenerator
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.Generators.IParentChunkGenerator
    
        
        .. code-block:: csharp
    
           public IParentChunkGenerator ChunkGenerator { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder.Type
    
        
        :rtype: System.Nullable{Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType}
    
        
        .. code-block:: csharp
    
           public BlockType? Type { get; set; }
    

