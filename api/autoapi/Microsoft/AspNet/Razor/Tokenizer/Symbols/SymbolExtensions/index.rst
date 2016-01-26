

SymbolExtensions Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions`








Syntax
------

.. code-block:: csharp

   public class SymbolExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Tokenizer/Symbols/SymbolExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions.FirstHtmlSymbolAs(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>, Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
    
        Converts the generic :any:`System.Collections.Generic.IEnumerable\`1` to a :any:`System.Collections.Generic.IEnumerable\`1` and
        finds the first :any:`Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol` with type ``type``.
    
        
        
        
        :param symbols: The  instance this method extends.
        
        :type symbols: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}
        
        
        :param type: The  to search for.
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol
        :return: The first <see cref="T:Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol" /> of type <paramref name="type" />.
    
        
        .. code-block:: csharp
    
           public static HtmlSymbol FirstHtmlSymbolAs(IEnumerable<ISymbol> symbols, HtmlSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public static LocationTagged<string> GetContent(SpanBuilder span)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder, System.Func<System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
        
        
        :type filter: System.Func{System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol},System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public static LocationTagged<string> GetContent(SpanBuilder span, Func<IEnumerable<ISymbol>, IEnumerable<ISymbol>> filter)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol)
    
        
        
        
        :type symbol: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public static LocationTagged<string> GetContent(ISymbol symbol)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolExtensions.GetContent(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>, Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type symbols: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}
        
        
        :type spanStart: Microsoft.AspNet.Razor.SourceLocation
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public static LocationTagged<string> GetContent(IEnumerable<ISymbol> symbols, SourceLocation spanStart)
    

