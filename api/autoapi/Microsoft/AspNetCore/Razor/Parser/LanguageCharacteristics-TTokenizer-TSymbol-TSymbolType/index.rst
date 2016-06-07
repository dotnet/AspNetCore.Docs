

LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType> Class
===============================================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics\<TTokenizer, TSymbol, TSymbolType>`








Syntax
------

.. code-block:: csharp

    public abstract class LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>
        where TTokenizer : Tokenizer<TSymbol, TSymbolType> where TSymbol : SymbolBase<TSymbolType> where TSymbolType : struct








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics`3
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.CreateMarkerSymbol(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            public abstract TSymbol CreateMarkerSymbol(SourceLocation location)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, TSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: TSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            protected abstract TSymbol CreateSymbol(SourceLocation location, string content, TSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.CreateTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
        :rtype: TTokenizer
    
        
        .. code-block:: csharp
    
            public abstract TTokenizer CreateTokenizer(ITextDocument source)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.FlipBracket(TSymbolType)
    
        
    
        
        :type bracket: TSymbolType
        :rtype: TSymbolType
    
        
        .. code-block:: csharp
    
            public abstract TSymbolType FlipBracket(TSymbolType bracket)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.GetKnownSymbolType(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: TSymbolType
    
        
        .. code-block:: csharp
    
            public abstract TSymbolType GetKnownSymbolType(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.GetSample(TSymbolType)
    
        
    
        
        :type type: TSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string GetSample(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsCommentBody(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsCommentBody(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsCommentStar(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsCommentStar(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsCommentStart(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsCommentStart(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsIdentifier(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsIdentifier(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsKeyword(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsKeyword(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsKnownSymbolType(TSymbol, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
    
        
        :type symbol: TSymbol
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsKnownSymbolType(TSymbol symbol, KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsNewLine(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsNewLine(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsTransition(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsTransition(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsUnknown(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsUnknown(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.IsWhiteSpace(TSymbol)
    
        
    
        
        :type symbol: TSymbol
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsWhiteSpace(TSymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.KnowsSymbolType(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool KnowsSymbolType(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.SplitSymbol(TSymbol, System.Int32, TSymbolType)
    
        
    
        
        :type symbol: TSymbol
    
        
        :type splitAt: System.Int32
    
        
        :type leftType: TSymbolType
        :rtype: System.Tuple<System.Tuple`2>{TSymbol, TSymbol}
    
        
        .. code-block:: csharp
    
            public virtual Tuple<TSymbol, TSymbol> SplitSymbol(TSymbol symbol, int splitAt, TSymbolType leftType)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.TokenizeString(Microsoft.AspNetCore.Razor.SourceLocation, System.String)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type input: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TSymbol}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<TSymbol> TokenizeString(SourceLocation start, string input)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<TTokenizer, TSymbol, TSymbolType>.TokenizeString(System.String)
    
        
    
        
        :type content: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TSymbol}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<TSymbol> TokenizeString(string content)
    

