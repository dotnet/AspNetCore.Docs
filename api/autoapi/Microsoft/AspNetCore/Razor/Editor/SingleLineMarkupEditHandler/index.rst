

SingleLineMarkupEditHandler Class
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Editor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Editor.SpanEditHandler`
* :dn:cls:`Microsoft.AspNetCore.Razor.Editor.SingleLineMarkupEditHandler`








Syntax
------

.. code-block:: csharp

    public class SingleLineMarkupEditHandler : SpanEditHandler








.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SingleLineMarkupEditHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SingleLineMarkupEditHandler

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SingleLineMarkupEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.SingleLineMarkupEditHandler.SingleLineMarkupEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        .. code-block:: csharp
    
            public SingleLineMarkupEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.SingleLineMarkupEditHandler.SingleLineMarkupEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        :type accepted: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
            public SingleLineMarkupEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, AcceptedCharacters accepted)
    

