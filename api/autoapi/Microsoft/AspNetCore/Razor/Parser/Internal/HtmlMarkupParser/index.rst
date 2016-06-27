

HtmlMarkupParser Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.Internal`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserBase`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TokenizerBackedParser{Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser`








Syntax
------

.. code-block:: csharp

    public class HtmlMarkupParser : TokenizerBackedParser<HtmlTokenizer, HtmlSymbol, HtmlSymbolType>








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.BuildSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder, Microsoft.AspNetCore.Razor.SourceLocation, System.String)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
            public override void BuildSpan(SpanBuilder span, SourceLocation start, string content)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.IsSpacingToken(System.Boolean)
    
        
    
        
        :type includeNewLines: System.Boolean
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected static Func<HtmlSymbol, bool> IsSpacingToken(bool includeNewLines)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.OutputSpanBeforeRazorComment()
    
        
    
        
        .. code-block:: csharp
    
            protected override void OutputSpanBeforeRazorComment()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.ParseBlock()
    
        
    
        
        .. code-block:: csharp
    
            public override void ParseBlock()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.ParseDocument()
    
        
    
        
        .. code-block:: csharp
    
            public override void ParseDocument()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.ParseSection(System.Tuple<System.String, System.String>, System.Boolean)
    
        
    
        
        :type nestingSequences: System.Tuple<System.Tuple`2>{System.String<System.String>, System.String<System.String>}
    
        
        :type caseSensitive: System.Boolean
    
        
        .. code-block:: csharp
    
            public override void ParseSection(Tuple<string, string> nestingSequences, bool caseSensitive)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.SkipToAndParseCode(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            protected void SkipToAndParseCode(HtmlSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.SkipToAndParseCode(System.Func<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol, System.Boolean>)
    
        
    
        
        :type condition: System.Func<System.Func`2>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected void SkipToAndParseCode(Func<HtmlSymbol, bool> condition)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.SymbolTypeEquals(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType)
    
        
    
        
        :type x: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        :type y: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool SymbolTypeEquals(HtmlSymbolType x, HtmlSymbolType y)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.Language
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics`3>{Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer<Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer>, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol>, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType>}
    
        
        .. code-block:: csharp
    
            protected override LanguageCharacteristics<HtmlTokenizer, HtmlSymbol, HtmlSymbolType> Language { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.OtherParser
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            protected override ParserBase OtherParser { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlMarkupParser.VoidElements
    
        
        :rtype: System.Collections.Generic.ISet<System.Collections.Generic.ISet`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ISet<string> VoidElements { get; }
    

