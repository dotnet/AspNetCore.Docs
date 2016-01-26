

TypeMemberChunkGenerator Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.TypeMemberChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class TypeMemberChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/TypeMemberChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TypeMemberChunkGenerator

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.TypeMemberChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.TypeMemberChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.TypeMemberChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

