

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

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.FirstHtmlSymbolAs(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
    
        
        Converts the generic :any:`System.Collections.Generic.IEnumerable\`1` to a :any:`System.Collections.Generic.IEnumerable\`1` and
        finds the first :any:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol` with type <em>type</em>.
    
        
    
        
        :param symbols: The :any:`System.Collections.Generic.IEnumerable\`1` instance this method extends.
        
        :type symbols: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}
    
        
        :param type: The :any:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType` to search for.
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol
        :return: The first :any:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol` of type <em>type</em>.
    
        
        .. code-block:: csharp
    
            public static HtmlSymbol FirstHtmlSymbolAs(IEnumerable<ISymbol> symbols, HtmlSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(SpanBuilder span)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder, System.Func<System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        :type filter: System.Func<System.Func`2>{System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(SpanBuilder span, Func<IEnumerable<ISymbol>, IEnumerable<ISymbol>> filter)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol)
    
        
    
        
        :type symbol: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(ISymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type symbols: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}
    
        
        :type spanStart: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static LocationTagged<string> GetContent(IEnumerable<ISymbol> symbols, SourceLocation spanStart)
    

