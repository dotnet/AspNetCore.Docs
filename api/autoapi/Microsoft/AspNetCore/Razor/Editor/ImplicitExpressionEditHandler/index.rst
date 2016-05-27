

ImplicitExpressionEditHandler Class
===================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Editor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Editor.SpanEditHandler`
* :dn:cls:`Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler`








Syntax
------

.. code-block:: csharp

    public class ImplicitExpressionEditHandler : SpanEditHandler








.. dn:class:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler.AcceptTrailingDot
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AcceptTrailingDot
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler.Keywords
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.IReadOnlyCollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyCollection<string> Keywords
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler.ImplicitExpressionEditHandler(System.Func<System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>>, System.Collections.Generic.ISet<System.String>, System.Boolean)
    
        
    
        
        :type tokenizer: System.Func<System.Func`2>{System.String<System.String>, System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}}
    
        
        :type keywords: System.Collections.Generic.ISet<System.Collections.Generic.ISet`1>{System.String<System.String>}
    
        
        :type acceptTrailingDot: System.Boolean
    
        
        .. code-block:: csharp
    
            public ImplicitExpressionEditHandler(Func<string, IEnumerable<ISymbol>> tokenizer, ISet<string> keywords, bool acceptTrailingDot)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler.CanAcceptChange(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type normalizedChange: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            protected override PartialParseResult CanAcceptChange(Span target, TextChange normalizedChange)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Editor.ImplicitExpressionEditHandler.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

