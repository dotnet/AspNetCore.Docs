

CSharpTokenizer Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.StateMachine{Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol}`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Tokenizer{Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer`








Syntax
------

.. code-block:: csharp

   public class CSharpTokenizer : Tokenizer<CSharpSymbol, CSharpSymbolType>, ITokenizer





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Tokenizer/CSharpTokenizer.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer.CSharpTokenizer(Microsoft.AspNet.Razor.Text.ITextDocument)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
           public CSharpTokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer.CreateSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
           protected override CSharpSymbol CreateSymbol(SourceLocation start, string content, CSharpSymbolType type, IEnumerable<RazorError> errors)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer.RazorCommentStarType
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
           public override CSharpSymbolType RazorCommentStarType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer.RazorCommentTransitionType
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
           public override CSharpSymbolType RazorCommentTransitionType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer.RazorCommentType
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
           public override CSharpSymbolType RazorCommentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer.StartState
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine{Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol}.State
    
        
        .. code-block:: csharp
    
           protected override StateMachine<CSharpSymbol>.State StartState { get; }
    

