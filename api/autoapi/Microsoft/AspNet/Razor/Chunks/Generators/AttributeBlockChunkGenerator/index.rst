

AttributeBlockChunkGenerator Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.ParentChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class AttributeBlockChunkGenerator : ParentChunkGenerator, IParentChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/AttributeBlockChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.AttributeBlockChunkGenerator(System.String, Microsoft.AspNet.Razor.Text.LocationTagged<System.String>, Microsoft.AspNet.Razor.Text.LocationTagged<System.String>)
    
        
        
        
        :type name: System.String
        
        
        :type prefix: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
        
        
        :type suffix: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public AttributeBlockChunkGenerator(string name, LocationTagged<string> prefix, LocationTagged<string> suffix)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.GenerateEndParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.GenerateStartParentChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Prefix
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Prefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Suffix
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Suffix { get; }
    

