

HtmlLanguageCharacteristics Class
=================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.LanguageCharacteristics{Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics`








Syntax
------

.. code-block:: csharp

    public class HtmlLanguageCharacteristics : LanguageCharacteristics<HtmlTokenizer, HtmlSymbol, HtmlSymbolType>








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics.Instance
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics
    
        
        .. code-block:: csharp
    
            public static HtmlLanguageCharacteristics Instance
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics.CreateMarkerSymbol(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol
    
        
        .. code-block:: csharp
    
            public override HtmlSymbol CreateMarkerSymbol(SourceLocation location)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol
    
        
        .. code-block:: csharp
    
            protected override HtmlSymbol CreateSymbol(SourceLocation location, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics.CreateTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer
    
        
        .. code-block:: csharp
    
            public override HtmlTokenizer CreateTokenizer(ITextDocument source)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics.FlipBracket(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
    
        
        :type bracket: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType FlipBracket(HtmlSymbolType bracket)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics.GetKnownSymbolType(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType GetKnownSymbolType(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.HtmlLanguageCharacteristics.GetSample(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetSample(HtmlSymbolType type)
    

