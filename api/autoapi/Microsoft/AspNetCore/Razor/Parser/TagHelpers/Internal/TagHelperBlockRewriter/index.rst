

TagHelperBlockRewriter Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.Internal`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter`








Syntax
------

.. code-block:: csharp

    public class TagHelperBlockRewriter








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.Internal.TagHelperBlockRewriter.Rewrite(System.String, System.Boolean, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        :type tagName: System.String
    
        
        :type validStructure: System.Boolean
    
        
        :type tag: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperBlockBuilder
    
        
        .. code-block:: csharp
    
            public static TagHelperBlockBuilder Rewrite(string tagName, bool validStructure, Block tag, IEnumerable<TagHelperDescriptor> descriptors, ErrorSink errorSink)
    

