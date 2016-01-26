

SpanChunkGenerator Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`








Syntax
------

.. code-block:: csharp

   public abstract class SpanChunkGenerator : ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/SpanChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public virtual void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator.Null
    
        
    
        
        .. code-block:: csharp
    
           public static readonly ISpanChunkGenerator Null
    

