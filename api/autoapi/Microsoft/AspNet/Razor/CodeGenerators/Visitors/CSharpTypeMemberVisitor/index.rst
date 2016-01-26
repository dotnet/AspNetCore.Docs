

CSharpTypeMemberVisitor Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpTypeMemberVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpTypeMemberVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor.CSharpTypeMemberVisitor(Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type csharpCodeVisitor: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpTypeMemberVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTypeMemberVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TypeMemberChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TypeMemberChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TypeMemberChunk chunk)
    

