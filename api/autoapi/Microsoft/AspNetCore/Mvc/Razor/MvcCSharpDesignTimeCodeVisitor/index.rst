

MvcCSharpDesignTimeCodeVisitor Class
====================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor`








Syntax
------

.. code-block:: csharp

    public class MvcCSharpDesignTimeCodeVisitor : CSharpDesignTimeCodeVisitor, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor.MvcCSharpDesignTimeCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type csharpCodeVisitor: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public MvcCSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor.Accept(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor.AcceptTreeCore(Microsoft.AspNetCore.Razor.Chunks.ChunkTree)
    
        
    
        
        :type tree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            protected override void AcceptTreeCore(ChunkTree tree)
    

