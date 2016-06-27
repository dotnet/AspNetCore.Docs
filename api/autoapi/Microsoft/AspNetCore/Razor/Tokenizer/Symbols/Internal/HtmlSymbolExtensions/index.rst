

HtmlSymbolExtensions Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlSymbolExtensions








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolExtensions.FirstHtmlSymbolAs(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType)
    
        
    
        
        Converts the generic :any:`System.Collections.Generic.IEnumerable\`1` to a :any:`System.Collections.Generic.IEnumerable\`1` and
        finds the first :any:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol` with type <em>type</em>.
    
        
    
        
        :param symbols: The :any:`System.Collections.Generic.IEnumerable\`1` instance this method extends.
        
        :type symbols: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}
    
        
        :param type: The :any:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType` to search for.
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol
        :return: The first :any:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol` of type <em>type</em>.
    
        
        .. code-block:: csharp
    
            public static HtmlSymbol FirstHtmlSymbolAs(this IEnumerable<ISymbol> symbols, HtmlSymbolType type)
    

