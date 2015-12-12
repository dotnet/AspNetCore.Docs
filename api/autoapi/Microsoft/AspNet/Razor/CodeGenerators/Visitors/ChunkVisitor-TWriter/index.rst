

ChunkVisitor<TWriter> Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor\<TWriter>`








Syntax
------

.. code-block:: csharp

   public abstract class ChunkVisitor<TWriter> : IChunkVisitor where TWriter : CodeWriter





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/ChunkVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.ChunkVisitor(TWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: {TWriter}
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public ChunkVisitor(TWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Accept(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public virtual void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Accept(System.Collections.Generic.IList<Microsoft.AspNet.Razor.Chunks.Chunk>)
    
        
        
        
        :type chunks: System.Collections.Generic.IList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           public void Accept(IList<Chunk> chunks)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(AddTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(CodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.DynamicCodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.DynamicCodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(DynamicCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.LiteralChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(LiteralCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.ParentChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(RemoveTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.SectionChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(SetBaseTypeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.StatementChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(TagHelperPrefixDirectiveChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TemplateChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(TemplateChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TypeMemberChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TypeMemberChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(TypeMemberChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.UsingChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.UsingChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(UsingChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Context
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           protected CodeGeneratorContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Writer
    
        
        :rtype: {TWriter}
    
        
        .. code-block:: csharp
    
           protected TWriter Writer { get; }
    

