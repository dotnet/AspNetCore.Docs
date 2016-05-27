

SetBaseTypeChunkMerger Class
============================






A :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk` instances.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger`








Syntax
------

.. code-block:: csharp

    public class SetBaseTypeChunkMerger : IChunkMerger








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger.SetBaseTypeChunkMerger(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger`\.
    
        
    
        
        :param modelType: The type name of the model used by default.
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
            public SetBaseTypeChunkMerger(string modelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger.MergeInheritedChunks(Microsoft.AspNetCore.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.Chunks.Chunk>)
    
        
    
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            public void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger.VisitChunk(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
            public void VisitChunk(Chunk chunk)
    

