

RazorParser Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.RazorParser`








Syntax
------

.. code-block:: csharp

    public class RazorParser








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RazorParser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RazorParser

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RazorParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.RazorParser.RazorParser(Microsoft.AspNetCore.Razor.Parser.ParserBase, Microsoft.AspNetCore.Razor.Parser.ParserBase, Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser`\.
    
        
    
        
        :param codeParser: The :any:`Microsoft.AspNetCore.Razor.Parser.ParserBase` used for parsing code content.
        
        :type codeParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        :param markupParser: The :any:`Microsoft.AspNetCore.Razor.Parser.ParserBase` used for parsing markup content.
        
        :type markupParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        :param tagHelperDescriptorResolver: The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver` used to resolve 
            :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
        
        :type tagHelperDescriptorResolver: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
            public RazorParser(ParserBase codeParser, ParserBase markupParser, ITagHelperDescriptorResolver tagHelperDescriptorResolver)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.RazorParser.RazorParser(Microsoft.AspNetCore.Razor.Parser.RazorParser)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser` from the specified <em>parser</em>.
    
        
    
        
        :param parser: The :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser` to copy values from.
        
        :type parser: Microsoft.AspNetCore.Razor.Parser.RazorParser
    
        
        .. code-block:: csharp
    
            public RazorParser(RazorParser parser)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RazorParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, Microsoft.AspNetCore.Razor.Parser.ParserVisitor)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type consumer: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task CreateParseTask(TextReader input, ParserVisitor consumer)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        :type errorCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNetCore.Razor.RazorError>, System.Threading.CancellationToken)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        :type errorCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        :type cancelToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, CancellationToken cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNetCore.Razor.RazorError>, System.Threading.SynchronizationContext)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        :type errorCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        :type context: System.Threading.SynchronizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, SynchronizationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNetCore.Razor.RazorError>, System.Threading.SynchronizationContext, System.Threading.CancellationToken)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        :type errorCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        :type context: System.Threading.SynchronizationContext
    
        
        :type cancelToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, SynchronizationContext context, CancellationToken cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.GetTagHelperDescriptors(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Returns a sequence of :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for tag helpers that are registered in the
        specified <em>documentRoot</em>.
    
        
    
        
        :param documentRoot: The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block` to scan for tag helper registrations in.
        
        :type documentRoot: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :param errorSink: Used to manage :any:`Microsoft.AspNetCore.Razor.RazorError`\s encountered during the Razor parsing
            phase.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
        :return: :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that are applicable to the <em>documentRoot</em>
    
        
        .. code-block:: csharp
    
            protected virtual IEnumerable<TagHelperDescriptor> GetTagHelperDescriptors(Block documentRoot, ErrorSink errorSink)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.Parse(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextDocument
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            public virtual ParserResults Parse(ITextDocument input)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.Parse(Microsoft.AspNetCore.Razor.Text.LookaheadTextReader)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            [Obsolete("Lookahead-based readers have been deprecated, use overrides which accept a TextReader or ITextDocument instead")]
            public virtual ParserResults Parse(LookaheadTextReader input)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.Parse(Microsoft.AspNetCore.Razor.Text.LookaheadTextReader, Microsoft.AspNetCore.Razor.Parser.ParserVisitor)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader
    
        
        :type visitor: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
            [Obsolete("Lookahead-based readers have been deprecated, use overrides which accept a TextReader or ITextDocument instead")]
            public virtual void Parse(LookaheadTextReader input, ParserVisitor visitor)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.Parse(System.IO.TextReader)
    
        
    
        
        :type input: System.IO.TextReader
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            public virtual ParserResults Parse(TextReader input)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.RazorParser.Parse(System.IO.TextReader, Microsoft.AspNetCore.Razor.Parser.ParserVisitor)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type visitor: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
            public virtual void Parse(TextReader input, ParserVisitor visitor)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RazorParser
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.RazorParser.DesignTimeMode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool DesignTimeMode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.RazorParser.TagHelperDescriptorResolver
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver` used to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
            protected ITagHelperDescriptorResolver TagHelperDescriptorResolver { get; }
    

