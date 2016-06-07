

CSharpTagHelperPropertyInitializationVisitor Class
==================================================






The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CodeVisitor\`1` that generates the code to initialize the TagHelperRunner.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor`








Syntax
------

.. code-block:: csharp

    public class CSharpTagHelperPropertyInitializationVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor.CSharpTagHelperPropertyInitializationVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor`\.
    
        
    
        
        :param writer: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter` used to generate code.
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :param context: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext`\.
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CSharpTagHelperPropertyInitializationVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor.Accept(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpTagHelperPropertyInitializationVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk)
    
        
    
        
        Writes the TagHelperRunner initialization code to the Writer.
    
        
    
        
        :param chunk: The :any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk`\.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TagHelperChunk chunk)
    

