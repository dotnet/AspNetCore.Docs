

CSharpTagHelperAttributeValueVisitor Class
==========================================






:any:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor\`1` that writes code for a non-<xref uid="langword_csharp_string" name="string" href=""></xref> tag helper
bound attribute value.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor`








Syntax
------

.. code-block:: csharp

    public class CSharpTagHelperAttributeValueVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.CSharpTagHelperAttributeValueVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext, System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor` class.
    
        
    
        
        :param writer: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter` used to write code.
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :param context: 
            A :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext` instance that contains information about the current code generation
            process.
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        :param attributeTypeName: 
            Full name of the property :any:`System.Type` for which this 
            :any:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor` is writing the value.
        
        :type attributeTypeName: System.String
    
        
        .. code-block:: csharp
    
            public CSharpTagHelperAttributeValueVisitor(CSharpCodeWriter writer, CodeGeneratorContext context, string attributeTypeName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk)
    
        
    
        
        Writes code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk)
    
        
    
        
        Writes code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.LiteralChunk)
    
        
    
        
        Writes code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.LiteralChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentChunk)
    
        
    
        
        Writes code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.ParentChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ParentLiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.SectionChunk)
    
        
    
        
        Writes code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.SectionChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.StatementChunk)
    
        
    
        
        Writes code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.StatementChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperAttributeValueVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.TemplateChunk)
    
        
    
        
        Writes code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.TemplateChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TemplateChunk chunk)
    

