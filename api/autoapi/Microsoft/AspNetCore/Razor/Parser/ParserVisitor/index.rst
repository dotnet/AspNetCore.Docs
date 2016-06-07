

ParserVisitor Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserVisitor`








Syntax
------

.. code-block:: csharp

    public abstract class ParserVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.CancelToken
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
    
        
        .. code-block:: csharp
    
            public CancellationToken? CancelToken
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.OnComplete()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void OnComplete()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.ThrowIfCanceled()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void ThrowIfCanceled()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.VisitBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type block: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public virtual void VisitBlock(Block block)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.VisitEndBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type block: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public virtual void VisitEndBlock(Block block)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.VisitError(Microsoft.AspNetCore.Razor.RazorError)
    
        
    
        
        :type err: Microsoft.AspNetCore.Razor.RazorError
    
        
        .. code-block:: csharp
    
            public virtual void VisitError(RazorError err)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.VisitSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public virtual void VisitSpan(Span span)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserVisitor.VisitStartBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type block: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public virtual void VisitStartBlock(Block block)
    

