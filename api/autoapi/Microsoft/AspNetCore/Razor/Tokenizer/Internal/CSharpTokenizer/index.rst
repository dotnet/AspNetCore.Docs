

CSharpTokenizer Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer.Internal`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer`








Syntax
------

.. code-block:: csharp

    public class CSharpTokenizer : Tokenizer<CSharpSymbol, CSharpSymbolType>, ITokenizer








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer.CSharpTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
            public CSharpTokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
            protected override CSharpSymbol CreateSymbol(SourceLocation start, string content, CSharpSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer.Dispatch()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected override Tokenizer<CSharpSymbol, CSharpSymbolType>.StateResult Dispatch()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer.RazorCommentStarType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType RazorCommentStarType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer.RazorCommentTransitionType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType RazorCommentTransitionType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer.RazorCommentType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType RazorCommentType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.CSharpTokenizer.StartState
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected override int StartState { get; }
    

