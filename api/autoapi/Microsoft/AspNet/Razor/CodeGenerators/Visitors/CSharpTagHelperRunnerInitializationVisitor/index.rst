

CSharpTagHelperRunnerInitializationVisitor Class
================================================



.. contents:: 
   :local:



Summary
-------

The :any:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor\`1` that generates the code to initialize the TagHelperRunner.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpTagHelperRunnerInitializationVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpTagHelperRunnerInitializationVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor.CSharpTagHelperRunnerInitializationVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor`\.
    
        
        
        
        :param writer: The  used to generate code.
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpTagHelperRunnerInitializationVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor.Accept(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public override void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpTagHelperRunnerInitializationVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperChunk)
    
        
    
        Writes the TagHelperRunner initialization code to the Writer.
    
        
        
        
        :param chunk: The .
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TagHelperChunk chunk)
    

