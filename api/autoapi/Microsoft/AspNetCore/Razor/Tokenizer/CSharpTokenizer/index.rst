

CSharpTokenizer Class
=====================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer`








Syntax
------

.. code-block:: csharp

    public class CSharpTokenizer : Tokenizer<CSharpSymbol, CSharpSymbolType>, ITokenizer








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer.RazorCommentStarType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType RazorCommentStarType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer.RazorCommentTransitionType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType RazorCommentTransitionType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer.RazorCommentType
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public override CSharpSymbolType RazorCommentType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer.StartState
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected override int StartState
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer.CSharpTokenizer(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
            public CSharpTokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer.CreateSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
            protected override CSharpSymbol CreateSymbol(SourceLocation start, string content, CSharpSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer.Dispatch()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer.StateResult<Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult>{}
    
        
        .. code-block:: csharp
    
            protected override Tokenizer<CSharpSymbol, CSharpSymbolType>.StateResult Dispatch()
    

