

ChunkTreeResult Class
=====================



.. contents:: 
   :local:



Summary
-------

Contains :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree` information.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult`








Syntax
------

.. code-block:: csharp

   public class ChunkTreeResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/ChunkTreeResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult.ChunkTreeResult(Microsoft.AspNet.Razor.Chunks.ChunkTree, System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult`\.
    
        
        
        
        :param chunkTree: The  generated from the file at the
            given .
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        
        
        :param filePath: The path to the file that generated the given .
        
        :type filePath: System.String
    
        
        .. code-block:: csharp
    
           public ChunkTreeResult(ChunkTree chunkTree, string filePath)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult.ChunkTree
    
        
    
        The :any:`Microsoft.AspNet.Razor.Chunks.ChunkTree` generated from the file at :dn:prop:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult.FilePath`\.
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           public ChunkTree ChunkTree { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult.FilePath
    
        
    
        The path to the file that generated the :dn:prop:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult.ChunkTree`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FilePath { get; }
    

