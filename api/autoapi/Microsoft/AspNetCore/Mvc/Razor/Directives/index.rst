

Microsoft.AspNetCore.Mvc.Razor.Directives Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/ChunkHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/ChunkInheritanceUtility/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/ChunkTreeResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/DefaultChunkTreeCache/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/IChunkMerger/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/IChunkTreeCache/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/InjectChunkMerger/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/SetBaseTypeChunkMerger/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Directives/UsingChunkMerger/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Razor.Directives


    .. rubric:: Classes


    class :dn:cls:`ChunkHelper`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper

        
        Contains helper methods for dealing with Chunks


    class :dn:cls:`ChunkInheritanceUtility`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility

        
        A utility type for supporting inheritance of directives into a page from applicable <code>_ViewImports</code> pages.


    class :dn:cls:`ChunkTreeResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult

        
        Contains :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` information.


    class :dn:cls:`DefaultChunkTreeCache`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Directives.DefaultChunkTreeCache

        
        Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache`\.


    class :dn:cls:`InjectChunkMerger`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Directives.InjectChunkMerger

        
        A :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNetCore.Mvc.Razor.InjectChunk` instances.


    class :dn:cls:`SetBaseTypeChunkMerger`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Directives.SetBaseTypeChunkMerger

        
        A :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNetCore.Razor.Chunks.SetBaseTypeChunk` instances.


    class :dn:cls:`UsingChunkMerger`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Directives.UsingChunkMerger

        
        A :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNetCore.Razor.Chunks.UsingChunk` instances.


    .. rubric:: Interfaces


    interface :dn:iface:`IChunkMerger`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkMerger

        
        Defines the contract for merging :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` instances from _ViewStart files.


    interface :dn:iface:`IChunkTreeCache`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache

        
        A cache for parsed :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree`\s.


