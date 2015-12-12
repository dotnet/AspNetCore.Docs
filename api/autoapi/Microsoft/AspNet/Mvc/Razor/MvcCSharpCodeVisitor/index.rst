

MvcCSharpCodeVisitor Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeVisitor`








Syntax
------

.. code-block:: csharp

   public abstract class MvcCSharpCodeVisitor : MvcCSharpChunkVisitor, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/MvcCSharpCodeVistor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeVisitor.MvcCSharpCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public MvcCSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeVisitor.Visit(Microsoft.AspNet.Mvc.Razor.InjectChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Mvc.Razor.InjectChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(InjectChunk chunk)
    

