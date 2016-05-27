

CSharpBaseTypeVisitor Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor`








Syntax
------

.. code-block:: csharp

    public class CSharpBaseTypeVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor.CurrentBaseType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CurrentBaseType
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor.CSharpBaseTypeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CSharpBaseTypeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpBaseTypeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(SetBaseTypeChunk chunk)
    

