

InjectChunkVisitor Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.ChunkVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.Visitors.CodeVisitor{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcCSharpChunkVisitor`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeVisitor`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor`








Syntax
------

.. code-block:: csharp

   public class InjectChunkVisitor : MvcCSharpCodeVisitor, IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/InjectChunkVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor.InjectChunkVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext, System.String)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        
        
        :type injectAttributeName: System.String
    
        
        .. code-block:: csharp
    
           public InjectChunkVisitor(CSharpCodeWriter writer, CodeGeneratorContext context, string injectAttributeName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor.Visit(Microsoft.AspNet.Mvc.Razor.InjectChunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Mvc.Razor.InjectChunk
    
        
        .. code-block:: csharp
    
           protected override void Visit(InjectChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.InjectChunkVisitor.InjectChunks
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Razor.InjectChunk}
    
        
        .. code-block:: csharp
    
           public IList<InjectChunk> InjectChunks { get; }
    

