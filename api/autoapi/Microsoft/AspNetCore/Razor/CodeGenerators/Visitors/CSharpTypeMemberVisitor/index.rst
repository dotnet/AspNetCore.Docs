

CSharpTypeMemberVisitor Class
=============================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor`








Syntax
------

.. code-block:: csharp

    public class CSharpTypeMemberVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor.CSharpTypeMemberVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type csharpCodeVisitor: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CSharpTypeMemberVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.TypeMemberChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TypeMemberChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TypeMemberChunk chunk)
    

