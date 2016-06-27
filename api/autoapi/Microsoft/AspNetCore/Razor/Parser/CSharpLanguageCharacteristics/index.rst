

CSharpLanguageCharacteristics Class
===================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics{Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics`








Syntax
------

.. code-block:: csharp

    public class CSharpLanguageCharacteristics : LanguageCharacteristics<CSharpTokenizer, CSharpSymbol, CSharpSymbolType>








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.CreateMarkerSymbol(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
            public override CSharpSymbol CreateMarkerSymbol(SourceLocation location)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
            protected override CSharpSymbol CreateSymbol(SourceLocation location, string content, CSharpSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.CreateTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer
    
        
        .. code-block:: csharp
    
            public override CSharpTokenizer CreateTokenizer(ITextDocument source)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.FlipBracket(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
    
        
        :type bracket: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType FlipBracket(CSharpSymbolType bracket)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.GetKeyword(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword)
    
        
    
        
        :type keyword: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetKeyword(CSharpKeyword keyword)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.GetKnownSymbolType(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType GetKnownSymbolType(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.GetSample(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetSample(CSharpSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.GetSymbolSample(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetSymbolSample(CSharpSymbolType type)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics.Instance
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.CSharpLanguageCharacteristics
    
        
        .. code-block:: csharp
    
            public static CSharpLanguageCharacteristics Instance { get; }
    

