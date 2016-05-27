

RazorChunkGenerator Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserVisitor`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator`








Syntax
------

.. code-block:: csharp

    public class RazorChunkGenerator : ParserVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.ClassName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClassName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.Context
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public ChunkGeneratorContext Context
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.DesignTimeMode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool DesignTimeMode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.GenerateLinePragmas
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool GenerateLinePragmas
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.Host
    
        
        :rtype: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public RazorEngineHost Host
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.RootNamespaceName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RootNamespaceName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.SourceFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SourceFileName
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.RazorChunkGenerator(System.String, System.String, System.String, Microsoft.AspNetCore.Razor.RazorEngineHost)
    
        
    
        
        :type className: System.String
    
        
        :type rootNamespaceName: System.String
    
        
        :type sourceFileName: System.String
    
        
        :type host: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public RazorChunkGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.Initialize(Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            protected virtual void Initialize(ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.VisitEndBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type block: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public override void VisitEndBlock(Block block)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.VisitSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public override void VisitSpan(Span span)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator.VisitStartBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type block: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public override void VisitStartBlock(Block block)
    

