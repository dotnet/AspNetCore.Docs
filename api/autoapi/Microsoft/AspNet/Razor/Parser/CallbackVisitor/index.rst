

CallbackVisitor Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserVisitor`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.CallbackVisitor`








Syntax
------

.. code-block:: csharp

   public class CallbackVisitor : ParserVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/CallbackVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.CallbackVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.CallbackVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>)
    
        
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
    
        
        .. code-block:: csharp
    
           public CallbackVisitor(Action<Span> spanCallback)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
        
        
        :type errorCallback: System.Action{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public CallbackVisitor(Action<Span> spanCallback, Action<RazorError> errorCallback)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNet.Razor.RazorError>, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType>, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType>)
    
        
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
        
        
        :type errorCallback: System.Action{Microsoft.AspNet.Razor.RazorError}
        
        
        :type startBlockCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType}
        
        
        :type endBlockCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType}
    
        
        .. code-block:: csharp
    
           public CallbackVisitor(Action<Span> spanCallback, Action<RazorError> errorCallback, Action<BlockType> startBlockCallback, Action<BlockType> endBlockCallback)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNet.Razor.RazorError>, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType>, System.Action<Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType>, System.Action)
    
        
        
        
        :type spanCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.Span}
        
        
        :type errorCallback: System.Action{Microsoft.AspNet.Razor.RazorError}
        
        
        :type startBlockCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType}
        
        
        :type endBlockCallback: System.Action{Microsoft.AspNet.Razor.Parser.SyntaxTree.BlockType}
        
        
        :type completeCallback: System.Action
    
        
        .. code-block:: csharp
    
           public CallbackVisitor(Action<Span> spanCallback, Action<RazorError> errorCallback, Action<BlockType> startBlockCallback, Action<BlockType> endBlockCallback, Action completeCallback)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.CallbackVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.OnComplete()
    
        
    
        
        .. code-block:: csharp
    
           public override void OnComplete()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.VisitEndBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type block: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public override void VisitEndBlock(Block block)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.VisitError(Microsoft.AspNet.Razor.RazorError)
    
        
        
        
        :type err: Microsoft.AspNet.Razor.RazorError
    
        
        .. code-block:: csharp
    
           public override void VisitError(RazorError err)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.VisitSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public override void VisitSpan(Span span)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.VisitStartBlock(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block)
    
        
        
        
        :type block: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public override void VisitStartBlock(Block block)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.CallbackVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.CallbackVisitor.SynchronizationContext
    
        
        :rtype: System.Threading.SynchronizationContext
    
        
        .. code-block:: csharp
    
           public SynchronizationContext SynchronizationContext { get; set; }
    

