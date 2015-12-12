

Microsoft.AspNet.Mvc.Razor.Directives Namespace
===============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/ChunkHelper/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/ChunkInheritanceUtility/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/ChunkTreeResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/DefaultChunkTreeCache/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/IChunkMerger/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/IChunkTreeCache/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/InjectChunkMerger/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/SetBaseTypeChunkMerger/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Directives/UsingChunkMerger/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Razor.Directives


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper`
        Contains helper methods for dealing with Chunks


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility`
        A utility type for supporting inheritance of directives into a page from applicable <c>_ViewImports</c> pages.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult`
        Contains :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree` information.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.DefaultChunkTreeCache`
        Default implementation of :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.InjectChunkMerger`
        A :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNet.Mvc.Razor.InjectChunk` instances.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.SetBaseTypeChunkMerger`
        A :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNet.Razor.Chunks.SetBaseTypeChunk` instances.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.UsingChunkMerger`
        A :any:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger` that merges :any:`Microsoft.AspNet.Razor.Chunks.UsingChunk` instances.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkMerger`
        Defines the contract for merging :any:`Microsoft.AspNet.Razor.Chunks.Chunk` instances from _ViewStart files.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache`
        A cache for parsed :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree`\s.


