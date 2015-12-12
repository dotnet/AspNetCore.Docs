

TagHelperBlockRewriter Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter`








Syntax
------

.. code-block:: csharp

   public class TagHelperBlockRewriter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/TagHelpers/TagHelperBlockRewriter.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter.Rewrite(System.String, System.Boolean, Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNet.Razor.ErrorSink)
    
        
        
        
        :type tagName: System.String
        
        
        :type validStructure: System.Boolean
        
        
        :type tag: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        :rtype: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    
        
        .. code-block:: csharp
    
           public static TagHelperBlockBuilder Rewrite(string tagName, bool validStructure, Block tag, IEnumerable<TagHelperDescriptor> descriptors, ErrorSink errorSink)
    

