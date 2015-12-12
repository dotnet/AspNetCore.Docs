

TagHelperChunkGenerator Class
=============================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Chunks.Generators.ParentChunkGenerator` that is responsible for generating valid :any:`Microsoft.AspNet.Razor.Chunks.TagHelperChunk`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.ParentChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class TagHelperChunkGenerator : ParentChunkGenerator, IParentChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/Generators/TagHelperChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator.TagHelperChunkGenerator(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator`\.
    
        
        
        
        :param tagHelperDescriptors: s associated with the current HTML tag.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public TagHelperChunkGenerator(IEnumerable<TagHelperDescriptor> tagHelperDescriptors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator.GenerateEndParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        Ends the generation of a :any:`Microsoft.AspNet.Razor.Chunks.TagHelperChunk` capturing all previously visited children
        since the :dn:meth:`Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator.GenerateStartParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block,Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)` method was called.
    
        
        
        
        :param target: The  responsible for this .
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :param context: A  instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperChunkGenerator.GenerateStartParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        Starts the generation of a :any:`Microsoft.AspNet.Razor.Chunks.TagHelperChunk`\.
    
        
        
        
        :param target: The  responsible for this .
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :param context: A  instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    

