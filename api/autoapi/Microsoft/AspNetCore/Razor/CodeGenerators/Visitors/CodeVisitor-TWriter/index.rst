

CodeVisitor<TWriter> Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor{{TWriter}}`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor\<TWriter>`








Syntax
------

.. code-block:: csharp

    public class CodeVisitor<TWriter> : ChunkVisitor<TWriter>, IChunkVisitor where TWriter : CodeWriter








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.CodeVisitor(TWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: TWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CodeVisitor(TWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(AddTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(CodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.DynamicCodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.DynamicCodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(DynamicCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.LiteralChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(LiteralCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ParentLiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(RemoveTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.SectionChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(SetBaseTypeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.StatementChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TagHelperPrefixDirectiveChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TemplateChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TemplateChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.TypeMemberChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TypeMemberChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TypeMemberChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNetCore.Razor.Chunks.UsingChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.UsingChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(UsingChunk chunk)
    

