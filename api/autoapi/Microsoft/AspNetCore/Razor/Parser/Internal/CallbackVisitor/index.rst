

CallbackVisitor Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.Internal`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserVisitor`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor`








Syntax
------

.. code-block:: csharp

    public class CallbackVisitor : ParserVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>)
    
        
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        .. code-block:: csharp
    
            public CallbackVisitor(Action<Span> spanCallback)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        :type errorCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public CallbackVisitor(Action<Span> spanCallback, Action<RazorError> errorCallback)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNetCore.Razor.RazorError>, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>)
    
        
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        :type errorCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        :type startBlockCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>}
    
        
        :type endBlockCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>}
    
        
        .. code-block:: csharp
    
            public CallbackVisitor(Action<Span> spanCallback, Action<RazorError> errorCallback, Action<BlockType> startBlockCallback, Action<BlockType> endBlockCallback)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.CallbackVisitor(System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>, System.Action<Microsoft.AspNetCore.Razor.RazorError>, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>, System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>, System.Action)
    
        
    
        
        :type spanCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span>}
    
        
        :type errorCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        :type startBlockCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>}
    
        
        :type endBlockCallback: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.BlockType>}
    
        
        :type completeCallback: System.Action
    
        
        .. code-block:: csharp
    
            public CallbackVisitor(Action<Span> spanCallback, Action<RazorError> errorCallback, Action<BlockType> startBlockCallback, Action<BlockType> endBlockCallback, Action completeCallback)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.OnComplete()
    
        
    
        
        .. code-block:: csharp
    
            public override void OnComplete()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.VisitEndBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type block: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public override void VisitEndBlock(Block block)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.VisitError(Microsoft.AspNetCore.Razor.RazorError)
    
        
    
        
        :type err: Microsoft.AspNetCore.Razor.RazorError
    
        
        .. code-block:: csharp
    
            public override void VisitError(RazorError err)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.VisitSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public override void VisitSpan(Span span)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.VisitStartBlock(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block)
    
        
    
        
        :type block: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public override void VisitStartBlock(Block block)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.Internal.CallbackVisitor.SynchronizationContext
    
        
        :rtype: System.Threading.SynchronizationContext
    
        
        .. code-block:: csharp
    
            public SynchronizationContext SynchronizationContext { get; set; }
    

