

CSharpCodeVisitor Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpCodeVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpCodeVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CSharpCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateCodeMapping(System.String, System.String, Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type padding: System.String
        
        
        :type code: System.String
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public void CreateCodeMapping(string padding, string code, Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateExpressionCodeMapping(System.String, Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type code: System.String
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public void CreateExpressionCodeMapping(string code, Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateRawCodeMapping(System.String, Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type code: System.String
        
        
        :type documentLocation: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public void CreateRawCodeMapping(string code, SourceLocation documentLocation)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.CreateStatementCodeMapping(System.String, Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type code: System.String
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public void CreateStatementCodeMapping(string code, Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.RenderDesignTimeExpressionBlockChunk(Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
           public void RenderDesignTimeExpressionBlockChunk(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.RenderPreWriteStart(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
           public static CSharpCodeWriter RenderPreWriteStart(CSharpCodeWriter writer, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.RenderRuntimeExpressionBlockChunk(Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
           public void RenderRuntimeExpressionBlockChunk(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(CodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.DynamicCodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.DynamicCodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(DynamicCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionBlockChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ExpressionBlockChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.ExpressionChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ExpressionChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ExpressionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.LiteralChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.LiteralChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(LiteralChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(LiteralCodeAttributeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.ParentChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(ParentChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.SectionChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SectionChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(SectionChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.StatementChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.StatementChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(StatementChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TemplateChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TemplateChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TemplateChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.TagHelperRenderer
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    
        
        .. code-block:: csharp
    
           public CSharpTagHelperCodeRenderer TagHelperRenderer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.WriteAttributeValueMethodName
    
        
    
        Gets the method name used to generate <c>WriteAttribute</c> invocations in the rendered page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string WriteAttributeValueMethodName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.WriteMethodName
    
        
    
        Method used to write an :any:`System.Object` to the current output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string WriteMethodName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor.WriteToMethodName
    
        
    
        Method used to write an :any:`System.Object` to a specified :any:`System.IO.TextWriter`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string WriteToMethodName { get; }
    

