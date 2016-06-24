

ParserContext Class
===================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserContext`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{Unparsed}")]
    public class ParserContext








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.ParserContext.ParserContext(Microsoft.AspNetCore.Razor.Text.ITextDocument, Microsoft.AspNetCore.Razor.Parser.ParserBase, Microsoft.AspNetCore.Razor.Parser.ParserBase, Microsoft.AspNetCore.Razor.Parser.ParserBase, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        :type codeParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        :type markupParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        :type activeParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public ParserContext(ITextDocument source, ParserBase codeParser, ParserBase markupParser, ParserBase activeParser, ErrorSink errorSink)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.ActiveParser
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            public ParserBase ActiveParser { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.CodeParser
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            public ParserBase CodeParser { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.CurrentBlock
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockBuilder
    
        
        .. code-block:: csharp
    
            public BlockBuilder CurrentBlock { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.CurrentCharacter
    
        
        :rtype: System.Char
    
        
        .. code-block:: csharp
    
            public char CurrentCharacter { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.DesignTimeMode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool DesignTimeMode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.EndOfFile
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool EndOfFile { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.Errors
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<RazorError> Errors { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.LastAcceptedCharacters
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
            public AcceptedCharacters LastAcceptedCharacters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.LastSpan
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public Span LastSpan { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.MarkupParser
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            public ParserBase MarkupParser { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.NullGenerateWhitespaceAndNewLine
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NullGenerateWhitespaceAndNewLine { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.Source
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.TextDocumentReader
    
        
        .. code-block:: csharp
    
            public TextDocumentReader Source { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserContext.WhiteSpaceIsSignificantToAncestorBlock
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool WhiteSpaceIsSignificantToAncestorBlock { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.AddSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public void AddSpan(Span span)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.CompleteParse()
    
        
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            public ParserResults CompleteParse()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.EndBlock()
    
        
    
        
        Ends the current block
    
        
    
        
        .. code-block:: csharp
    
            public void EndBlock()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.IsWithin(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType)
    
        
    
        
        Gets a boolean indicating if any of the ancestors of the current block is of the specified type
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsWithin(BlockType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.OnError(Microsoft.AspNetCore.Razor.RazorError)
    
        
    
        
        :type error: Microsoft.AspNetCore.Razor.RazorError
    
        
        .. code-block:: csharp
    
            public void OnError(RazorError error)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.OnError(Microsoft.AspNetCore.Razor.SourceLocation, System.String, System.Int32)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type message: System.String
    
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public void OnError(SourceLocation location, string message, int length)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.OnError(Microsoft.AspNetCore.Razor.SourceLocation, System.String, System.Int32, System.Object[])
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type message: System.String
    
        
        :type length: System.Int32
    
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public void OnError(SourceLocation location, string message, int length, params object[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.StartBlock()
    
        
    
        
        Starts a block
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable StartBlock()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.StartBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType)
    
        
    
        
        Starts a block of the specified type
    
        
    
        
        :param blockType: The type of the block to start
        
        :type blockType: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable StartBlock(BlockType blockType)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserContext.SwitchActiveParser()
    
        
    
        
        .. code-block:: csharp
    
            public void SwitchActiveParser()
    

