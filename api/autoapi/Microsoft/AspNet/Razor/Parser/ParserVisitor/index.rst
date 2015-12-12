

ParserVisitor Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserVisitor`








Syntax
------

.. code-block:: csharp

   public abstract class ParserVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Parser/ParserVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserVisitor

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserVisitor.OnComplete()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void OnComplete()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserVisitor.ThrowIfCanceled()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void ThrowIfCanceled()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserVisitor.VisitBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type block: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public virtual void VisitBlock(Block block)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserVisitor.VisitEndBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type block: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public virtual void VisitEndBlock(Block block)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserVisitor.VisitError(Microsoft.AspNet.Razor.RazorError)
    
        
        
        
        :type err: Microsoft.AspNet.Razor.RazorError
    
        
        .. code-block:: csharp
    
           public virtual void VisitError(RazorError err)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserVisitor.VisitSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public virtual void VisitSpan(Span span)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserVisitor.VisitStartBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type block: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public virtual void VisitStartBlock(Block block)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserVisitor.CancelToken
    
        
        :rtype: System.Nullable{System.Threading.CancellationToken}
    
        
        .. code-block:: csharp
    
           public CancellationToken? CancelToken { get; set; }
    

