

GeneratorResults Class
======================






The results of parsing and generating code for a Razor document.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.ParserResults`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults`








Syntax
------

.. code-block:: csharp

    public class GeneratorResults : ParserResults








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults.ChunkTree
    
        
    
        
        A :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` for the document.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            public ChunkTree ChunkTree
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults.DesignTimeLineMappings
    
        
    
        
        :any:`Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping`\s used to project code from a file during design time.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping<Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping>}
    
        
        .. code-block:: csharp
    
            public IList<LineMapping> DesignTimeLineMappings
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults.GeneratedCode
    
        
    
        
        The generated code for the document.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GeneratedCode
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults.GeneratorResults(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNetCore.Razor.ErrorSink, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult, Microsoft.AspNetCore.Razor.Chunks.ChunkTree)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults` instance.
    
        
    
        
        :param document: The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block` for the syntax tree.
        
        :type document: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :param tagHelperDescriptors: 
            The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that apply to the current Razor document.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        :param errorSink: 
            The :any:`Microsoft.AspNetCore.Razor.ErrorSink` used to collect :any:`Microsoft.AspNetCore.Razor.RazorError`\s encountered when parsing the
            current Razor document.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        :param codeGeneratorResult: The results of generating code for the document.
        
        :type codeGeneratorResult: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult
    
        
        :param chunkTree: A :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults.ChunkTree` for the document.
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            public GeneratorResults(Block document, IEnumerable<TagHelperDescriptor> tagHelperDescriptors, ErrorSink errorSink, CodeGeneratorResult codeGeneratorResult, ChunkTree chunkTree)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults.GeneratorResults(Microsoft.AspNetCore.Razor.ParserResults, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult, Microsoft.AspNetCore.Razor.Chunks.ChunkTree)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults` instance.
    
        
    
        
        :param parserResults: The results of parsing a document.
        
        :type parserResults: Microsoft.AspNetCore.Razor.ParserResults
    
        
        :param codeGeneratorResult: The results of generating code for the document.
        
        :type codeGeneratorResult: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult
    
        
        :param chunkTree: A :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults.ChunkTree` for the document.
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            public GeneratorResults(ParserResults parserResults, CodeGeneratorResult codeGeneratorResult, ChunkTree chunkTree)
    

