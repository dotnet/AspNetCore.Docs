

InjectChunkVisitor Class
========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor`








Syntax
------

.. code-block:: csharp

    public class InjectChunkVisitor : MvcCSharpCodeVisitor, IChunkVisitor








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor.InjectChunks
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Razor.InjectChunk<Microsoft.AspNetCore.Mvc.Razor.InjectChunk>}
    
        
        .. code-block:: csharp
    
            public IList<InjectChunk> InjectChunks
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor.InjectChunkVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext, System.String)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        :type injectAttributeName: System.String
    
        
        .. code-block:: csharp
    
            public InjectChunkVisitor(CSharpCodeWriter writer, CodeGeneratorContext context, string injectAttributeName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor.Visit(Microsoft.AspNetCore.Mvc.Razor.InjectChunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Mvc.Razor.InjectChunk
    
        
        .. code-block:: csharp
    
            protected override void Visit(InjectChunk chunk)
    

