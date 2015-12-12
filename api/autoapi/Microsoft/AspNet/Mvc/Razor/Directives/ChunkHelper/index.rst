

ChunkHelper Class
=================



.. contents:: 
   :local:



Summary
-------

Contains helper methods for dealing with Chunks





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper`








Syntax
------

.. code-block:: csharp

   public class ChunkHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/Directives/ChunkHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper.GetModelChunk(Microsoft.AspNet.Razor.Chunks.ChunkTree)
    
        
    
        Returns the :any:`Microsoft.AspNet.Mvc.Razor.ModelChunk` used to determine the model name for the page generated
        using the specified ``chunkTree``
    
        
        
        
        :param chunkTree: The  to scan for s in.
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        :rtype: Microsoft.AspNet.Mvc.Razor.ModelChunk
        :return: The last <see cref="T:Microsoft.AspNet.Mvc.Razor.ModelChunk" /> in the <see cref="T:Microsoft.AspNet.Razor.Chunks.ChunkTree" /> if found, <c>null</c> otherwise.
    
        
        .. code-block:: csharp
    
           public static ModelChunk GetModelChunk(ChunkTree chunkTree)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper.GetModelTypeName(Microsoft.AspNet.Razor.Chunks.ChunkTree, System.String)
    
        
    
        Returns the type name of the Model specified via a :any:`Microsoft.AspNet.Mvc.Razor.ModelChunk` in the
        ``chunkTree`` if specified or the default model type.
    
        
        
        
        :param chunkTree: The  to scan for s in.
        
        :type chunkTree: Microsoft.AspNet.Razor.Chunks.ChunkTree
        
        
        :param defaultModelName: The  name of the default model.
        
        :type defaultModelName: System.String
        :rtype: System.String
        :return: The model type name for the generated page.
    
        
        .. code-block:: csharp
    
           public static string GetModelTypeName(ChunkTree chunkTree, string defaultModelName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper.ReplaceTModel(System.String, System.String)
    
        
    
        Returns a string with the &lt;TModel&gt; token replaced with the value specified in
        ``modelName``.
    
        
        
        
        :param value: The string to replace the token in.
        
        :type value: System.String
        
        
        :param modelName: The model name to replace with.
        
        :type modelName: System.String
        :rtype: System.String
        :return: A string with the token replaced.
    
        
        .. code-block:: csharp
    
           public static string ReplaceTModel(string value, string modelName)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Razor.Directives.ChunkHelper.TModelToken
    
        
    
        Token that is replaced by the model name in <c>@inherits</c> and <c>@inject</c>
        chunks as part of :any:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkInheritanceUtility`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string TModelToken
    

