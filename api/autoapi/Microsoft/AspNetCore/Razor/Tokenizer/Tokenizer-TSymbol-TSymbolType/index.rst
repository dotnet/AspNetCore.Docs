

Tokenizer<TSymbol, TSymbolType> Class
=====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer\<TSymbol, TSymbolType>`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebugDisplay}")]
    public abstract class Tokenizer<TSymbol, TSymbolType> : ITokenizer where TSymbol : SymbolBase<TSymbolType> where TSymbolType : struct








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Tokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
            protected Tokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.AfterRazorCommentTransition()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult AfterRazorCommentTransition()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.AtSymbolAfterRazorCommentBody()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult AtSymbolAfterRazorCommentBody()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, TSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: TSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            protected abstract TSymbol CreateSymbol(SourceLocation start, string content, TSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Dispatch()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected abstract Tokenizer<TSymbol, TSymbolType>.StateResult Dispatch()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.EndSymbol(Microsoft.AspNetCore.Razor.SourceLocation, TSymbolType)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type type: TSymbolType
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            protected TSymbol EndSymbol(SourceLocation start, TSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.EndSymbol(TSymbolType)
    
        
    
        
        :type type: TSymbolType
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            protected TSymbol EndSymbol(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Microsoft.AspNetCore.Razor.Tokenizer.ITokenizer.NextSymbol()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol
    
        
        .. code-block:: csharp
    
            ISymbol ITokenizer.NextSymbol()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.MoveNext()
    
        
    
        
        .. code-block:: csharp
    
            protected void MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.NextSymbol()
    
        
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            public virtual TSymbol NextSymbol()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Peek()
    
        
        :rtype: System.Char
    
        
        .. code-block:: csharp
    
            protected char Peek()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentBody()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult RazorCommentBody()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Single(TSymbolType)
    
        
    
        
        :type type: TSymbolType
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            protected TSymbol Single(TSymbolType type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StarAfterRazorCommentBody()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult StarAfterRazorCommentBody()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StartSymbol()
    
        
    
        
        .. code-block:: csharp
    
            protected void StartSymbol()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Stay()
    
        
    
        
        Returns a result indicating that this state has no output and the machine should remain in this state
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult Stay()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Stay(TSymbol)
    
        
    
        
        Returns a result containing the specified output and indicating that the next call to 
        :dn:meth:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer\`2.Turn` should re-invoke the current state.
    
        
    
        
        :type result: TSymbol
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult Stay(TSymbol result)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Stop()
    
        
    
        
        Returns a result indicating that the machine should stop executing and return null output.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult Stop()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.TakeAll(System.String, System.Boolean)
    
        
    
        
        :type expected: System.String
    
        
        :type caseSensitive: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool TakeAll(string expected, bool caseSensitive)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.TakeCurrent()
    
        
    
        
        .. code-block:: csharp
    
            protected void TakeCurrent()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.TakeUntil(System.Func<System.Char, System.Boolean>)
    
        
    
        
        :type predicate: System.Func<System.Func`2>{System.Char<System.Char>, System.Boolean<System.Boolean>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool TakeUntil(Func<char, bool> predicate)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Transition(Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentTokenizerState)
    
        
    
        
        :type state: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.RazorCommentTokenizerState<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.RazorCommentTokenizerState>{}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult Transition(Tokenizer<TSymbol, TSymbolType>.RazorCommentTokenizerState state)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Transition(Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentTokenizerState, TSymbol)
    
        
    
        
        :type state: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.RazorCommentTokenizerState<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.RazorCommentTokenizerState>{}
    
        
        :type result: TSymbol
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult Transition(Tokenizer<TSymbol, TSymbolType>.RazorCommentTokenizerState state, TSymbol result)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Transition(System.Int32)
    
        
    
        
        Returns a result indicating that this state has no output and the machine should immediately invoke the specified state
    
        
    
        
        :type state: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult Transition(int state)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Transition(System.Int32, TSymbol)
    
        
    
        
        Returns a result containing the specified output and indicating that the next call to 
        :dn:meth:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer\`2.Turn` should invoke the provided state.
    
        
    
        
        :type state: System.Int32
    
        
        :type result: TSymbol
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected Tokenizer<TSymbol, TSymbolType>.StateResult Transition(int state, TSymbol result)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Turn()
    
        
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            protected virtual TSymbol Turn()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Buffer
    
        
        :rtype: System.Text.StringBuilder
    
        
        .. code-block:: csharp
    
            protected StringBuilder Buffer { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentCharacter
    
        
        :rtype: System.Char
    
        
        .. code-block:: csharp
    
            protected char CurrentCharacter { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentErrors
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            protected IList<RazorError> CurrentErrors { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            protected SourceLocation CurrentLocation { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentStart
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            protected SourceLocation CurrentStart { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentState
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            protected int ? CurrentState { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.CurrentSymbol
    
        
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            protected TSymbol CurrentSymbol { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.DebugDisplay
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DebugDisplay { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.EndOfFile
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool EndOfFile { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.HaveContent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool HaveContent { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentStarType
    
        
        :rtype: TSymbolType
    
        
        .. code-block:: csharp
    
            public abstract TSymbolType RazorCommentStarType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentTransitionType
    
        
        :rtype: TSymbolType
    
        
        .. code-block:: csharp
    
            public abstract TSymbolType RazorCommentTransitionType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.RazorCommentType
    
        
        :rtype: TSymbolType
    
        
        .. code-block:: csharp
    
            public abstract TSymbolType RazorCommentType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Remaining
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Remaining { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.Source
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.TextDocumentReader
    
        
        .. code-block:: csharp
    
            public TextDocumentReader Source { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StartState
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected abstract int StartState { get; }
    

