

TemplateBlockChunkGenerator Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.ParentChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.TemplateBlockChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class TemplateBlockChunkGenerator : ParentChunkGenerator, IParentChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/TemplateBlockChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TemplateBlockChunkGenerator

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TemplateBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.TemplateBlockChunkGenerator.GenerateEndParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.TemplateBlockChunkGenerator.GenerateStartParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    

