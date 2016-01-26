

TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType> Class
=============================================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserBase`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.TokenizerBackedParser\<TTokenizer, TSymbol, TSymbolType>`








Syntax
------

.. code-block:: csharp

   public abstract class TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType> : ParserBase where TTokenizer : Tokenizer<TSymbol, TSymbolType> where TSymbol : SymbolBase<TSymbolType> where TSymbolType : struct





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Parser/TokenizerBackedParser.Helpers.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.TokenizerBackedParser()
    
        
    
        
        .. code-block:: csharp
    
           protected TokenizerBackedParser()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Accept(System.Collections.Generic.IEnumerable<TSymbol>)
    
        
        
        
        :type symbols: System.Collections.Generic.IEnumerable{{TSymbol}}
    
        
        .. code-block:: csharp
    
           protected void Accept(IEnumerable<TSymbol> symbols)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Accept(TSymbol)
    
        
        
        
        :type symbol: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected void Accept(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptAll(TSymbolType[])
    
        
        
        
        :type types: {TSymbolType}[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool AcceptAll(params TSymbolType[] types)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptAndMoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool AcceptAndMoveNext()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptSingleWhiteSpaceCharacter()
    
        
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol AcceptSingleWhiteSpaceCharacter()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptUntil(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
    
        
        .. code-block:: csharp
    
           protected void AcceptUntil(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptUntil(TSymbolType, TSymbolType)
    
        
        
        
        :type type1: {TSymbolType}
        
        
        :type type2: {TSymbolType}
    
        
        .. code-block:: csharp
    
           protected void AcceptUntil(TSymbolType type1, TSymbolType type2)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptUntil(TSymbolType, TSymbolType, TSymbolType)
    
        
        
        
        :type type1: {TSymbolType}
        
        
        :type type2: {TSymbolType}
        
        
        :type type3: {TSymbolType}
    
        
        .. code-block:: csharp
    
           protected void AcceptUntil(TSymbolType type1, TSymbolType type2, TSymbolType type3)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptUntil(TSymbolType[])
    
        
        
        
        :type types: {TSymbolType}[]
    
        
        .. code-block:: csharp
    
           protected void AcceptUntil(params TSymbolType[] types)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptWhile(System.Func<TSymbol, System.Boolean>)
    
        
        
        
        :type condition: System.Func{{TSymbol},System.Boolean}
    
        
        .. code-block:: csharp
    
           protected void AcceptWhile(Func<TSymbol, bool> condition)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptWhile(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
    
        
        .. code-block:: csharp
    
           protected void AcceptWhile(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptWhile(TSymbolType, TSymbolType)
    
        
        
        
        :type type1: {TSymbolType}
        
        
        :type type2: {TSymbolType}
    
        
        .. code-block:: csharp
    
           protected void AcceptWhile(TSymbolType type1, TSymbolType type2)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptWhile(TSymbolType, TSymbolType, TSymbolType)
    
        
        
        
        :type type1: {TSymbolType}
        
        
        :type type2: {TSymbolType}
        
        
        :type type3: {TSymbolType}
    
        
        .. code-block:: csharp
    
           protected void AcceptWhile(TSymbolType type1, TSymbolType type2, TSymbolType type3)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptWhile(TSymbolType[])
    
        
        
        
        :type types: {TSymbolType}[]
    
        
        .. code-block:: csharp
    
           protected void AcceptWhile(params TSymbolType[] types)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AcceptWhiteSpaceInLines()
    
        
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol AcceptWhiteSpaceInLines()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AddMarkerSymbolIfNecessary()
    
        
    
        
        .. code-block:: csharp
    
           protected void AddMarkerSymbolIfNecessary()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AddMarkerSymbolIfNecessary(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           protected void AddMarkerSymbolIfNecessary(SourceLocation location)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.At(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool At(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.AtIdentifier(System.Boolean)
    
        
        
        
        :type allowKeywords: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool AtIdentifier(bool allowKeywords)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Balance(Microsoft.AspNet.Razor.Parser.BalancingModes)
    
        
        
        
        :type mode: Microsoft.AspNet.Razor.Parser.BalancingModes
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool Balance(BalancingModes mode)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Balance(Microsoft.AspNet.Razor.Parser.BalancingModes, TSymbolType, TSymbolType, Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type mode: Microsoft.AspNet.Razor.Parser.BalancingModes
        
        
        :type left: {TSymbolType}
        
        
        :type right: {TSymbolType}
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool Balance(BalancingModes mode, TSymbolType left, TSymbolType right, SourceLocation start)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.BuildSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder, Microsoft.AspNet.Razor.SourceLocation, System.String)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
           public override void BuildSpan(SpanBuilder span, SourceLocation start, string content)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.ConfigureSpan(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder>>)
    
        
        
        
        :type config: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder,System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder}}
    
        
        .. code-block:: csharp
    
           protected void ConfigureSpan(Action<SpanBuilder, Action<SpanBuilder>> config)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.ConfigureSpan(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder>)
    
        
        
        
        :type config: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder}
    
        
        .. code-block:: csharp
    
           protected void ConfigureSpan(Action<SpanBuilder> config)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.EnsureCurrent()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool EnsureCurrent()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Expected(Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType
    
        
        .. code-block:: csharp
    
           protected void Expected(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Expected(TSymbolType[])
    
        
        
        
        :type types: {TSymbolType}[]
    
        
        .. code-block:: csharp
    
           protected void Expected(params TSymbolType[] types)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.HandleEmbeddedTransition()
    
        
    
        
        .. code-block:: csharp
    
           protected virtual void HandleEmbeddedTransition()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Initialize(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
           protected void Initialize(SpanBuilder span)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.IsAtEmbeddedTransition(System.Boolean, System.Boolean)
    
        
        
        
        :type allowTemplatesAndComments: System.Boolean
        
        
        :type allowTransitions: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual bool IsAtEmbeddedTransition(bool allowTemplatesAndComments, bool allowTransitions)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Lookahead(System.Int32)
    
        
        
        
        :type count: System.Int32
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol Lookahead(int count)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.NextIs(System.Func<TSymbol, System.Boolean>)
    
        
        
        
        :type condition: System.Func{{TSymbol},System.Boolean}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool NextIs(Func<TSymbol, bool> condition)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.NextIs(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool NextIs(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.NextIs(TSymbolType[])
    
        
        
        
        :type types: {TSymbolType}[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool NextIs(params TSymbolType[] types)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.NextToken()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool NextToken()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Optional(Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool Optional(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Optional(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool Optional(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Output(Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
        
        
        :type accepts: Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
           protected void Output(AcceptedCharacters accepts)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Output(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanKind)
    
        
        
        
        :type kind: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanKind
    
        
        .. code-block:: csharp
    
           protected void Output(SpanKind kind)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Output(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanKind, Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
        
        
        :type kind: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanKind
        
        
        :type accepts: Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
           protected void Output(SpanKind kind, AcceptedCharacters accepts)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.OutputSpanBeforeRazorComment()
    
        
    
        
        .. code-block:: csharp
    
           protected virtual void OutputSpanBeforeRazorComment()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.PushSpanConfig()
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           protected IDisposable PushSpanConfig()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.PushSpanConfig(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder>>)
    
        
        
        
        :type newConfig: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder,System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder}}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           protected IDisposable PushSpanConfig(Action<SpanBuilder, Action<SpanBuilder>> newConfig)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.PushSpanConfig(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder>)
    
        
        
        
        :type newConfig: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           protected IDisposable PushSpanConfig(Action<SpanBuilder> newConfig)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.PutBack(System.Collections.Generic.IEnumerable<TSymbol>)
    
        
    
        Put the specified symbols back in the input stream. The provided list MUST be in the ORDER THE SYMBOLS WERE READ. The
        list WILL be reversed and the Putback(TSymbol) will be called on each item.
    
        
        
        
        :type symbols: System.Collections.Generic.IEnumerable{{TSymbol}}
    
        
        .. code-block:: csharp
    
           protected void PutBack(IEnumerable<TSymbol> symbols)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.PutBack(TSymbol)
    
        
        
        
        :type symbol: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected void PutBack(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.PutCurrentBack()
    
        
    
        
        .. code-block:: csharp
    
           protected void PutCurrentBack()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.RazorComment()
    
        
    
        
        .. code-block:: csharp
    
           protected void RazorComment()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.ReadWhile(System.Func<TSymbol, System.Boolean>)
    
        
        
        
        :type condition: System.Func{{TSymbol},System.Boolean}
        :rtype: System.Collections.Generic.IEnumerable{{TSymbol}}
    
        
        .. code-block:: csharp
    
           protected IEnumerable<TSymbol> ReadWhile(Func<TSymbol, bool> condition)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Required(TSymbolType, System.Boolean, System.Func<System.String, System.String>)
    
        
        
        
        :type expected: {TSymbolType}
        
        
        :type errorIfNotFound: System.Boolean
        
        
        :type errorBase: System.Func{System.String,System.String}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool Required(TSymbolType expected, bool errorIfNotFound, Func<string, string> errorBase)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Was(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool Was(TSymbolType type)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.CurrentLocation
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           protected SourceLocation CurrentLocation { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.CurrentSymbol
    
        
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol CurrentSymbol { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.EndOfFile
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool EndOfFile { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Language
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.LanguageCharacteristics{{TTokenizer},{TSymbol},{TSymbolType}}
    
        
        .. code-block:: csharp
    
           protected abstract LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType> Language { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.PreviousSymbol
    
        
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol PreviousSymbol { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Span
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
           protected SpanBuilder Span { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.SpanConfig
    
        
        :rtype: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder}
    
        
        .. code-block:: csharp
    
           protected Action<SpanBuilder> SpanConfig { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.TokenizerBackedParser<TTokenizer, TSymbol, TSymbolType>.Tokenizer
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.TokenizerView{{TTokenizer},{TSymbol},{TSymbolType}}
    
        
        .. code-block:: csharp
    
           protected TokenizerView<TTokenizer, TSymbol, TSymbolType> Tokenizer { get; }
    

