

AttributeBlockChunkGenerator Class
==================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class AttributeBlockChunkGenerator : ParentChunkGenerator, IParentChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Prefix
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Prefix
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Suffix
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Suffix
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.AttributeBlockChunkGenerator(System.String, Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>, Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>)
    
        
    
        
        :type name: System.String
    
        
        :type prefix: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        :type suffix: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public AttributeBlockChunkGenerator(string name, LocationTagged<string> prefix, LocationTagged<string> suffix)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.GenerateEndParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateEndParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.GenerateStartParentChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateStartParentChunk(Block target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.AttributeBlockChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

