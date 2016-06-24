

SectionChunkGenerator Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class SectionChunkGenerator : ParentChunkGenerator, IParentChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator.SectionChunkGenerator(System.String)
    
        
    
        
        :type sectionName: System.String
    
        
        .. code-block:: csharp
    
            public SectionChunkGenerator(string sectionName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator.GenerateEndParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator.GenerateStartParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.SectionChunkGenerator.SectionName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SectionName { get; }
    

