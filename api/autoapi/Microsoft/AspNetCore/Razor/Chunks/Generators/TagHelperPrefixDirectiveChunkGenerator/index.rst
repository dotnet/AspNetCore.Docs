

TagHelperPrefixDirectiveChunkGenerator Class
============================================






A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator` responsible for generating
:any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class TagHelperPrefixDirectiveChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator.TagHelperPrefixDirectiveChunkGenerator(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator`\.
    
        
    
        
        :param prefix: 
            Text used as a required prefix when matching HTML.
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public TagHelperPrefixDirectiveChunkGenerator(string prefix)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator.GenerateChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        Generates :any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk`\s.
    
        
    
        
        :param target: 
            The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span` responsible for this :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator`\.
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :param context: A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext` instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    

