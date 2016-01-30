

SetBaseTypeChunkGenerator Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class SetBaseTypeChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/SetBaseTypeChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.SetBaseTypeChunkGenerator(System.String)
    
        
        
        
        :type baseType: System.String
    
        
        .. code-block:: csharp
    
           public SetBaseTypeChunkGenerator(string baseType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.BaseType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BaseType { get; }
    

