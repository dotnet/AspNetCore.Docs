

CodeVisitor<TWriter> Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{{TWriter}}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor\<TWriter>`








Syntax
------

.. code-block:: csharp

   public class CodeVisitor<TWriter> : ChunkVisitor<TWriter>, IChunkVisitor where TWriter : CodeWriter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CodeVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.CodeVisitor(TWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: {TWriter}
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CodeVisitor(TWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(AddTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(CodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.DynamicCodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.DynamicCodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(DynamicCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.LiteralChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(LiteralCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.ParentChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(RemoveTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.SectionChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(SetBaseTypeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.StatementChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TagHelperPrefixDirectiveChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TemplateChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TemplateChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.TypeMemberChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TypeMemberChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TypeMemberChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor<TWriter>.Visit(Microsoft.AspNet.Razor.Chunks.UsingChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.UsingChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(UsingChunk chunk)
    

