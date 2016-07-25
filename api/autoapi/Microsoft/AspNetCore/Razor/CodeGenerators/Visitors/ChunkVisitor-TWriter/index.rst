

ChunkVisitor<TWriter> Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor\<TWriter>`








Syntax
------

.. code-block:: csharp

    public abstract class ChunkVisitor<TWriter> : IChunkVisitor where TWriter : CodeWriter








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.ChunkVisitor(TWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: TWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public ChunkVisitor(TWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Accept(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public virtual void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Accept(System.Collections.Generic.IList<Microsoft.AspNetCore.Razor.Chunks.Chunk>)
    
        
    
        
        :type chunks: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            public void Accept(IList<Chunk> chunks)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(AddTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(CodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.DynamicCodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.DynamicCodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(DynamicCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.LiteralChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(LiteralCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(ParentLiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(RemoveTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.SectionChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(SetBaseTypeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.StatementChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(TagHelperPrefixDirectiveChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TemplateChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(TemplateChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TypeMemberChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TypeMemberChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(TypeMemberChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.UsingChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.UsingChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(UsingChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Context
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            protected CodeGeneratorContext Context { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor<TWriter>.Writer
    
        
        :rtype: TWriter
    
        
        .. code-block:: csharp
    
            protected TWriter Writer { get; }
    

