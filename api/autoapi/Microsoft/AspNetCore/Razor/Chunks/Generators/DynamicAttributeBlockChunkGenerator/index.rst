

DynamicAttributeBlockChunkGenerator Class
=========================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class DynamicAttributeBlockChunkGenerator : ParentChunkGenerator, IParentChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.Prefix
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Prefix
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.ValueStart
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation ValueStart
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.DynamicAttributeBlockChunkGenerator(Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type prefix: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        :type valueStart: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public DynamicAttributeBlockChunkGenerator(LocationTagged<string> prefix, SourceLocation valueStart)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.DynamicAttributeBlockChunkGenerator(Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>, System.Int32, System.Int32, System.Int32)
    
        
    
        
        :type prefix: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type col: System.Int32
    
        
        .. code-block:: csharp
    
            public DynamicAttributeBlockChunkGenerator(LocationTagged<string> prefix, int offset, int line, int col)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.GenerateEndParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.GenerateStartParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.DynamicAttributeBlockChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

