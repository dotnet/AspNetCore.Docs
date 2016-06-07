

UsingChunkMerger Class
======================






A :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNetCore.Razor.Chunks.UsingChunk` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Directives`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Directives.UsingChunkMerger`








Syntax
------

.. code-block:: csharp

    public class UsingChunkMerger : IChunkMerger








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.UsingChunkMerger
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.UsingChunkMerger

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.UsingChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.UsingChunkMerger.MergeInheritedChunks(Microsoft.AspNetCore.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.Chunk>)
    
        
    
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            public void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.UsingChunkMerger.VisitChunk(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public void VisitChunk(Chunk chunk)
    

