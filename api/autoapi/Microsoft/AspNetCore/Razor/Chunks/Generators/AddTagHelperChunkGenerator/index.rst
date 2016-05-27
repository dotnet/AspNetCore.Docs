

AddTagHelperChunkGenerator Class
================================






A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator` responsible for generating :any:`Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class AddTagHelperChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator.AddTagHelperChunkGenerator(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator`\.
    
        
    
        
        :param lookupText: 
            Text used to look up :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that should be added.
        
        :type lookupText: System.String
    
        
        .. code-block:: csharp
    
            public AddTagHelperChunkGenerator(string lookupText)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator.GenerateChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        Generates :any:`Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk`\s.
    
        
    
        
        :param target: 
            The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span` responsible for this :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.AddTagHelperChunkGenerator`\.
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :param context: A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext` instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    

