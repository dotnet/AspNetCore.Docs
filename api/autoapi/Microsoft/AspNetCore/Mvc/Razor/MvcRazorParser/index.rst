

MvcRazorParser Class
====================






A subtype of :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser` that :any:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost` uses to support inheritance of tag
helpers from <code>_ViewImports</code> files.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.RazorParser`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser`








Syntax
------

.. code-block:: csharp

    public class MvcRazorParser : RazorParser








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser.MvcRazorParser(Microsoft.AspNetCore.Razor.Parser.RazorParser, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.ChunkTree>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.Chunk>, System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser`\.
    
        
    
        
        :param parser: The :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser` to copy properties from.
        
        :type parser: Microsoft.AspNetCore.Razor.Parser.RazorParser
    
        
        :param inheritedChunkTrees: The :any:`System.Collections.Generic.IReadOnlyList\`1`\s that are inherited
            from parsed pages from _ViewImports files.
        
        :type inheritedChunkTrees: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.ChunkTree<Microsoft.AspNetCore.Razor.Chunks.ChunkTree>}
    
        
        :param defaultInheritedChunks: The :any:`System.Collections.Generic.IReadOnlyList\`1` inherited by
            default by all Razor pages in the application.
        
        :type defaultInheritedChunks: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        :param modelExpressionTypeName: The full name of the model expression :any:`System.Type`\.
        
        :type modelExpressionTypeName: System.String
    
        
        .. code-block:: csharp
    
            public MvcRazorParser(RazorParser parser, IReadOnlyList<ChunkTree> inheritedChunkTrees, IReadOnlyList<Chunk> defaultInheritedChunks, string modelExpressionTypeName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser.GetTagHelperDescriptors(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        :type documentRoot: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            protected override IEnumerable<TagHelperDescriptor> GetTagHelperDescriptors(Block documentRoot, ErrorSink errorSink)
    

