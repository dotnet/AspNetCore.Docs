

ParentChunkGenerator Class
==========================





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








Syntax
------

.. code-block:: csharp

    public abstract class ParentChunkGenerator : IParentChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator.GenerateEndParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public virtual void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator.GenerateStartParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public virtual void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Chunks.Generators.ParentChunkGenerator.Null
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.IParentChunkGenerator
    
        
        .. code-block:: csharp
    
            public static readonly IParentChunkGenerator Null
    

