

MvcCSharpCodeVisitor Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor`








Syntax
------

.. code-block:: csharp

    public abstract class MvcCSharpCodeVisitor : MvcCSharpChunkVisitor, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor.MvcCSharpCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public MvcCSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor.Visit(Microsoft.AspNetCore.Mvc.Razor.InjectChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Mvc.Razor.InjectChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(InjectChunk chunk)
    

