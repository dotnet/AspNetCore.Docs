

SpanEditHandler Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Editor.SpanEditHandler`








Syntax
------

.. code-block:: csharp

   public class SpanEditHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Editor/SpanEditHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Editor.SpanEditHandler

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Editor.SpanEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.SpanEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
    
        
        .. code-block:: csharp
    
           public SpanEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.SpanEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>, Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
        
        
        :type accepted: Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
           public SpanEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, AcceptedCharacters accepted)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Editor.SpanEditHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.ApplyChange(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: Microsoft.AspNet.Razor.Editor.EditResult
    
        
        .. code-block:: csharp
    
           public virtual EditResult ApplyChange(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.ApplyChange(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange, System.Boolean)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        
        
        :type force: System.Boolean
        :rtype: Microsoft.AspNet.Razor.Editor.EditResult
    
        
        .. code-block:: csharp
    
           public virtual EditResult ApplyChange(Span target, TextChange change, bool force)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.CanAcceptChange(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type normalizedChange: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: Microsoft.AspNet.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
           protected virtual PartialParseResult CanAcceptChange(Span target, TextChange normalizedChange)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.CreateDefault()
    
        
        :rtype: Microsoft.AspNet.Razor.Editor.SpanEditHandler
    
        
        .. code-block:: csharp
    
           public static SpanEditHandler CreateDefault()
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.CreateDefault(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
        :rtype: Microsoft.AspNet.Razor.Editor.SpanEditHandler
    
        
        .. code-block:: csharp
    
           public static SpanEditHandler CreateDefault(Func<string, IEnumerable<ISymbol>> tokenizer)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.GetOldText(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
    
        Returns the old text referenced by the change.
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected static string GetOldText(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.IsAtEndOfFirstLine(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected static bool IsAtEndOfFirstLine(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.IsAtEndOfSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected static bool IsAtEndOfSpan(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.IsEndDeletion(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
    
        Returns true if the specified change is an insertion of text at the end of this span.
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected static bool IsEndDeletion(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.IsEndInsertion(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
    
        Returns true if the specified change is an insertion of text at the end of this span.
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected static bool IsEndInsertion(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.IsEndReplace(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
    
        Returns true if the specified change is a replacement of text at the end of this span.
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected static bool IsEndReplace(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.OwnsChange(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool OwnsChange(Span target, TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.UpdateSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type normalizedChange: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
           protected virtual SpanBuilder UpdateSpan(Span target, TextChange normalizedChange)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Editor.SpanEditHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.AcceptedCharacters
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.AcceptedCharacters
    
        
        .. code-block:: csharp
    
           public AcceptedCharacters AcceptedCharacters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.EditorHints
    
        
    
        Provides a set of hints to editors which may be manipulating the document in which this span is located.
    
        
        :rtype: Microsoft.AspNet.Razor.Editor.EditorHints
    
        
        .. code-block:: csharp
    
           public EditorHints EditorHints { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Editor.SpanEditHandler.Tokenizer
    
        
        :rtype: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
    
        
        .. code-block:: csharp
    
           public Func<string, IEnumerable<ISymbol>> Tokenizer { get; set; }
    

