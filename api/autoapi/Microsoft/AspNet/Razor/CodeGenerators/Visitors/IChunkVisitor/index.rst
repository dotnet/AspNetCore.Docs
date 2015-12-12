

IChunkVisitor Interface
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IChunkVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/Visitors/IChunkVisitor.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.IChunkVisitor

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.IChunkVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.IChunkVisitor.Accept(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           void Accept(Chunk chunk)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.Visitors.IChunkVisitor.Accept(System.Collections.Generic.IList<Microsoft.AspNet.Razor.Chunks.Chunk>)
    
        
        
        
        :type chunks: System.Collections.Generic.IList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           void Accept(IList<Chunk> chunks)
    

