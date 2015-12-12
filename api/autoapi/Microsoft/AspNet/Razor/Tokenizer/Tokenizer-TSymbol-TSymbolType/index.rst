

Tokenizer<TSymbol, TSymbolType> Class
=====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.StateMachine{{TSymbol}}`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Tokenizer\<TSymbol, TSymbolType>`








Syntax
------

.. code-block:: csharp

   public abstract class Tokenizer<TSymbol, TSymbolType> : StateMachine<TSymbol>, ITokenizer where TSymbol : SymbolBase<TSymbolType> where TSymbolType : struct





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Tokenizer/Tokenizer.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Tokenizer(Microsoft.AspNet.Razor.Text.ITextDocument)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
           protected Tokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.AfterRazorCommentTransition()
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine{{TSymbol}}.StateResult
    
        
        .. code-block:: csharp
    
           protected StateMachine<TSymbol>.StateResult AfterRazorCommentTransition()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CreateSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, TSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: {TSymbolType}
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected abstract TSymbol CreateSymbol(SourceLocation start, string content, TSymbolType type, IEnumerable<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.EndSymbol(Microsoft.AspNet.Razor.SourceLocation, TSymbolType)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type type: {TSymbolType}
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol EndSymbol(SourceLocation start, TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.EndSymbol(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol EndSymbol(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Microsoft.AspNet.Razor.Tokenizer.ITokenizer.NextSymbol()
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol
    
        
        .. code-block:: csharp
    
           ISymbol ITokenizer.NextSymbol()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.MoveNext()
    
        
    
        
        .. code-block:: csharp
    
           protected void MoveNext()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.NextSymbol()
    
        
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           public virtual TSymbol NextSymbol()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Peek()
    
        
        :rtype: System.Char
    
        
        .. code-block:: csharp
    
           protected char Peek()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentBody()
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine{{TSymbol}}.StateResult
    
        
        .. code-block:: csharp
    
           protected StateMachine<TSymbol>.StateResult RazorCommentBody()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Single(TSymbolType)
    
        
        
        
        :type type: {TSymbolType}
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           protected TSymbol Single(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StartSymbol()
    
        
    
        
        .. code-block:: csharp
    
           protected void StartSymbol()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.TakeAll(System.String, System.Boolean)
    
        
        
        
        :type expected: System.String
        
        
        :type caseSensitive: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool TakeAll(string expected, bool caseSensitive)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.TakeCurrent()
    
        
    
        
        .. code-block:: csharp
    
           protected void TakeCurrent()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.TakeUntil(System.Func<System.Char, System.Boolean>)
    
        
        
        
        :type predicate: System.Func{System.Char,System.Boolean}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool TakeUntil(Func<char, bool> predicate)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Buffer
    
        
        :rtype: System.Text.StringBuilder
    
        
        .. code-block:: csharp
    
           protected StringBuilder Buffer { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentCharacter
    
        
        :rtype: System.Char
    
        
        .. code-block:: csharp
    
           protected char CurrentCharacter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentErrors
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           protected IList<RazorError> CurrentErrors { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentLocation
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           protected SourceLocation CurrentLocation { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentStart
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           protected SourceLocation CurrentStart { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.DebugDisplay
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DebugDisplay { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.EndOfFile
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool EndOfFile { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.HaveContent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool HaveContent { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentStarType
    
        
        :rtype: {TSymbolType}
    
        
        .. code-block:: csharp
    
           public abstract TSymbolType RazorCommentStarType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentTransitionType
    
        
        :rtype: {TSymbolType}
    
        
        .. code-block:: csharp
    
           public abstract TSymbolType RazorCommentTransitionType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentType
    
        
        :rtype: {TSymbolType}
    
        
        .. code-block:: csharp
    
           public abstract TSymbolType RazorCommentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Remaining
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Remaining { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Source
    
        
        :rtype: Microsoft.AspNet.Razor.Text.TextDocumentReader
    
        
        .. code-block:: csharp
    
           public TextDocumentReader Source { get; }
    

