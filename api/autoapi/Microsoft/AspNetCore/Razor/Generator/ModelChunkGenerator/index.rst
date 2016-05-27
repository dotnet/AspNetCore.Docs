

ModelChunkGenerator Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Generator`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class ModelChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator.ModelType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ModelType
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator.ModelChunkGenerator(System.String)
    
        
    
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
            public ModelChunkGenerator(string modelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator.GenerateChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Generator.ModelChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

