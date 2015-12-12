

RazorParser Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.RazorParser`








Syntax
------

.. code-block:: csharp

   public class RazorParser





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/RazorParser.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.RazorParser

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.RazorParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.RazorParser.RazorParser(Microsoft.AspNet.Razor.Parser.ParserBase, Microsoft.AspNet.Razor.Parser.ParserBase, Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.Parser.RazorParser`\.
    
        
        
        
        :param codeParser: The  used for parsing code content.
        
        :type codeParser: Microsoft.AspNet.Razor.Parser.ParserBase
        
        
        :param markupParser: The  used for parsing markup content.
        
        :type markupParser: Microsoft.AspNet.Razor.Parser.ParserBase
        
        
        :param tagHelperDescriptorResolver: The  used to resolve
            s.
        
        :type tagHelperDescriptorResolver: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
           public RazorParser(ParserBase codeParser, ParserBase markupParser, ITagHelperDescriptorResolver tagHelperDescriptorResolver)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.RazorParser.RazorParser(Microsoft.AspNet.Razor.Parser.RazorParser)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.Parser.RazorParser` from the specified ``parser``.
    
        
        
        
        :param parser: The  to copy values from.
        
        :type parser: Microsoft.AspNet.Razor.Parser.RazorParser
    
        
        .. code-block:: csharp
    
           public RazorParser(RazorParser parser)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.RazorParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, Microsoft.AspNet.Razor.Parser.ParserVisitor)
    
        
        
        
        :type input: System.IO.TextReader
        
        
        :type consumer: Microsoft.AspNet.Razor.Parser.ParserVisitor
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task CreateParseTask(TextReader input, ParserVisitor consumer)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type input: System.IO.TextReader
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
        
        
        :type errorCallback: System.Action{Microsoft.AspNet.Razor.RazorError}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNet.Razor.RazorError>, System.Threading.CancellationToken)
    
        
        
        
        :type input: System.IO.TextReader
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
        
        
        :type errorCallback: System.Action{Microsoft.AspNet.Razor.RazorError}
        
        
        :type cancelToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, CancellationToken cancelToken)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNet.Razor.RazorError>, System.Threading.SynchronizationContext)
    
        
        
        
        :type input: System.IO.TextReader
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
        
        
        :type errorCallback: System.Action{Microsoft.AspNet.Razor.RazorError}
        
        
        :type context: System.Threading.SynchronizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, SynchronizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.CreateParseTask(System.IO.TextReader, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNet.Razor.RazorError>, System.Threading.SynchronizationContext, System.Threading.CancellationToken)
    
        
        
        
        :type input: System.IO.TextReader
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
        
        
        :type errorCallback: System.Action{Microsoft.AspNet.Razor.RazorError}
        
        
        :type context: System.Threading.SynchronizationContext
        
        
        :type cancelToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, SynchronizationContext context, CancellationToken cancelToken)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.GetTagHelperDescriptors(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Returns a sequence of :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for tag helpers that are registered in the
        specified ``documentRoot``.
    
        
        
        
        :param documentRoot: The  to scan for tag helper registrations in.
        
        :type documentRoot: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :param errorSink: Used to manage s encountered during the Razor parsing
            phase.
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        :return: <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor" />s that are applicable to the <paramref name="documentRoot" />
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<TagHelperDescriptor> GetTagHelperDescriptors(Block documentRoot, ErrorSink errorSink)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.Parse(Microsoft.AspNet.Razor.Text.ITextDocument)
    
        
        
        
        :type input: Microsoft.AspNet.Razor.Text.ITextDocument
        :rtype: Microsoft.AspNet.Razor.ParserResults
    
        
        .. code-block:: csharp
    
           public virtual ParserResults Parse(ITextDocument input)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.Parse(Microsoft.AspNet.Razor.Text.LookaheadTextReader)
    
        
        
        
        :type input: Microsoft.AspNet.Razor.Text.LookaheadTextReader
        :rtype: Microsoft.AspNet.Razor.ParserResults
    
        
        .. code-block:: csharp
    
           public virtual ParserResults Parse(LookaheadTextReader input)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.Parse(Microsoft.AspNet.Razor.Text.LookaheadTextReader, Microsoft.AspNet.Razor.Parser.ParserVisitor)
    
        
        
        
        :type input: Microsoft.AspNet.Razor.Text.LookaheadTextReader
        
        
        :type visitor: Microsoft.AspNet.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
           public virtual void Parse(LookaheadTextReader input, ParserVisitor visitor)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.Parse(System.IO.TextReader)
    
        
        
        
        :type input: System.IO.TextReader
        :rtype: Microsoft.AspNet.Razor.ParserResults
    
        
        .. code-block:: csharp
    
           public virtual ParserResults Parse(TextReader input)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.RazorParser.Parse(System.IO.TextReader, Microsoft.AspNet.Razor.Parser.ParserVisitor)
    
        
        
        
        :type input: System.IO.TextReader
        
        
        :type visitor: Microsoft.AspNet.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
           public virtual void Parse(TextReader input, ParserVisitor visitor)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.RazorParser
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.RazorParser.DesignTimeMode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool DesignTimeMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.RazorParser.TagHelperDescriptorResolver
    
        
    
        Gets the :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver` used to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
    
        
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
           protected ITagHelperDescriptorResolver TagHelperDescriptorResolver { get; }
    

