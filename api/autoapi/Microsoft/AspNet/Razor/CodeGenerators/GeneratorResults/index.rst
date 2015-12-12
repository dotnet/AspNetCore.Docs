

GeneratorResults Class
======================



.. contents:: 
   :local:



Summary
-------

The results of parsing and generating code for a Razor document.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.ParserResults`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults`








Syntax
------

.. code-block:: csharp

   public class GeneratorResults : ParserResults





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/GeneratorResults.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults.GeneratorResults(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNet.Razor.ErrorSink, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult, Microsoft.AspNet.Razor.Chunks.ChunkTree)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults` instance.
    
        
        
        
        :param document: The  for the syntax tree.
        
        :type document: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :param tagHelperDescriptors: The s that apply to the current Razor document.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        
        
        :param errorSink: The  used to collect s encountered when parsing the
            current Razor document.
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        
        
        :param codeGeneratorResult: The results of generating code for the document.
        
        :type codeGeneratorResult: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult
        
        
        :param chunkTree: A  for the document.
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           public GeneratorResults(Block document, IEnumerable<TagHelperDescriptor> tagHelperDescriptors, ErrorSink errorSink, CodeGeneratorResult codeGeneratorResult, ChunkTree chunkTree)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults.GeneratorResults(Microsoft.AspNet.Razor.ParserResults, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult, Microsoft.AspNet.Razor.Chunks.ChunkTree)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults` instance.
    
        
        
        
        :param parserResults: The results of parsing a document.
        
        :type parserResults: Microsoft.AspNet.Razor.ParserResults
        
        
        :param codeGeneratorResult: The results of generating code for the document.
        
        :type codeGeneratorResult: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult
        
        
        :param chunkTree: A  for the document.
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           public GeneratorResults(ParserResults parserResults, CodeGeneratorResult codeGeneratorResult, ChunkTree chunkTree)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults.ChunkTree
    
        
    
        A :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree` for the document.
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           public ChunkTree ChunkTree { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults.DesignTimeLineMappings
    
        
    
        :any:`Microsoft.AspNet.Razor.CodeGenerators.LineMapping`\s used to project code from a file during design time.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Razor.CodeGenerators.LineMapping}
    
        
        .. code-block:: csharp
    
           public IList<LineMapping> DesignTimeLineMappings { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults.GeneratedCode
    
        
    
        The generated code for the document.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GeneratedCode { get; }
    

