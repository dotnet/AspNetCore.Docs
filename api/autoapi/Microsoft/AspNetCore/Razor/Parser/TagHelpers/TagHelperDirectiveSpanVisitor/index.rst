

TagHelperDirectiveSpanVisitor Class
===================================






A :any:`Microsoft.AspNetCore.Razor.Parser.ParserVisitor` that generates :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from
tag helper chunk generators in a Razor document.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserVisitor`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor`








Syntax
------

.. code-block:: csharp

    public class TagHelperDirectiveSpanVisitor : ParserVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.TagHelperDirectiveSpanVisitor(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        :type descriptorResolver: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public TagHelperDirectiveSpanVisitor(ITagHelperDescriptorResolver descriptorResolver, ErrorSink errorSink)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.GetDescriptors(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type root: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperDescriptor> GetDescriptors(Block root)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.GetTagHelperDescriptorResolutionContext(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor>, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor>}
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
    
        
        .. code-block:: csharp
    
            protected virtual TagHelperDescriptorResolutionContext GetTagHelperDescriptorResolutionContext(IEnumerable<TagHelperDirectiveDescriptor> descriptors, ErrorSink errorSink)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperDirectiveSpanVisitor.VisitSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public override void VisitSpan(Span span)
    

