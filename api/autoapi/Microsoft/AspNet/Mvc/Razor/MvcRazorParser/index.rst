

MvcRazorParser Class
====================



.. contents:: 
   :local:



Summary
-------

A subtype of :any:`Microsoft.AspNet.Razor.Parser.RazorParser` that :any:`Microsoft.AspNet.Mvc.Razor.MvcRazorHost` uses to support inheritance of tag
helpers from <c>_ViewImports</c> files.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.RazorParser`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcRazorParser`








Syntax
------

.. code-block:: csharp

   public class MvcRazorParser : RazorParser





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/MvcRazorParser.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorParser

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcRazorParser.MvcRazorParser(Microsoft.AspNet.Razor.Parser.RazorParser, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.ChunkTree>, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.Chunk>, System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.MvcRazorParser`\.
    
        
        
        
        :param parser: The  to copy properties from.
        
        :type parser: Microsoft.AspNet.Razor.Parser.RazorParser
        
        
        :param inheritedChunkTrees: The s that are inherited
            from parsed pages from _ViewImports files.
        
        :type inheritedChunkTrees: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.ChunkTree}
        
        
        :param defaultInheritedChunks: The  inherited by
            default by all Razor pages in the application.
        
        :type defaultInheritedChunks: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.Chunk}
        
        
        :type modelExpressionTypeName: System.String
    
        
        .. code-block:: csharp
    
           public MvcRazorParser(RazorParser parser, IReadOnlyList<ChunkTree> inheritedChunkTrees, IReadOnlyList<Chunk> defaultInheritedChunks, string modelExpressionTypeName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorParser.GetTagHelperDescriptors(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.ErrorSink)
    
        
        
        
        :type documentRoot: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           protected override IEnumerable<TagHelperDescriptor> GetTagHelperDescriptors(Block documentRoot, ErrorSink errorSink)
    

