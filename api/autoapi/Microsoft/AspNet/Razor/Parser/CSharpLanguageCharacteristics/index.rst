

CSharpLanguageCharacteristics Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.LanguageCharacteristics{Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer,Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics`








Syntax
------

.. code-block:: csharp

   public class CSharpLanguageCharacteristics : LanguageCharacteristics<CSharpTokenizer, CSharpSymbol, CSharpSymbolType>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/CSharpLanguageCharacteristics.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.CreateMarkerSymbol(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
           public override CSharpSymbol CreateMarkerSymbol(SourceLocation location)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.CreateSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
           protected override CSharpSymbol CreateSymbol(SourceLocation location, string content, CSharpSymbolType type, IEnumerable<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.CreateTokenizer(Microsoft.AspNet.Razor.Text.ITextDocument)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Text.ITextDocument
        :rtype: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer
    
        
        .. code-block:: csharp
    
           public override CSharpTokenizer CreateTokenizer(ITextDocument source)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.FlipBracket(Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
        
        
        :type bracket: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
           public override CSharpSymbolType FlipBracket(CSharpSymbolType bracket)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.GetKeyword(Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpKeyword)
    
        
        
        
        :type keyword: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpKeyword
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetKeyword(CSharpKeyword keyword)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.GetKnownSymbolType(Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.KnownSymbolType
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
           public override CSharpSymbolType GetKnownSymbolType(KnownSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.GetSample(Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string GetSample(CSharpSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.GetSymbolSample(Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetSymbolSample(CSharpSymbolType type)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics.Instance
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.CSharpLanguageCharacteristics
    
        
        .. code-block:: csharp
    
           public static CSharpLanguageCharacteristics Instance { get; }
    

