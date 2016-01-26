

HtmlTokenizer Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.StateMachine{Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol}`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Tokenizer{Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol,Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer`








Syntax
------

.. code-block:: csharp

   public class HtmlTokenizer : Tokenizer<HtmlSymbol, HtmlSymbolType>, ITokenizer





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Tokenizer/HtmlTokenizer.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer.HtmlTokenizer(Microsoft.AspNet.Razor.Text.ITextDocument)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
           public HtmlTokenizer(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer.CreateSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol
    
        
        .. code-block:: csharp
    
           protected override HtmlSymbol CreateSymbol(SourceLocation start, string content, HtmlSymbolType type, IEnumerable<RazorError> errors)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer.RazorCommentStarType
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           public override HtmlSymbolType RazorCommentStarType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer.RazorCommentTransitionType
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           public override HtmlSymbolType RazorCommentTransitionType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer.RazorCommentType
    
        
        :rtype: Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
           public override HtmlSymbolType RazorCommentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.HtmlTokenizer.StartState
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine{Microsoft.AspNet.Razor.Tokenizer.Symbols.HtmlSymbol}.State
    
        
        .. code-block:: csharp
    
           protected override StateMachine<HtmlSymbol>.State StartState { get; }
    

