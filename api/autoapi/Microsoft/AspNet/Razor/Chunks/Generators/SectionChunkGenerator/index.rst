

SectionChunkGenerator Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.ParentChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class SectionChunkGenerator : ParentChunkGenerator, IParentChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/SectionChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator.SectionChunkGenerator(System.String)
    
        
        
        
        :type sectionName: System.String
    
        
        .. code-block:: csharp
    
           public SectionChunkGenerator(string sectionName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator.GenerateEndParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator.GenerateStartParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.SectionChunkGenerator.SectionName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SectionName { get; }
    

