

CSharpUsingVisitor Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpUsingVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpUsingVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor.CSharpUsingVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpUsingVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor.Accept(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor.Visit(Microsoft.AspNet.Razor.Chunks.UsingChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.UsingChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(UsingChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpUsingVisitor.ImportedUsings
    
        
        :rtype: System.Collections.Generic.HashSet{System.String}
    
        
        .. code-block:: csharp
    
           public HashSet<string> ImportedUsings { get; set; }
    

