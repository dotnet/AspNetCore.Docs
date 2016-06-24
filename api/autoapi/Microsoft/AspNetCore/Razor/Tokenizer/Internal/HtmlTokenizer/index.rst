

HtmlTokenizer Class
===================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer`








Syntax
------

.. code-block:: csharp

    public class HtmlTokenizer : Tokenizer<HtmlSymbol, HtmlSymbolType>, ITokenizer








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer.HtmlTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
            public HtmlTokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbol
    
        
        .. code-block:: csharp
    
            protected override HtmlSymbol CreateSymbol(SourceLocation start, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer.Dispatch()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected override Tokenizer<HtmlSymbol, HtmlSymbolType>.StateResult Dispatch()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer.RazorCommentStarType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType RazorCommentStarType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer.RazorCommentTransitionType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType RazorCommentTransitionType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer.RazorCommentType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.Internal.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType RazorCommentType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Internal.HtmlTokenizer.StartState
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected override int StartState { get; }
    

