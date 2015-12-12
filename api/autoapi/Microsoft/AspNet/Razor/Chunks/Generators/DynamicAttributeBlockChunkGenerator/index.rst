

DynamicAttributeBlockChunkGenerator Class
=========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.ParentChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class DynamicAttributeBlockChunkGenerator : ParentChunkGenerator, IParentChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/DynamicAttributeBlockChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.DynamicAttributeBlockChunkGenerator(Microsoft.AspNet.Razor.Text.LocationTagged<System.String>, Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type prefix: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
        
        
        :type valueStart: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public DynamicAttributeBlockChunkGenerator(LocationTagged<string> prefix, SourceLocation valueStart)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.DynamicAttributeBlockChunkGenerator(Microsoft.AspNet.Razor.Text.LocationTagged<System.String>, System.Int32, System.Int32, System.Int32)
    
        
        
        
        :type prefix: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
        
        
        :type offset: System.Int32
        
        
        :type line: System.Int32
        
        
        :type col: System.Int32
    
        
        .. code-block:: csharp
    
           public DynamicAttributeBlockChunkGenerator(LocationTagged<string> prefix, int offset, int line, int col)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.GenerateEndParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.GenerateStartParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.Prefix
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Prefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.ValueStart
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation ValueStart { get; }
    

