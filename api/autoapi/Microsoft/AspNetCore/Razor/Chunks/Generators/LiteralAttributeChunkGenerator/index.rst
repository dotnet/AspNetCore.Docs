

LiteralAttributeChunkGenerator Class
====================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class LiteralAttributeChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.Prefix
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Prefix
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.Value
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Value
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.ValueGenerator
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator<Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<SpanChunkGenerator> ValueGenerator
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.LiteralAttributeChunkGenerator(Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>, Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator>)
    
        
    
        
        :type prefix: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        :type valueGenerator: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator<Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator>}
    
        
        .. code-block:: csharp
    
            public LiteralAttributeChunkGenerator(LocationTagged<string> prefix, LocationTagged<SpanChunkGenerator> valueGenerator)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.LiteralAttributeChunkGenerator(Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>, Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>)
    
        
    
        
        :type prefix: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        :type value: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LiteralAttributeChunkGenerator(LocationTagged<string> prefix, LocationTagged<string> value)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.GenerateChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

