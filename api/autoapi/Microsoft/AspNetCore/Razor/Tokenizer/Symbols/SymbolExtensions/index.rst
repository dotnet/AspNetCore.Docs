

SymbolExtensions Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions`








Syntax
------

.. code-block:: csharp

    public class SymbolExtensions








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(this SpanBuilder span)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder, System.Func<System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        :type filter: System.Func<System.Func`2>{System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(this SpanBuilder span, Func<IEnumerable<ISymbol>, IEnumerable<ISymbol>> filter)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol)
    
        
    
        
        :type symbol: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(this ISymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type symbols: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}
    
        
        :type spanStart: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(this IEnumerable<ISymbol> symbols, SourceLocation spanStart)
    

