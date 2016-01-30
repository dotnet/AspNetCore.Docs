

MvcCSharpDesignTimeCodeVisitor Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor`








Syntax
------

.. code-block:: csharp

   public class MvcCSharpDesignTimeCodeVisitor : CSharpDesignTimeCodeVisitor, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/MvcCSharpDesignTimeCodeVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor.MvcCSharpDesignTimeCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type csharpCodeVisitor: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public MvcCSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor.Accept(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor.AcceptTreeCore(Microsoft.AspNet.Razor.Chunks.ChunkTree)
    
        
        
        
        :type tree: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           protected override void AcceptTreeCore(ChunkTree tree)
    

