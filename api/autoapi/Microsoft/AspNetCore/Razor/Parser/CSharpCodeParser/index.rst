

CSharpCodeParser Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserBase`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TokenizerBackedParser{Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser`








Syntax
------

.. code-block:: csharp

    public class CSharpCodeParser : TokenizerBackedParser<CSharpTokenizer, CSharpSymbol, CSharpSymbolType>








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.CSharpCodeParser()
    
        
    
        
        .. code-block:: csharp
    
            public CSharpCodeParser()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.AcceptIf(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword)
    
        
    
        
        :type keyword: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool AcceptIf(CSharpKeyword keyword)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.AddTagHelperDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void AddTagHelperDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.AssertDirective(System.String)
    
        
    
        
        :type directive: System.String
    
        
        .. code-block:: csharp
    
            [Conditional("DEBUG")]
            protected void AssertDirective(string directive)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.At(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword)
    
        
    
        
        :type keyword: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool At(CSharpKeyword keyword)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.BaseTypeDirective(System.String, System.Func<System.String, Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator>)
    
        
    
        
        :type noTypeNameError: System.String
    
        
        :type createChunkGenerator: System.Func<System.Func`2>{System.String<System.String>, Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator<Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator>}
    
        
        .. code-block:: csharp
    
            protected void BaseTypeDirective(string noTypeNameError, Func<string, SpanChunkGenerator> createChunkGenerator)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.CompleteBlock()
    
        
    
        
        .. code-block:: csharp
    
            protected void CompleteBlock()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.CompleteBlock(System.Boolean)
    
        
    
        
        :type insertMarkerIfNecessary: System.Boolean
    
        
        .. code-block:: csharp
    
            protected void CompleteBlock(bool insertMarkerIfNecessary)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.CompleteBlock(System.Boolean, System.Boolean)
    
        
    
        
        :type insertMarkerIfNecessary: System.Boolean
    
        
        :type captureWhitespaceToEndOfLine: System.Boolean
    
        
        .. code-block:: csharp
    
            protected void CompleteBlock(bool insertMarkerIfNecessary, bool captureWhitespaceToEndOfLine)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.FunctionsDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void FunctionsDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.HandleEmbeddedTransition()
    
        
    
        
        .. code-block:: csharp
    
            protected override void HandleEmbeddedTransition()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.InheritsDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void InheritsDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.InheritsDirectiveCore()
    
        
    
        
        .. code-block:: csharp
    
            protected void InheritsDirectiveCore()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.IsAtEmbeddedTransition(System.Boolean, System.Boolean)
    
        
    
        
        :type allowTemplatesAndComments: System.Boolean
    
        
        :type allowTransitions: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool IsAtEmbeddedTransition(bool allowTemplatesAndComments, bool allowTransitions)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.IsSpacingToken(System.Boolean, System.Boolean)
    
        
    
        
        :type includeNewLines: System.Boolean
    
        
        :type includeComments: System.Boolean
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected static Func<CSharpSymbol, bool> IsSpacingToken(bool includeNewLines, bool includeComments)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.MapDirectives(System.Action, System.String[])
    
        
    
        
        :type handler: System.Action
    
        
        :type directives: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            protected void MapDirectives(Action handler, params string[] directives)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.NamespaceOrTypeName()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool NamespaceOrTypeName()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.OutputSpanBeforeRazorComment()
    
        
    
        
        .. code-block:: csharp
    
            protected override void OutputSpanBeforeRazorComment()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.ParseBlock()
    
        
    
        
        .. code-block:: csharp
    
            public override void ParseBlock()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.RemoveTagHelperDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void RemoveTagHelperDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.ReservedDirective(System.Boolean)
    
        
    
        
        :type topLevel: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void ReservedDirective(bool topLevel)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.SectionDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void SectionDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.SymbolTypeEquals(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
    
        
        :type x: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        :type y: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool SymbolTypeEquals(CSharpSymbolType x, CSharpSymbolType y)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.TagHelperPrefixDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void TagHelperPrefixDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.TryGetDirectiveHandler(System.String, out System.Action)
    
        
    
        
        :type directive: System.String
    
        
        :type handler: System.Action
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool TryGetDirectiveHandler(string directive, out Action handler)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.IsNested
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsNested { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Keywords
    
        
        :rtype: System.Collections.Generic.ISet<System.Collections.Generic.ISet`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            protected ISet<string> Keywords { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Language
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics<Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics`3>{Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer<Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer>, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol>, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType>}
    
        
        .. code-block:: csharp
    
            protected override LanguageCharacteristics<CSharpTokenizer, CSharpSymbol, CSharpSymbolType> Language { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.OtherParser
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            protected override ParserBase OtherParser { get; }
    

