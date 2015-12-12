

HtmlSymbol Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase{Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol`








Syntax
------

.. code-block:: csharp

   public class HtmlSymbol : SymbolBase<HtmlSymbolType>, ISymbol





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Tokenizer/Symbols/HtmlSymbol.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           public HtmlSymbol(SourceLocation start, string content, HtmlSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public HtmlSymbol(SourceLocation start, string content, HtmlSymbolType type, IEnumerable<RazorError> errors)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
        
        
        :type offset: System.Int32
        
        
        :type line: System.Int32
        
        
        :type column: System.Int32
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           public HtmlSymbol(int offset, int line, int column, string content, HtmlSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type offset: System.Int32
        
        
        :type line: System.Int32
        
        
        :type column: System.Int32
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public HtmlSymbol(int offset, int line, int column, string content, HtmlSymbolType type, IEnumerable<RazorError> errors)
    

