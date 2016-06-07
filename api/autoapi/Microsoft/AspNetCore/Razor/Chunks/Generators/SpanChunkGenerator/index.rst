

SpanChunkGenerator Class
========================





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








Syntax
------

.. code-block:: csharp

    public abstract class SpanChunkGenerator : ISpanChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator.GenerateChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public virtual void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator.Null
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.ISpanChunkGenerator
    
        
        .. code-block:: csharp
    
            public static readonly ISpanChunkGenerator Null
    

