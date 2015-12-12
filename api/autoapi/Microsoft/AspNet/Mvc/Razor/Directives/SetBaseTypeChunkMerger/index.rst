

SetBaseTypeChunkMerger Class
============================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk` instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger`








Syntax
------

.. code-block:: csharp

   public class SetBaseTypeChunkMerger : IChunkMerger





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/SetBaseTypeChunkMerger.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger.SetBaseTypeChunkMerger(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger`\.
    
        
        
        
        :param modelType: The type name of the model used by default.
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
           public SetBaseTypeChunkMerger(string modelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger.MergeInheritedChunks(Microsoft.AspNet.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.Chunk>)
    
        
        
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           public void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger.VisitChunk(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public void VisitChunk(Chunk chunk)
    

