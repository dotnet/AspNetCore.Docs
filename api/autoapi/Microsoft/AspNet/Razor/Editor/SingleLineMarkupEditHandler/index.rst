

SingleLineMarkupEditHandler Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Editor.SpanEditHandler`
* :dn:cls:`Microsoft.AspNet.Razor.Editor.SingleLineMarkupEditHandler`








Syntax
------

.. code-block:: csharp

   public class SingleLineMarkupEditHandler : SpanEditHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Editor/SingleLineMarkupEditHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Editor.SingleLineMarkupEditHandler

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Editor.SingleLineMarkupEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Editor.SingleLineMarkupEditHandler.SingleLineMarkupEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
    
        
        .. code-block:: csharp
    
           public SingleLineMarkupEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Editor.SingleLineMarkupEditHandler.SingleLineMarkupEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>, Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
        
        
        :type accepted: Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
           public SingleLineMarkupEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, AcceptedCharacters accepted)
    

