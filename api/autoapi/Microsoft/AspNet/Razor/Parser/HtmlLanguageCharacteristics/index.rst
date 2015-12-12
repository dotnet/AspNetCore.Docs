

HtmlLanguageCharacteristics Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.LanguageCharacteristics{Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer,Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol,Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics`








Syntax
------

.. code-block:: csharp

   public class HtmlLanguageCharacteristics : LanguageCharacteristics<HtmlTokenizer, HtmlSymbol, HtmlSymbolType>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/HtmlLanguageCharacteristics.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics.CreateMarkerSymbol(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol
    
        
        .. code-block:: csharp
    
           public override HtmlSymbol CreateMarkerSymbol(SourceLocation location)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics.CreateSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol
    
        
        .. code-block:: csharp
    
           protected override HtmlSymbol CreateSymbol(SourceLocation location, string content, HtmlSymbolType type, IEnumerable<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics.CreateTokenizer(Microsoft.AspNet.Razor.Text.ITextDocument)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Text.ITextDocument
        :rtype: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer
    
        
        .. code-block:: csharp
    
           public override HtmlTokenizer CreateTokenizer(ITextDocument source)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics.FlipBracket(Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
        
        
        :type bracket: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           public override HtmlSymbolType FlipBracket(HtmlSymbolType bracket)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics.GetKnownSymbolType(Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           public override HtmlSymbolType GetKnownSymbolType(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics.GetSample(Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string GetSample(HtmlSymbolType type)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics.Instance
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.HtmlLanguageCharacteristics
    
        
        .. code-block:: csharp
    
           public static HtmlLanguageCharacteristics Instance { get; }
    

