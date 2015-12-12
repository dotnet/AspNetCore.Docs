

InjectChunkMerger Class
=======================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNet.Mvc.Razor.InjectChunk` instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger`








Syntax
------

.. code-block:: csharp

   public class InjectChunkMerger : IChunkMerger





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/InjectChunkMerger.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger.InjectChunkMerger(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger`\.
    
        
        
        
        :param modelType: The model type to be used to replace <TModel> tokens.
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
           public InjectChunkMerger(string modelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger.MergeInheritedChunks(Microsoft.AspNet.Razor.Chunks.ChunkTree, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Razor.Chunks.Chunk>)
    
        
        
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        
        
        :type inheritedChunks: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           public void MergeInheritedChunks(ChunkTree chunkTree, IReadOnlyList<Chunk> inheritedChunks)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger.VisitChunk(Microsoft.AspNet.Razor.Chunks.Chunk)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
    
        
        .. code-block:: csharp
    
           public void VisitChunk(Chunk chunk)
    

