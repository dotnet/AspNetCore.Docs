

LiteralAttributeChunkGenerator Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class LiteralAttributeChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/Generators/LiteralAttributeChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.LiteralAttributeChunkGenerator(Microsoft.AspNet.Razor.Text.LocationTagged<System.String>, Microsoft.AspNet.Razor.Text.LocationTagged<Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator>)
    
        
        
        
        :type prefix: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
        
        
        :type valueGenerator: Microsoft.AspNet.Razor.Text.LocationTagged{Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator}
    
        
        .. code-block:: csharp
    
           public LiteralAttributeChunkGenerator(LocationTagged<string> prefix, LocationTagged<SpanChunkGenerator> valueGenerator)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.LiteralAttributeChunkGenerator(Microsoft.AspNet.Razor.Text.LocationTagged<System.String>, Microsoft.AspNet.Razor.Text.LocationTagged<System.String>)
    
        
        
        
        :type prefix: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
        
        
        :type value: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LiteralAttributeChunkGenerator(LocationTagged<string> prefix, LocationTagged<string> value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.Prefix
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Prefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.Value
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Value { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.LiteralAttributeChunkGenerator.ValueGenerator
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator}
    
        
        .. code-block:: csharp
    
           public LocationTagged<SpanChunkGenerator> ValueGenerator { get; }
    

