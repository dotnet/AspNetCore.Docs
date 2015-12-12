

HtmlMarkupParser Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserBase`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.TokenizerBackedParser{Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer,Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol,Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.HtmlMarkupParser`








Syntax
------

.. code-block:: csharp

   public class HtmlMarkupParser : TokenizerBackedParser<HtmlTokenizer, HtmlSymbol, HtmlSymbolType>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/HtmlMarkupParser.Section.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.BuildSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder, Microsoft.AspNet.Razor.SourceLocation, System.String)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
           public override void BuildSpan(SpanBuilder span, SourceLocation start, string content)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.IsSpacingToken(System.Boolean)
    
        
        
        
        :type includeNewLines: System.Boolean
        :rtype: System.Func{Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol,System.Boolean}
    
        
        .. code-block:: csharp
    
           protected static Func<HtmlSymbol, bool> IsSpacingToken(bool includeNewLines)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.OutputSpanBeforeRazorComment()
    
        
    
        
        .. code-block:: csharp
    
           protected override void OutputSpanBeforeRazorComment()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.ParseBlock()
    
        
    
        
        .. code-block:: csharp
    
           public override void ParseBlock()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.ParseDocument()
    
        
    
        
        .. code-block:: csharp
    
           public override void ParseDocument()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.ParseSection(System.Tuple<System.String, System.String>, System.Boolean)
    
        
        
        
        :type nestingSequences: System.Tuple{System.String,System.String}
        
        
        :type caseSensitive: System.Boolean
    
        
        .. code-block:: csharp
    
           public override void ParseSection(Tuple<string, string> nestingSequences, bool caseSensitive)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.SkipToAndParseCode(Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           protected void SkipToAndParseCode(HtmlSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.SkipToAndParseCode(System.Func<Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol, System.Boolean>)
    
        
        
        
        :type condition: System.Func{Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol,System.Boolean}
    
        
        .. code-block:: csharp
    
           protected void SkipToAndParseCode(Func<HtmlSymbol, bool> condition)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.Language
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.LanguageCharacteristics{Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer,Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol,Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType}
    
        
        .. code-block:: csharp
    
           protected override LanguageCharacteristics<HtmlTokenizer, HtmlSymbol, HtmlSymbolType> Language { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.OtherParser
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           protected override ParserBase OtherParser { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.HtmlMarkupParser.VoidElements
    
        
        :rtype: System.Collections.Generic.ISet{System.String}
    
        
        .. code-block:: csharp
    
           public ISet<string> VoidElements { get; }
    

