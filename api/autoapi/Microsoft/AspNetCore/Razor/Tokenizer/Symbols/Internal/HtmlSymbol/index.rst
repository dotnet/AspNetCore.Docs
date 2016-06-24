

HtmlSymbol Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol`








Syntax
------

.. code-block:: csharp

    public class HtmlSymbol : SymbolBase<HtmlSymbolType>, ISymbol








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol.HtmlSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(SourceLocation start, string content, HtmlSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol.HtmlSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(SourceLocation start, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol.HtmlSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType)
    
        
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type column: System.Int32
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(int offset, int line, int column, string content, HtmlSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol.HtmlSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type column: System.Int32
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(int offset, int line, int column, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    

