

MvcCSharpChunkVisitor Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor`








Syntax
------

.. code-block:: csharp

    public abstract class MvcCSharpChunkVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor.MvcCSharpChunkVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public MvcCSharpChunkVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor.Accept(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor.Visit(Microsoft.AspNetCore.Mvc.Razor.InjectChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Mvc.Razor.InjectChunk
    
        
        .. code-block:: csharp
    
            protected abstract void Visit(InjectChunk chunk)
    

