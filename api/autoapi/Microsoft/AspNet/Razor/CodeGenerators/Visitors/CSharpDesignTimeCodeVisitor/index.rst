

CSharpDesignTimeCodeVisitor Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor`








Syntax
------

.. code-block:: csharp

   public class CSharpDesignTimeCodeVisitor : CodeVisitor<CSharpCodeWriter>, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/CSharpDesignTimeCodeVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.CSharpDesignTimeCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type csharpCodeVisitor: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.AcceptTree(Microsoft.AspNet.Razor.Chunks.ChunkTree)
    
        
        
        
        :type tree: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           public void AcceptTree(ChunkTree tree)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.AcceptTreeCore(Microsoft.AspNet.Razor.Chunks.ChunkTree)
    
        
        
        
        :type tree: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           protected virtual void AcceptTreeCore(ChunkTree tree)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(AddTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(RemoveTagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(SetBaseTypeChunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.Visit(Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(TagHelperPrefixDirectiveChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor.CSharpCodeVisitor
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        .. code-block:: csharp
    
           public CSharpCodeVisitor CSharpCodeVisitor { get; }
    

