

IChunkVisitor Interface
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IChunkVisitor








.. dn:interface:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor.Accept(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor.Accept(System.Collections.Generic.IList<Microsoft.AspNetCore.Razor.Chunks.Chunk>)
    
        
    
        
        :type chunks: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            void Accept(IList<Chunk> chunks)
    

