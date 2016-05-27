

CSharpCodeVisitor Class
=======================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor`








Syntax
------

.. code-block:: csharp

    public class CSharpCodeVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.TagHelperRenderer
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    
        
        .. code-block:: csharp
    
            public CSharpTagHelperCodeRenderer TagHelperRenderer
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.WriteAttributeValueMethodName
    
        
    
        
        Gets the method name used to generate <code>WriteAttribute</code> invocations in the rendered page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected virtual string WriteAttributeValueMethodName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.WriteMethodName
    
        
    
        
        Method used to write an :any:`System.Object` to the current output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected virtual string WriteMethodName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.WriteToMethodName
    
        
    
        
        Method used to write an :any:`System.Object` to a specified :any:`System.IO.TextWriter`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected virtual string WriteToMethodName
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CSharpCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateCodeMapping(System.String, System.String, Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type padding: System.String
    
        
        :type code: System.String
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public void CreateCodeMapping(string padding, string code, Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateExpressionCodeMapping(System.String, Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type code: System.String
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public void CreateExpressionCodeMapping(string code, Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateRawCodeMapping(System.String, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type code: System.String
    
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public void CreateRawCodeMapping(string code, SourceLocation documentLocation)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateStatementCodeMapping(System.String, Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type code: System.String
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public void CreateStatementCodeMapping(string code, Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.RenderDesignTimeExpressionBlockChunk(Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
            public void RenderDesignTimeExpressionBlockChunk(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.RenderRuntimeExpressionBlockChunk(Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
            public void RenderRuntimeExpressionBlockChunk(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(CodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.DynamicCodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.DynamicCodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(DynamicCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.LiteralChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(LiteralCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.ParentLiteralChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(ParentLiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.SectionChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.StatementChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.TemplateChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TemplateChunk chunk)
    

