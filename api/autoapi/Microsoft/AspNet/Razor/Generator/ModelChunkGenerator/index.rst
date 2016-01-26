

ModelChunkGenerator Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Generator.ModelChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class ModelChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/ModelChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator.ModelChunkGenerator(System.String)
    
        
        
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
           public ModelChunkGenerator(string modelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Generator.ModelChunkGenerator.ModelType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ModelType { get; }
    

