

RazorChunkGenerator Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserVisitor`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class RazorChunkGenerator : ParserVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/RazorChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.RazorChunkGenerator(System.String, System.String, System.String, Microsoft.AspNet.Razor.RazorEngineHost)
    
        
        
        
        :type className: System.String
        
        
        :type rootNamespaceName: System.String
        
        
        :type sourceFileName: System.String
        
        
        :type host: Microsoft.AspNet.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
           public RazorChunkGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.Initialize(Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           protected virtual void Initialize(ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.VisitEndBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type block: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public override void VisitEndBlock(Block block)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.VisitSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public override void VisitSpan(Span span)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.VisitStartBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type block: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public override void VisitStartBlock(Block block)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.ClassName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClassName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.Context
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public ChunkGeneratorContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.DesignTimeMode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool DesignTimeMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.GenerateLinePragmas
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool GenerateLinePragmas { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.Host
    
        
        :rtype: Microsoft.AspNet.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
           public RazorEngineHost Host { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.RootNamespaceName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RootNamespaceName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator.SourceFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SourceFileName { get; }
    

