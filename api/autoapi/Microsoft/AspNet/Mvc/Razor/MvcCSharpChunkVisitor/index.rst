

MvcCSharpChunkVisitor Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor`








Syntax
------

.. code-block:: csharp

   public abstract class MvcCSharpChunkVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/MvcCSharpChunkVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor.MvcCSharpChunkVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public MvcCSharpChunkVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor.Accept(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor.Visit(Microsoft.AspNet.Mvc.Razor.InjectChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Mvc.Razor.InjectChunk
    
        
        .. code-block:: csharp
    
           protected abstract void Visit(InjectChunk chunk)
    

