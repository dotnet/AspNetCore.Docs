

TagHelperChunkGenerator Class
=============================






A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator` that is responsible for generating valid :any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Chunks.Generators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class TagHelperChunkGenerator : ParentChunkGenerator, IParentChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator.TagHelperChunkGenerator(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator`\.
    
        
    
        
        :param tagHelperDescriptors: 
            :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s associated with the current HTML tag.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public TagHelperChunkGenerator(IEnumerable<TagHelperDescriptor> tagHelperDescriptors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator.GenerateEndParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        Ends the generation of a :any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk` capturing all previously visited children
        since the :dn:meth:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator.GenerateStartParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block,Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)` method was called.
    
        
    
        
        :param target: 
            The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block` responsible for this :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator`\.
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :param context: A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext` instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator.GenerateStartParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        Starts the generation of a :any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk`\.
    
        
    
        
        :param target: 
            The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block` responsible for this :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperChunkGenerator`\.
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :param context: A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext` instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    

