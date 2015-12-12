

IChunkMerger Interface
======================



.. contents:: 
   :local:



Summary
-------

Defines the contract for merging :any:`Microsoft.AspNet.Razor.Chunks.Chunk` instances from _ViewStart files.











Syntax
------

.. code-block:: csharp

   public interface IChunkMerger





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/IChunkMerger.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger.MergeInheritedChunks(Microsoft.AspNet.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.Chunk>)
    
        
    
        Merges an inherited :any:`Microsoft.AspNet.Razor.Chunks.Chunk` into the :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree`\.
    
        
        
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        
        
        :param inheritedChunks: The s to merge.
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger.VisitChunk(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
    
        Visits a :any:`Microsoft.AspNet.Razor.Chunks.Chunk` from the :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree` to merge into.
    
        
        
        
        :param chunk: A  from the tree.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           void VisitChunk(Chunk chunk)
    

