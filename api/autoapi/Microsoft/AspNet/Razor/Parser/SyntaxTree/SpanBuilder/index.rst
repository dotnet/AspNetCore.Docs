

SpanBuilder Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder`








Syntax
------

.. code-block:: csharp

   public class SpanBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/SyntaxTree/SpanBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.SpanBuilder()
    
        
    
        
        .. code-block:: csharp
    
           public SpanBuilder()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.SpanBuilder(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type original: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public SpanBuilder(Span original)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.Accept(Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol)
    
        
        
        
        :type symbol: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol
    
        
        .. code-block:: csharp
    
           public void Accept(ISymbol symbol)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.Build()
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
    
        
        .. code-block:: csharp
    
           public Span Build()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.ClearSymbols()
    
        
    
        
        .. code-block:: csharp
    
           public void ClearSymbols()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.ChunkGenerator
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.Generators.ISpanChunkGenerator
    
        
        .. code-block:: csharp
    
           public ISpanChunkGenerator ChunkGenerator { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.EditHandler
    
        
        :rtype: Microsoft.AspNet.Razor.Editor.SpanEditHandler
    
        
        .. code-block:: csharp
    
           public SpanEditHandler EditHandler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.Kind
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanKind
    
        
        .. code-block:: csharp
    
           public SpanKind Kind { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.Start
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Start { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder.Symbols
    
        
        :rtype: System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol}
    
        
        .. code-block:: csharp
    
           public ReadOnlyCollection<ISymbol> Symbols { get; }
    

