

CSharpDesignTimeCodeVisitor Class
=================================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor`








Syntax
------

.. code-block:: csharp

    public class CSharpDesignTimeCodeVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.CSharpCodeVisitor
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        .. code-block:: csharp
    
            public CSharpCodeVisitor CSharpCodeVisitor
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.CSharpDesignTimeCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type csharpCodeVisitor: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.AcceptTree(Microsoft.AspNetCore.Razor.Chunks.ChunkTree)
    
        
    
        
        :type tree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            public void AcceptTree(ChunkTree tree)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.AcceptTreeCore(Microsoft.AspNetCore.Razor.Chunks.ChunkTree)
    
        
    
        
        :type tree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            protected virtual void AcceptTreeCore(ChunkTree tree)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.AddTagHelperChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(AddTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(RemoveTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(SetBaseTypeChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(TagHelperPrefixDirectiveChunk chunk)
    

