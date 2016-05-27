

SpanEditHandler Class
=====================





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








Syntax
------

.. code-block:: csharp

    public class SpanEditHandler








.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.AcceptedCharacters
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
            public AcceptedCharacters AcceptedCharacters
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.EditorHints
    
        
    
        
        Provides a set of hints to editors which may be manipulating the document in which this span is located.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Editor.EditorHints
    
        
        .. code-block:: csharp
    
            public EditorHints EditorHints
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.Tokenizer
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        .. code-block:: csharp
    
            public Func<string, IEnumerable<ISymbol>> Tokenizer
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.SpanEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        .. code-block:: csharp
    
            public SpanEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.SpanEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        :type accepted: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
            public SpanEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, AcceptedCharacters accepted)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.ApplyChange(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: Microsoft.AspNetCore.Razor.Editor.EditResult
    
        
        .. code-block:: csharp
    
            public virtual EditResult ApplyChange(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.ApplyChange(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange, System.Boolean)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
    
        
        :type force: System.Boolean
        :rtype: Microsoft.AspNetCore.Razor.Editor.EditResult
    
        
        .. code-block:: csharp
    
            public virtual EditResult ApplyChange(Span target, TextChange change, bool force)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.CanAcceptChange(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type normalizedChange: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            protected virtual PartialParseResult CanAcceptChange(Span target, TextChange normalizedChange)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.CreateDefault()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    
        
        .. code-block:: csharp
    
            public static SpanEditHandler CreateDefault()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.CreateDefault(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
        :rtype: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    
        
        .. code-block:: csharp
    
            public static SpanEditHandler CreateDefault(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.GetOldText(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        Returns the old text referenced by the change.
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected static string GetOldText(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.IsAtEndOfFirstLine(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected static bool IsAtEndOfFirstLine(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.IsAtEndOfSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected static bool IsAtEndOfSpan(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.IsEndDeletion(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        Returns true if the specified change is an insertion of text at the end of this span.
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected static bool IsEndDeletion(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.IsEndInsertion(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        Returns true if the specified change is an insertion of text at the end of this span.
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected static bool IsEndInsertion(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.IsEndReplace(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        Returns true if the specified change is a replacement of text at the end of this span.
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected static bool IsEndReplace(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.OwnsChange(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool OwnsChange(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler.UpdateSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type normalizedChange: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
            protected virtual SpanBuilder UpdateSpan(Span target, TextChange normalizedChange)
    

