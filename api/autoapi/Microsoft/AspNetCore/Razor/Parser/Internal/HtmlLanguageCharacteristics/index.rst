

HtmlLanguageCharacteristics Class
=================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics{Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics`








Syntax
------

.. code-block:: csharp

    public class HtmlLanguageCharacteristics : LanguageCharacteristics<HtmlTokenizer, HtmlSymbol, HtmlSymbolType>








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics.CreateMarkerSymbol(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol
    
        
        .. code-block:: csharp
    
            public override HtmlSymbol CreateMarkerSymbol(SourceLocation location)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol
    
        
        .. code-block:: csharp
    
            protected override HtmlSymbol CreateSymbol(SourceLocation location, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics.CreateTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer
    
        
        .. code-block:: csharp
    
            public override HtmlTokenizer CreateTokenizer(ITextDocument source)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics.FlipBracket(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType)
    
        
    
        
        :type bracket: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType FlipBracket(HtmlSymbolType bracket)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics.GetKnownSymbolType(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType GetKnownSymbolType(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics.GetSample(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetSample(HtmlSymbolType type)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics.Instance
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.Internal.HtmlLanguageCharacteristics
    
        
        .. code-block:: csharp
    
            public static HtmlLanguageCharacteristics Instance { get; }
    

