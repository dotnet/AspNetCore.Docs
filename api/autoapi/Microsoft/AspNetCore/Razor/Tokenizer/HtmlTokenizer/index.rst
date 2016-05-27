

HtmlTokenizer Class
===================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer`








Syntax
------

.. code-block:: csharp

    public class HtmlTokenizer : Tokenizer<HtmlSymbol, HtmlSymbolType>, ITokenizer








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer.RazorCommentStarType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType RazorCommentStarType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer.RazorCommentTransitionType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType RazorCommentTransitionType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer.RazorCommentType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public override HtmlSymbolType RazorCommentType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer.StartState
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected override int StartState
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer.HtmlTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
            public HtmlTokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol
    
        
        .. code-block:: csharp
    
            protected override HtmlSymbol CreateSymbol(SourceLocation start, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.HtmlTokenizer.Dispatch()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected override Tokenizer<HtmlSymbol, HtmlSymbolType>.StateResult Dispatch()
    

