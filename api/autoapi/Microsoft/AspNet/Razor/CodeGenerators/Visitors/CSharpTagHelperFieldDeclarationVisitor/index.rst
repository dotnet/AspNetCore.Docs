

CSharpTagHelperFieldDeclarationVisitor Class
============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperFieldDeclarationVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpTagHelperFieldDeclarationVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpTagHelperFieldDeclarationVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperFieldDeclarationVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperFieldDeclarationVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperFieldDeclarationVisitor.CSharpTagHelperFieldDeclarationVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpTagHelperFieldDeclarationVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperFieldDeclarationVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperFieldDeclarationVisitor.Accept(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperFieldDeclarationVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TagHelperChunk chunk)
    

