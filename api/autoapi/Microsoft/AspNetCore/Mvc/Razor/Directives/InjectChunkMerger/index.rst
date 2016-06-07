

InjectChunkMerger Class
=======================






A :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNetCore.Mvc.Razor.InjectChunk` instances.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger`








Syntax
------

.. code-block:: csharp

    public class InjectChunkMerger : IChunkMerger








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger.InjectChunkMerger(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger`\.
    
        
    
        
        :param modelType: The model type to be used to replace <TModel> tokens.
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
            public InjectChunkMerger(string modelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger.MergeInheritedChunks(Microsoft.AspNetCore.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.Chunk>)
    
        
    
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            public void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger.VisitChunk(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public void VisitChunk(Chunk chunk)
    

