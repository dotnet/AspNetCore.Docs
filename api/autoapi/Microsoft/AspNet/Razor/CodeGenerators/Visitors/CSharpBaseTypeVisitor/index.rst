

CSharpBaseTypeVisitor Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpBaseTypeVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpBaseTypeVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor.CSharpBaseTypeVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpBaseTypeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(SetBaseTypeChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor.CurrentBaseType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CurrentBaseType { get; set; }
    

