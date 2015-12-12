

ParserContext Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserContext`








Syntax
------

.. code-block:: csharp

   public class ParserContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/ParserContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.ParserContext.ParserContext(Microsoft.AspNet.Razor.Text.ITextDocument, Microsoft.AspNet.Razor.Parser.ParserBase, Microsoft.AspNet.Razor.Parser.ParserBase, Microsoft.AspNet.Razor.Parser.ParserBase, Microsoft.AspNet.Razor.ErrorSink)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Text.ITextDocument
        
        
        :type codeParser: Microsoft.AspNet.Razor.Parser.ParserBase
        
        
        :type markupParser: Microsoft.AspNet.Razor.Parser.ParserBase
        
        
        :type activeParser: Microsoft.AspNet.Razor.Parser.ParserBase
        
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public ParserContext(ITextDocument source, ParserBase codeParser, ParserBase markupParser, ParserBase activeParser, ErrorSink errorSink)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.AddSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public void AddSpan(Span span)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.CompleteParse()
    
        
        :rtype: Microsoft.AspNet.Razor.ParserResults
    
        
        .. code-block:: csharp
    
           public ParserResults CompleteParse()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.EndBlock()
    
        
    
        Ends the current block
    
        
    
        
        .. code-block:: csharp
    
           public void EndBlock()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.IsWithin(Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType)
    
        
    
        Gets a boolean indicating if any of the ancestors of the current block is of the specified type
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsWithin(BlockType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.OnError(Microsoft.AspNet.Razor.RazorError)
    
        
        
        
        :type error: Microsoft.AspNet.Razor.RazorError
    
        
        .. code-block:: csharp
    
           public void OnError(RazorError error)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.OnError(Microsoft.AspNet.Razor.SourceLocation, System.String, System.Int32)
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type message: System.String
        
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
           public void OnError(SourceLocation location, string message, int length)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.OnError(Microsoft.AspNet.Razor.SourceLocation, System.String, System.Int32, System.Object[])
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type message: System.String
        
        
        :type length: System.Int32
        
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public void OnError(SourceLocation location, string message, int length, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.StartBlock()
    
        
    
        Starts a block
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable StartBlock()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.StartBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType)
    
        
    
        Starts a block of the specified type
    
        
        
        
        :param blockType: The type of the block to start
        
        :type blockType: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable StartBlock(BlockType blockType)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserContext.SwitchActiveParser()
    
        
    
        
        .. code-block:: csharp
    
           public void SwitchActiveParser()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.ActiveParser
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           public ParserBase ActiveParser { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.CodeParser
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           public ParserBase CodeParser { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.CurrentBlock
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockBuilder
    
        
        .. code-block:: csharp
    
           public BlockBuilder CurrentBlock { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.CurrentCharacter
    
        
        :rtype: System.Char
    
        
        .. code-block:: csharp
    
           public char CurrentCharacter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.DesignTimeMode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool DesignTimeMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.EndOfFile
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool EndOfFile { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.Errors
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public IEnumerable<RazorError> Errors { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.LastAcceptedCharacters
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
           public AcceptedCharacters LastAcceptedCharacters { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.LastSpan
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public Span LastSpan { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.MarkupParser
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           public ParserBase MarkupParser { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.NullGenerateWhitespaceAndNewLine
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool NullGenerateWhitespaceAndNewLine { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.Source
    
        
        :rtype: Microsoft.AspNet.Razor.Text.TextDocumentReader
    
        
        .. code-block:: csharp
    
           public TextDocumentReader Source { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserContext.WhiteSpaceIsSignificantToAncestorBlock
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool WhiteSpaceIsSignificantToAncestorBlock { get; set; }
    

