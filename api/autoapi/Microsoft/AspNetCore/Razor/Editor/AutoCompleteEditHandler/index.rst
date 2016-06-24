

AutoCompleteEditHandler Class
=============================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler`








Syntax
------

.. code-block:: csharp

    public class AutoCompleteEditHandler : SpanEditHandler








.. dn:class:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.AutoCompleteEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        .. code-block:: csharp
    
            public AutoCompleteEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.AutoCompleteEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        :type accepted: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
            public AutoCompleteEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, AcceptedCharacters accepted)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.AutoCompleteEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>, System.Boolean)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        :type autoCompleteAtEndOfSpan: System.Boolean
    
        
        .. code-block:: csharp
    
            public AutoCompleteEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, bool autoCompleteAtEndOfSpan)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.AutoCompleteAtEndOfSpan
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AutoCompleteAtEndOfSpan { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.AutoCompleteString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AutoCompleteString { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.CanAcceptChange(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type normalizedChange: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            protected override PartialParseResult CanAcceptChange(Span target, TextChange normalizedChange)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.AutoCompleteEditHandler.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

