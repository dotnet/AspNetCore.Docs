

ImplicitExpressionEditHandler Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Editor.SpanEditHandler`
* :dn:cls:`Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler`








Syntax
------

.. code-block:: csharp

   public class ImplicitExpressionEditHandler : SpanEditHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Editor/ImplicitExpressionEditHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler.ImplicitExpressionEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol>>, System.Collections.Generic.ISet<System.String>, System.Boolean)
    
        
        
        
        :type tokenizer: System.Func{System.String,System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}}
        
        
        :type keywords: System.Collections.Generic.ISet{System.String}
        
        
        :type acceptTrailingDot: System.Boolean
    
        
        .. code-block:: csharp
    
           public ImplicitExpressionEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, ISet<string> keywords, bool acceptTrailingDot)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler.CanAcceptChange(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Text.TextChange)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type normalizedChange: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: Microsoft.AspNet.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
           protected override PartialParseResult CanAcceptChange(Span target, TextChange normalizedChange)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler.AcceptTrailingDot
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AcceptTrailingDot { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Editor.ImplicitExpressionEditHandler.Keywords
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection{System.String}
    
        
        .. code-block:: csharp
    
           public IReadOnlyCollection<string> Keywords { get; }
    

