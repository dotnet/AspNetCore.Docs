

SpanBuilder Class
=================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder`








Syntax
------

.. code-block:: csharp

    public class SpanBuilder








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.ChunkGenerator
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.ISpanChunkGenerator
    
        
        .. code-block:: csharp
    
            public ISpanChunkGenerator ChunkGenerator
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.EditHandler
    
        
        :rtype: Microsoft.AspNetCore.Razor.Editor.SpanEditHandler
    
        
        .. code-block:: csharp
    
            public SpanEditHandler EditHandler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.Kind
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanKind
    
        
        .. code-block:: csharp
    
            public SpanKind Kind
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.Start
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Start
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.Symbols
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ISymbol> Symbols
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.SpanBuilder()
    
        
    
        
        .. code-block:: csharp
    
            public SpanBuilder()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.SpanBuilder(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type original: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public SpanBuilder(Span original)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.Accept(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol)
    
        
    
        
        :type symbol: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol
    
        
        .. code-block:: csharp
    
            public void Accept(ISymbol symbol)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.Build()
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
            public Span Build()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.ClearSymbols()
    
        
    
        
        .. code-block:: csharp
    
            public void ClearSymbols()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

