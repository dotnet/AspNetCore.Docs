

CSharpTagHelperAttributeValueVisitor Class
==========================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor\`1` that writes code for a non-<see langword="string" /> tag helper
bound attribute value.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpTagHelperAttributeValueVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpTagHelperAttributeValueVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.CSharpTagHelperAttributeValueVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext, System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor` class.
    
        
        
        
        :param writer: The  used to write code.
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :param context: A  instance that contains information about the current code generation
            process.
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        
        
        :param attributeTypeName: Full name of the property  for which this
            is writing the value.
        
        :type attributeTypeName: System.String
    
        
        .. code-block:: csharp
    
           public CSharpTagHelperAttributeValueVisitor(CSharpCodeWriter writer, CodeGeneratorContext context, string attributeTypeName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk)
    
        
    
        Writes code for the given ``chunk``.
    
        
        
        
        :param chunk: The  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionChunk)
    
        
    
        Writes code for the given ``chunk``.
    
        
        
        
        :param chunk: The  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNet.Razor.Chunks.LiteralChunk)
    
        
    
        Writes code for the given ``chunk``.
    
        
        
        
        :param chunk: The  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNet.Razor.Chunks.ParentChunk)
    
        
    
        Writes code for the given ``chunk``.
    
        
        
        
        :param chunk: The  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNet.Razor.Chunks.SectionChunk)
    
        
    
        Writes code for the given ``chunk``.
    
        
        
        
        :param chunk: The  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNet.Razor.Chunks.StatementChunk)
    
        
    
        Writes code for the given ``chunk``.
    
        
        
        
        :param chunk: The  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TemplateChunk)
    
        
    
        Writes code for the given ``chunk``.
    
        
        
        
        :param chunk: The  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TemplateChunk chunk)
    

