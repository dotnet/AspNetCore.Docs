

ChunkTreeResult Class
=====================






Contains :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` information.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult`








Syntax
------

.. code-block:: csharp

    public class ChunkTreeResult








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult.ChunkTreeResult(Microsoft.AspNetCore.Razor.Chunks.ChunkTree, System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult`\.
    
        
    
        
        :param chunkTree: The :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` generated from the file at the
            given <em>filePath</em>.
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        :param filePath: The path to the file that generated the given <em>chunkTree</em>.
        
        :type filePath: System.String
    
        
        .. code-block:: csharp
    
            public ChunkTreeResult(ChunkTree chunkTree, string filePath)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult.ChunkTree
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` generated from the file at :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult.FilePath`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            public ChunkTree ChunkTree { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult.FilePath
    
        
    
        
        The path to the file that generated the :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult.ChunkTree`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FilePath { get; }
    

