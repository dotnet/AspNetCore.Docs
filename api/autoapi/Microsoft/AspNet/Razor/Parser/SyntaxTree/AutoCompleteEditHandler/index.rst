

AutoCompleteEditHandler Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Editor.SpanEditHandler`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler`








Syntax
------

.. code-block:: csharp

   public class AutoCompleteEditHandler : SpanEditHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Editor/AutoCompleteEditHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.AutoCompleteEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
    
        
        .. code-block:: csharp
    
           public AutoCompleteEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.AutoCompleteEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>, Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
        
        
        :type accepted: Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
           public AutoCompleteEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, AcceptedCharacters accepted)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.AutoCompleteEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>, System.Boolean)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
        
        
        :type autoCompleteAtEndOfSpan: System.Boolean
    
        
        .. code-block:: csharp
    
           public AutoCompleteEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, bool autoCompleteAtEndOfSpan)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.CanAcceptChange(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type normalizedChange: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: Microsoft.AspNet.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
           protected override PartialParseResult CanAcceptChange(Span target, TextChange normalizedChange)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.AutoCompleteAtEndOfSpan
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AutoCompleteAtEndOfSpan { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.AutoCompleteEditHandler.AutoCompleteString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AutoCompleteString { get; set; }
    

