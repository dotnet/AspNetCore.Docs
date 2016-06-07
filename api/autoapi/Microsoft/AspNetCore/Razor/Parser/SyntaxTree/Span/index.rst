

Span Class
==========





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span`








Syntax
------

.. code-block:: csharp

    public class Span : SyntaxTreeNode








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.ChunkGenerator
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.ISpanChunkGenerator
    
        
        .. code-block:: csharp
    
            public ISpanChunkGenerator ChunkGenerator
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Content
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Content
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.EditHandler
    
        
        :rtype: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    
        
        .. code-block:: csharp
    
            public SpanEditHandler EditHandler
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.IsBlock
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsBlock
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Kind
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanKind
    
        
        .. code-block:: csharp
    
            public SpanKind Kind
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Next
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public Span Next
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Previous
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public Span Previous
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Start
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public override SourceLocation Start
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Symbols
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ISymbol> Symbols
            {
                get;
                protected set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Span(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
    
        
        :type builder: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
            public Span(SpanBuilder builder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Accept(Microsoft.AspNetCore.Razor.Parser.ParserVisitor)
    
        
    
        
        Accepts the specified visitor
    
        
    
        
        :type visitor: Microsoft.AspNetCore.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
            public override void Accept(ParserVisitor visitor)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Change(System.Action<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder>)
    
        
    
        
        :type changes: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder<Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder>}
    
        
        .. code-block:: csharp
    
            public void Change(Action<SpanBuilder> changes)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.ChangeStart(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type newStart: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public void ChangeStart(SourceLocation newStart)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.EquivalentTo(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        Checks that the specified span is equivalent to the other in that it has the same start point and content.
    
        
    
        
        :type node: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool EquivalentTo(SyntaxTreeNode node)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.GetEquivalenceHash()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetEquivalenceHash()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.ReplaceWith(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
    
        
        :type builder: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
            public void ReplaceWith(SpanBuilder builder)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

