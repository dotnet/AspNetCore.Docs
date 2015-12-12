

UsingChunkMerger Class
======================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNet.Razor.Chunks.UsingChunk` instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.UsingChunkMerger`








Syntax
------

.. code-block:: csharp

   public class UsingChunkMerger : IChunkMerger





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/UsingChunkMerger.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.UsingChunkMerger

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.UsingChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.UsingChunkMerger.MergeInheritedChunks(Microsoft.AspNet.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.Chunk>)
    
        
        
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           public void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.UsingChunkMerger.VisitChunk(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public void VisitChunk(Chunk chunk)
    

