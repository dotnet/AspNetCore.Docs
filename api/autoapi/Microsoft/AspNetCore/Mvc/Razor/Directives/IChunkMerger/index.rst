

IChunkMerger Interface
======================






Defines the contract for merging :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` instances from _ViewStart files.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Directives`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IChunkMerger








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger.MergeInheritedChunks(Microsoft.AspNetCore.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.Chunk>)
    
        
    
        
        Merges an inherited :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` into the :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree`\.
    
        
    
        
        :param chunkTree: The :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` to merge into.
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        :param inheritedChunks: The :any:`System.Collections.Generic.IReadOnlyList\`1`\s to merge.
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger.VisitChunk(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        Visits a :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` from the :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` to merge into.
    
        
    
        
        :param chunk: A :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` from the tree.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            void VisitChunk(Chunk chunk)
    

