

SetBaseTypeChunkGenerator Class
===============================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class SetBaseTypeChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.SetBaseTypeChunkGenerator(System.String)
    
        
    
        
        :type baseType: System.String
    
        
        .. code-block:: csharp
    
            public SetBaseTypeChunkGenerator(string baseType)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.BaseType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BaseType { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.GenerateChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SetBaseTypeChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

