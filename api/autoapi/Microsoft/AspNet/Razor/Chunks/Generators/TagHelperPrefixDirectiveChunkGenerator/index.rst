

TagHelperPrefixDirectiveChunkGenerator Class
============================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator` responsible for generating 
:any:`Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class TagHelperPrefixDirectiveChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/Generators/TagHelperPrefixDirectiveChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator.TagHelperPrefixDirectiveChunkGenerator(System.String)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator`\.
    
        
        
        
        :param prefix: Text used as a required prefix when matching HTML.
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
           public TagHelperPrefixDirectiveChunkGenerator(string prefix)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        Generates :any:`Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk`\s.
    
        
        
        
        :param target: The  responsible for this .
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :param context: A  instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.TagHelperPrefixDirectiveChunkGenerator.Prefix
    
        
    
        Text used as a required prefix when matching HTML.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Prefix { get; }
    

