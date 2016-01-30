

TagHelperDirectiveSpanVisitor Class
===================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Parser.ParserVisitor` that generates :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from
tag helper chunk generators in a Razor document.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserVisitor`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor`








Syntax
------

.. code-block:: csharp

   public class TagHelperDirectiveSpanVisitor : ParserVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Parser/TagHelpers/TagHelperDirectiveSpanVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.TagHelperDirectiveSpanVisitor(Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver, Microsoft.AspNet.Razor.ErrorSink)
    
        
        
        
        :type descriptorResolver: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
        
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public TagHelperDirectiveSpanVisitor(ITagHelperDescriptorResolver descriptorResolver, ErrorSink errorSink)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.GetDescriptors(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type root: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperDescriptor> GetDescriptors(Block root)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.GetTagHelperDescriptorResolutionContext(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor>, Microsoft.AspNet.Razor.ErrorSink)
    
        
        
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor}
        
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
    
        
        .. code-block:: csharp
    
           protected virtual TagHelperDescriptorResolutionContext GetTagHelperDescriptorResolutionContext(IEnumerable<TagHelperDirectiveDescriptor> descriptors, ErrorSink errorSink)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.VisitSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public override void VisitSpan(Span span)
    

